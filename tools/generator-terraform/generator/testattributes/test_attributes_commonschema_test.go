package testattributes

import (
	"fmt"
	"testing"

	"github.com/hashicorp/hcl/v2/hclwrite"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestPluginSdkAttributes_CommonSchema_EdgeZone(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"EdgeZone": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeEdgeZone,
						},
						HclName:  "edge_zone",
						Optional: true,
					},
				},
			},
			expected: "edge_zone = data.azurerm_extended_locations.test.extended_locations[0]",
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_SystemAndUserAssignedIdentity(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SystemAndUserAssignedIdentity": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
						},
						HclName:  "identity",
						Optional: true,
					},
				},
			},
			expected: `
identity {
	type = "SystemAssigned, UserAssigned"
	// todo add azurerm_user_assigned_identity.test to template
	identity_ids = [azurerm_user_assigned_identity.test.id]
}
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_SystemAssignedIdentity(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SystemAssignedIdentity": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
						},
						HclName:  "identity",
						Optional: true,
					},
				},
			},
			expected: `
identity {
	type = "SystemAssigned"
}
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_SystemOrUserAssignedIdentity(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SystemAssignedIdentity": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
						},
						HclName:  "identity",
						Optional: true,
					},
				},
			},
			expected: `
identity {
	type = "SystemAssigned"
}
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_UserAssignedIdentity(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"SystemAndUserAssignedIdentity": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
						},
						HclName:  "identity",
						Optional: true,
					},
				},
			},
			expected: `
identity {
	type = "UserAssigned"
	// todo add azurerm_user_assigned_identity.test to template
	identity_ids = [azurerm_user_assigned_identity.test.id]
}
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_Location(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Location": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeLocation,
						},
						HclName:  "location",
						Optional: true,
					},
				},
			},
			expected: "location = azurerm_resource_group.test.location",
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_ResourceGroup(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroup": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
						},
						HclName:  "resource_group_name",
						Optional: true,
					},
				},
			},
			expected: "resource_group_name = azurerm_resource_group.test.name",
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_Tags(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Tags": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeTags,
						},
						HclName:  "tags",
						Optional: true,
					},
				},
			},
			expected: `
tags = {
	env  = "Production"
	test = "Acceptance"
}
`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_Zone(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Zone": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeZone,
						},
						HclName:  "zone",
						Optional: true,
					},
				},
			},
			expected: "zone = 1",
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}

func TestPluginSdkAttributes_CommonSchema_Zones(t *testing.T) {
	testData := []struct {
		input    resourcemanager.TerraformSchemaModelDefinition
		expected string
	}{
		{
			input: resourcemanager.TerraformSchemaModelDefinition{
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Zones": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeZones,
						},
						HclName:  "zones",
						Optional: true,
					},
				},
			},
			expected: `zones = ["1"]`,
		},
	}

	file := hclwrite.NewEmptyFile()
	helper := TestAttributesHelpers{}
	for i, testCase := range testData {
		err := helper.GetAttributesForTests(testCase.input, *file.Body(), false)
		if err != nil {
			if testCase.expected == "" {
				continue
			}

			t.Fatalf("unexpected error for index %d", i)
		}
		assertTemplatedCodeMatches(t, testCase.expected, fmt.Sprintf("%s", file.Bytes()))
	}
}
