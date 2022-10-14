package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestResourceTestStruct(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
	}
	actual, err := testResourceStruct(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `type ExampleTestResource struct{}`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
