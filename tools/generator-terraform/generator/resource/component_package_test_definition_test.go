package resource

import (
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"strings"
	"testing"
)

func TestComponentPackageTestDefinition(t *testing.T) {
	input := models.ResourceInput{
		ServicePackageName: "example",
	}
	actual := strings.TrimSpace(packageTestDefinitionForResource(input))
	expected := `package example_test`
	assertTemplatedCodeMatches(t, expected, actual)
}
