service "ChaosStudio" {
  terraform_package = "chaosstudio"

  api "2023-04-15-preview" {
    package "Targets" {
      definition "chaos_studio_targets" {
        id = "/{scope}/providers/Microsoft.Chaos/targets/{targetName}"
        display_name = "Chaos Studio Targets"
        website_subcategory = "Chaos Studio"
        description = "Manages Chaos Studio Targets"
      }
    }
  }
}