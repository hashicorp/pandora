// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentDefinition(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual, err := definitionForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}

type ExampleResource struct {}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDefinitionForMethodWithUpdate(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		Details: models.TerraformResourceDefinition{
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Update",
				TimeoutInMinutes: 30,
			},
		},
	}
	actual, err := definitionForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}
var _ sdk.ResourceWithUpdate = ExampleResource{}

type ExampleResource struct {}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDefinitionForMethodWithUpdateDisabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		Details: models.TerraformResourceDefinition{
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "Update",
				TimeoutInMinutes: 30,
			},
		},
	}
	actual, err := definitionForResource(input)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}

type ExampleResource struct {}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
