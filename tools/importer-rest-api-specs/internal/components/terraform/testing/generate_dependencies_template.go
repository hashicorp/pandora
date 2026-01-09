// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
)

func (tb testBuilder) generateTemplateConfigForDependencies(dependencies testDependencies) string {
	components := make([]string, 0)

	// NOTE: as this gets refactored we should try and output these in the right order, for now
	// this is an intentional design choice to order these alphabetically - but that makes reviewing
	// the generated output harder, so with more dependencies this approach becomes problematic.

	if dependencies.needsApplicationInsights {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_application_insights" "test" {
  name                = "acctestai-${var.random_integer}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
  application_type    = "web"
}
`, tb.providerPrefix))
	}

	if dependencies.needsClientConfig {
		components = append(components, fmt.Sprintf(`
data "%[1]s_client_config" "test" {}
`, tb.providerPrefix))
	}

	if dependencies.needsDevCenter {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_dev_center" "test" {
  name                = "acctestdc-${var.random_string}"
  resource_group_name = %[1]s_resource_group.test.name
  location            = %[1]s_resource_group.test.location

  identity {
    type = "SystemAssigned"
  }
}
`, tb.providerPrefix))
	}

	if dependencies.needsEdgeZone {
		components = append(components, fmt.Sprintf(`
data "%[1]s_extended_locations" "test" {
  location = var.primary_location
}
`, tb.providerPrefix))
	}

	if dependencies.needsKeyVault {
		if dependencies.needsKeyVaultAccessPolicy {
			components = append(components, fmt.Sprintf(`
resource "%[1]s_key_vault" "test" {
  name                       = "acctest-${var.random_string}"
  location                   = %[1]s_resource_group.test.location
  resource_group_name        = %[1]s_resource_group.test.name
  tenant_id                  = data.%[1]s_client_config.test.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 7
}
`, tb.providerPrefix))
		} else {
			components = append(components, fmt.Sprintf(`
resource "%[1]s_key_vault" "test" {
  name                       = "acctest-${var.random_string}"
  location                   = %[1]s_resource_group.test.location
  resource_group_name        = %[1]s_resource_group.test.name
  tenant_id                  = data.%[1]s_client_config.test.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 7

  access_policy {
	tenant_id = data.%[1]s_client_config.test.tenant_id
	object_id = data.%[1]s_client_config.test.object_id

	certificate_permissions = [
	  "ManageContacts",
	]

	key_permissions = [
	  "Create",
	  "Delete",
	  "Get",
	  "Purge",
	  "Recover",
	  "Update",
	  "SetRotationPolicy",
	  "GetRotationPolicy",
	  "Rotate",
	]

	secret_permissions = [
	  "Delete",
	  "Get",
	  "Set",
	]
  }
}
`, tb.providerPrefix))
		}
	}

	if dependencies.needsKeyVaultAccessPolicy {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_key_vault_access_policy" "test" {
  key_vault_id = %[1]s_key_vault.test.id
  tenant_id    = data.%[1]s_client_config.test.tenant_id
  object_id    = data.%[1]s_client_config.test.object_id

  key_permissions = [
    "Create",
    "Get",
    "Delete",
    "Purge",
    "GetRotationPolicy",
  ]
}
`, tb.providerPrefix))
	}

	if dependencies.needsKeyVaultKey {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_key_vault_key" "test" {
  name         = "key-${var.random_string}"
  key_vault_id = %[1]s_key_vault.test.id
  key_type     = "EC"
  key_size     = 2048

  key_opts = [
    "sign",
    "verify",
  ]
}
`, tb.providerPrefix))
	}

	if dependencies.needsKubernetesCluster {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_kubernetes_cluster" "test" {
  name         = "acctestaks${var.random_string}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
  dns_prefix          = "acctestaks${var.random_string}"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_DS2_v2"
    upgrade_settings {
      max_surge = "10%%%%"
    }
  }

  identity {
    type = "SystemAssigned"
  }
}
`, tb.providerPrefix))
	}

	if dependencies.needsKubernetesFleetManager {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_kubernetes_fleet_manager" "test" {
  name                = "acctestkfm${var.random_string}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
}
`, tb.providerPrefix))
	}

	if dependencies.needsMachineLearningWorkspace {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_machine_learning_workspace" "test" {
  name                = "acctestmlw-${var.random_integer}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
  key_vault_id		  = azurerm_key_vault.test.id
  storage_account_id = azurerm_storage_account.test.id
  application_insights_id = azurerm_application_insights.test.id
  
  identity {
	type = "SystemAssigned"
  }
}
`, tb.providerPrefix))
	}

	if dependencies.needsNetworkInterface {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_network_interface" "test" {
  name                = "acctestnic-${var.random_integer}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = %[1]s_subnet.test.id
    private_ip_address_allocation = "Static"
  }
}
`, tb.providerPrefix))
	}

	if dependencies.needsPublicIP {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_public_ip" "test" {
  name                = "acctest-${var.random_integer}"
  location            = %[1]s_resource_group.test.location
  resource_group_name = %[1]s_resource_group.test.name
  allocation_method   = "Static"
}
`, tb.providerPrefix))
	}

	if dependencies.needsResourceGroup {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`, tb.providerPrefix))
	}

	if dependencies.needsStorageAccount {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_storage_account" "test" {
  name                     = "acctestsa${var.random_string}"
  location                 = %[1]s_resource_group.test.location
  resource_group_name      = %[1]s_resource_group.test.name
  account_tier             = "Standard"
  account_replication_type = "LRS"
}
`, tb.providerPrefix))
	}

	if dependencies.needsSubnet {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_subnet" "test" {
  name                 = "internal"
  resource_group_name  = %[1]s_resource_group.test.name
  virtual_network_name = %[1]s_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]
}
`, tb.providerPrefix))
	}

	if dependencies.needsUserAssignedIdentity {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_user_assigned_identity" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = %[1]s_resource_group.test.name
  location            = %[1]s_resource_group.test.location
}
`, tb.providerPrefix))
	}

	if dependencies.needsVirtualNetwork {
		components = append(components, fmt.Sprintf(`
resource "%[1]s_virtual_network" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = %[1]s_resource_group.test.name
  location            = %[1]s_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`, tb.providerPrefix))
	}

	out := strings.Join(components, "\n")
	bytes := []byte(out)
	hclsyntax.ParseConfig(bytes, "temp-for-format.hcl", hcl.Pos{Line: 1, Column: 1})
	out = string(hclwrite.Format(bytes))
	return out
}
