

provider "azurerm" {
  features {}
}

resource "azurerm_load_test" "test" {
  location            = azurerm_resource_group.test.location
  name                = "acctestlt-${var.random_string}"
  resource_group_name = azurerm_resource_group.test.name
}

