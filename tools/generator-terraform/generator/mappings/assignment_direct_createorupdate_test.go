package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_CreateOrUpdate_Constant_RequiredToRequired_TopLevel(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected:             "output.ToPath = sdkresource.SomeConstant(input.FromPath)",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.ToPath = sdkresource.SomeConstant(input.FromPath)",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.ToPath = sdkresource.SomeConstant(input.FromPath)",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "from_path",
					Required: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeConstant"),
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_RequiredToOptional_TopLevel(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected:             "output.ToPath = as.Pointer(sdkresource.SomeConstant(input.FromPath))",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.ToPath = as.Pointer(sdkresource.SomeConstant(input.FromPath))",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.ToPath = as.Pointer(sdkresource.SomeConstant(input.FromPath))",
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "from_path",
					Required: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeConstant"),
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_OptionalToRequired_TopLevel(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		constant             assignmentConstantDetails
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "from_path",
					Optional: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeConstant"),
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_OptionalToOptional_TopLevel(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = as.Pointer(sdkresource.SomeConstant(*input.FromPath))
}
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = as.Pointer(sdkresource.SomeConstant(*input.FromPath))
}
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = as.Pointer(sdkresource.SomeConstant(*input.FromPath))
}
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "from_path",
					Optional: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("SomeConstant"),
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_RequiredToRequired_List(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HclName:  "from_path",
					Required: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
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
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SomeConstant"),
						},
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_RequiredToOptional_List(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, sdkresource.SomeConstant(v))
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HclName:  "from_path",
					Required: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
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
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SomeConstant"),
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_OptionalToRequired_List(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HclName:  "from_path",
					Optional: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
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
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SomeConstant"),
						},
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Constant_OptionalToOptional_List(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.FloatConstant,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, sdkresource.SomeConstant(v))
	}
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.IntegerConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, sdkresource.SomeConstant(v))
	}
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: resourcemanager.ConstantDetails{
					Type: resourcemanager.StringConstant,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
toPath := make([]sdkresource.SomeConstant, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, sdkresource.SomeConstant(v))
	}
}
output.ToPath = &toPath
`,
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HclName:  "from_path",
					Optional: true,
					Validation: &resourcemanager.TerraformSchemaValidationDefinition{
						Type:           resourcemanager.TerraformSchemaValidationTypePossibleValues,
						PossibleValues: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
					},
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
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SomeConstant"),
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, &v.constant)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_RequiredToRequired_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,

			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
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
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		expected := "output.ToPath = input.FromPath"
		testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_RequiredToOptional_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
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
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		expected := "output.ToPath = &input.FromPath"
		testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_OptionalToRequired_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
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
						Type: v.sdkFieldType,
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_OptionalToOptional_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
			expected:             `output.ToPath = input.FromPath`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected:             `output.ToPath = input.FromPath`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected:             `output.ToPath = input.FromPath`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected:             `output.ToPath = input.FromPath`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
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
						Type: v.sdkFieldType,
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_RequiredToRequired_MatchingListOfSimpleTypes(t *testing.T) {
	// mapping a Schema Model Field to an SDK Field where both are Required and a List of Matching Simple Types (string/int etc)

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
			expected: `
toPath := make([]bool, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = toPath
`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
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
							Type: v.sdkFieldType,
						},
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_RequiredToOptional_MatchingListOfSimpleTypes(t *testing.T) {
	// mapping a Schema Model Field (Required) to an SDK Field (Optional) where both are List of Matching Simple Types (string/int etc)

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
			expected: `
toPath := make([]bool, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, v)
}
output.ToPath = &toPath
`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
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
							Type: v.sdkFieldType,
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_OptionalToRequired_MatchingListOfSimpleTypes(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Required) where both are List of Matching Simple Types (string/int etc)
	// this isn't possible (since the SDK Field has to be set) - so we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
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
							Type: v.sdkFieldType,
						},
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_CreateOrUpdate_Model_OptionalToOptional_MatchingListOfSimpleTypes(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Optional) where both are List of Matching Simple Types (string/int etc)

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
			expected: `
toPath := make([]bool, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, v)
	}
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, v)
	}
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, v)
	}
}
output.ToPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, v)
	}
}
output.ToPath = &toPath
`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "FromPath",
				SdkFieldPath:    "ToPath",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"FromPath": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeList,
						NestedObject: &resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: v.schemaModelFieldType,
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
							Type: v.sdkFieldType,
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, nil)
		if err != nil {
			t.Fatalf("retrieving create/update assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving create/update assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}
