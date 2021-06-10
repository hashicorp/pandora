package generator

import (
	"fmt"
)

var _ stage = dataSourceSchemaStage{}

type dataSourceSchemaStage struct{}

func (r dataSourceSchemaStage) applicable(data *Data) bool {
	return !data.IsResource && data.TopLevelSchema != nil
}

func (r dataSourceSchemaStage) filePath(data Data) string {
	return fmt.Sprintf("%s_schema.go", data.fileNamePrefix)
}

func (r dataSourceSchemaStage) generate(data Data) (*string, error) {
	argumentsFields := make(map[string]FieldDefinition, 0)
	attributesFields := make(map[string]FieldDefinition, 0)
	for name, field := range data.TopLevelSchema.Fields {
		if field.Computed {
			if !field.Optional && !field.Required {
				attributesFields[name] = field
				continue
			}
		}

		argumentsFields[name] = field
	}

	argumentsCode, err := schemaForFields(argumentsFields, data.Objects, true)
	if err != nil {
		return nil, fmt.Errorf("generating schema code for arguments: %+v", err)
	}
	attributesCode, err := schemaForFields(attributesFields, data.Objects, true)
	if err != nil {
		return nil, fmt.Errorf("generating schema code for attributes: %+v", err)
	}

	content := fmt.Sprintf(`package %[1]s

import (
	tfsdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/sdk"
	gosdk "github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/services/%[1]s/sdk"
	"github.com/terraform-providers/terraform-provider-azurerm/azurerm/internal/tf/pluginsdk"
)

func (r %[2]sDataSource) Arguments() map[string]*pluginsdk.Schema {
	return %[3]s
}

func (r %[2]sDataSource) Attributes() map[string]*pluginsdk.Schema {
	return %[4]s
}
`, data.PackageName, data.ResourceName, *argumentsCode, *attributesCode)
	return &content, nil
}
