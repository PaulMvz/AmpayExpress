using AmpayExpress.Application.Interfaces;
using AmpayExpress.Application.Services;
using AmpayExpress.Domain.Interfaces;
using AmpayExpress.Infrastructure.Repository;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
