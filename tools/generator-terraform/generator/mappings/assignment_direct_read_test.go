package mappings

import (
	"fmt"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_Read_Constant_RequiredToRequired_TopLevel(t *testing.T) {
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
			expected:             "output.FromPath = float64(input.ToPath)",
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
			expected:             "output.FromPath = int64(input.ToPath)",
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
			expected:             "output.FromPath = string(input.ToPath)",
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
						ReferenceName: pointer.To("SomeConstant"),
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Constant_RequiredToOptional_TopLevel(t *testing.T) {
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
			expected:             "output.FromPath = pointer.To(float64(input.ToPath))",
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
			expected:             "output.FromPath = pointer.To(int64(input.ToPath))",
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
			expected:             "output.FromPath = pointer.To(string(input.ToPath))",
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
						ReferenceName: pointer.To("SomeConstant"),
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Constant_OptionalToRequired_TopLevel(t *testing.T) {
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
						ReferenceName: pointer.To("SomeConstant"),
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_Read_Constant_OptionalToOptional_TopLevel(t *testing.T) {
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
	output.ToPath = pointer.To(float64(*input.FromPath))
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
	output.ToPath = pointer.To(int64(*input.FromPath))
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
	output.ToPath = pointer.To(string(*input.FromPath))
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
						ReferenceName: pointer.To("SomeConstant"),
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Constant_RequiredToRequired_List(t *testing.T) {
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
toPath := make([]float64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, float64(v))
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
toPath := make([]int64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, int64(v))
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
toPath := make([]string, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, string(v))
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
							ReferenceName: pointer.To("SomeConstant"),
						},
					},
					Required: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Constant_RequiredToOptional_List(t *testing.T) {
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
toPath := make([]float64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, float64(v))
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
toPath := make([]int64, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, int64(v))
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
toPath := make([]string, 0)
for _, v := range input.FromPath {
	toPath = append(toPath, string(v))
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
							ReferenceName: pointer.To("SomeConstant"),
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Constant_OptionalToRequired_List(t *testing.T) {
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
							ReferenceName: pointer.To("SomeConstant"),
						},
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

func TestDirectAssignment_Read_Constant_OptionalToOptional_List(t *testing.T) {
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
toPath := make([]float64, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, float64(v))
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
toPath := make([]int64, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, int64(v))
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
toPath := make([]string, 0)
if input.FromPath != nil {
	for _, v := range *input.FromPath {
		toPath = append(toPath, string(v))
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
							ReferenceName: pointer.To("SomeConstant"),
						},
					},
					Optional: true,
				},
			},
		}
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, &v.constant, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		testhelpers.AssertTemplatedCodeMatches(t, v.expected, *actual)
	}
}

func TestDirectAssignment_Read_Model_RequiredToRequired_MatchingSimpleTypes(t *testing.T) {
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
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		expected := "output.FromPath = input.ToPath"
		testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
	}
}

func TestDirectAssignment_Read_Model_RequiredToOptional_MatchingSimpleTypes(t *testing.T) {
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
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err != nil {
			t.Fatalf("retrieving read assignment mapping: %+v", err)
		}
		if actual == nil {
			t.Fatalf("retrieving read assignment mapping: `actual` was nil")
		}
		expected := `
if input.ToPath != nil {
	output.FromPath = *input.ToPath
}
`
		testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
	}
}

func TestDirectAssignment_Read_Model_OptionalToRequired_MatchingSimpleTypes(t *testing.T) {
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
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_Read_Model_OptionalToOptional_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
			sdkFieldType:         resourcemanager.BooleanApiObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
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

func TestDirectAssignment_Read_Model_RequiredToRequired_MatchingListOfSimpleTypes(t *testing.T) {
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
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
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

func TestDirectAssignment_Read_Model_RequiredToOptional_MatchingListOfSimpleTypes(t *testing.T) {
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
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
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

func TestDirectAssignment_Read_Model_OptionalToRequired_MatchingListOfSimpleTypes(t *testing.T) {
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
		actual, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, nil, "sdkresource")
		if err == nil {
			t.Fatalf("expected an error but didn't get one")
		}
		if actual != nil {
			t.Fatalf("expected an error and no result but got a result (%q) and no error", *actual)
		}
	}
}

func TestDirectAssignment_Read_Model_OptionalToOptional_MatchingListOfSimpleTypes(t *testing.T) {
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
if input.ToPath != nil {
	for _, v := range *input.ToPath {
		toPath = append(toPath, v)
	}
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeFloat,
			sdkFieldType:         resourcemanager.FloatApiObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
if input.ToPath != nil {
	for _, v := range *input.ToPath {
		toPath = append(toPath, v)
	}
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
			sdkFieldType:         resourcemanager.IntegerApiObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
if input.ToPath != nil {
	for _, v := range *input.ToPath {
		toPath = append(toPath, v)
	}
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeString,
			sdkFieldType:         resourcemanager.StringApiObjectDefinitionType,
			expected: `
toPath := make([]string, 0)
if input.ToPath != nil {
	for _, v := range *input.ToPath {
		toPath = append(toPath, v)
	}
}
output.FromPath = &toPath
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

func TestDirectAssignment_Read_Model_RequiredToRequired_ListOfReference(t *testing.T) {
	// mapping a Schema Model Field to an SDK Field where both are Required and a List of a Reference

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
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
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
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: pointer.To("SomeSdkModel"),
					},
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
	expected := `
		toPath := make([]SomeOtherSchemaModel, 0)
        for i, v := range input.ToPath {
        	item := SomeOtherSchemaModel{}
			if err := r.mapSomeSdkModelToSomeOtherSchemaModel(v, &item); err != nil {
				return fmt.Errorf("mapping SomeOtherSchemaModel item %d to SomeSdkModel: %+v", i, err)
			}
        	toPath = append(toPath, item)
        }
        output.FromPath = toPath
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDirectAssignment_Read_Model_RequiredToOptional_ListOfReference(t *testing.T) {
	// mapping an (Optional) Schema Model Field to a (Required) SDK Field where both are a List of a Reference

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
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
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
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: pointer.To("SomeSdkModel"),
					},
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
	expected := `
		toPath := make([]SomeOtherSchemaModel, 0)
        for i, v := range input.ToPath {
        	item := SomeOtherSchemaModel{}
			if err := r.mapSomeSdkModelToSomeOtherSchemaModel(v, &item); err != nil {
				return fmt.Errorf("mapping SomeOtherSchemaModel item %d to SomeSdkModel: %+v", i, err)
			}
        	toPath = append(toPath, item)
        }
        output.FromPath = &toPath
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDirectAssignment_Read_Model_OptionalToRequired_ListOfReference(t *testing.T) {
	// mapping a Schema Model Field (Optional) to an SDK Field (Required) for List of Reference
	// this has to be mapped, so is a Schema error / we should raise an error

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
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
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
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: pointer.To("SomeSdkModel"),
					},
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

func TestDirectAssignment_Read_Model_OptionalToOptional_ListOfReference(t *testing.T) {
	// mapping a Schema Model Field to an SDK Field where both are Optional and a List of a Reference

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
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
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
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: pointer.To("SomeSdkModel"),
					},
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
	expected := `
		toPath := make([]SomeOtherSchemaModel, 0)
		if input.ToPath != nil {
			for i, v := range *input.ToPath {
				item := SomeOtherSchemaModel{}
				if err := r.mapSomeSdkModelToSomeOtherSchemaModel(v, &item); err != nil {
					return fmt.Errorf("mapping SomeOtherSchemaModel item %d to SomeSdkModel: %+v", i, err)
				}
				toPath = append(toPath, item)
			}
		}
        output.FromPath = &toPath
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestDirectAssignment_Read_Location_RequiredToRequired_TopLevel(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching location
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeLocation,
			sdkFieldType:         resourcemanager.LocationApiObjectDefinitionType,
			expected:             "output.Location = location.Normalize(input.Location)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Location",
				SdkFieldPath:    "Location",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Location": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "location",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Location": {
					JsonName: "location",
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

func TestDirectAssignment_Read_Location_RequiredToOptional_TopLevel(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeLocation,
			sdkFieldType:         resourcemanager.LocationApiObjectDefinitionType,
			expected:             "output.Location = location.NormalizeNilable(input.Location)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Location",
				SdkFieldPath:    "Location",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Location": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "location",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Location": {
					JsonName: "location",
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

func TestDirectAssignment_Read_Location_OptionalToRequired_TopLevel(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeLocation,
			sdkFieldType:         resourcemanager.LocationApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Location",
				SdkFieldPath:    "Location",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Location": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "location",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Location": {
					JsonName: "location",
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

func TestDirectAssignment_Read_Location_OptionalToOptional_TopLevel(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching location
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeLocation,
			sdkFieldType:         resourcemanager.LocationApiObjectDefinitionType,
			expected:             `output.Location = location.NormalizeNilable(input.Location)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Location",
				SdkFieldPath:    "Location",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Location": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "location",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Location": {
					JsonName: "location",
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

func TestDirectAssignment_Read_Identity_SystemAssigned_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching SystemAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			sdkFieldType:         resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	output.Identity = identity.FlattenSystemAssignedToModel(input.Identity)
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAssigned_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching SystemAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			sdkFieldType:         resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	output.Identity = identity.FlattenSystemAssignedToModel(input.Identity)
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAssigned_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			sdkFieldType:         resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAssigned_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching SystemAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
			sdkFieldType:         resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	output.Identity = identity.FlattenSystemAssignedToModel(input.Identity)
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAndUserAssigned_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching SystemAndUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			sdkFieldType:         resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemAndUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAndUserAssigned_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching SystemAndUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			sdkFieldType:         resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemAndUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAndUserAssigned_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			sdkFieldType:         resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemAndUserAssigned_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching SystemAndUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
			sdkFieldType:         resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemAndUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemOrUserAssigned_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching SystemOrUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			sdkFieldType:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemOrUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemOrUserAssigned_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching SystemOrUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			sdkFieldType:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemOrUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemOrUserAssigned_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			sdkFieldType:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_SystemOrUserAssigned_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching SystemOrUserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
			sdkFieldType:         resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenSystemOrUserAssignedMapToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_UserAssigned_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching UserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			sdkFieldType:         resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenUserAssignedListToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_UserAssigned_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching UserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			sdkFieldType:         resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenUserAssignedListToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_UserAssigned_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			sdkFieldType:         resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Identity_UserAssigned_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching UserAssignedIdentity
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
			sdkFieldType:         resourcemanager.UserAssignedIdentityListApiObjectDefinitionType,
			expected: fmt.Sprintf(`
	identity, err := identity.FlattenUserAssignedListToModel(input.Identity)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	output.Identity = identity
`),
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Identity",
				SdkFieldPath:    "Identity",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Identity": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "identity",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Identity": {
					JsonName: "identity",
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

func TestDirectAssignment_Read_Zones_RequiredToRequired(t *testing.T) {
	// when mapping a model to a model where both fields are required and matching zones
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeZones,
			sdkFieldType:         resourcemanager.ZonesApiObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Zones",
				SdkFieldPath:    "Zones",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Zones": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Zones": {
					JsonName: "zones",
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

func TestDirectAssignment_Read_Zones_RequiredToOptional(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching zones
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeZones,
			sdkFieldType:         resourcemanager.ZonesApiObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Zones",
				SdkFieldPath:    "Zones",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Zones": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "zones",
					Required: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Zones": {
					JsonName: "zones",
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

func TestDirectAssignment_Read_Zones_OptionalToRequired(t *testing.T) {
	// when mapping a model to a model where the Schema field is Optional but the SDK field is Required
	// this has to be mapped, so is a Schema error / we should raise an error

	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeZones,
			sdkFieldType:         resourcemanager.ZonesApiObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Zones",
				SdkFieldPath:    "Zones",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Zones": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Zones": {
					JsonName: "zones",
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

func TestDirectAssignment_Read_Zones_OptionalToOptional(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching zones
	testData := []struct {
		schemaModelFieldType resourcemanager.TerraformSchemaFieldType
		sdkFieldType         resourcemanager.ApiObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: resourcemanager.TerraformSchemaFieldTypeZones,
			sdkFieldType:         resourcemanager.ZonesApiObjectDefinitionType,
			expected:             "output.Zones = zones.Flatten(input.Zones)",
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := resourcemanager.FieldMappingDefinition{
			Type: resourcemanager.DirectAssignmentMappingDefinitionType,
			DirectAssignment: &resourcemanager.FieldMappingDirectAssignmentDefinition{
				SchemaModelName: "FromModel",
				SchemaFieldPath: "Zones",
				SdkFieldPath:    "Zones",
				SdkModelName:    "ToModel",
			},
		}
		schemaModel := resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Zones": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HclName:  "zones",
					Optional: true,
				},
			},
		}
		sdkModel := resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Zones": {
					JsonName: "zones",
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
