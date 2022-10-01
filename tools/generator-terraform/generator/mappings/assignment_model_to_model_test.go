package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestModelToModelMapping_SchemaToSdk_Required_HappyPath(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ModelToModelMappingDefinitionType,
		ModelToModel: &resourcemanager.FieldMappingModelToModelDefinition{
			SchemaModelName: "TheSchemaModel",
			SdkModelName:    "TheSdkModel",
			SdkFieldName:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ModelToModelMappingDefinitionType,
		ModelToModel: &resourcemanager.FieldMappingModelToModelDefinition{
			SchemaModelName: "TheSchemaModel",
			SdkModelName:    "TheSdkModel",
			SdkFieldName:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
        if err := r.mapTheSchemaModelToSomeOtherModel(input, output.SomeSdkField); err != nil {
        	return fmt.Errorf("mapping Schema to SDK Field %q / Model %q: %+v", "SomeOtherModel", "SomeSdkField", err)
        }
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelToModelMapping_SchemaToSdk_WrongType(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.DirectAssignmentMappingDefinitionType,
		DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
			SchemaModelName: "TheSchemaModel",
			SchemaFieldPath: "SomeSchemaField",
			SdkModelName:    "TheSdkModel",
			SdkFieldPath:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ModelToModelMappingDefinitionType,
		ModelToModel: &resourcemanager.FieldMappingModelToModelDefinition{
			SchemaModelName: "TheSchemaModel",
			SdkModelName:    "TheSdkModel",
			SdkFieldName:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ModelToModelMappingDefinitionType,
		ModelToModel: &resourcemanager.FieldMappingModelToModelDefinition{
			SchemaModelName: "TheSchemaModel",
			SdkModelName:    "TheSdkModel",
			SdkFieldName:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.DirectAssignmentMappingDefinitionType,
		DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
			SchemaModelName: "TheSchemaModel",
			SchemaFieldPath: "SomeSchemaField",
			SdkModelName:    "TheSdkModel",
			SdkFieldPath:    "SomeSdkField",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		// not used for this one, just a placeholder
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"SomeSdkField": {
				JsonName: "someSdkField",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeOtherModel"),
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
