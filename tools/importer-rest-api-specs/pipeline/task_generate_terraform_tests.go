package pipeline

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/testattributes"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (t pipelineTask) generateTerraformTests(data *models.AzureApiDefinition, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	for _, resource := range data.Resources {
		if t := resource.Terraform; t != nil {
			for resourceName, resourceDetails := range t.Resources {
				logger.Trace(fmt.Sprintf("Generating Tests for %q", resourceName))
				h := testattributes.TestAttributesHelpers{
					SchemaModels: resourceDetails.SchemaModels,
					Dependencies: &testattributes.TestDependencyHelper{},
				}

				basicTest, err := generateTestConfig(resourceDetails, true, h)
				if err != nil {
					return nil, err
				}
				if basicTest != nil {
					resourceDetails.Tests.BasicConfiguration = *basicTest
				}

				importTest, err := generateImportTestConfig(resourceDetails, h)
				if err != nil {
					return nil, err
				}
				if importTest != nil {
					resourceDetails.Tests.RequiresImportConfiguration = *importTest
				}

				// todo check that there not attributes are required before calling this
				completeTest, err := generateTestConfig(resourceDetails, false, h)
				if err != nil {
					return nil, err
				}
				if completeTest != nil {
					resourceDetails.Tests.CompleteConfiguration = completeTest
				}

				// todo figure out ids that could be resources and have those added to the template
				resourceDetails.Tests.TemplateConfiguration = generateTestTemplate(*h.Dependencies)

				if t.Resources == nil {
					t.Resources = map[string]resourcemanager.TerraformResourceDetails{resourceName: resourceDetails}
				} else {
					t.Resources[resourceName] = resourceDetails
				}
			}
		}
	}

	return data, nil
}

func generateTestConfig(input resourcemanager.TerraformResourceDetails, requiredOnly bool, helper testattributes.TestAttributesHelpers) (*string, error) {
	f := hclwrite.NewEmptyFile()

	// todo don't hardcode azurerm
	resourceHeader := fmt.Sprintf(`resource "azurerm_%s" "test"`, helpers.ConvertToSnakeCase(input.ResourceName))

	if err := helper.GetAttributesForTests(input.SchemaModels[input.SchemaModelName], *f.Body().AppendNewBlock(resourceHeader, nil).Body(), requiredOnly); err != nil {
		return nil, err
	}

	output := strings.Replace(fmt.Sprintf(`
%s
`, hclwrite.Format(f.Bytes())), "\"", "'", -1)
	return &output, nil
}

func generateImportTestConfig(input resourcemanager.TerraformResourceDetails, helper testattributes.TestAttributesHelpers) (*string, error) {
	f := hclwrite.NewEmptyFile()

	// todo don't hardcode azurerm
	resourceHeader := fmt.Sprintf(`resource "azurerm_%s" "import"`, helpers.ConvertToSnakeCase(input.ResourceName))

	if err := helper.GetAttributesForTests(input.SchemaModels[input.SchemaModelName], *f.Body().AppendNewBlock(resourceHeader, nil).Body(), true); err != nil {
		return nil, err
	}

	for hclName := range f.Body().Attributes() {
		f.Body().SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				// todo don't hardcode azurerm
				Name: fmt.Sprintf("azurerm_%s.test.%s", helpers.ConvertToSnakeCase(input.ResourceName), hclName),
			},
		})
	}

	output := strings.Replace(fmt.Sprintf(`
%s
`, hclwrite.Format(f.Bytes())), "\"", "'", -1)
	return &output, nil
}

func generateTestTemplate(dependencies testattributes.TestDependencyHelper) *string {
	output := `
provider "azurerm" {
	features {}
}

`
	// todo add random local variables

	// todo don't hardcode location
	if dependencies.Resource.HasResourceGroup {
		output += `
resource "azurerm_resource_group" "test" {
  name     = "acctestRG-${local.random_integer}"
  location = "West Europe"
}

`
	}

	if dependencies.Resource.HasEdgeZone {
		output += `
data "azurerm_extended_locations" "test" {
  location = azurerm_resource_group.test.location
}

`
	}

	if dependencies.Resource.HasUserAssignedIdentity {
		output += `
resource "azurerm_user_assigned_identity" "test" {
  name                = "acctest-${local.random_integer}"
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location
}

`
	}

	return &output
}
