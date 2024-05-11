var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity();

builder.Services.AddControllers().AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddApiConfigurations();

builder.Services.AddAuthWithJwt(builder.Configuration);

string[] roles = ["Administrator", "Contributor", "Client"];
builder.Services.AddRoles(roles);

builder.Services.AddCorsForClientProject();

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

await app.Services.UseRoles(roles);

app.MapControllers();
app.MapFallbackToFile("/index.html");

await app.RunAsync();