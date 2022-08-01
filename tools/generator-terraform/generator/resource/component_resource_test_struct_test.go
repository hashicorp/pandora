package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func TestResourceTestStruct(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual, err := testResourceStruct(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `type ExampleResource struct{}`
	assertTemplatedCodeMatches(t, expected, *actual)
}
