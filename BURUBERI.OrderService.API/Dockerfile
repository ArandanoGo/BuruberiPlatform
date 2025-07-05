FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BURUBERI.OrderService.API.csproj ./BURUBERI.OrderService.API.csproj
RUN dotnet restore "./BURUBERI.OrderService.API.csproj"

COPY . .

RUN dotnet build "BURUBERI.OrderService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BURUBERI.OrderService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BURUBERI.OrderService.API.dll"]
