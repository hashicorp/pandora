package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentDefinition(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual, err := definitionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}

type ExampleResource struct {}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDefinitionForMethodWithUpdate(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		Details: resourcemanager.TerraformResourceDetails{
			UpdateMethod: &resourcemanager.MethodDefinition{
				MethodName:       "Update",
				Generate:         true,
				TimeoutInMinutes: 30,
			},
		},
	}
	actual, err := definitionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}
var _ sdk.ResourceWithUpdate = ExampleResource{}

type ExampleResource struct {}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
