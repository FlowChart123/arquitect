
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Extensions;
using WebApi.Token;
using DataContext = Infra.Configuracao.DataContext;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7068", "http://192.168.2.1:7068");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


//DependencyInjections Extensions
builder.Services.RegisterRepositories();
builder.Services.RegisterDomains();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.SaveToken = true;
          string notConfig = "Secret_Key-12345678";
          string? keys = builder.Configuration["JWT:Key"];          
          var simetricKey = Encoding.UTF8.GetBytes(keys==null ? notConfig:keys);
          var oldKey = JWTSecurityKey.Create(keys==null ? notConfig:keys);

          option.TokenValidationParameters = new TokenValidationParameters
          {              
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = builder.Configuration["JWT:Issuer"],
              ValidAudience = builder.Configuration["JWT:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(simetricKey),
              ClockSkew = TimeSpan.Zero,

          };
          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                  {
                      context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                  }
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    IdentityModelEventSource.ShowPII = true;
}

var devClient = "http://localhost:4200";

app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
