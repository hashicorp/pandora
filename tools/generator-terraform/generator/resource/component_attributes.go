package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/pluginsdkattributes"
)

func attributesCodeFunctionForResource(input models.ResourceInput) (*string, error) {
	helper := pluginsdkattributes.PluginSdkAttributesHelpers{
		SchemaModels: input.SchemaModels,
	}
	schemaModel := input.SchemaModels[input.SchemaModelName]
	argumentsCode, err := helper.CodeForModelAttributesOnly(schemaModel)
	if err != nil {
		return nil, fmt.Errorf("building code for top level schema model %q: %+v", input.SchemaModelName, err)
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) Attributes() map[string]*pluginsdk.Schema {
	return %[2]s
}
`, input.ResourceTypeName, *argumentsCode)
	return &output, nil
}
