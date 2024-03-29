

provider "azurerm" {
  features {}
}

resource "azurerm_dev_center_project" "test" {
  dev_center_id              = azurerm_dev_center.test.id
  location                   = azurerm_resource_group.test.location
  name                       = "acctestdcp-${var.random_string}"
  resource_group_name        = azurerm_resource_group.test.name
  description                = "Description for the Dev Center Project"
  maximum_dev_boxes_per_user = 21
  tags = {
    environment = "terraform-acctests"
    some_key    = "some-value"
  }
}

