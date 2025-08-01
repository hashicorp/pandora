# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

service "ManagedIdentity" {
  terraform_package = "managedidentity"

  api "2024-11-30" {
    package "ManagedIdentities" {
      definition "user_assigned_identity" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}"
        display_name = "User Assigned Identity"
        website_subcategory = "Authorization"
        description = "Manages a User Assigned Identity"
      }
    }
  }
}
