package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = zoneFieldMatcher{}

type zoneFieldMatcher struct {
}

func (e zoneFieldMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeZone
}

func (e zoneFieldMatcher) IsMatch(field models.FieldDetails, definition models.ObjectDefinition, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZone") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := definition.Type == models.ObjectDefinitionString
	return nameMatches && typeMatches
}
