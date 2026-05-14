# Bakery Web App Template

This repository contains a classic ASP.NET Web Pages site ready to deploy from GitHub to Azure App Service.

## Deploy From GitHub Actions to Azure App Service

1. Create an Azure App Service (Windows).
2. In the Azure portal, open your Web App and download the Publish Profile.
3. In your GitHub repository, add these secrets:
	- `AZURE_WEBAPP_NAME`: Your Web App name.
	- `AZURE_WEBAPP_PUBLISH_PROFILE`: The full publish profile XML content.
4. Push to the `main` branch (or run the workflow manually from Actions).

The workflow file is located at `.github/workflows/deploy-azure-webapp.yml`.

## Optional: Deploy Infrastructure

An ARM template is included as `azuredeploy.json` if you want to provision supporting Azure resources separately.