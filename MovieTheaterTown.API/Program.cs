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
    ?? throw new ArgumentNullException("Connection string not found...");

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
string secretKey = jwtSettings["SecretKey"] ?? "";
byte[] key = Encoding.ASCII.GetBytes(secretKey);

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
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
 {
     options.AddDefaultPolicy(builder =>
     {
         builder.WithOrigins("https://localhost:5173")
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

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
