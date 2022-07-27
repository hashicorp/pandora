package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentPackageDefinition(t *testing.T) {
	input := models.ResourceInput{
		ServicePackageName: "example",
	}
	actual := strings.TrimSpace(packageDefinitionForResource(input))
	expected := `package example`
	assertTemplatedCodeMatches(t, expected, actual)
}
