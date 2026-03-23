using AmpayExpress.Application.Interfaces;
using AmpayExpress.Application.Services;
using AmpayExpress.Domain.Interfaces;
using AmpayExpress.Infrastructure.Repository;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AmpayExpress.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. Configurar la Base de Datos (Asegúrate que coincida con tu appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// 2. Registrar el Repositorio (Infraestructura)
builder.Services.AddScoped<IComercioRepository, ComercioRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
// 3. Registrar el Servicio (Aplicación)
builder.Services.AddScoped<IComercioService, ComercioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar el DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var keyString = jwtSettings["Key"] ?? "8e70f6e1f0e44b8283002b58e7b3a4f65c9292d3b5a14d5e9f1a2b3c4d5e6f7a"; // Clave secreta para firmar los tokens. En producción, esta clave debe ser segura y no debe estar hardcodeada.
var key = Encoding.ASCII.GetBytes(keyString); // Asegúrate de que esta clave sea lo suficientemente larga y segura en producción

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
	};
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication(); // Quién eres

app.UseHttpsRedirection();

app.UseAuthorization(); // Qué puedes hacer

app.MapControllers();

app.Run();
