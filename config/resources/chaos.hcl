service "ChaosStudio" {
  terraform_package = "chaos"

  api "2022-07-01-preview" {
    package "Experiments" {
      definition "chaos_studio_experiment" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/experiments/{experimentName}"
        display_name = "Chaos Studio Experiment"
      }
    }
  }
}
