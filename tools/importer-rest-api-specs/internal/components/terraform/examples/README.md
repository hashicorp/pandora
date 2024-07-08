## `./internal/components/terraform/examples`

This package is used to generate the Example Usage for a Terraform Resource.

This is done based on the Tests, therefore we base the Example Usage off of the `Basic` test, also adding the `Template` if available.

As a part of this the label for this resource name is updated from `test` to `example`, as are any references to known variables/other resources.

As an example, the Test Configuration shown below:

```terraform
variable "random_integer" {}
variable "primary_location" {}

resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}

resource "azurerm_virtual_network" "test" {
  name                = "${var.random_integer}-network"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
  address_space       = ["10.0.0.0/16"]
  dns_servers         = ["10.0.0.4", "10.0.0.5"]
}
```

Would generate the following Example Usage:

```terraform
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
resource "azurerm_virtual_network" "example" {
  name                = "21-network"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  address_space       = "example-value"
  dns_servers         = "example-value"
}
```
