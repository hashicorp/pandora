## Common (Resource) IDs

Pandora leans heavily on the concept of Resource IDs, which is a unique identifier for the Azure Resource which typically maps to the (normalized) URI.

In Azure Resource Manager these tie to Resources within the Azure Resource Providers (e.g. `Microsoft.Compute`) - in Microsoft Graph these tie to the Services (such as `ServicePrincipals` or `Users`).

Typically, these Resource IDs are located within a given Service (such as `Compute`), API Version (`2020-01-01`) and Resource (e.g. `DedicatedHostGroups`) - however a subset of these Resource IDs are used across many Services (such as a Network Interface, Storage Account or Virtual Machine ID).

Rather than having different versions of these Resource IDs exposed per Service/API Version/Resource combination, these Common Resource IDs are instead detected by Pandora and referenced [from `hashicorp/go-azure-sdk`'s `commonids` package](https://github.com/hashicorp/go-azure-helpers/tree/main/resourcemanager/commonids) instead.

Having these referenced in a single place allows downstream consumers of Pandora, such as `hashicorp/terraform-provider-azurerm` to have a single reference to these IDs and for Validation etc - meaning there's less code churn needed when updating the API Version being used.

### Adding a new Common ID

Common IDs need to be added in a specific order:

1. Send a Pull Request [adding the new Resource ID to update `./resourcemanager/commonids` within `hashicorp/go-azure-helpers`](https://github.com/hashicorp/go-azure-helpers). [Example](https://github.com/hashicorp/go-azure-helpers/pull/172).
2. Once that Pull Request has been merged and released, `hashicorp/go-azure-helpers` should be tagged/released and then vendored into both `hashicorp/go-azure-sdk` and `hashicorp/terraform-provider-azurerm`.
3. Send a Pull Request [adding the new Resource ID to update `./tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids/commonids` within `hashicorp/pandora`](https://github.com/hashicorp/pandora/tree/main/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids/commonids) so that it can be detected as a new Common ID. [Example](https://github.com/hashicorp/pandora/pull/2816).
4. Once that Pull Request is merged, `hashicorp/go-azure-sdk` will be regenerated and make use of the new Common ID from `hashicorp/go-azure-helpers`.
