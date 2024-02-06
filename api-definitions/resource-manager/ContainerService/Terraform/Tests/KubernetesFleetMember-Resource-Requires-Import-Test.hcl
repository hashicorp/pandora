resource "azurerm_kubernetes_fleet_member" "import" {
  kubernetes_cluster_id = azurerm_kubernetes_fleet_member.test.kubernetes_cluster_id
  kubernetes_fleet_id   = azurerm_kubernetes_fleet_member.test.kubernetes_fleet_id
  name                  = azurerm_kubernetes_fleet_member.test.name
}
