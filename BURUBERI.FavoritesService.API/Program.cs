using System.Text;
using System.Text.Json;
using System.Net.Http;
using BURUBERI.FavoritesService.API;
using BURUBERI.FavoritesService.API.Application.Internal.CommandServices;
using BURUBERI.FavoritesService.API.Domain.Repositories;
using BURUBERI.FavoritesService.API.Domain.Services;
using BURUBERI.FavoritesService.API.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger y Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DBContext en memoria
builder.Services.AddDbContext<FavoritesDbContext>(options =>
    options.UseInMemoryDatabase("FavoritesDB"));

// Servicios de dominio
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteCommandService, FavoriteCommandService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Autorregistro en RegistryService
try
{
    var serviceInfo = new
    {
        name = "favorites-service", // 👈 NOMBRE CORRECTO DEL SERVICIO
        url = "http://favorites-service:5056"
    };

    var json = JsonSerializer.Serialize(serviceInfo);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    using var client = new HttpClient();
    var response = await client.PostAsync("http://registry-service:8080/registry/register", content);

    Console.WriteLine($"✅ Registro en RegistryService: {response.StatusCode}");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error registrando FavoritesService: {ex.Message}");
}

app.Run();