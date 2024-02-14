// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_CreateOrUpdate_Tags_RequiredToRequired_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Required) for tags

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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

func TestDirectAssignment_CreateOrUpdate_Tags_RequiredToOptional_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Optional) for tags

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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

func TestDirectAssignment_CreateOrUpdate_Tags_OptionalToRequired_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Required) for tags
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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

func TestDirectAssignment_CreateOrUpdate_Tags_OptionalToOptional_TopLevel(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Optional) for tags

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             `output.Tags = tags.Expand(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             "output.Tags = tags.Flatten(input.Tags)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             "output.Tags = tags.Flatten(input.Tags)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeTags,
			sdkFieldType:         resourcemanager.TagsApiObjectDefinitionType,
			expected:             `output.Tags = tags.Flatten(input.Tags)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Tags",
				SdkFieldPath:    "Tags",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Tags": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "tags",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Tags": {
					JsonName: "tags",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
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
