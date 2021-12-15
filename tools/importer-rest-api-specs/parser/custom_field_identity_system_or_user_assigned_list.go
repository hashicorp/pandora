package parser

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = systemOrUserAssignedIdentityListMatcher{}

type systemOrUserAssignedIdentityListMatcher struct{}

func (systemOrUserAssignedIdentityListMatcher) customFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemOrUserAssignedIdentityList
}

func (systemOrUserAssignedIdentityListMatcher) isMatch(field models.FieldDetails, definition models.ObjectDefinition, known parseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.models[*definition.ReferenceName]
	if !ok {
		return false
	}

	hasUserAssignedIdentities := false
	hasMatchingType := false
	hasPrincipalId := false
	hasTenantId := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "PrincipalId") {
			hasPrincipalId = true
			continue
		}

		if strings.EqualFold(fieldName, "TenantId") {
			hasTenantId = true
			continue
		}

		if strings.EqualFold(fieldName, "UserAssignedIdentities") {
			// this should be a List of Strings
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionList {
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
				"SystemAssigned": "SystemAssigned",
				"UserAssigned":   "UserAssigned",
			}
			hasMatchingType = validateIdentityConstantValues(constant, expected)
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities && hasMatchingType && hasPrincipalId && hasTenantId
}
