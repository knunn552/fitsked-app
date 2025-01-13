# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FitskedApp/FitskedApp.csproj", "FitskedApp/"]
COPY ["FitskedApp.Client/FitskedApp.Client.csproj", "FitskedApp.Client/"]
RUN dotnet restore "./FitskedApp/FitskedApp.csproj"
COPY . .
WORKDIR "/src/FitskedApp"
RUN dotnet build "./FitskedApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FitskedApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Add the startup script
COPY ./scripts/startup-app.sh /usr/local/bin/startup-app.sh

RUN chmod +x /usr/local/bin/startup-app.sh
# Use the startup script as the entry point
ENTRYPOINT ["sh", "-c", "/usr/local/bin/startup-app.sh"]
