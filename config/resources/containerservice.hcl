# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0

service "ContainerService" {
  terraform_package = "containers"

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
