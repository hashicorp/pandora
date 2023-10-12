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
  }
}
