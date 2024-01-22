# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

resource "azurerm_dev_center" "import" {
  location            = azurerm_dev_center.test.location
  name                = azurerm_dev_center.test.name
  resource_group_name = azurerm_dev_center.test.resource_group_name
}
