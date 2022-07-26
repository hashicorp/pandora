package generator

import (
	"strings"
	"testing"
)

func TestComponentPackageTestDefinition(t *testing.T) {
	input := ResourceInput{
		ServicePackageName: "example",
	}
	actual := strings.TrimSpace(packageTestDefinitionForResource(input))
	expected := `package example_test`
	assertTemplatedCodeMatches(t, expected, actual)
}
