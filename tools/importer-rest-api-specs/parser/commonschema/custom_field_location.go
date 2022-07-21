package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
)

var _ customFieldMatcher = locationMatcher{}

type locationMatcher struct{}

func (l locationMatcher) IsMatch(field models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "location") && definition.Type == models.ObjectDefinitionString
}

func (locationMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeLocation
}
