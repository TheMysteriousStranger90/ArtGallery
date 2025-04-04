FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
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
ENTRYPOINT ["dotnet", "ArtGallery.WebAPI.dll"]

HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1
