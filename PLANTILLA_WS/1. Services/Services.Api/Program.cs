using Services.Api.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var _cors = "AllowAllHeaders";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Config Services
// WebAPI Config
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();
// .NET native DI Abstraction   AddDependencyInjectionConfiguration
builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("MyAnonnymousAdnSecuredSecretKeyMyAnonnymousAdnSecuredSecretKey")),
        ClockSkew = new System.TimeSpan(0)
    };
});

builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      }));

builder.Services.AddRazorPages();

// Register DbContext
builder.Services.AddDbContext<ContextDatabase>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAnyOrigin");
app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddlewareLogs();
app.UseSwaggerSetup(app.Environment);
app.MapRazorPages();

app.Run();
