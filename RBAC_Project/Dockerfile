#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RBAC_Project/RBAC.Api.csproj", "RBAC_Project/"]
COPY ["Application/RBAC.Application.csproj", "Application/"]
COPY ["Domain/RBAC.Domain.csproj", "Domain/"]
COPY ["Infrastructure/RBAC.Presistence.csproj", "Infrastructure/"]
RUN dotnet restore "RBAC_Project/RBAC.Api.csproj"
COPY . .
WORKDIR "/src/RBAC_Project"
RUN dotnet build "RBAC.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RBAC.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RBAC.Api.dll"]