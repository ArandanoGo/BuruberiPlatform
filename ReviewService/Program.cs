using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ReviewService.Messaging;
using ReviewService.ReviewService.Application.Internal.CommandServices;
using ReviewService.ReviewService.Application.Internal.QueryServices;
using ReviewService.ReviewService.Domain.Repositories;
using ReviewService.ReviewService.Domain.Services;
using ReviewService.ReviewService.Infrastructure.Repositories;
using ReviewService.Shared.Domain.Repositories;
using ReviewService.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReviewService.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
 builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
 builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnet/core/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify if the connection string is not null or empty
 if (string.IsNullOrEmpty(connectionString))
 {
     throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
 }

// Configure Database Context and Logging Level
 if (builder.Environment.IsDevelopment())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
  });
 else  if (builder.Environment.IsProduction())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Error)
    .EnableDetailedErrors();
  }); 
 
// Configure Dependency Injection
 
// Shared Bounded Context Injection Configuration
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
  builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
  builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
  builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();
  builder.Services.AddHostedService<ReviewRequestConsumer>();

var app = builder.Build();

// Verify if the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var context = services.GetRequiredService<AppDbContext>();
   context.Database.EnsureCreated();
}

// ====== RegistryService Registration ======
try
{
 var serviceInfo = new
 {
  name = "review-service",
  url = "http://review-service:8080"
 };

 var json = JsonSerializer.Serialize(serviceInfo);
 var content = new StringContent(json, Encoding.UTF8, "application/json");

 using var client = new HttpClient();
 var response = await client.PostAsync("http://registry-service:8080/registry/register", content);

 Console.WriteLine($"✅ Registro en RegistryService: {response.StatusCode}");
}
catch (Exception ex)
{
 Console.WriteLine($"❌ Error registrando ReviewService: {ex.Message}");
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.MapOpenApi();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();