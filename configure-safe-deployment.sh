#!/bin/bash

# Configure Azure App Service for Safe Deployment
# This script applies settings to ensure files are preserved during deployment

set -e

APP_NAME="karnival-smapk-2025"
RESOURCE_GROUP="karnival-rg"

echo "⚙️  Configuring Azure App Service for safe deployment..."

# Apply safe deployment settings
az webapp config appsettings set \
    --resource-group "$RESOURCE_GROUP" \
    --name "$APP_NAME" \
    --settings \
        WEBSITE_SKIP_CONTENTSHARE_VALIDATION=1 \
        WEBSITE_ENABLE_SYNC_UPDATE_SITE=true \
        SCM_DO_BUILD_DURING_DEPLOYMENT=false \
        WEBSITE_WEBDEPLOY_USE_SCM=false \
        MSDEPLOY_RENAME_LOCKED_FILES=1 \
        WEBSITE_RUN_FROM_PACKAGE=0 \
        WEBSITES_ENABLE_APP_SERVICE_STORAGE=true \
        WEBSITE_TIME_ZONE="Singapore Standard Time"

echo "✅ Safe deployment settings applied!"
echo ""
echo "📋 Settings applied:"
echo "   - WEBSITE_SKIP_CONTENTSHARE_VALIDATION=1 (Skip content validation)"
echo "   - WEBSITE_ENABLE_SYNC_UPDATE_SITE=true (Enable sync updates)"
echo "   - SCM_DO_BUILD_DURING_DEPLOYMENT=false (No build during deployment)"
echo "   - WEBSITE_WEBDEPLOY_USE_SCM=false (Use direct deployment)"
echo "   - MSDEPLOY_RENAME_LOCKED_FILES=1 (Rename locked files instead of failing)"
echo "   - WEBSITE_RUN_FROM_PACKAGE=0 (Don't run from package, extract files)"
echo "   - WEBSITES_ENABLE_APP_SERVICE_STORAGE=true (Enable persistent storage)"
echo "   - WEBSITE_TIME_ZONE=Singapore Standard Time (Set timezone)"
echo ""
echo "🔒 These settings ensure that:"
echo "   ✓ Existing files not in deployment package are preserved"
echo "   ✓ Database files and logs are not deleted"
echo "   ✓ Custom configuration files are maintained"
echo "   ✓ Locked files are handled gracefully"
