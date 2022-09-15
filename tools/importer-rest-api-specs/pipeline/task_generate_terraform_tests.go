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
	// TODO: @mbfrahry: go through and add the tests to each of the existing resources in details.Resources["blag"].Tests

	for _, resource := range data.Resources {
		if t := resource.Terraform; t != nil {
			for resourceName, resourceDetails := range t.Resources {
				logger.Trace(fmt.Sprintf("Generating Tests for %q", resourceName))

				basicTest, err := generateTestConfig(resourceDetails, true)
				if err != nil {
					return nil, err
				}
				if basicTest != nil {
					resourceDetails.Tests.BasicConfiguration = *basicTest
				}

				importTest, err := generateImportTestConfig(resourceDetails)
				if err != nil {
					return nil, err
				}
				if importTest != nil {
					resourceDetails.Tests.RequiresImportConfiguration = *importTest
				}

				// todo check that there not attributes are required before calling this
				completeTest, err := generateTestConfig(resourceDetails, false)
				if err != nil {
					return nil, err
				}
				if completeTest != nil {
					resourceDetails.Tests.CompleteConfiguration = completeTest
				}

				// todo figure out ids that could be resources and have those added to the template

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

func generateTestConfig(input resourcemanager.TerraformResourceDetails, requiredOnly bool) (*string, error) {
	f := hclwrite.NewEmptyFile()
	h := testattributes.TestAttributesHelpers{
		SchemaModels: input.SchemaModels,
	}

	// todo don't hardcode azurerm
	resourceHeader := fmt.Sprintf(`resource "azurerm_%s" "test"`, helpers.ConvertToSnakeCase(input.ResourceName))

	if err := h.GetAttributesForTests(input.SchemaModels[input.SchemaModelName], *f.Body().AppendNewBlock(resourceHeader, nil).Body(), requiredOnly); err != nil {
		return nil, err
	}

	output := strings.Replace(fmt.Sprintf(`
%s
`, hclwrite.Format(f.Bytes())), "\"", "`", -1)
	return &output, nil
}

func generateImportTestConfig(input resourcemanager.TerraformResourceDetails) (*string, error) {
	f := hclwrite.NewEmptyFile()
	h := testattributes.TestAttributesHelpers{
		SchemaModels: input.SchemaModels,
	}

	// todo don't hardcode azurerm
	resourceHeader := fmt.Sprintf(`resource "azurerm_%s" "import"`, helpers.ConvertToSnakeCase(input.ResourceName))

	if err := h.GetAttributesForTests(input.SchemaModels[input.SchemaModelName], *f.Body().AppendNewBlock(resourceHeader, nil).Body(), true); err != nil {
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
`, hclwrite.Format(f.Bytes())), "\"", "`", -1)
	return &output, nil
}
