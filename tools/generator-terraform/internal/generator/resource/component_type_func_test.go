// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentTypeFunc(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		ProviderPrefix:   "zoo",
		ResourceLabel:    "panda",
	}
	actual, err := typeFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
func (r ExampleResource) ResourceType() string {
	return "zoo_panda"
}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
