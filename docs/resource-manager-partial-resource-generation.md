## Guide: Partially generating a new (Resource Manager) Resource

There are instances where we might only want to generate parts of a resource, e.g. everything except for the update which can require special logic to do.

This guide walks through an example for the resource `azurerm_chaos_studio_target` where we generate everything but handwrite the create method.

### Prerequisites and Known Limitations

At the moment only the resource's Create/Read/Update/Delete methods can be toggled for generation. It isn't possible to toggle test generation yet.

### Example

```hcl
service "ChaosStudio" {
  terraform_package = "chaosstudio"

  api "2023-11-01" {
    package "Targets" {
      definition "chaos_studio_target" {
        id                  = "/{scope}/providers/Microsoft.Chaos/targets/{targetName}"
        display_name        = "Chaos Studio Target"
        website_subcategory = "Chaos Studio"
        description         = "Manages a Chaos Studio Target"
        generate_create     = false
        overrides "name" {
          updated_name = "target_type"
          description = "The name of the Chaos Studio Target. This has the format of [publisher]-[targetType] e.g. `Microsoft-StorageAccount`. For supported values please see this Target Type column in [this table](https://learn.microsoft.com/azure/chaos-studio/chaos-studio-fault-providers)."
        }
        overrides "scope" {
          updated_name = "target_resource_id"
        }
        test_data {
          basic_variables {
            strings = {
              "target_type" = "Microsoft-AzureKubernetesServiceChaosMesh"
            }
          }
        }
      }
    }
  }
}
```

The configuration above will generate the resource `azurerm_chaos_studio_target` but without the create method.

In addition to not generating the create method we are also applying overrides to the fields `name` and `scope`, renaming them to `target_type` and `target_resource_id` respectively.

The property `name` also has a custom description applied that gives the user more information on what the field is and what information we expect in it.

### Workflow

For partially generated resources we need to add the pieces in a specific order. For this particular example the order is as follows:

1. Open a PR to add the following files to the `hashicorp/terraform-azurerm-provider` repository under the path `internal/services/chaosstudio`:
    * `client/client_gen.go` - contains the initialisation of the Chaos Studio client, this file will be overwritten
    * `chaos_studio_target_resource_create.go` - contains the handwritten create method for the Chaos Studio Target resource
    * `chaos_studio_target_resource_gen.go` - contains the initialised typed resource, but with the bare minimum information so that `chaos_studio_target_resource_create.go` can be added without causing a compile error. This file will be overwritten with the correct information when the automated PR is opened on the repository.
    * `registration.go` - contains the registration information for the resource
    * `registration_gen.go` - contains the registration information for generated resources, this file will be overwritten as well
2. Once the PR from step 1. has been merged we can open a PR on `hashicorp/pandora` adding the resource definition defined in the [Example](#example)
3. When the PR from step 2. has been merged `hashicorp/pandora` will generate and open a PR on the `hashicorp/terraform-azurerm-provider` repository, overwriting the files suffixed with `_gen.go` listed in step.1 with the generated resource information.