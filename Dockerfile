# Imagen base para .NET SDK (construcción)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar archivos del proyecto
COPY ["PruebaTecnica_Backend.csproj", "./"]
RUN dotnet restore "PruebaTecnica_Backend.csproj"

# Copiar todo el contenido del proyecto y compilarlo
COPY . .
RUN dotnet publish "PruebaTecnica_Backend.csproj" -c Release -o /app/publish

# Imagen base para ASP.NET Core (ejecución)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "PruebaTecnica_Backend.dll"]
