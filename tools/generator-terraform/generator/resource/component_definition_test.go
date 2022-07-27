package resource

import (
	"strings"
	"testing"
)

func TestComponentDefinition(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
	}
	actual := strings.TrimSpace(definitionForResource(input))
	expected := strings.TrimSpace(`
var _ sdk.Resource = ExampleResource{}

type ExampleResource struct {}
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
