using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieTheaterTown.API;
using MovieTheaterTown.Core.Contracts;
using MovieTheaterTown.Core.Services;
using MovieTheaterTown.Infrastructure.Data;
using MovieTheaterTown.Infrastructure.Data.Common;
using MovieTheaterTown.Infrastructure.Data.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");

builder.Services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MovieContext>();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
if (string.IsNullOrEmpty(jwtSettings["SecretKey"]))
{
    jwtSettings["SecretKey"] = KeyGenerator.GenerateSecretKey(32);
}
string key = jwtSettings["SecretKey"]!;
byte[] keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.SaveToken = true;
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});

builder.Services.AddCors(options =>
 {
     options.AddDefaultPolicy(builder =>
     {
         builder.WithOrigins("https://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
         
         builder.WithOrigins("https://localhost:5176")
                .AllowAnyHeader()
                .AllowAnyMethod();
     });
 });

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
