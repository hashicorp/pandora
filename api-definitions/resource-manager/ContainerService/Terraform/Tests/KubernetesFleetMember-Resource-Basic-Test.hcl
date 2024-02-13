

provider "azurerm" {
  features {}
}

resource "azurerm_kubernetes_fleet_member" "test" {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.test.id
  kubernetes_fleet_id   = azurerm_kubernetes_fleet_manager.test.id
  name                  = "acctestkfm-${var.random_string}"
}

