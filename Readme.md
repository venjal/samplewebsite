# Bakery Web App Template

This repository contains a classic ASP.NET Web Pages site ready to deploy from GitHub to Azure App Service.

## Deploy From GitHub Actions to Azure App Service

1. Create an Azure App Service (Windows).
2. Configure Azure AD workload identity federation for this GitHub repository (OIDC) so GitHub can deploy without stored secrets.
3. In your GitHub repository, add these repository variables (Settings -> Secrets and variables -> Actions -> Variables):
	- `AZURE_CLIENT_ID`: App registration (service principal) client ID.
	- `AZURE_TENANT_ID`: Azure tenant ID.
	- `AZURE_SUBSCRIPTION_ID`: Azure subscription ID.
	- `AZURE_RESOURCE_GROUP`: Resource group containing the web app.
	- `AZURE_WEBAPP_NAME`: Azure Web App name.
4. Push to the `main` branch (or run the workflow manually from Actions).

This setup keeps the repo open and avoids publish profile secrets.

If your organization disables GitHub-hosted runners, configure a self-hosted Windows runner for this repository. The workflow is already set to use `self-hosted` and `windows` labels.

The workflow file is located at `.github/workflows/deploy-azure-webapp.yml`.

## Optional: Deploy Infrastructure

An ARM template is included as `azuredeploy.json` if you want to provision supporting Azure resources separately.