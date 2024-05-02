using Microsoft.EntityFrameworkCore;
using MovieTheatreTown.Infrastructure.Data;
using MovieTheatreTown.Infrastructure.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentNullException("Connection string not found...");
builder.Services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
