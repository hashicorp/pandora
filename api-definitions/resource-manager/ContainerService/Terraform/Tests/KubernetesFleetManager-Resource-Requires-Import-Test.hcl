# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

resource "azurerm_kubernetes_fleet_manager" "import" {
  location            = azurerm_kubernetes_fleet_manager.test.location
  name                = azurerm_kubernetes_fleet_manager.test.name
  resource_group_name = azurerm_kubernetes_fleet_manager.test.resource_group_name
}
