# Pandora

Pandora is a suite of single-purpose tools which enable transforming the Azure API Definitions into both a Go SDK and (in the future) Terraform Data Sources/Resources.

These tools are:

1. **Rest API Specs Importer** - imports data from the Azure OpenAPI/Swagger Definitions into the intermediate C# format used by the Data API.
2. **Data API** - exposes the imported API Definitions over an HTTP API (for ease of consumption in other tooling).
3. **Go SDK Generator** - generates a Go SDK using data from the Data API.
4. **Terraform Generator** (**WIP**) - generates Terraform Data Sources and Resources using data from the Data API.
5. **Version Bumper** - used to add new Azure Services and new API Versions for existing Azure Services to the config.

At the current time only Resource Manager Services are supported - although we plan to support both Microsoft Graph and (potentially) the Data Plane APIs in the future.

## Getting Started

The following dependencies are required:

* [Golang 1.18.x](https://go.dev/dl/)
* [.NET 6.x](https://dotnet.microsoft.com/download/dotnet/6.0)

At first checkout you'll need to both initialize and then update the Git submodule:

```sh
$ git submodule init
$ git submodule update
```

The Swagger Git Submodule is updated every weekday (via Dependabot) - once updated you'll need to update your submodule, via:

```sh
$ git submodule update
```

## How does this work?

Pandora's primarily intended to be run in automation (using both Github Actions and Dependabot) - which gets run once a Pull Request is merged.

* Once a Pull Request is merged that updates one of the following paths, the Rest API Specs Importer is run.
  * The Resource Manager Config (`./config/resource-manager.hcl`).
  * The Resource Manager Swagger Git Submodule (`./swagger`).
  * Any of the tooling within `./tools`.
* If the Rest API Specs Importer outputs any changes to the Imported API Definitions, those are committed and a Pull Request is opened ([example](https://github.com/hashicorp/pandora/pull/751)).
* Once that PR is merged, if there's any changes then the `hashicorp/go-azure-sdk` repository is updated in the same fashion via the Go SDK Generator.
* (**Future**) Once the Go SDK is updated, (if there's any changes) the Terraform Data Sources & Resources are re-generated via the Go SDK Generator, and the Go SDK dependency is updated via a Pull Request.

The `./docs` folder contains more information, of particular note:

* [Guide: how to import a new Resource Manager Service/API Version for an existing Service](./docs/resource-manager-service-import)
* (Temporary, until the automation is completed) [Guide: how to generate a Go SDK](./docs/generating-a-go-sdk.md).

## Project Structure

- `./config/resource-manager.hcl` - contains the list of Resource Manager Services and API Versions which should be imported.
- `./data` - contains the Data API, containing the transformed Azure API Definitions in the intermediate C# format.
- `./docs` - contains documentation.
- `./swagger` - contains the Git Submodule to [the Azure Rest API Specs repository](https://github.com/Azure/azure-rest-api-specs) - containing the OpenAPI/Swagger definitions for Azure Resource Manager.
- `./tools/generator-go-sdk` - contains the Go SDK Generator, pulling information from the Data API.
- `./tools/generator-terraform` - (**WIP**) contains the Terraform Generator, pulling information from the Data API.
- `./tools/importer-rest-api-specs` - contains the Importer for the Azure Resource Manager OpenAPI/Swagger definitions.
- `./tools/version-bumper` - contains a small tool to add new Services and new API Versions for existing Services to the config.

There's also a couple of helper tools (for example, for use in automation):

- `./tools/sdk` - contains a lightweight HTTP API for the Data API.
- `./tools/wrapper-go-sdk-generator` - launches the Data API and then the Go SDK Generator for use in automation.
