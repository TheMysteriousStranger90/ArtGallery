FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ArtGallery.ClientApp/ArtGallery.ClientApp.csproj", "ArtGallery.ClientApp/"]
RUN dotnet restore "ArtGallery.ClientApp/ArtGallery.ClientApp.csproj"
COPY . .
WORKDIR "/src/ArtGallery.ClientApp"
RUN dotnet publish -c Release -o /app/publish

FROM nginx:alpine AS final
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html
COPY ArtGallery.ClientApp/nginx.conf /etc/nginx/conf.d/default.conf

# Create certificates directory
RUN mkdir -p /etc/nginx/certs && \
    chmod 700 /etc/nginx/certs

# Create initialization script directly in Dockerfile
RUN echo '#!/bin/sh' > /docker-entrypoint.d/01-init-config.sh && \
    echo 'if [ ! -z "$API_URL" ]; then' >> /docker-entrypoint.d/01-init-config.sh && \
    echo '  echo "window.API_BASE_URL = \"$API_URL\";" > /usr/share/nginx/html/config.js' >> /docker-entrypoint.d/01-init-config.sh && \
    echo '  echo "API URL set to: $API_URL"' >> /docker-entrypoint.d/01-init-config.sh && \
    echo 'else' >> /docker-entrypoint.d/01-init-config.sh && \
    echo '  echo "window.API_BASE_URL = \"https://localhost:8081/\";" > /usr/share/nginx/html/config.js' >> /docker-entrypoint.d/01-init-config.sh && \
    echo '  echo "API URL set to default: https://localhost:8081/"' >> /docker-entrypoint.d/01-init-config.sh && \
    echo 'fi' >> /docker-entrypoint.d/01-init-config.sh && \
    chmod +x /docker-entrypoint.d/01-init-config.sh

# Create detect-protocol script
RUN echo '<script>if(window.location.protocol==="http:"&&window.location.hostname!=="localhost"){window.location.href=window.location.href.replace("http:","https:")}</script>' > /usr/share/nginx/html/detect-protocol.js

# Update index.html to include the script
RUN sed -i 's/<head>/<head><script src="\/detect-protocol.js"><\/script>/' /usr/share/nginx/html/index.html

EXPOSE 80
EXPOSE 443

# Use default nginx entrypoint
CMD ["nginx", "-g", "daemon off;"]