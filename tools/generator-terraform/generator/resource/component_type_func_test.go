package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestComponentTypeFunc(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ProviderPrefix:   "zoo",
		ResourceLabel:    "panda",
	}
	actual := strings.TrimSpace(typeFuncForResource(input))
	expected := strings.TrimSpace(`
func (r ExampleResource) ResourceType() string {
	return "zoo_panda"
}
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
