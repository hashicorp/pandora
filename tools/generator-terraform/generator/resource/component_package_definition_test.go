package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
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
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
