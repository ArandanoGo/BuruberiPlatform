# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto
COPY *.csproj ./
RUN dotnet restore

# Copia todo el código y compila
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto que usas
EXPOSE 5297

# Comando de inicio
ENTRYPOINT ["dotnet", "ReviewService.dll"]
