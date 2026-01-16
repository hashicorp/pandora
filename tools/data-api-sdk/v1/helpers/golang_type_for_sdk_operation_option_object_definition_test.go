// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestGolangTypeForSDKOperationOptionObjectDefinition_Valid(t *testing.T) {
	testData := []struct {
		input    models.SDKOperationOptionObjectDefinition
		expected string
	}{
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.BooleanSDKOperationOptionObjectDefinitionType,
			},
			expected: "bool",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.CSVSDKOperationOptionObjectDefinitionType,
			},
			expected: "string",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.FloatSDKOperationOptionObjectDefinitionType,
			},
			expected: "float64",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.IntegerSDKOperationOptionObjectDefinitionType,
			},
			expected: "int64",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.BooleanSDKOperationOptionObjectDefinitionType,
				},
			},
			expected: "[]bool",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.FloatSDKOperationOptionObjectDefinitionType,
				},
			},
			expected: "[]float64",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.IntegerSDKOperationOptionObjectDefinitionType,
				},
			},
			expected: "[]int64",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type:          models.ReferenceSDKOperationOptionObjectDefinitionType,
					ReferenceName: pointer.To("SomeCustomType"),
				},
			},
			expected: "[]SomeCustomType",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.StringSDKOperationOptionObjectDefinitionType,
				},
			},
			expected: "[]string",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type:          models.ReferenceSDKOperationOptionObjectDefinitionType,
				ReferenceName: pointer.To("SomeCustomType"),
			},
			expected: "SomeCustomType",
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.StringSDKOperationOptionObjectDefinitionType,
			},
			expected: "string",
		},
	}
	for i, val := range testData {
		t.Logf("Iteration %d..", i)

		actual, err := GolangTypeForSDKOperationOptionObjectDefinition(val.input)
		if err != nil {
			t.Fatal(err.Error())
		}

		if *actual != val.expected {
			t.Fatalf("expected %q but got %q", val.expected, *actual)
		}
	}
}

func TestGolangTypeForSDKOperationOptionObjectDefinition_Invalid(t *testing.T) {
	testData := []struct {
		input models.SDKOperationOptionObjectDefinition
	}{
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.CSVSDKOperationOptionObjectDefinitionType,
				},
			},
		},
		{
			input: models.SDKOperationOptionObjectDefinition{
				Type: models.ListSDKOperationOptionObjectDefinitionType,
				NestedItem: &models.SDKOperationOptionObjectDefinition{
					Type: models.ListSDKOperationOptionObjectDefinitionType,
				},
			},
		},
	}
	for i, val := range testData {
		t.Logf("Iteration %d..", i)

		actual, err := GolangTypeForSDKOperationOptionObjectDefinition(val.input)
		if err != nil {
			continue
		}

		t.Fatalf("expected an error but didn't get one - result was %q", *actual)
	}
}
