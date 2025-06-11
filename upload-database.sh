#!/bin/bash

# Upload SQLite Database to Azure App Service
# This script uploads the local kris.db file to Azure App Service

set -e

APP_NAME="karnival-smapk-2025"
RESOURCE_GROUP="karnival-rg"
DB_FILE="kris.db"

echo "📊 Uploading SQLite database to Azure App Service..."
echo "🔧 Configuration:"
echo "   App Service: $APP_NAME"
echo "   Database File: $DB_FILE"
echo ""

# Check if database file exists
if [ ! -f "$DB_FILE" ]; then
    echo "❌ Database file $DB_FILE not found!"
    exit 1
fi

# Get file size
DB_SIZE=$(ls -lah "$DB_FILE" | awk '{print $5}')
echo "📁 Database file size: $DB_SIZE"

# Get deployment credentials
echo "🔑 Getting deployment credentials..."
CREDENTIALS=$(az webapp deployment list-publishing-profiles \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --query "[?publishMethod=='MSDeploy'].{userName:userName,password:userPWD}" \
    --output json)

USERNAME=$(echo $CREDENTIALS | jq -r '.[0].userName')
PASSWORD=$(echo $CREDENTIALS | jq -r '.[0].password')

# Kudu API endpoint
KUDU_URL="https://${APP_NAME}.scm.azurewebsites.net"

echo "🔍 Checking if database exists on Azure..."
DB_EXISTS=$(curl -s -u "$USERNAME:$PASSWORD" \
    "$KUDU_URL/api/vfs/site/wwwroot/kris.db" \
    -w "%{http_code}" -o /dev/null || echo "404")

if [ "$DB_EXISTS" = "200" ]; then
    echo "⚠️  Database already exists on Azure. Creating backup..."
    BACKUP_NAME="kris.db.backup.$(date +%Y%m%d-%H%M%S)"
    curl -s -u "$USERNAME:$PASSWORD" \
        -X PUT \
        "$KUDU_URL/api/vfs/site/wwwroot/$BACKUP_NAME" \
        --data-binary @<(curl -s -u "$USERNAME:$PASSWORD" "$KUDU_URL/api/vfs/site/wwwroot/kris.db") \
        > /dev/null
    echo "✅ Backup created as: $BACKUP_NAME"
else
    echo "ℹ️  No existing database found on Azure."
fi

echo "☁️  Uploading database to Azure App Service..."

# Upload the database file using Kudu VFS API
curl -u "$USERNAME:$PASSWORD" \
    -T "$DB_FILE" \
    "$KUDU_URL/api/vfs/site/wwwroot/kris.db" \
    --header "Content-Type: application/octet-stream" \
    --fail \
    --show-error \
    --progress-bar

echo ""
echo "🔍 Verifying upload..."

# Verify the upload
REMOTE_SIZE=$(curl -s -u "$USERNAME:$PASSWORD" \
    "$KUDU_URL/api/vfs/site/wwwroot/kris.db" \
    -I | grep -i content-length | awk '{print $2}' | tr -d '\r')

LOCAL_SIZE=$(stat -f%z "$DB_FILE" 2>/dev/null || stat -c%s "$DB_FILE" 2>/dev/null)

echo "📊 Size comparison:"
echo "   Local:  $LOCAL_SIZE bytes"
echo "   Remote: $REMOTE_SIZE bytes"

if [ "$LOCAL_SIZE" = "$REMOTE_SIZE" ]; then
    echo "✅ Upload successful! Database sizes match."
else
    echo "⚠️  Warning: Database sizes don't match. Upload may have failed."
    exit 1
fi

echo ""
echo "🔄 Restarting App Service to load new database..."
az webapp restart \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME"

echo ""
echo "✅ Database upload completed successfully!"
echo "🌍 Your application should now have data: https://${APP_NAME}.azurewebsites.net"
echo "🔍 Admin panel: https://${APP_NAME}.azurewebsites.net/admin"
echo ""
echo "📝 Note: The database file is now available at /site/wwwroot/kris.db on Azure"
