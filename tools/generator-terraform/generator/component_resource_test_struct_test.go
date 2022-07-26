package generator

import (
	"strings"
	"testing"
)

func TestResourceTestStruct(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
	}
	actual := strings.TrimSpace(testResourceStruct(input))
	expected := `type ExampleResource struct{}`
	assertTemplatedCodeMatches(t, expected, actual)
}
