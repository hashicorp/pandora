# Pandora

Pandora is a suite of single-purpose tools which enable transforming the Azure API Definitions into both a Go SDK and Terraform Resources.

These tools are:

1. **Rest API Specs Importer** - imports data from the Azure OpenAPI/Swagger Definitions into the intermediate C# format used by the Data API.
2. **Data API** - exposes the imported API Definitions over an HTTP API (for ease of consumption in other tooling).
3. **Go SDK Generator** - generates a Go SDK using data from the Data API.
4. **Terraform Generator** - generates Terraform Resources using data from the Data API.
5. **Version Bumper** - used to add new Azure Services and new API Versions for existing Azure Services to the config.

At the current time only Resource Manager Services are supported - although we're looking to support Microsoft Graph and (potentially) the Data Plane APIs in the future.

Additional documentation can be found [in the `./docs` folder](docs/README.md).

## Getting Started

The following dependencies are required:

* [Golang 1.21.x](https://go.dev/dl/)
* [.NET 7.x](https://dotnet.microsoft.com/download/dotnet/7.0)

At first checkout you'll need to both initialize and then update the Git submodule:

```sh
$ git submodule init
$ git submodule update
```

The Swagger Git Submodule is updated every weekday (via Dependabot) - once updated you'll need to update your submodule, via:

```sh
$ git submodule update
```

## Project Structure

- `./config` - contains the configuration for which Services should be imported from both Resource Manager and Microsoft Graph, and (for Resource Manager) the list of Terraform Resources which should be generated.
- `./data` - contains V1 of the Data API - and the transformed Azure API Definitions in the intermediate C# format.
- `./docs` - contains documentation.
- `./submodules/msgraph-metadata` - contains the Git Submodule to [the `microsoftgraph/msgraph-metadata` repository](https://github.com/microsoftgraph/msgraph-metadata) - containing the OpenAPI/Swagger definitions for Microsoft Graph.
- `./submodules/rest-api-specs` - contains the Git Submodule to [the `Azure/azure-rest-api-specs` repository](https://github.com/Azure/azure-rest-api-specs) - containing the OpenAPI/Swagger definitions for Azure Resource Manager.
- `./tools/generator-go-sdk` - contains the Go SDK Generator, pulling information from the Data API.
- `./tools/generator-terraform` - contains the Terraform Generator, pulling information from the Data API.
- `./tools/importer-msgraph-metadata` - contains the Importer for the Microsoft Graph API Definitions.
- `./tools/importer-rest-api-specs` - contains the Importer for the Azure Resource Manager OpenAPI/Swagger definitions.
- `./tools/version-bumper` - contains a small tool to add new Services and new API Versions for existing Services to the config.

The following directories are under active development, but aren't used in production at this time:

- `./api-definitions` - contains V2 of the API Definitions - output as JSON rather than C# (as in V1).
- `./tools/data-api` - contains V2 of the Data API - which will replace V1 of the Data API in time.

There's also few helper tools (for example, for use in automation):

- `./tools/extract-tf-resource-ids` - contains the tool used to output a list of Resource IDs included in a given Pull Request.
- `./tools/sdk` - contains a lightweight HTTP API for the Data API.
- `./tools/wrapper-automation` - launches the Data API and then the Rest API Specs Importer/Go SDK/Terraform Generator for use in automation.
