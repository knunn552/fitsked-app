# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file
COPY FitskedApp.sln ./

# Copy all the project files for the application, API, and test projects
COPY FitskedApp/FitskedApp.csproj FitskedApp/
COPY FitskedApp.Client/FitskedApp.Client.csproj FitskedApp.Client/
COPY fitsked-web-api/fitsked-web-api.csproj fitsked-web-api/
COPY FitskedApp.Test/FitskedApp.Test.csproj FitskedApp.Test/

# Restore dependencies (this will restore for all projects referenced in the solution)
RUN dotnet restore

# Copy the rest of the files for all projects
COPY FitskedApp/ FitskedApp/
COPY FitskedApp.Client/ FitskedApp.Client/
COPY fitsked-web-api/ fitsked-web-api/
COPY FitskedApp.Test/ FitskedApp.Test/

# Publish the app (adjust path as needed for the main project)
RUN dotnet publish FitskedApp/FitskedApp.csproj -c Release -o /out

# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expose the port the app runs on
# This needs to be changed to 8080
EXPOSE 8080

# Set the startup command
ENTRYPOINT ["dotnet", "FitskedApp.dll"]
