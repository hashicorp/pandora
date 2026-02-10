# Pandora

Pandora is a suite of single-purpose tools which enable transforming the Azure API Definitions into both a Go SDK and Terraform Resources.

These tools are:

1. **Rest API Specs Importer** - imports data from [the Azure Rest API Specs repository](https://github.com/Azure/azure-rest-api-specs) into the API Definitions format used by the Data API.
2. **Data API** - exposes the imported API Definitions over an HTTP API (for ease of consumption in other tooling).
3. **Go SDK Generator** - generates a Go SDK using data from the Data API.
4. **Terraform Generator** - generates Terraform Resources using data from the Data API.
5. **Version Bumper** - automatically detects and proposes importing new Services and API Versions for Azure Resource Manager.

At the current time only Resource Manager Services are supported - although we're looking to support Microsoft Graph and (potentially) the Data Plane APIs in the future.

## Getting Started

The following dependencies are required:

* [Golang 1.21.x](https://go.dev/dl/)

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
  * The Resource Manager Swagger Git Submodule (`./submodules/rest-api-specs`).
  * Any of the tooling within `./tools`.
* If the Rest API Specs Importer outputs any changes to the Imported API Definitions, those are committed and a Pull Request is opened.
* Once that PR is merged, if there's any changes then the `hashicorp/go-azure-sdk` repository is updated in the same fashion via the Go SDK Generator (outputting any new/changes to the Go SDK).
* At the same time, if there's any changes then the `hashicorp/terraform-provider-azurerm` repository is also updated via the Terraform Generator (outputting any new/changes to the Terraform Generator).

To show the workflow with examples:

1. A Pull Request is opened to add a new Service/API version to the config ([example](https://github.com/hashicorp/pandora/pull/939)).
2. Once that Pull Request is merged that generates a Data API PR ([example](https://github.com/hashicorp/pandora/pull/941)).
3. Once that Pull Request is merged that generates a Go SDK PR ([example](https://github.com/hashicorp/go-azure-sdk/pull/20)).
4. Once that Pull Request is merged the SDK is automatically released (e.g. we add a new git tag).

## Contributing API Versions

The API versions maintained in this repository are primarily intended to serve the **Terraform Azure Providers**. The generated [`go-azure-sdk`](https://github.com/hashicorp/go-azure-sdk) is built to support the providers' needs, and API version additions are prioritized accordingly.

If you would like to add an API version for use outside of the Terraform Azure Providers (e.g., for another project that consumes `go-azure-sdk`), please open a Pull Request and include a description of what you would like to use it for. This helps us evaluate the request and understand the broader impact of maintaining additional API versions.

For information and guides on how to contribute, add services, service versions or resources, see the overview of guides located in the [`./docs`](https://github.com/hashicorp/pandora/tree/main/docs).

## Project Structure

- `./api-definitions` - contains V2 of the transformed Azure API Definitions, used by the (V2) Data API.
- `./config/resource-manager.hcl` - contains the list of Resource Manager Services and API Versions which should be imported.
- `./docs` - contains documentation.
- `./submodules/msgraph-metadata` - contains the Git Submodule to [the `microsoftgraph/msgraph-metadata` repository](https://github.com/microsoftgraph/msgraph-metadata) - containing the OpenAPI/Swagger definitions for Microsoft Graph.
- `./submodules/rest-api-specs` - contains the Git Submodule to [the `Azure/azure-rest-api-specs` repository](https://github.com/Azure/azure-rest-api-specs) - containing the OpenAPI/Swagger definitions for Azure Resource Manager.
- `./tools/data-api` - contains V2 of the Data API - which serves the transformed Azure API Definitions from `./api-definitions`.
- `./tools/data-api-differ` - contains the Data API Differ which detects changes to the API Definitions.
- `./tools/generator-go-sdk` - contains the Go SDK Generator, pulling information from the Data API.
- `./tools/generator-terraform` - contains the Terraform Generator, pulling information from the Data API.
- `./tools/importer-rest-api-specs` - contains the Importer for the Azure Resource Manager OpenAPI/Swagger definitions.
- `./tools/version-bumper` - contains a small tool to add new Services and new API Versions for existing Services to the config.

There's also few helper tools (for example, for use in automation):

- `./tools/sdk` - contains a lightweight HTTP API for the Data API.
- `./tools/wrapper-automation` - launches the Data API and then the Rest API Specs Importer/Go SDK/Terraform Generator for use in automation.

The following paths are still a work-in-progress:

- `./config/microsoft-graph.hcl` - contains the list of Microsoft Graph Services which should be imported.
- `./tools/importer-msgraph-metadata` - contains the Importer for the Microsoft Graph API Definitions.
