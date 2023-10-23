# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

service "DevCenter" {
  terraform_package = "devcenter"

  api "2023-04-01" {
    package "DevCenters" {
      definition "dev_center" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devCenters/{devCenterName}"
        display_name = "Dev Center"
        website_subcategory = "Dev Center"
        description = "Manages a Dev Center"
      }
    }

    package "Projects" {
      definition "dev_center_project" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/projects/{projectName}"
        display_name = "Dev Center Project"
        website_subcategory = "Dev Center"
        description = "Manages a Dev Center Project"
      }
    }

    package "NetworkConnections" {
        definition "dev_center_network_connection" {
          id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/networkConnections/{networkConnectionName}"
          display_name = "Dev Center Network Connection"
          website_subcategory = "Dev Center"
          description = "Manages a Dev Center Network Connection"
        }
    }
  }
}
