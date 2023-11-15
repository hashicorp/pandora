variable "primary_location" {}
variable "random_integer" {}
variable "random_string" {}

resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
