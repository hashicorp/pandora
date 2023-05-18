package testattributes

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func (h TestAttributesHelpers) workaround(resourceLabel string, input resourcemanager.TerraformSchemaFieldDefinition, requiredOnly bool, hclBody *hclwrite.Body) (done bool) {
	refName := pointer.From(input.ObjectDefinition.ReferenceName)
	switch resourceLabel {
	case "load_test":
		// for reference
		switch refName {
		case "LoadTestResourceEncryptionPropertiesIdentity":
			hclBody.AppendNewline()
			identityBody := hclBody.AppendNewBlock(input.HclName, nil).Body()
			identityBody.SetAttributeValue("type", cty.StringVal("UserAssigned"))

			setHclWithRef(identityBody, "resource_id", userAssignedIdentity.RefValue())
			h.AllDeps.Add(userAssignedIdentity)
			return true
		}

		// for literal field
		switch input.HclName {
		case "key_url":
			kvDep := newKeyVaultDep(`
  name                       = "acctestkv-${local.random_str}"
  location                   = azurerm_resource_group.test.location
  resource_group_name        = azurerm_resource_group.test.name
  tenant_id                  = data.azurerm_client_config.current.tenant_id
  sku_name                   = "standard"
  purge_protection_enabled   = true
  soft_delete_retention_days = 7

  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

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

  access_policy {
    tenant_id = azurerm_user_assigned_identity.test.tenant_id
    object_id = azurerm_user_assigned_identity.test.principal_id

    key_permissions = [
      "Get",
      "WrapKey",
      "UnwrapKey",
      "GetRotationPolicy",
      "Decrypt",
      "Encrypt",
    ]
  }

  tags = {
    environment = "Production"
  }
`)
			h.AllDeps.Add(keyVaultKeyDep.WithDeps(kvDep))
			setHclWithRef(hclBody, input.HclName, keyVaultKeyDep.RefValue())
			return true
		}
	}
	return false

}

func setHclWithRef(hclBody *hclwrite.Body, hclName, value string) {
	hclBody.SetAttributeTraversal(hclName, hcl.Traversal{
		hcl.TraverseRoot{
			Name: value,
		},
	})
}
