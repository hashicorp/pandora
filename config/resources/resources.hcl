service "Resources" {
  api "2020-06-01" {
    package "ResourceGroups" {
      definition "resource_group" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}"
        display_name = "Resource Group"
      }
    }
  }
}
