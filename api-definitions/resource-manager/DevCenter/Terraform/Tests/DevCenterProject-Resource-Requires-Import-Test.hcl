# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

resource "azurerm_dev_center_project" "import" {
  dev_center_id       = azurerm_dev_center_project.test.dev_center_id
  location            = azurerm_dev_center_project.test.location
  name                = azurerm_dev_center_project.test.name
  resource_group_name = azurerm_dev_center_project.test.resource_group_name
}
