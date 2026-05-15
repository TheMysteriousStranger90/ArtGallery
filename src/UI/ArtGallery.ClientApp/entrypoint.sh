#!/bin/sh

# Set API URL configuration
if [ -n "$API_URL" ]; then
    echo "window.API_BASE_URL = '$API_URL';" > /usr/share/nginx/html/config.js
    echo "API URL set to: $API_URL"
else
    echo "window.API_BASE_URL = 'https://localhost:8081/';" > /usr/share/nginx/html/config.js
    echo "API URL set to default: https://localhost:8081/"
fi

chmod 644 /usr/share/nginx/html/config.js

# Configure nginx based on certificate availability
CERT_FULLCHAIN="/etc/nginx/certs/fullchain.pem"
CERT_KEY="/etc/nginx/certs/privkey.pem"

if [ -f "$CERT_FULLCHAIN" ] && [ -f "$CERT_KEY" ]; then
    echo "SSL certificates found. Enabling HTTPS with HTTP redirect."
else
    echo "SSL certificates not found. Writing HTTP-only nginx config."
    cat > /etc/nginx/conf.d/default.conf << 'NGINX_CONF'
server {
    listen 80;
    server_name localhost;
    root /usr/share/nginx/html;
    index index.html;

    location = /service-worker.js {
        add_header Content-Type application/javascript;
        try_files $uri =404;
    }

    location = /config.js {
        add_header Content-Type application/javascript;
        try_files $uri =404;
    }

    location /_framework/ {
        types {
            application/javascript js;
            application/wasm wasm;
            application/octet-stream dll;
            application/json json;
            application/octet-stream pdb;
        }
        try_files $uri =404;
    }

    location / {
        try_files $uri $uri/ /index.html;
    }

    location ~* \.(js|css|woff2?|eot|ttf|otf|svg|ico|jpg|jpeg|png|gif|webp)$ {
        expires 30d;
        access_log off;
    }
}
NGINX_CONF
fi

echo "Starting Nginx..."
exec nginx -g 'daemon off;'