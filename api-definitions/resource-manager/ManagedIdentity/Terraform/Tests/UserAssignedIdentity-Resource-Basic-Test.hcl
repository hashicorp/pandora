

provider "azurerm" {
  features {}
}

resource "azurerm_user_assigned_identity" "test" {
  location            = azurerm_resource_group.test.location
  name                = "acctestuai-${var.random_string}"
  resource_group_name = azurerm_resource_group.test.name
}

