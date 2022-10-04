/*
service "ManagedIdentity" {
  terraform_package = "managedidentity"

  api "2018-11-30" {
    package "ManagedIdentities" {
      definition "user_assigned_identity" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{resourceName}"
        display_name = "User Assigned Identity"
        website_subcategory = "Authorization"
        description = "Manages a User Assigned Identity"
      }
    }
  }
}
*/