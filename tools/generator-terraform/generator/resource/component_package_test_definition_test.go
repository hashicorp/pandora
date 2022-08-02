package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentPackageTestDefinition(t *testing.T) {
	input := models.ResourceInput{
		ServicePackageName: "example",
	}
	actual, err := packageTestDefinitionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `package example_test`
	assertTemplatedCodeMatches(t, expected, *actual)
}
