// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package docs

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestExampleUsage(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			Documentation: models.TerraformDocumentationDefinition{
				ExampleUsageHCL: `
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
`,
			},
		},
	}
	actual, err := codeForExampleUsage(input)
	if err != nil {
		t.Fatalf("expected no error but got one: %+v", err)
	}
	expected := strings.ReplaceAll(`
## Example Usage

'''hcl
resource "azurerm_resource_group" "example" {
  name     = "example-resources"
  location = "West Europe"
}
'''
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
