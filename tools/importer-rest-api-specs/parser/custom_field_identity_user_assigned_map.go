package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"strings"
)

var _ customFieldMatcher = userAssignedIdentityMapMatcher{}

type userAssignedIdentityMapMatcher struct{}

func (userAssignedIdentityMapMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeUserAssignedIdentityMap
}

func (userAssignedIdentityMapMatcher) isMatch(_ models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.models[*definition.ReferenceName]
	if !ok {
		return false
	}

	hasUserAssignedIdentities := false
	hasTypeMatch := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "UserAssignedIdentities") {
			// this should be a List of Strings
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
				continue
			}
			if fieldVal.ObjectDefinition.NestedItem == nil || fieldVal.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionString {
				continue
			}

			hasUserAssignedIdentities = true
			continue
		}

		if strings.EqualFold(fieldName, "Type") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}
			constant, ok := known.constants[*fieldVal.ObjectDefinition.ReferenceName]
			if !ok {
				continue
			}
			expected := map[string]string{
				"UserAssigned": "UserAssigned",
			}
			hasTypeMatch = validateIdentityConstantValues(constant, expected)
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities && hasTypeMatch
}
