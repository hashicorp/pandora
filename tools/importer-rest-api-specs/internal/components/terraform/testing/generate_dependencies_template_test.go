// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDependenciesTemplate_NoDependenciesShouldOutputNothing(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},
	}
	expected := ""
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_EverythingEnabled(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsClientConfig:         true,
		needsDevCenter:            true,
		needsEdgeZone:             true,
		needsNetworkInterface:     true,
		needsPublicIP:             true,
		needsResourceGroup:        true,
		needsSubnet:               true,
		needsUserAssignedIdentity: true,
		needsVirtualNetwork:       true,
	}
	expected := `
data "example_client_config" "test" {}

resource "example_dev_center" "test" {
  name                = "acctestdc-${var.random_string}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location

  identity {
    type = "SystemAssigned"
  }
}

data "example_extended_locations" "test" {
  location = var.primary_location
}

resource "example_network_interface" "test" {
  name                = "acctestnic-${var.random_integer}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = example_subnet.test.id
    private_ip_address_allocation = "Static"
  }
}

resource "example_public_ip" "test" {
  name                = "acctest-${var.random_integer}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name
  allocation_method   = "Static"
}

resource "example_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}

resource "example_subnet" "test" {
  name                 = "internal"
  resource_group_name  = example_resource_group.test.name
  virtual_network_name = example_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]
}

resource "example_user_assigned_identity" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
}

resource "example_virtual_network" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsClientConfig(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		needsClientConfig: true,
	}
	expected := `
data "example_client_config" "test" {}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsDevCenter(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsDevCenter: true,
	}
	expected := `
resource "example_dev_center" "test" {
  name                = "acctestdc-${var.random_string}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location

  identity {
    type = "SystemAssigned"
  }
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsEdgeZone(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
		},

		needsEdgeZone: true,
	}
	expected := `
data "example_extended_locations" "test" {
  location = var.primary_location
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsKeyVault(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsKeyVault: true,
	}
	expected := `
resource "example_key_vault" "test" {
  name                       = "acctest-${var.random_string}"
  location                   = example_resource_group.test.location
  resource_group_name        = example_resource_group.test.name
  tenant_id                  = data.example_client_config.test.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 7

  access_policy {
	tenant_id = data.example_client_config.test.tenant_id
	object_id = data.example_client_config.test.object_id

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
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsKeyVaultKey(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsKeyVaultKey: true,
	}
	expected := `
resource "example_key_vault_key" "test" {
  name         = "key-${var.random_string}"
  key_vault_id = example_key_vault.test.id
  key_type     = "EC"
  key_size     = 2048

  key_opts = [
    "sign",
    "verify",
  ]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsNetworkInterface(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
		},

		needsNetworkInterface: true,
	}
	expected := `
resource "example_network_interface" "test" {
  name                = "acctestnic-${var.random_integer}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = example_subnet.test.id
    private_ip_address_allocation = "Static"
  }
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsPublicIP(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsPublicIP: true,
	}
	expected := `
resource "example_public_ip" "test" {
  name                = "acctest-${var.random_integer}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name
  allocation_method   = "Static"
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsResourceGroup(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsResourceGroup: true,
	}
	expected := `
resource "example_resource_group" "test" {
  name     = "acctestrg-${var.random_integer}"
  location = var.primary_location
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsSubnet(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsSubnet: true,
	}
	expected := `
resource "example_subnet" "test" {
  name                 = "internal"
  resource_group_name  = example_resource_group.test.name
  virtual_network_name = example_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsUserAssignedIdentity(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsUserAssignedIdentity: true,
	}
	expected := `
resource "example_user_assigned_identity" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsVirtualNetwork(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsVirtualNetwork: true,
	}
	expected := `
resource "example_virtual_network" "test" {
  name                = "acctest-${var.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsKubernetesFleetManager(t *testing.T) {
	t.Parallel()
	builder := newTestBuilder("example", "resource", sdkModels.TerraformResourceDefinition{})
	dependencies := testDependencies{
		variables:                   testVariables{},
		needsKubernetesFleetManager: true,
	}
	expected := `
resource "example_kubernetes_fleet_manager" "test" {
  name                = "acctestkfm${var.random_string}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
