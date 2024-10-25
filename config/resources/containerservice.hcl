# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

service "ContainerService" {
  terraform_package = "containers"

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

  api "2024-04-01" {
    package "FleetMembers" {
      definition "kubernetes_fleet_member" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}/members/{memberName}"
        display_name = "Kubernetes Fleet Member"
        website_subcategory = "Container"
        description = "Manages a Kubernetes Fleet Member"
        overrides "cluster_resource_id" {
          updated_name = "kubernetes_cluster_id"
        }
        overrides "fleet_id" {
          updated_name = "kubernetes_fleet_id"
        }
      }
    }
  }
}
