service "ContainerService" {
  terraform_package = "containers"

  api "2022-09-02-preview" {
    package "Fleets" {
      definition "kubernetes_fleet_manager" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}"
        display_name = "Kubernetes Fleet Manager"
        website_subcategory = "Container"
        description = <<HERE
Manages a Kubernetes Fleet Manager

~> **Note:** This Resource is in **Preview** to use this you must be opted into the Preview. You can do this by running `az feature register --namespace Microsoft.ContainerService --name FleetResourcePreview` and then `az provider register -n Microsoft.ContainerService`
HERE
      }
    }
  }

  api "2023-04-02-preview" {
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
