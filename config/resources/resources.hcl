service "Resources" {
  terraform_package = "resource"

  api "2020-06-01" {
    package "ResourceGroups" {
      definition "resource_group" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
        display_name = "Resource Group"
        website_subcategory = "Base"
        description = "Manages a Resource Group"
      }
    }
  }
}
