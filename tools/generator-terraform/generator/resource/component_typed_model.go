package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

// TODO: tests covering this

func codeForTopLevelTypedModelAndDefinition(input models.ResourceInput) (*string, error) {
	//if !input.Details.GenerateModel {
	//	return nil, nil
	//}

	schemaModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("schema model named %q was not found", input.SchemaModelName)
	}

	codeForTopLevelModel, err := codeForModel(input.SchemaModelName, schemaModel)
	if err != nil {
		return nil, fmt.Errorf("building code for top-level schema model %q: %+v", input.SchemaModelName, err)
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) ModelObject() interface{} {
	return &%[2]s{}
}

%[3]s
`, input.ResourceTypeName, input.SchemaModelName, *codeForTopLevelModel)
	return &output, nil
}

// TODO: codeForNonTopLevelModels

func codeForModel(name string, input resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	schemaFields := make([]string, 0)
	for fieldName, fieldDetails := range input.Fields {
		golandFieldType, err := golangFieldTypeFromObjectFieldDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining Golang Field Type from ObjectDefinition for Field %q: %+v", fieldName, err)
		}
		if fieldDetails.Optional {
			v := fmt.Sprintf("*%s", *golandFieldType)
			golandFieldType = &v
		}

		schemaFields = append(schemaFields, fmt.Sprintf("%s %s `tfschema:%q`", fieldName, *golandFieldType, fieldDetails.HclName))
	}
	sort.Strings(schemaFields)

	output := fmt.Sprintf(`
type %[1]s struct {
	%[2]s
}
`, name, strings.Join(schemaFields, "\n"))
	return &output, nil
}
