package processors

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"strings"
)

var _ FieldNameProcessor = fieldNameSchemaOverrideRename{}

type fieldNameSchemaOverrideRename struct{}

func (fieldNameSchemaOverrideRename) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.TerraformDetails.SchemaOverrides != nil {
		for old, updated := range *metadata.TerraformDetails.SchemaOverrides {
			if strings.EqualFold(fieldName, strings.ReplaceAll(old, "_", "")) {

				updated = helpers.ConvertFromSnakeToTitleCase(updated)
				return &updated, nil
			}
		}
	}

	return nil, nil
}
