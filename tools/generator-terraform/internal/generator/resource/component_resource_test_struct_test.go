// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"

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
