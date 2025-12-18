// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_CreateOrUpdate_Zones_RequiredToRequired(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Required) for zones

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = zones.Expand(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Zones_RequiredToOptional(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Optional) for zones

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = pointer.To(zones.Expand(input.Zones))",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Zones_OptionalToRequired(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Required) for tags
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Zones_OptionalToOptional(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Optional) for zones

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = pointer.To(zones.Expand(input.Zones))",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Zones_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching zones
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Zones_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching zones
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Zones_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_Read_Zones_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching zones
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.ZonesTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.ZonesSDKObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Zones",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Zones",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Zones": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Zones": {
					JsonName: "zones",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}
