// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestModelToModelMapping_SchemaToSdk_Required_HappyPath(t *testing.T) {
	mapping := models.TerraformModelToModelFieldMappingDefinition{
		ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
				Required: true,
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err != nil {
		t.Fatalf("expected no error but got %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	expected := `
        if err := r.mapTheSchemaModelToSomeOtherModel(input, &output.SomeSdkField); err != nil {
        	return fmt.Errorf("mapping Schema to SDK Field %q / Model %q: %+v", "SomeOtherModel", "SomeSdkField", err)
        }
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelToModelMapping_SchemaToSdk_Optional_HappyPath(t *testing.T) {
	mapping := models.TerraformModelToModelFieldMappingDefinition{
		ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
				Optional: true,
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err != nil {
		t.Fatalf("expected no error but got %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	expected := `
		if output.SomeSdkField == nil {
        	output.SomeSdkField = &someresource.SomeOtherModel{}
        }
        if err := r.mapTheSchemaModelToSomeOtherModel(input, output.SomeSdkField); err != nil {
        	return fmt.Errorf("mapping Schema to SDK Field %q / Model %q: %+v", "SomeOtherModel", "SomeSdkField", err)
        }
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelToModelMapping_SchemaToSdk_WrongType(t *testing.T) {
	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaFieldName: "SomeSchemaField",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got: %+v", *actual)
	}
}

func TestModelToModelMapping_SdkToSchema_Required_HappyPath(t *testing.T) {
	mapping := models.TerraformModelToModelFieldMappingDefinition{
		ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
				Required: true,
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err != nil {
		t.Fatalf("expected no error but got %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	expected := `
		if err := r.mapSomeOtherModelToTheSchemaModel(input.SomeSdkField, output); err != nil {
	        return fmt.Errorf("mapping SDK Field %q / Model %q to Schema: %+v", "SomeOtherModel", "SomeSdkField", err)
        }
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelToModelMapping_SdkToSchema_Optional_HappyPath(t *testing.T) {
	mapping := models.TerraformModelToModelFieldMappingDefinition{
		ModelToModel: models.TerraformModelToModelFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
				Optional: true,
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err != nil {
		t.Fatalf("expected no error but got %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	expected := `
		if input.SomeSdkField == nil {
			input.SomeSdkField = &someresource.SomeOtherModel{}
		}
		if err := r.mapSomeOtherModelToTheSchemaModel(*input.SomeSdkField, output); err != nil {
	        return fmt.Errorf("mapping SDK Field %q / Model %q to Schema: %+v", "SomeOtherModel", "SomeSdkField", err)
        }
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelToModelMapping_SdkToSchema_WrongType(t *testing.T) {
	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "SomeSdkField",
			SDKModelName:             "TheSdkModel",
			TerraformSchemaFieldName: "SomeSchemaField",
			TerraformSchemaModelName: "TheSchemaModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		// not used for this one, just a placeholder
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeOtherModel"),
				},
			},
		},
	}
	actual, err := modelToModelAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "someresource")
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got: %+v", *actual)
	}
}
