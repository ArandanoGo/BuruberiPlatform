# Dockerfile - BURUBERI.InventoryService.API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["BURUBERI.InventoryService.API/BURUBERI.InventoryService.API.csproj", "BURUBERI.InventoryService.API/"]
RUN dotnet restore "BURUBERI.InventoryService.API/BURUBERI.InventoryService.API.csproj"

COPY . .
WORKDIR "/src/BURUBERI.InventoryService.API"
RUN dotnet build "BURUBERI.InventoryService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BURUBERI.InventoryService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BURUBERI.InventoryService.API.dll"]
