package resource

import (
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"strings"
	"testing"
)

func TestResourceTestStruct(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual := strings.TrimSpace(testResourceStruct(input))
	expected := `type ExampleResource struct{}`
	assertTemplatedCodeMatches(t, expected, actual)
}
