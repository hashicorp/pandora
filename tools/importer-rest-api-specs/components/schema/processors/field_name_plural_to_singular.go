package processors

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ FieldNameProcessor = fieldNamePluralToSingular{}

type fieldNamePluralToSingular struct{}

func (fieldNamePluralToSingular) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		// do not singularize the field name if nested object is a basic/primitive type
		// TODO extend for other base types
		if metadata.Model.Fields[fieldName].ObjectDefinition.NestedItem.Type != resourcemanager.StringApiObjectDefinitionType {
			updatedName := cleanup.GetSingular(fieldName)
			return &updatedName, nil
		}
	}

	return nil, nil
}
