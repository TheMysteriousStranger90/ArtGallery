#!/bin/sh
# filepath: ArtGallery.ClientApp/entrypoint.sh

# Check if certificates exist
if [ ! -f "/etc/nginx/certs/fullchain.pem" ] || [ ! -f "/etc/nginx/certs/privkey.pem" ]; then
    echo "Warning: SSL certificates not found!"
    echo "Expected files:"
    echo "  - /etc/nginx/certs/fullchain.pem"
    echo "  - /etc/nginx/certs/privkey.pem"
    echo "HTTPS may not work properly."
fi

# Set API URL configuration
if [ ! -z "$API_URL" ]; then
  echo "window.API_BASE_URL = '$API_URL';" > /usr/share/nginx/html/config.js
  echo "API URL set to: $API_URL"
else
  echo "window.API_BASE_URL = 'https://localhost:8081/';" > /usr/share/nginx/html/config.js
  echo "API URL set to default: https://localhost:8081/"
fi

# Ensure config.js is readable
chmod 644 /usr/share/nginx/html/config.js

echo "Starting Nginx..."
exec nginx -g 'daemon off;'