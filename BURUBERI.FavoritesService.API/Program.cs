using BURUBERI.FavoritesService.API;

using BURUBERI.FavoritesService.API.Application.Internal.CommandServices;
using BURUBERI.FavoritesService.API.Domain.Repositories;
using BURUBERI.FavoritesService.API.Domain.Services;
using BURUBERI.FavoritesService.API.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FavoritesDbContext>(options =>
    options.UseInMemoryDatabase("FavoritesDB")); 

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteCommandService, FavoriteCommandService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();