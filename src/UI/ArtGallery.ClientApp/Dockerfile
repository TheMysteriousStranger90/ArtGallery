FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/UI/ArtGallery.ClientApp/ArtGallery.ClientApp.csproj", "src/UI/ArtGallery.ClientApp/"]
COPY ["Directory.Packages.props", "./"]
RUN dotnet restore "src/UI/ArtGallery.ClientApp/ArtGallery.ClientApp.csproj"
COPY . .
WORKDIR "/src/src/UI/ArtGallery.ClientApp"
RUN dotnet publish -c Release -o /app/publish

FROM nginx:alpine AS final
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY src/UI/ArtGallery.ClientApp/nginx.conf /etc/nginx/conf.d/default.conf

# Create certificates directory
RUN mkdir -p /etc/nginx/certs && chmod 700 /etc/nginx/certs

# Copy and enable the entrypoint script
COPY src/UI/ArtGallery.ClientApp/entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

EXPOSE 80 443
ENTRYPOINT ["/entrypoint.sh"]