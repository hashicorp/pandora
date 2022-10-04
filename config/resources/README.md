## Configuration for Resources

> **Note:** this is a **work in progress**.

Each `*.hcl` file within this directory defines the Azure Resources which should be transformed into Terraform Data Sources and Resources.

### Example

```hcl
service "Compute" {
  api "2021-11-01" {
    package "VirtualMachines" {
      definition "virtual_machine" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachines/{virtualMachineName}"
        display_name = "Virtual Machine"
        website_subcategory = "Compute"
        description = "Manages a Virtual Machine"
      }
    }

    package "VirtualMachineScaleSets" {
      definition "virtual_machine_scale_set" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/virtualMachinesScaleSets/{virtualMachineScaleSetName}"
        display_name = "Virtual Machine Scale Set"
        website_subcategory = "Compute"
        description = "Manages a Virtual Machine Scale Set"
      }
    }
  }
}
```

### Options

TODO.

### Workflow

1. A new Service gets imported into Pandora, and the Data API generated for it (which is reviewed/merged).
2. A PR is sent either automatically/manually to add any new resources to the configs in this directory.
3. The Importer runs again, generating the Schema and Mappings for these new Resources based on the available information, sending a PR with new definitions for the Data API.
4. Once merged, a PR is sent to the Terraform Provider repository, both updating to the latest version of the Go SDK and then generating the new resources based off of that information.

When running the Importer connects to the Data API to find any existing Models and Schema for these resources, and patches them as required - allowing (for example) overrides and schema changes to be applied.

This also allows fields to be ignored, manually mapped by pushing to the branch created at step 3 above - which then remain as required etc.
