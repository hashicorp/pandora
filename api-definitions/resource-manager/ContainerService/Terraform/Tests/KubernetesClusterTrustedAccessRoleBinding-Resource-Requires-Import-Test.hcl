resource "azurerm_kubernetes_cluster_trusted_access_role_binding" "import" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster_trusted_access_role_binding.test.kubernetes_cluster_id
  name                  = azurerm_kubernetes_cluster_trusted_access_role_binding.test.name
  roles                 = azurerm_kubernetes_cluster_trusted_access_role_binding.test.roles
  source_resource_id    = azurerm_kubernetes_cluster_trusted_access_role_binding.test.source_resource_id
}
