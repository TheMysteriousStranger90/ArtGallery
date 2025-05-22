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
COPY ["ArtGallery.WebAPI/ArtGallery.WebAPI.csproj", "ArtGallery.WebAPI/"]
COPY ["ArtGallery.Persistence/ArtGallery.Persistence.csproj", "ArtGallery.Persistence/"]
COPY ["ArtGallery.Application/ArtGallery.Application.csproj", "ArtGallery.Application/"]
COPY ["ArtGallery.Domain/ArtGallery.Domain.csproj", "ArtGallery.Domain/"]
COPY ["ArtGallery.Infrastructure/ArtGallery.Infrastructure.csproj", "ArtGallery.Infrastructure/"]
COPY ["ArtGallery.Identity/ArtGallery.Identity.csproj", "ArtGallery.Identity/"]
RUN dotnet restore "ArtGallery.WebAPI/ArtGallery.WebAPI.csproj"
COPY . .
WORKDIR "/src/ArtGallery.WebAPI"
RUN dotnet build "ArtGallery.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ArtGallery.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ../.env.production /app/.env.production
ENTRYPOINT ["dotnet", "ArtGallery.WebAPI.dll"]

HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1