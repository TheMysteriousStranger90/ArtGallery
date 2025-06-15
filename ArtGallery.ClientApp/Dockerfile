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
RUN mkdir -p /etc/nginx/certs && \
    chmod 700 /etc/nginx/certs
RUN echo 'window.API_BASE_URL = "https://localhost:8081/";' > /usr/share/nginx/html/config.js && \
    echo '<script>if(window.location.protocol==="http:"&&window.location.hostname!=="localhost"){window.location.href=window.location.href.replace("http:","https:")}</script>' > /usr/share/nginx/html/detect-protocol.js
RUN sed -i 's/<head>/<head><script src="\/detect-protocol.js"><\/script>/' /usr/share/nginx/html/index.html
COPY ArtGallery.ClientApp/startup.sh /startup.sh
RUN chmod +x /startup.sh
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["/startup.sh"]