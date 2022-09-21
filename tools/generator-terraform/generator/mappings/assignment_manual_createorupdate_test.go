package mappings

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestManualMapping_CreateOrUpdate_RequiredToRequired_TopLevel(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.StringApiObjectDefinitionType,
				},
				Required: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
toPath, err := myCustomMappingFunction(input.FromPath)
if err != nil {
	return fmt.Errorf("flattening 'FromPath': %+v", err)
}
out.ToPath = toPath
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestManualMapping_CreateOrUpdate_RequiredToOptional_TopLevel(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.StringApiObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
toPath, err := myCustomMappingFunction(input.FromPath)
if err != nil {
	return fmt.Errorf("flattening 'FromPath': %+v", err)
}
out.ToPath = &toPath
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestManualMapping_CreateOrUpdate_OptionalToRequired_TopLevel(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.StringApiObjectDefinitionType,
				},
				Required: true,
			},
		},
	}

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actual != nil {
		t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
	}
}

func TestManualMapping_CreateOrUpdate_OptionalToOptional_TopLevel(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				HclName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.StringApiObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
if input.FromPath != nil {
	toPath, err := myCustomMappingFunction(*input.FromPath)
	if err != nil {
		return fmt.Errorf("flattening 'FromPath': %+v", err)
	}
	out.ToPath = &toPath
}
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestManualMapping_CreateOrUpdate_RequiredToRequired_List(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
				HclName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.ListApiObjectDefinitionType,
					NestedItem: &resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				Required: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
toPath, err := myCustomMappingFunction(input.FromPath)
if err != nil {
	return fmt.Errorf("flattening 'FromPath': %+v", err)
}
out.ToPath = toPath
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestManualMapping_CreateOrUpdate_RequiredToOptional_List(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
				HclName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.ListApiObjectDefinitionType,
					NestedItem: &resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				Optional: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
toPath, err := myCustomMappingFunction(input.FromPath)
if err != nil {
	return fmt.Errorf("flattening 'FromPath': %+v", err)
}
out.ToPath = &toPath
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestManualMapping_CreateOrUpdate_OptionalToRequired_List(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
				HclName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.ListApiObjectDefinitionType,
					NestedItem: &resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				Required: true,
			},
		},
	}

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actual != nil {
		t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
	}
}

func TestManualMapping_CreateOrUpdate_OptionalToOptional_List(t *testing.T) {
	mapping := resourcemanager.FieldMappingDefinition{
		Type: resourcemanager.ManualMappingDefinitionType,
		From: resourcemanager.FieldMappingFromDefinition{
			SchemaModelName: "FromModel",
			SchemaFieldPath: "FromPath",
		},
		To: resourcemanager.FieldMappingToDefinition{
			SdkFieldPath: "ToPath",
			SdkModelName: "ToModel",
		},
		Manual: &resourcemanager.FieldManualMappingDefinition{
			MethodName: "myCustomMappingFunction",
		},
	}
	schemaModel := resourcemanager.TerraformSchemaModelDefinition{
		Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
			"FromPath": {
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeList,
					NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
				},
				HclName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := resourcemanager.ModelDetails{
		Fields: map[string]resourcemanager.FieldDetails{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: resourcemanager.ApiObjectDefinition{
					Type: resourcemanager.ListApiObjectDefinitionType,
					NestedItem: &resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				Optional: true,
			},
		},
	}
	expected := strings.ReplaceAll(`
if input.FromPath != nil {
	toPath, err := myCustomMappingFunction(*input.FromPath)
	if err != nil {
		return fmt.Errorf("flattening 'FromPath': %+v", err)
	}
	out.ToPath = &toPath
}
`, "'", "\"")

	actual, err := manualAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
	if err != nil {
		t.Fatalf("error building create/update assignment: %+v", err)
	}
	if actual == nil {
		t.Fatalf("`actual` was nil but shouldn't be")
	}
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
