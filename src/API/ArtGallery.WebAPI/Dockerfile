FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN mkdir -p /home/app/.aspnet/DataProtection-Keys \
    && mkdir -p /tmp/serilog-buffer \
    && mkdir -p /certificates \
    && mkdir -p /root/.aspnet/DataProtection-Keys \
    && chmod 777 /root/.aspnet/DataProtection-Keys \
    && chown -R 1000:1000 /home/app/.aspnet \
    && chown -R 1000:1000 /certificates \
    && chmod -R 755 /home/app/.aspnet \
    && chmod -R 755 /certificates \
    && chmod -R 755 /tmp/serilog-buffer

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/ArtGallery.WebAPI/ArtGallery.WebAPI.csproj", "src/API/ArtGallery.WebAPI/"]
COPY ["src/Infrastructure/ArtGallery.Persistence/ArtGallery.Persistence.csproj", "src/Infrastructure/ArtGallery.Persistence/"]
COPY ["src/Core/ArtGallery.Application/ArtGallery.Application.csproj", "src/Core/ArtGallery.Application/"]
COPY ["src/Core/ArtGallery.Domain/ArtGallery.Domain.csproj", "src/Core/ArtGallery.Domain/"]
COPY ["src/Infrastructure/ArtGallery.Infrastructure/ArtGallery.Infrastructure.csproj", "src/Infrastructure/ArtGallery.Infrastructure/"]
COPY ["src/Infrastructure/ArtGallery.Identity/ArtGallery.Identity.csproj", "src/Infrastructure/ArtGallery.Identity/"]
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
RUN dotnet restore "src/API/ArtGallery.WebAPI/ArtGallery.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/API/ArtGallery.WebAPI"
RUN dotnet build "ArtGallery.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ArtGallery.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.WebAPI.dll"]