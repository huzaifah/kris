#!/bin/bash

# Kris Application Deployment Script
# This script builds and deploys the Kris application to Azure App Service

set -e  # Exit on any error

# Configuration
APP_NAME="karnival-smapk-2025"
RESOURCE_GROUP="karnival-rg"
PROJECT_PATH="src/Apps/Kris.csproj"
PUBLISH_PATH="./publish"

echo "🚀 Starting deployment of Kris application to Azure App Service..."
echo "📋 Configuration:"
echo "   App Service: $APP_NAME"
echo "   Resource Group: $RESOURCE_GROUP"
echo "   Project: $PROJECT_PATH"
echo "   Publish Path: $PUBLISH_PATH"
echo ""

# Step 1: Clean previous publish
echo "🧹 Cleaning previous publish..."
if [ -d "$PUBLISH_PATH" ]; then
    rm -rf "$PUBLISH_PATH"
fi

# Step 2: Build and publish the application
echo "🔨 Building and publishing application..."
dotnet publish "$PROJECT_PATH" \
    --configuration Release \
    --output "$PUBLISH_PATH" \
    --self-contained false \
    --verbosity minimal

# Step 3: Create deployment package
echo "📦 Creating deployment package..."
cd "$PUBLISH_PATH"
zip -r ../kris-deployment.zip . -q
cd ..

# Step 4: Configure safe deployment settings
echo "⚙️  Configuring safe deployment settings..."
az webapp config appsettings set \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --settings \
        WEBSITE_SKIP_CONTENTSHARE_VALIDATION=1 \
        WEBSITE_ENABLE_SYNC_UPDATE_SITE=true \
        SCM_DO_BUILD_DURING_DEPLOYMENT=false \
        WEBSITE_WEBDEPLOY_USE_SCM=false

# Step 5: Deploy to Azure App Service using safer method
echo "☁️  Deploying to Azure App Service (safe mode)..."
az webapp deployment source config-zip \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --src "kris-deployment.zip" \
    --timeout 600

# Step 6: Restart the app service
echo "🔄 Restarting App Service..."
az webapp restart \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME"

# Step 7: Get the app URL
echo "🌐 Getting application URL..."
APP_URL=$(az webapp show \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --query "defaultHostName" \
    --output tsv)

echo ""
echo "✅ Deployment completed successfully!"
echo "🌍 Application URL: https://$APP_URL"
echo "🔍 Admin Panel: https://$APP_URL/admin"
echo ""
echo "📊 You can check the deployment status in the Azure portal:"
echo "   https://portal.azure.com/#@huzaifahdhotmail.onmicrosoft.com/resource/subscriptions/3cf7d2b8-9231-4162-b9e3-2ded79a58b29/resourceGroups/$RESOURCE_GROUP/providers/Microsoft.Web/sites/$APP_NAME"
echo ""

# Cleanup
echo "🧹 Cleaning up deployment files..."
rm -f kris-deployment.zip

echo "🎉 Deployment process completed!"
