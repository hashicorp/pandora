// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_BasicTypeBoolean(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.BooleanTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `false`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeInteger(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.IntegerTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `21`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeFloat(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.FloatTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `21.42`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables:                 testVariables{},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeString(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "some_field",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `"val-${var.random_string}"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsRandomString: true,
		},
		needsEdgeZone:             false,
		needsPublicIP:             false,
		needsResourceGroup:        false,
		needsSubnet:               false,
		needsUserAssignedIdentity: false,
		needsVirtualNetwork:       false,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringDescription(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "description",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"Description": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
		DisplayName:     "Example Thing",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{}
	builder := newTestBuilder("example", "resource", details)
	expected := `"Description for the Example Thing"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{},
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringName(t *testing.T) {
	resourceLabelsToExpected := map[string]string{
		"linux_virtual_machine_scale_set": `"acctestlvmss-${var.random_string}"`,
		"resource":                        `"acctestr-${var.random_string}"`,
		"resource_group":                  `"acctestrg-${var.random_string}"`,
		"subnet":                          `"acctests-${var.random_string}"`,
		"virtual_network":                 `"acctestvn-${var.random_string}"`,
	}
	for resourceLabel, expectedValue := range resourceLabelsToExpected {
		t.Logf("testing Label %q", resourceLabel)

		field := sdkModels.TerraformSchemaField{
			HCLName:  "name",
			Required: true,
			ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
				Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
			},
		}
		details := sdkModels.TerraformResourceDefinition{
			SchemaModels: map[string]sdkModels.TerraformSchemaModel{
				"TopLevelModel": {
					Fields: map[string]sdkModels.TerraformSchemaField{
						"Name": field,
					},
				},
			},
			SchemaModelName: "TopLevelModel",
		}
		variables := definitions.VariablesDefinition{}
		actualDependencies := testDependencies{
			variables: testVariables{},
		}
		builder := newTestBuilder("example", resourceLabel, details)
		actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
		if err != nil {
			t.Fatal(err.Error())
		}
		testhelpers.AssertTemplatedCodeMatches(t, expectedValue, string(actual.Bytes()))
		expectedDependencies := testDependencies{
			variables: testVariables{
				needsRandomString: true,
			},
			needsEdgeZone:             false,
			needsPublicIP:             false,
			needsResourceGroup:        false,
			needsSubnet:               false,
			needsUserAssignedIdentity: false,
			needsVirtualNetwork:       false,
		}
		assertDependenciesMatch(t, expectedDependencies, actualDependencies)
	}
}

func TestAttributeValueForField_BasicTypeStringKeyVaultID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "key_vault_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"KeyVaultId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_key_vault.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
		},
		needsClientConfig:  true,
		needsResourceGroup: true,
		needsKeyVault:      true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringKeyVaultKeyID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "key_vault_key_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"KeyVaultKeyId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_key_vault_key.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
			needsRandomString:    true,
		},
		needsClientConfig:  true,
		needsResourceGroup: true,
		needsKeyVault:      true,
		needsKeyVaultKey:   true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringKubernetesClusterID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "kubernetes_cluster_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"KubernetesClusterId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_kubernetes_cluster.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
			needsRandomString:    true,
		},
		needsResourceGroup:     true,
		needsKubernetesCluster: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringNetworkInterfaceID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "network_interface_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"NetworkInterfaceId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_network_interface.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
		},
		needsNetworkInterface: true,
		needsResourceGroup:    true,
		needsSubnet:           true,
		needsVirtualNetwork:   true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringSubnetID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "subnet_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SubnetId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_subnet.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
		},
		needsResourceGroup:  true,
		needsSubnet:         true,
		needsVirtualNetwork: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringSubscriptionID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "subscription_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"SubscriptionId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `data.example_client_config.test.subscription_id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		needsClientConfig: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringTenantID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "tenant_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"TenantId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `data.example_client_config.test.tenant_id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		needsClientConfig: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringUserAssignedIdentityID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "user_assigned_identity_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"UserAssignedIdentityId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_user_assigned_identity.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
		},
		needsResourceGroup:        true,
		needsUserAssignedIdentity: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringVirtualNetworkID(t *testing.T) {
	field := sdkModels.TerraformSchemaField{
		HCLName:  "virtual_network_id",
		Required: true,
		ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
			Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
		},
	}
	details := sdkModels.TerraformResourceDefinition{
		SchemaModels: map[string]sdkModels.TerraformSchemaModel{
			"TopLevelModel": {
				Fields: map[string]sdkModels.TerraformSchemaField{
					"VirtualNetworkId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	variables := definitions.VariablesDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := newTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies, variables)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `example_virtual_network.test.id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		variables: testVariables{
			needsPrimaryLocation: true,
			needsRandomInteger:   true,
		},
		needsResourceGroup:  true,
		needsVirtualNetwork: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}
