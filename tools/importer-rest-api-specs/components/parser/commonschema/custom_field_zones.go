package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = zonesFieldMatcher{}

type zonesFieldMatcher struct {
}

func (e zonesFieldMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeZones
}

func (e zonesFieldMatcher) IsMatch(field models.FieldDetails, definition models.ObjectDefinition, _ internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "availabilityZones") && definition.Type == models.ObjectDefinitionReference && definition.NestedItem.Type == models.ObjectDefinitionString
}
