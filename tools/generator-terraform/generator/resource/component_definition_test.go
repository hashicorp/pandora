package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentDefinition(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual := strings.TrimSpace(definitionForResource(input))
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}

type ExampleResource struct {}
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
