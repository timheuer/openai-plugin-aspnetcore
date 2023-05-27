# ChatGPT Plugin Quickstart using C# and ASP.NET Core

This is a quickstart for sample for creating [ChatGPT Plugin](https://openai.com/blog/chatgpt-plugins) using GitHub Codespaces, Visual Studio or VS Code, and Azure. The sample includes templates to deploy the plugin to [Azure Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/) using the [Azure Developer CLI](https://aka.ms/azd/install). To gain access to ChatGPT plugins, [join waitlist here](https://openai.com/waitlist/plugins)!


[![Open in GitHub Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=lightgrey&logo=github)](https://codespaces.new/timheuer/openai-plugin-aspnetcore)
[![Open in Dev Container](https://img.shields.io/static/v1?style=for-the-badge&label=Dev+Container&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/timheuer/openai-plugin-aspnetcore)

## Getting started

1. **📤 One-click setup**: [Open a new Codespace](https://codespaces.new/timheuer/openai-plugin-aspnetcore), giving you a fully configured cloud developer environment.
2. **🪄 Make an API**: Add routes in `Program.cs`, done in a few minutes even without [ASP.NET Core minimal API](https://learn.microsoft.com/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio) experience, thanks to [GitHub Copilot](https://github.com/features/copilot/).
3. **▶️ Run, one-click again**: Use VS or VS Code's built-in *Run* command and open the forwarded port *8000* in your browser.
4. **💬 Test in ChatGPT**: Copy the URL (make sure its public) and paste it in ChatGPT's [Develop your own plugin](https://platform.openai.com/docs/plugins/getting-started/debugging) flow.
5. **🔄 Iterate quickly:** Codespaces updates the server on each save, and VS Code's debugger lets you dig into the code execution.

## Run

### Run in Codespaces
1. Click here to open in GitHub Codespaces

    [![Open in GitHub Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=lightgrey&logo=github)](https://codespaces.new/timheuer/openai-plugin-aspnetcore)

1. Open Codespaces Ports tab, right click 8000, and make it public.
1. Copy the Codesapces address for port 8000
1. Open Chat GPT and add the plugin with the Codespaces address
1. Run a query for 'hiking boots'

### Run in Dev Container

1. Click here to open in Dev Container

    [![Open in Dev Container](https://img.shields.io/static/v1?style=for-the-badge&label=Dev+Container&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/timheuer/openai-plugin-aspnetcore)

1. Hit F5 to start the API
1. Open Chat GPT and add the plugin with `localhost:8000`
1. Run a query for 'hiking boots'


### Run Locally

1. Clone the repo to your local machine `git clone https://github.com/timheuer/openai-plugin-aspnetcore`
1. Open repo in Visual Studio or VS Code 
1. Hit F5 to start the API
1. Open Chat GPT and add the plugin with `localhost:8000`
1. Run a query for 'hiking boots'

## Deploy to Azure

> NOTE: If you are running locally, then you first need to [install the Azure Developer CLI](https://aka.ms/azd/install)

### Deploy with Azure Developer CLI

1. Open a terminal
1. Run `azd auth login`
1. Run `azd up`
1. Copy the endpoint printed to the terminal
1. Open Chat GPT and add the plugin with that endpoint
1. Run a query for 'hiking boots'

### Deploy with GitHub Actions

> NOTE: Due to a security restriction Codespaces in the browser may not work for you.  If you see an error when running the following commands, then please open the project with VS Code by choosing the Connect to Codespace option.

1. Fork this repo to your own account
1. Open your fork in Codespaces, Dev Container or Local
1. Open a terminal
1. Run `azd auth login`
1. Run `azd pipeline config`
1. Click on the printed actions link. Scroll to the bottom of the logs to find the endpoint.
1. Open Chat GPT and add the plugin with that endpoint
1. Run a query for 'hiking boots'