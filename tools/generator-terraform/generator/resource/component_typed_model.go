package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

// TODO: tests covering this

func codeForTopLevelTypedModelAndDefinition(input models.ResourceInput) (*string, error) {
	schemaModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("schema model named %q was not found", input.SchemaModelName)
	}

	schemaFields := make([]string, 0)
	for fieldName, fieldDetails := range schemaModel.Fields {
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
type %[2]s struct {
	%[3]s
}

func (r %[1]sResource) ModelObject() interface{} {
	return &%[2]s{}
}
`, input.ResourceTypeName, input.SchemaModelName, strings.Join(schemaFields, "\n"))
	return &output, nil
}

// TODO: codeForNonTopLevelModels
