package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentPackageDefinition(t *testing.T) {
	input := models.ResourceInput{
		ServicePackageName: "example",
	}
	actual, err := packageDefinitionForResource(input)
	if err != nil {
		t.Fatalf("retrieving package definition: %+v", err)
	}
	expected := `package example`
	assertTemplatedCodeMatches(t, expected, *actual)
}
