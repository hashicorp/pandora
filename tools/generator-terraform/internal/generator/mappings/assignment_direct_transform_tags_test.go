// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_CreateOrUpdate_Tags_RequiredToRequired_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Required) for tags

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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
			t.Fatal("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Tags_RequiredToOptional_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Optional) for tags

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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
			t.Fatal("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Tags_OptionalToRequired_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Required) for tags
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err == nil {
			t.Fatal("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Tags_OptionalToOptional_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Optional) for tags

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					HCLName: "tags",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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

func TestDirectAssignment_Read_Tags_RequiredToRequired_TopLevel(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching tags
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             "output.Tags = tags.Flatten(input.Tags)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaModelName: "FromModel",
				TerraformSchemaFieldName: "Tags",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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

func TestDirectAssignment_Read_Tags_RequiredToOptional_TopLevel(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching tags
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             "output.Tags = tags.Flatten(input.Tags)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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

func TestDirectAssignment_Read_Tags_OptionalToRequired_TopLevel(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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

func TestDirectAssignment_Read_Tags_OptionalToOptional_TopLevel(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching tags
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.TagsTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.TagsSDKObjectDefinitionType,
			expected:             `output.Tags = tags.Flatten(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "Tags",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "Tags",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Tags": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"Tags": {
					JsonName: "tags",
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
