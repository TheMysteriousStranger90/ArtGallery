#!/bin/sh

if [ ! -z "$API_URL" ]; then
  echo "window.API_BASE_URL = '$API_URL';" > /usr/share/nginx/html/config.js
  echo "API URL set to: $API_URL"
else
  echo "window.API_BASE_URL = 'https://localhost:8081/';" > /usr/share/nginx/html/config.js
  echo "API URL set to default: https://localhost:8081/"
fi

exec nginx -g 'daemon off;'