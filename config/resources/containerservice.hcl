service "ContainerService" {
  terraform_package = "containers"

  api "2022-09-02-preview" {
    package "Fleets" {
      definition "kubernetes_fleet_manager" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/fleets/{fleetName}"
        display_name = "Kubernetes Fleet Manager"
        website_subcategory = "Containers"
        description = "Manages a Kubernetes Fleet Manager"
      }
    }
  }
}
