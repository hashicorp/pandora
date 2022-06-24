package parser

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
)

var _ customFieldMatcher = edgeZoneFieldMatcher{}

type edgeZoneFieldMatcher struct {
}

func (e edgeZoneFieldMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeEdgeZone
}

func (e edgeZoneFieldMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.Models[*definition.ReferenceName]
	if !ok {
		return false
	}

	hasName := false
	hasMatchingType := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "Name") {
			hasName = true
			continue
		}

		if strings.EqualFold(fieldName, "Type") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}
			constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
			if !ok || len(constant.Values) != 1 {
				continue
			}
			for k, v := range constant.Values {
				if strings.EqualFold(k, "EdgeZone") && strings.EqualFold(v, "EdgeZone") {
					hasMatchingType = true
				}
			}
			continue
		}

		// other fields
		return false
	}

	return hasName && hasMatchingType
}
