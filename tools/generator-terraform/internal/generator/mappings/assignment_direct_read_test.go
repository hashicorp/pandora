// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestDirectAssignment_Read_Constant_RequiredToRequired_TopLevel(t *testing.T) {
	testData := []struct {
		constant             assignmentConstantDetails
		expected             string
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected:             "output.FromPath = float64(input.ToPath)",
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.FromPath = int64(input.ToPath)",
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.FromPath = string(input.ToPath)",
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:    "from_path",
					Required:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected:             "output.FromPath = pointer.To(float64(input.ToPath))",
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.FromPath = pointer.To(int64(input.ToPath))",
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected:             "output.FromPath = pointer.To(string(input.ToPath))",
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:    "from_path",
					Required:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:    "from_path",
					Optional:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = float64(*input.FromPath)
}
`,
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = int64(*input.FromPath)
}
`,
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			expected: `
if input.FromPath != nil {
	output.ToPath = string(*input.FromPath)
}
`,
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:    "from_path",
					Optional:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
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
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
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
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
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
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:    "from_path",
					Required:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
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
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
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
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
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
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:    "from_path",
					Required:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
					Values: map[string]string{
						"OnePointZeroOne":   "1.01",
						"ThreePointOneFour": "3.14",
					},
				},
			},
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"One":   "1",
						"Three": "3",
					},
				},
			},
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:    "from_path",
					Optional:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
	}{
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.FloatSDKConstantType,
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
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.IntegerSDKConstantType,
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
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
		},
		{
			constant: assignmentConstantDetails{
				apiResourcePackageName: "sdkresource",
				constantName:           "SomeConstant",
				constantDetails: models.SDKConstant{
					Type: models.StringSDKConstantType,
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
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to a %q constant", i, string(v.schemaModelFieldType), string(v.constant.constantDetails.Type))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:    "from_path",
					Optional:   true,
					Validation: possibleValuesDefinitionFromConstant(t, v.constant.constantDetails),
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "from_path",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
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
		expected := "output.FromPath = input.ToPath"
		testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
	}
}

func TestDirectAssignment_Read_Model_RequiredToOptional_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where the Schema field is Required but the SDK field is Optional
	// and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "from_path",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "from_path",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
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

func TestDirectAssignment_Read_Model_OptionalToOptional_MatchingSimpleTypes(t *testing.T) {
	// when mapping a model to a model where both fields are optional and matching simple (bool/string etc) types
	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
			expected:             `output.FromPath = pointer.From(input.ToPath)`,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: v.schemaModelFieldType,
					},
					HCLName:  "from_path",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
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

func TestDirectAssignment_Read_Model_RequiredToRequired_MatchingListOfSimpleTypes(t *testing.T) {
	// mapping a Schema Model Field to an SDK Field where both are Required and a List of Matching Simple Types (string/int etc)

	testData := []struct {
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
			expected: `
toPath := make([]bool, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = toPath
`,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
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
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:  "from_path",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
			expected: `
toPath := make([]bool, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
			expected: `
toPath := make([]float64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
			expected: `
toPath := make([]int64, 0)
for _, v := range input.ToPath {
	toPath = append(toPath, v)
}
output.FromPath = &toPath
`,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
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
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:  "from_path",
					Required: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
		},
		{
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
		},
	}
	for i, v := range testData {
		t.Logf("Test %d - mapping %q to %q", i, string(v.schemaModelFieldType), string(v.sdkFieldType))
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:  "from_path",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
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
		schemaModelFieldType models.TerraformSchemaObjectDefinitionType
		sdkFieldType         models.SDKObjectDefinitionType
		expected             string
	}{
		{
			schemaModelFieldType: models.BooleanTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.BooleanSDKObjectDefinitionType,
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
			schemaModelFieldType: models.FloatTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.FloatSDKObjectDefinitionType,
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
			schemaModelFieldType: models.IntegerTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.IntegerSDKObjectDefinitionType,
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
			schemaModelFieldType: models.StringTerraformSchemaObjectDefinitionType,
			sdkFieldType:         models.StringSDKObjectDefinitionType,
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
		mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
			DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
				SDKFieldName:             "ToPath",
				SDKModelName:             "ToModel",
				TerraformSchemaFieldName: "FromPath",
				TerraformSchemaModelName: "FromModel",
			},
		}
		schemaModel := models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"FromPath": {
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.ListTerraformSchemaObjectDefinitionType,
						NestedObject: &models.TerraformSchemaObjectDefinition{
							Type: v.schemaModelFieldType,
						},
					},
					HCLName:  "from_path",
					Optional: true,
				},
			},
		}
		sdkModel := models.SDKModel{
			Fields: map[string]models.SDKField{
				"ToPath": {
					JsonName: "toPath",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
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

	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "ToPath",
			SDKModelName:             "ToModel",
			TerraformSchemaFieldName: "FromPath",
			TerraformSchemaModelName: "FromModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		Fields: map[string]models.TerraformSchemaField{
			"FromPath": {
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
					},
				},
				HCLName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: models.SDKObjectDefinition{
					Type: models.ListSDKObjectDefinitionType,
					NestedItem: &models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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

	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "ToPath",
			SDKModelName:             "ToModel",
			TerraformSchemaFieldName: "FromPath",
			TerraformSchemaModelName: "FromModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		Fields: map[string]models.TerraformSchemaField{
			"FromPath": {
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
					},
				},
				HCLName:  "from_path",
				Required: true,
			},
		},
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: models.SDKObjectDefinition{
					Type: models.ListSDKObjectDefinitionType,
					NestedItem: &models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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

	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "ToPath",
			SDKModelName:             "ToModel",
			TerraformSchemaFieldName: "FromPath",
			TerraformSchemaModelName: "FromModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		Fields: map[string]models.TerraformSchemaField{
			"FromPath": {
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
					},
				},
				HCLName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: models.SDKObjectDefinition{
					Type: models.ListSDKObjectDefinitionType,
					NestedItem: &models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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

	mapping := models.TerraformDirectAssignmentFieldMappingDefinition{
		DirectAssignment: models.TerraformDirectAssignmentFieldMappingDefinitionImpl{
			SDKFieldName:             "ToPath",
			SDKModelName:             "ToModel",
			TerraformSchemaFieldName: "FromPath",
			TerraformSchemaModelName: "FromModel",
		},
	}
	schemaModel := models.TerraformSchemaModel{
		Fields: map[string]models.TerraformSchemaField{
			"FromPath": {
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.ListTerraformSchemaObjectDefinitionType,
					NestedObject: &models.TerraformSchemaObjectDefinition{
						Type:          models.ReferenceTerraformSchemaObjectDefinitionType,
						ReferenceName: pointer.To("SomeOtherSchemaModel"),
					},
				},
				HCLName:  "from_path",
				Optional: true,
			},
		},
	}
	sdkModel := models.SDKModel{
		Fields: map[string]models.SDKField{
			"ToPath": {
				JsonName: "toPath",
				ObjectDefinition: models.SDKObjectDefinition{
					Type: models.ListSDKObjectDefinitionType,
					NestedItem: &models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
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
