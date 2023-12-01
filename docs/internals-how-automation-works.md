## Internals: How the Automation Works

> NOTE: This has been lifted from the README and needs to be extended in a follow-up PR.

Pandora's primarily intended to be run in automation (using both GitHub Actions and Dependabot) - with each of the different tools running once a Pull Request is merged.

## Overview

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

See also: [how to import a new Resource Manager Service/API Version for an existing Service](resource-manager-service-import.md).
