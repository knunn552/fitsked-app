# Here we are exhibiting a multi stage build in the dockerfile
# Although this is a multi stage build. There will only be one image created, which uses the runtime build. 

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY FitskedApp.sln ./

COPY FitskedApp/FitskedApp.csproj FitskedApp/
COPY FitskedApp.Client/FitskedApp.Client.csproj FitskedApp.Client/
COPY FitskedApp.Test/FitskedApp.Test.csproj FitskedApp.Test/

RUN dotnet restore

# We load the csproj files first because they contain all the dependencies and our app and the files within most likely rely on those
# Copy the rest of the files for all projects
COPY FitskedApp/ FitskedApp/
COPY FitskedApp.Client/ FitskedApp.Client/
COPY FitskedApp.Test/ FitskedApp.Test/

# Specified the container directory where the published application with reside
RUN dotnet publish FitskedApp/FitskedApp.csproj -c Release -o /out

# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Were "exposing" the port that the application runs on, but this is only for documentation purposes. 
EXPOSE 8080

# We are specifying basically what gets run in the container command line to start the app
ENTRYPOINT ["dotnet", "FitskedApp.dll"]

