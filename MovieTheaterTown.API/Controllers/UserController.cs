﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieTheaterTown.API.Models;
using MovieTheaterTown.Infrastructure.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieTheaterTown.API.Controllers
{
    [ApiController]
    [Route("account")]
    public class UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config) : ControllerBase
    {
        [HttpPost("register")]
        [Consumes("application/json")]
        public async Task<ActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            AppUser user = new()
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            await userManager.AddToRoleAsync(user, "Client");
            await signInManager.SignInAsync(user, isPersistent: false);

            string token = await GenerateJwtTokenAsync(user);
            return Ok(new { token, role = "Client", username = user.UserName, });
        }

        [HttpPost("login")]
        [Consumes("application/json")]
        public async Task<ActionResult<string>> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest();
            }
            
            AppUser user = (await userManager.FindByNameAsync(model.Username))!;

            string token = await GenerateJwtTokenAsync(user);
            string role = (await userManager.GetRolesAsync(user)).Single();

            return Ok(new { token, role, username = user.UserName });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            catch
            {
                return BadRequest($"Failed to log out.");
            }
        }

        private async Task<string> GenerateJwtTokenAsync(AppUser user)
        {
            byte[] key = Encoding.ASCII.GetBytes(config["JwtSettings:SecretKey"]!);

            JwtSecurityTokenHandler tokenHandler = new();

            SecurityToken token = tokenHandler.CreateToken(new()
            {
                Subject = new(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Email, user.Email!),
                    new(ClaimTypes.Name, user.UserName!),
                    new(ClaimTypes.Role, (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = config["JwtSettings:Audience"],
                Issuer = config["JwtSettings:Issuer"],
            });
            return tokenHandler.WriteToken(token);
        }
    }
}
