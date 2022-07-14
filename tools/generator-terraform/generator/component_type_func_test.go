package generator

import (
	"strings"
	"testing"
)

func TestComponentTypeFunc(t *testing.T) {
	input := ResourceInput{
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
