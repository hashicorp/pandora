package resource

import (
	"fmt"

	"github.com/hashicorp/hcl/v2"

	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/testattributes"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func generateBasicTestConfig(input models.ResourceInput) (*string, error) {
	f := hclwrite.NewEmptyFile()
	h := testattributes.TestAttributesHelpers{
		SchemaModels: input.Details.SchemaModels,
	}
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}
	if err := h.GetAttributesForTests(input.Details.SchemaModels[input.Details.SchemaModelName], *f.Body(), true); err != nil {
		return nil, err
	}

	output := fmt.Sprintf(`
func (%[1]sResource) basic(data acceptance.TestData) string {
	return fmt.Sprintf(%[4]s
resource "%[2]s_%[3]s" "test" {
%[5]s
}
%[4]s)}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel, "`", f.Bytes())
	return &output, nil
}

func generateImportTestConfig(input models.ResourceInput) (*string, error) {
	f := hclwrite.NewEmptyFile()
	h := testattributes.TestAttributesHelpers{
		SchemaModels: input.Details.SchemaModels,
	}
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}
	if err := h.GetAttributesForTests(input.Details.SchemaModels[input.Details.SchemaModelName], *f.Body(), true); err != nil {
		return nil, err
	}

	for hclName := range f.Body().Attributes() {
		f.Body().SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_%s.test.%s", input.ProviderPrefix, input.ResourceLabel, hclName),
			},
		})
	}

	output := fmt.Sprintf(`
func (%[1]sResource) requiresImport(data acceptance.TestData) string {
	return fmt.Sprintf(%[4]s
resource "%[2]s_%[3]s" "import" {
%[5]s
}
%[4]s)}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel, "`", f.Bytes())
	return &output, nil
}
