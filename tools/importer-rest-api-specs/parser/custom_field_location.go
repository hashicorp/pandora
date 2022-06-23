package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = locationMatcher{}

type locationMatcher struct{}

func (l locationMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "location") && definition.Type == models.ObjectDefinitionString
}

func (locationMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeLocation
}
