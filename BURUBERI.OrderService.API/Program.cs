using BURUBERI.OrderService.API;
using BURUBERI.OrderService.API.Application.Internal.CommandServices;
using BURUBERI.OrderService.API.Application.Internal.QueryServices;
using BURUBERI.OrderService.API.Domain.Model.Aggregates;
using BURUBERI.OrderService.API.Domain.Repositories;
using BURUBERI.OrderService.API.Domain.Services;
using BURUBERI.OrderService.API.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Agrega servicios para Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Configura EF Core con MySQL (ajusta la cadena en appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// ✅ Registra repositorio e infra
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// ✅ Registra servicios de aplicación
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

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

app.Run();
