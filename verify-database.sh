#!/bin/bash

# Verify Database Upload to Azure App Service
# This script checks if the database file was uploaded correctly

set -e

APP_NAME="karnival-smapk-2025"
RESOURCE_GROUP="karnival-rg"
DB_FILE="kris.db"

echo "🔍 Verifying database upload to Azure App Service..."
echo ""

# Get deployment credentials
CREDENTIALS=$(az webapp deployment list-publishing-profiles \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --query "[?publishMethod=='MSDeploy'].{userName:userName,password:userPWD}" \
    --output json)

USERNAME=$(echo $CREDENTIALS | jq -r '.[0].userName')
PASSWORD=$(echo $CREDENTIALS | jq -r '.[0].password')

# Kudu API endpoint
KUDU_URL="https://${APP_NAME}.scm.azurewebsites.net"

# Check local file
if [ -f "$DB_FILE" ]; then
    LOCAL_SIZE=$(stat -f%z "$DB_FILE" 2>/dev/null || stat -c%s "$DB_FILE" 2>/dev/null)
    echo "📁 Local database size: $LOCAL_SIZE bytes"
else
    echo "❌ Local database file not found!"
    LOCAL_SIZE=0
fi

# Check remote file
REMOTE_SIZE=$(curl -s -u "$USERNAME:$PASSWORD" \
    "$KUDU_URL/api/vfs/site/wwwroot/kris.db" \
    -I | grep -i content-length | awk '{print $2}' | tr -d '\r' || echo "0")

echo "☁️  Remote database size: $REMOTE_SIZE bytes"
echo ""

# Compare sizes
if [ "$LOCAL_SIZE" = "$REMOTE_SIZE" ] && [ "$LOCAL_SIZE" -gt "0" ]; then
    echo "✅ Database upload verified successfully!"
    echo "   Both local and remote files are $LOCAL_SIZE bytes"
else
    echo "❌ Database verification failed!"
    echo "   Local: $LOCAL_SIZE bytes"
    echo "   Remote: $REMOTE_SIZE bytes"
    
    if [ "$REMOTE_SIZE" = "0" ]; then
        echo "   💡 Tip: Run ./upload-database.sh to upload the database"
    fi
    exit 1
fi

echo ""
echo "🌍 Application URLs:"
echo "   Main: https://${APP_NAME}.azurewebsites.net"
echo "   Admin: https://${APP_NAME}.azurewebsites.net/admin"
echo ""
echo "🔄 If you see data issues, restart the app service:"
echo "   az webapp restart --resource-group $RESOURCE_GROUP --name $APP_NAME"
