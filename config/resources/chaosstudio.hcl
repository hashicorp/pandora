service "ChaosStudio" {
  terraform_package = "chaosstudio"

  api "2023-04-15-preview" {
    package "Experiments" {
      definition "chaos_studio_experiments" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/experiments/{experimentName}"
        display_name = "Chaos Studio Experiments"
        website_subcategory = "Chaos Studio"
        description = "Manages a Chaos Studio Experiment"
      }
    }
  }
}