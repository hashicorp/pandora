package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestAttributeValueForField_BasicTypeBoolean(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeBoolean,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `false`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `21`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `21.42`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "some_field",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SomeField": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{}
	builder := NewTestBuilder("example", "resource", details)
	expected := `"val-${var.random_string}"`
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestAttributeValueForField_BasicTypeStringName(t *testing.T) {
	resourceLabelsToExpected := map[string]string{
		"linux_virtual_machine_scale_set": `"acctestlvmss-${var.random_integer}"`,
		"resource":                        `"acctestr-${var.random_integer}"`,
		"resource_group":                  `"acctestrg-${var.random_integer}"`,
		"subnet":                          `"acctests-${var.random_integer}"`,
		"virtual_network":                 `"acctestvn-${var.random_integer}"`,
	}
	for resourceLabel, expectedValue := range resourceLabelsToExpected {
		t.Logf("testing Label %q", resourceLabel)

		field := resourcemanager.TerraformSchemaFieldDefinition{
			HclName:  "name",
			Required: true,
			ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
		}
		details := resourcemanager.TerraformResourceDetails{
			SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"TopLevelModel": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"Name": field,
					},
				},
			},
			SchemaModelName: "TopLevelModel",
		}
		actualDependencies := testDependencies{
			variables: testVariables{},
		}
		builder := NewTestBuilder("example", resourceLabel, details)
		actual, err := builder.getAttributeValueForField(field, &actualDependencies)
		if err != nil {
			t.Fatalf(err.Error())
		}
		testhelpers.AssertTemplatedCodeMatches(t, expectedValue, string(actual.Bytes()))
		expectedDependencies := testDependencies{
			variables: testVariables{
				needsRandomInteger: true,
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

func TestAttributeValueForField_BasicTypeStringNetworkInterfaceID(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "network_interface_id",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"NetworkInterfaceId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "subnet_id",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SubnetId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "subscription_id",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SubscriptionId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := `data.example_client_config.test.subscription_id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		needsClientConfig: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringTenantID(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "tenant_id",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"TenantId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := `data.example_client_config.test.tenant_id`
	testhelpers.AssertTemplatedCodeMatches(t, expected, string(actual.Bytes()))
	expectedDependencies := testDependencies{
		needsClientConfig: true,
	}
	assertDependenciesMatch(t, expectedDependencies, actualDependencies)
}

func TestAttributeValueForField_BasicTypeStringVirtualNetworkID(t *testing.T) {
	field := resourcemanager.TerraformSchemaFieldDefinition{
		HclName:  "virtual_network_id",
		Required: true,
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	details := resourcemanager.TerraformResourceDetails{
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"TopLevelModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"VirtualNetworkId": field,
				},
			},
		},
		SchemaModelName: "TopLevelModel",
	}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	builder := NewTestBuilder("example", "resource", details)
	actual, err := builder.getAttributeValueForField(field, &actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
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
