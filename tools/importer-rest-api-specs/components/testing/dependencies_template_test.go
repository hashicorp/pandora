package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDependenciesTemplate_NoDependenciesShouldOutputNothing(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},
	}
	expected := ""
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_EverythingEnabled(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsEdgeZone:             true,
		needsPublicIP:             true,
		needsResourceGroup:        true,
		needsSubnet:               true,
		needsUserAssignedIdentity: true,
		needsVirtualNetwork:       true,
	}
	expected := `
data "example_extended_locations" "test" {
  location = example_resource_group.test.location
}

resource "example_public_ip" "test" {
  name                = "acctest-${local.random_integer}"
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
  name                = "acctest-${local.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
}

resource "example_virtual_network" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsEdgeZone(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsEdgeZone: true,
	}
	expected := `
data "example_extended_locations" "test" {
  location = example_resource_group.test.location
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsPublicIP(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsPublicIP: true,
	}
	expected := `
resource "example_public_ip" "test" {
  name                = "acctest-${local.random_integer}"
  location            = example_resource_group.test.location
  resource_group_name = example_resource_group.test.name
  allocation_method   = "Static"
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsResourceGroup(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
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
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
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
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsUserAssignedIdentity: true,
	}
	expected := `
resource "example_user_assigned_identity" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestDependenciesTemplate_NeedsVirtualNetwork(t *testing.T) {
	builder := NewTestBuilder("example", "resource", resourcemanager.TerraformResourceDetails{})
	dependencies := testDependencies{
		variables: testVariables{},

		needsVirtualNetwork: true,
	}
	expected := `
resource "example_virtual_network" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = example_resource_group.test.name
  location            = example_resource_group.test.location
  address_space       = ["10.0.0.0/16"]
}
`
	actual := builder.generateTemplateConfigForDependencies(dependencies)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
