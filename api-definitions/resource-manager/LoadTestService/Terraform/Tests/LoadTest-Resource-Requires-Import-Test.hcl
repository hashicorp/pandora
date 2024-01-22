# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

resource "azurerm_load_test" "import" {
  location            = azurerm_load_test.test.location
  name                = azurerm_load_test.test.name
  resource_group_name = azurerm_load_test.test.resource_group_name
}
