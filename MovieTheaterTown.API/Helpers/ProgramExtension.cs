using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieTheaterTown.API.Extensions;
using MovieTheaterTown.Core.Contracts;
using MovieTheaterTown.Core.Services;
using MovieTheaterTown.Infrastructure.Data;
using MovieTheaterTown.Infrastructure.Data.Common;
using MovieTheaterTown.Infrastructure.Data.Models;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProgramExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");

            services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MovieContext>();

            return services;
        }

        public static IServiceCollection AddApiConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();            
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AddRequiredHeaderParameter>();

                OpenApiSecurityScheme securityScheme = new()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header. \r\n\r\n Enter the token in the text input below.",
                };
                options.AddSecurityDefinition("Bearer", securityScheme);
            });

            return services;
        }

        public static IServiceCollection AddAuthWithJwt(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                byte[] key = config.GetJwtSecretKey();

            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                byte[] key = config.GetJwtSecretKey();
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = config["JwtSettings:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return services;
        }

        private static byte[] GetJwtSecretKey(this IConfiguration config)
        {
            string? secretKey = config["JwtSettings:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                secretKey = KeyGenerator.GenerateSecretKey(32);
                config["JwtSettings:SecretKey"] = secretKey;
            }
            byte[] keyBytes = Encoding.ASCII.GetBytes(secretKey);

            return keyBytes;
        }

        public static IServiceCollection AddRoles(this IServiceCollection services, string[] roles)
        {
            services.AddAuthorization(options =>
            {
                foreach (string role in roles)
                {
                    options.AddPolicy(role, policy => policy.RequireRole(role));
                }
            });

            return services;
        }

        public static IServiceCollection AddCorsForClientProject(this IServiceCollection services)
        {
            services.AddCors(options =>
             {
                 options.AddDefaultPolicy(builder =>
                 {
                     builder.WithOrigins("https://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                 });
             });

            return services;
        }

        public static async Task<IServiceProvider> UseRoles(this IServiceProvider provider, string[] roles)
        {
            using IServiceScope scope = provider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole(role));
                }
            }

            return provider;
        }
    }
}
