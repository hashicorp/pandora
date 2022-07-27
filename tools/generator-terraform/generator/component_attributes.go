package generator

import (
	"fmt"
)

func attributesCodeFunctionForResource(input ResourceInput) string {
	helper := pluginSdkAttributesHelpers{
		schemaModels: input.SchemaModels,
	}
	schemaModel := input.SchemaModels[input.SchemaModelName]
	argumentsCode, err := helper.codeForModelAttributesOnly(schemaModel)
	if err != nil {
		// TODO: thread through errors
		panic(fmt.Sprintf("building code for top level schema model %q: %+v", input.SchemaModelName, err))
	}

	return fmt.Sprintf(`
func (r %[1]sResource) Attributes() map[string]*pluginsdk.Schema {
	return %[2]s
}
`, input.ResourceTypeName, *argumentsCode)
}
