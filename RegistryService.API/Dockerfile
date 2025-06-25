# Dockerfile - RegistryService.API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RegistryService.API/RegistryService.API.csproj", "RegistryService.API/"]
RUN dotnet restore "RegistryService.API/RegistryService.API.csproj"
COPY . .
WORKDIR "/src/RegistryService.API"
RUN dotnet build "RegistryService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RegistryService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RegistryService.API.dll"]
