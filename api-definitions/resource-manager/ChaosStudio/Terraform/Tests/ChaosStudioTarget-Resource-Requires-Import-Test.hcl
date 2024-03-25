resource "azurerm_chaos_studio_target" "import" {
  location           = azurerm_chaos_studio_target.test.location
  target_resource_id = azurerm_chaos_studio_target.test.target_resource_id
  target_type        = azurerm_chaos_studio_target.test.target_type
}
