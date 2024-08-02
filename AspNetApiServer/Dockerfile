#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Container we use for final publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build container
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Copy the code into the container
WORKDIR /src
COPY ["AspNetApiServer/AspNetApiServer.csproj", "AspNetApiServer/"]

# NuGet restore
RUN dotnet restore "AspNetApiServer/AspNetApiServer.csproj"
COPY ["AspNetApiServer/", "AspNetApiServer/"]

# Build the API
WORKDIR "AspNetApiServer"
RUN dotnet build "AspNetApiServer.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
RUN dotnet publish "AspNetApiServer.csproj" -c Release -o /app/publish

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", ".dll"]
