using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterTown.API.Models;
using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.API.Controllers
{
    [ApiController]
    [Route("signin")]
    public class UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
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

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok(user);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                AppUser user = (await userManager.FindByNameAsync(model.Username))!;
                return Ok(user);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest();
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
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
    }
}
