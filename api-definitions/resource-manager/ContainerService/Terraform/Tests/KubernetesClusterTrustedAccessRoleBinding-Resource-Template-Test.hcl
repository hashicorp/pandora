variable "primary_location" {}
variable "random_integer" {}
variable "random_string" {}

resource "azurerm_application_insights" "test" {
  name                = "acctestai-${var.random_integer}"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
  application_type    = "web"
}


data "azurerm_client_config" "test" {}


resource "azurerm_key_vault" "test" {
  name                       = "acctest-${var.random_string}"
  location                   = azurerm_resource_group.test.location
  resource_group_name        = azurerm_resource_group.test.name
  tenant_id                  = data.azurerm_client_config.test.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 7
}


resource "azurerm_key_vault_access_policy" "test" {
  key_vault_id = azurerm_key_vault.test.id
  tenant_id    = data.azurerm_client_config.test.tenant_id
  object_id    = data.azurerm_client_config.test.object_id

  key_permissions = [
    "Create",
    "Get",
    "Delete",
    "Purge",
    "GetRotationPolicy",
  ]
}


resource "azurerm_kubernetes_cluster" "test" {
  name                = "acctestaks${var.random_string}"
  location            = azurerm_resource_group.test.location
  resource_group_name = azurerm_resource_group.test.name
  dns_prefix          = "acctestaks${var.random_string}"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_DS2_v2"
  }
  upgrade_settings {
    max_surge = "10%%"
  }

  identity {
    type = "SystemAssigned"
  }
}


resource "azurerm_machine_learning_workspace" "test" {
  name                    = "acctestmlw-${var.random_integer}"
  location                = azurerm_resource_group.test.location
  resource_group_name     = azurerm_resource_group.test.name
  key_vault_id            = azurerm_key_vault.test.id
  storage_account_id      = azurerm_storage_account.test.id
  application_insights_id = azurerm_application_insights.test.id

  identity {
    type = "SystemAssigned"
  }
}


resource "azurerm_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}


resource "azurerm_storage_account" "test" {
  name                     = "acctestsa${var.random_string}"
  location                 = azurerm_resource_group.test.location
  resource_group_name      = azurerm_resource_group.test.name
  account_tier             = "Standard"
  account_replication_type = "LRS"
}
