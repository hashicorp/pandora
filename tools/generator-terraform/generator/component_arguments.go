package generator

import (
	"fmt"
)

func argumentsCodeFunctionForResource(input ResourceInput) string {
	helper := pluginSdkAttributesHelpers{
		schemaModels: input.SchemaModels,
	}
	schemaModel := input.SchemaModels[input.SchemaModelName]
	argumentsCode, err := helper.codeForModel(schemaModel, true)
	if err != nil {
		// TODO: thread through errors
		panic(fmt.Sprintf("building code for top level schema model %q: %+v", input.SchemaModelName, err))
	}

	return fmt.Sprintf(`
func (r %[1]sResource) Arguments() map[string]*pluginsdk.Schema {
	return %[2]s
}
`, input.ResourceTypeName, *argumentsCode)
}
