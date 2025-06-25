using BURUBERI.InventoryService.API;
using BURUBERI.InventoryService.API.Application.Internal.CommandServices;
using BURUBERI.InventoryService.API.Application.Internal.QueryServices;
using BURUBERI.InventoryService.API.Domain.Model.Aggregates;
using BURUBERI.InventoryService.API.Domain.Repositories;
using BURUBERI.InventoryService.API.Domain.Services;
using BURUBERI.InventoryService.API.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// ✅ Agrega servicios para Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Configura EF Core con MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// ✅ Registra repositorio e infraestructura
builder.Services.AddScoped<ILoteRepository, LoteRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();

// ✅ Registra servicios de aplicación
builder.Services.AddScoped<ILoteCommandService, LoteCommandService>();
builder.Services.AddScoped<ILoteQueryService, LoteQueryService>();
builder.Services.AddScoped<IReservaCommandService, ReservaCommandService>();
builder.Services.AddScoped<IReservaQueryService, ReservaQueryService>();

// ✅ Agrega el servicio en segundo plano (Worker)
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// ✅ Middleware para Swagger y API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// 🔧 Asegura creación de la base de datos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// ✅ Registro automático en RegistryService
// ✅ Registro automático en RegistryService (versión compatible con Docker)
try
{
    var serviceInfo = new
    {
        name = "inventory-service",
        url = "http://inventory-service:8080"
    };

    var json = JsonSerializer.Serialize(serviceInfo);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    using var client = new HttpClient();
    var response = await client.PostAsync("http://registry-service:8080/registry/register", content);

    Console.WriteLine($"✅ Registro en RegistryService: {response.StatusCode}");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error registrando InventoryService: {ex.Message}");
}


app.Run();
