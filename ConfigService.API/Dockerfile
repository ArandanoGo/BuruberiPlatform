# Etapa base para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ConfigService.API/ConfigService.API.csproj", "ConfigService.API/"]
RUN dotnet restore "ConfigService.API/ConfigService.API.csproj"
COPY . .
WORKDIR "/src/ConfigService.API"
RUN dotnet build "ConfigService.API.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "ConfigService.API.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConfigService.API.dll"]
