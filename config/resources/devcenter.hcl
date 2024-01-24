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

    package "Galleries" {
      definition "dev_center_gallery" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devCenters/{devCenterName}/galleries/{galleryName}"
        display_name = "Dev Center Gallery"
        website_subcategory = "Dev Center"
        description = "Manages a Dev Center Gallery"
        overrides "gallery_resource_id" {
          updated_name = "shared_gallery_id"
        }
      }
    }
  }
}
