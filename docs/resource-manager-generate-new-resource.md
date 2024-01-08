## Guide: Generating a new (Resource Manager) Resource

The AzureRM Provider is made up of Services which contain Data Sources and Resources.

### Prerequisites and Known Limitations

As [covered in the overview](README.md), Pandora imports data from the Azure API Definitions into Pandora's API Definition format and normalizes data as it passes through.

At this point in time we support generating Terraform Resources (with some known limitations) once the Service and API version have been imported into Pandora - [see this document for how to do that](resource-manager-service-import.md) which also includes generating the associated Go SDK into [`hashicorp/go-azure-sdk`](https://github.com/hashicorp/go-azure-sdk).

The Terraform Resources which should be imported are [defined within this repository](../config/resources).

Each `*.hcl` file within this directory defines the Azure Resources which should be transformed into Terraform Data Sources and Resources.

### Example

```hcl
service "ContainerService" {
  terraform_package = "containers"

  api "2022-09-02-preview" {
    package "Fleets" {
      definition "kubernetes_fleet_manager" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}"
        display_name = "Kubernetes Fleet Manager"
        website_subcategory = "Container"
        description = "Manages a Kubernetes Fleet Manager"
      }
    }
  }

  api "2023-03-02-preview" {
    package "TrustedAccess" {
      definition "kubernetes_cluster_trusted_access_role_binding" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}/trustedAccessRoleBindings/{trustedAccessRoleBindingName}"
        display_name = "Kubernetes Cluster Trusted Access Role Binding"
        website_subcategory = "Container"
        description = <<HERE
Manages a Kubernetes Cluster Trusted Access Role Binding
~> **Note:** This Resource is in **Preview** to use this you must be opted into the Preview. You can do this by running `az feature register --namespace Microsoft.ContainerService --name TrustedAccessPreview` and then `az provider register -n Microsoft.ContainerService`
HERE
        test_data {
          basic_variables {
            lists = {
              "roles" = ["Microsoft.MachineLearningServices/workspaces/mlworkload"]
            }
            strings = {
              "source_resource_id" = "machine_learning_workspace_id"
            }
          }
          complete_variables {
            lists = {
              "roles" = ["Microsoft.MachineLearningServices/workspaces/mlworkload", "Microsoft.MachineLearningServices/workspaces/inference-v1"]
            }
            strings = {
              "source_resource_id" = "machine_learning_workspace_id"
            }
          }
        }
      }
    }
  }
}
```

The example above consists of the following properties:

* Labels:
  * `Compute` - (Required) - This is the name of the Service defined in Pandora, it is identical to the directory name containing the Pandora API definitions residing in [ `./api-definitions`](https://github.com/hashicorp/pandora/blob/main/api-definitions)
  * `2021-11-01` - (Required) - This is the Version of the Service
  * `VirtualMachines`, `VirtualMachineScaleSets` - (Required) - This is the name of the Resource for which there are Pandora API definitions
  * `virtual_machine`, `virtual_machine_scale_set` - (Required) - This is the name that the resource should have in the AzureRM provider with the `azurerm` prefix omitted. The prefix will be added automatically during generation
* `id` - (Required) - This is the resource ID that the resource should have. Segments must be camel cased and user specified segments are expressed in curly braces e.g. {resourceName}
* `display_name` - (Required) - This is the name we use when referring to the resource in the documentation
* `website_subcategory` - (Required) - This is the documentation category that the resource belongs to
* `description` - (Required) - This is the description text that is shown in the documentation for the resource

### Options

In addition to the properties above there are also several options that are available to control the generation of a resource.

* `test_data` - (Optional) - One test data block that allows us to customise the test data to be used in the basic and complete tests
* `basic_variables` - (Optional) - One basic variable block that specifies custom values for test data in the basic resource test
* `complete_variables` - (Optional) - One complete variable block that specifies custom values for test data in the complete resource test
* `lists` - (Optional) - This is a map of property name to list, e.g. if there is a list property in a resource that requires a custom value it would be specified in this map
* `strings` - (Optional) - This is a map of property name to string, e.g. if there is a string property in a resource that requires a custom value it would be specified in this map

### Workflow

1. A new Service is imported into Pandora, by the Configuration being updated in a PR. Once merged, the API Definitions are regenerated, sending a PR containing any changes which is then reviewed/merged.
2. A PR is sent to add any new resources to the configs in this directory.
3. The Importer runs again, generating the Schema and Mappings for these new Resources based on the available information. It will apply any patches and/or overrides for this Resource, resulting in a PR containing the updated Terraform Resource Definitions.
4. Once merged, a PR is sent to regenerate the existing Terraform Resources into `hashicorp/terraform-provider-azurerm` based off of that information.

This also allows fields to be ignored, manually mapped by pushing to the branch created at step 3 above - which then remain as required etc.

Some resources cannot, unfortunately, be generated. Reasons include, but are not necessarily limited to:

* Data fidelity - Some API specs simply do not contain enough information to accurately determine how a resource is intended to be used.
* Resource Complexity - Some resources make use of polymorphic properties, called discriminators, these are not (currently) supported.
* Data Errors - Some API Specifications contain errors or breaches of compatibility with the ARM specification. These can typically be addressed by submitting fixes back to the source at https://github.com/Azure/azure-rest-api-specs/issues
