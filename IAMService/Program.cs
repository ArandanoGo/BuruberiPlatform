using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using IAMService.IAM.Application.Internal.CommandServices;
using IAMService.IAM.Application.Internal.OutboundServices;
using IAMService.IAM.Application.Internal.QueryServices;
using IAMService.IAM.Domain.Repositories;
using IAMService.IAM.Domain.Services;
using IAMService.IAM.Infrastructure.Hashing.BCrypt.Services;
using IAMService.IAM.Infrastructure.Persistence.EFC.Repositories;
using IAMService.IAM.Infrastructure.Tokens.JWT.Configuration;
using IAMService.IAM.Infrastructure.Tokens.JWT.Services;
using IAMService.Profiles.Application.Internal.CommandServices;
using IAMService.Profiles.Application.Internal.QueryServices;
using IAMService.Profiles.Domain.Repositories;
using IAMService.Profiles.Domain.Services;
using IAMService.Profiles.Infrastructure.Persistence.EFC.Repositories;
using IAMService.Shared.Domain.Repositories;
using IAMService.Shared.Infrastructure.Interfaces.ASP.Configuration;
using IAMService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IAMService.Shared.Infrastructure.Persistence.EFC.Repositories;
using IAMService.Shared.Infrastructure.Pipeline.Middleware.Components;

var builder = WebApplication.CreateBuilder(args);

// ======================= CORS ========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// =================== Web API Controllers ====================
builder.Services.AddControllers();
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// =================== DB Connection ====================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null)
    throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySQL(connectionString)
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
    else
    {
        options.UseMySQL(connectionString)
               .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// =================== Swagger ====================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());



// =================== Dependency Injection ====================
builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();

// -------- Profiles
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

// Common Exception Handling Middleware
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddExceptionHandler<CommonExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// ========== Middleware ==========
app.UseCors("AllowAll");



// ====== Ensure database exists ======
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// ====== RegistryService Registration ======
// ====== RegistryService Registration ======
try
{
    var serviceInfo = new
    {
        name = "iam-service",
        url = "http://iam-service:8080"
    };

    var json = JsonSerializer.Serialize(serviceInfo);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    using var client = new HttpClient();
    var response = await client.PostAsync("http://registry-service:8080/registry/register", content);

    Console.WriteLine($"✅ Registro en RegistryService: {response.StatusCode}");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error registrando IAMService: {ex.Message}");
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();


app.Run();
