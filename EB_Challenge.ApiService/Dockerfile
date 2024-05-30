#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EB_Challenge.ApiService/EB_Challenge.ApiService.csproj", "EB_Challenge.ApiService/"]
COPY ["EB_Challenge.ServiceDefaults/EB_Challenge.ServiceDefaults.csproj", "EB_Challenge.ServiceDefaults/"]
RUN dotnet restore "./EB_Challenge.ApiService/EB_Challenge.ApiService.csproj"
COPY . .
WORKDIR "/src/EB_Challenge.ApiService"
RUN dotnet build "./EB_Challenge.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EB_Challenge.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EB_Challenge.ApiService.dll"]