using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Reglas
var Politicas = "ReglasCors";
builder.Services.AddCors(options =>
    options.AddPolicy(name: Politicas,
                      builder =>
                      {
                          builder.AllowAnyOrigin().
                          AllowAnyHeader().
                          AllowAnyMethod();
                      })
);

//Seguridad
builder.Configuration.AddJsonFile("appsettings.json");
var skey = builder.Configuration.GetSection("WMConfigure").
                   GetSection("sKey").Value;
//var sKeyB = Encoding.UTF8.GetBytes(skey);

builder.Services.AddAuthentication(c=> {
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(c => {
    c.RequireHttpsMetadata = false;
    c.SaveToken = true;
    c.TokenValidationParameters = new TokenValidationParameters()
    {
           ValidateIssuerSigningKey= true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(skey)),
           ValidateIssuer = false,
           ValidateAudience= false,

    };
    });



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UsuariosDBContext>(
    options=> options.UseSqlServer(
        builder.Configuration.GetConnectionString("con"))
    );


// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//aplicacion de reglas
app.UseCors(Politicas);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
