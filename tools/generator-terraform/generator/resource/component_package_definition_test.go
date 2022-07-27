package resource

import (
	"strings"
	"testing"
)

func TestComponentPackageDefinition(t *testing.T) {
	input := ResourceInput{
		ServicePackageName: "example",
	}
	actual := strings.TrimSpace(packageDefinitionForResource(input))
	expected := `package example`
	assertTemplatedCodeMatches(t, expected, actual)
}
