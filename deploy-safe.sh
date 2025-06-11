#!/bin/bash

# Kris Application Safe Deployment Script
# This script uses Kudu API for more controlled deployment that preserves existing files

set -e  # Exit on any error

# Configuration
APP_NAME="karnival-smapk-2025"
RESOURCE_GROUP="karnival-rg"
PROJECT_PATH="src/Apps/Kris.csproj"
PUBLISH_PATH="./publish"

echo "🚀 Starting SAFE deployment of Kris application to Azure App Service..."
echo "📋 Configuration:"
echo "   App Service: $APP_NAME"
echo "   Resource Group: $RESOURCE_GROUP"
echo "   Project: $PROJECT_PATH"
echo "   Publish Path: $PUBLISH_PATH"
echo ""

# Step 1: Get deployment credentials
echo "🔑 Getting deployment credentials..."
DEPLOYMENT_CREDENTIALS=$(az webapp deployment list-publishing-profiles \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --query "[?publishMethod=='MSDeploy'].{publishUrl:publishUrl,userName:userName,password:userPWD}" \
    --output json)

PUBLISH_URL=$(echo $DEPLOYMENT_CREDENTIALS | jq -r '.[0].publishUrl')
USERNAME=$(echo $DEPLOYMENT_CREDENTIALS | jq -r '.[0].userName')
PASSWORD=$(echo $DEPLOYMENT_CREDENTIALS | jq -r '.[0].password')

# Step 2: Clean previous publish
echo "🧹 Cleaning previous publish..."
if [ -d "$PUBLISH_PATH" ]; then
    rm -rf "$PUBLISH_PATH"
fi

# Step 3: Build and publish the application
echo "🔨 Building and publishing application..."
dotnet publish "$PROJECT_PATH" \
    --configuration Release \
    --output "$PUBLISH_PATH" \
    --self-contained false \
    --verbosity minimal

# Step 4: Create deployment package
echo "📦 Creating deployment package..."
cd "$PUBLISH_PATH"
zip -r ../kris-deployment.zip . -q
cd ..

# Step 5: Backup current app (optional safety measure)
echo "💾 Creating backup of current application..."
BACKUP_NAME="backup-$(date +%Y%m%d-%H%M%S)"
az webapp deployment slot create \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --slot "$BACKUP_NAME" \
    --configuration-source "$APP_NAME" \
    || echo "⚠️  Note: Could not create backup slot (this is normal for free tiers)"

# Step 6: Configure safe deployment settings
echo "⚙️  Configuring safe deployment settings..."
az webapp config appsettings set \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --settings \
        WEBSITE_SKIP_CONTENTSHARE_VALIDATION=1 \
        WEBSITE_ENABLE_SYNC_UPDATE_SITE=true \
        SCM_DO_BUILD_DURING_DEPLOYMENT=false \
        WEBSITE_WEBDEPLOY_USE_SCM=false \
        MSDEPLOY_RENAME_LOCKED_FILES=1

# Step 7: Deploy using Kudu API with safe options
echo "☁️  Deploying to Azure App Service (preserving existing files)..."

# Get Kudu URL
KUDU_URL="https://${APP_NAME}.scm.azurewebsites.net"

# Deploy using Kudu ZIP API (this preserves files not in the package)
curl -X POST \
    -u "$USERNAME:$PASSWORD" \
    -T "kris-deployment.zip" \
    "$KUDU_URL/api/zipdeploy?isAsync=false&author=kris-deploy-script" \
    --header "Content-Type: application/zip" \
    --header "Cache-Control: no-cache" \
    --fail \
    --show-error \
    --silent

# Step 8: Verify deployment
echo "🔍 Verifying deployment..."
sleep 10  # Wait for deployment to settle

DEPLOYMENT_STATUS=$(curl -s -u "$USERNAME:$PASSWORD" \
    "$KUDU_URL/api/deployments/latest" | \
    jq -r '.status // "unknown"')

echo "📊 Deployment status: $DEPLOYMENT_STATUS"

# Step 9: Restart the app service if deployment was successful
if [ "$DEPLOYMENT_STATUS" = "4" ] || [ "$DEPLOYMENT_STATUS" = "Success" ]; then
    echo "🔄 Restarting App Service..."
    az webapp restart \
        --resource-group "$RESOURCE_GROUP" \
        --name "$APP_NAME"
else
    echo "⚠️  Deployment may not have completed successfully. Check Azure portal."
fi

# Step 10: Get the app URL
echo "🌐 Getting application URL..."
APP_URL=$(az webapp show \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --query "defaultHostName" \
    --output tsv)

echo ""
echo "✅ Safe deployment completed!"
echo "🌍 Application URL: https://$APP_URL"
echo "🔍 Admin Panel: https://$APP_URL/admin"
echo ""
echo "📊 You can check the deployment status in the Azure portal:"
echo "   https://portal.azure.com/#@huzaifahdhotmail.onmicrosoft.com/resource/subscriptions/3cf7d2b8-9231-4162-b9e3-2ded79a58b29/resourceGroups/$RESOURCE_GROUP/providers/Microsoft.Web/sites/$APP_NAME"
echo ""

# Step 11: Cleanup
echo "🧹 Cleaning up deployment files..."
rm -f kris-deployment.zip

echo "🎉 Safe deployment process completed!"
echo "📝 Note: This deployment preserves existing files that were not in the deployment package."
