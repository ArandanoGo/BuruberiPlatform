# Dockerfile - AdminService.API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AdminService.API/AdminService.API.csproj", "AdminService.API/"]
RUN dotnet restore "AdminService.API/AdminService.API.csproj"
COPY . .
WORKDIR "/src/AdminService.API"
RUN dotnet build "AdminService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminService.API.dll"]
