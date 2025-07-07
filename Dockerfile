FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file
COPY RoastLounge.sln .

# Copy the individual project files to their correct locations in the container
COPY WebApp/WebApp.csproj WebApp/
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Domain/Domain.csproj Domain/

# Restore dependencies
RUN dotnet restore RoastLounge.sln

# Copy the rest of the project files
COPY . .

# Build and publish
WORKDIR /src/WebApp
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
