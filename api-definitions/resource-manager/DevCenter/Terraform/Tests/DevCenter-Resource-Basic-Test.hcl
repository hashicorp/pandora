

provider "azurerm" {
  features {}
}

resource "azurerm_dev_center" "test" {
  location            = azurerm_resource_group.test.location
  name                = "acctestdc-${var.random_string}"
  resource_group_name = azurerm_resource_group.test.name
}

