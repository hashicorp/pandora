package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = systemOrUserAssignedIdentityMapMatcher{}

type systemOrUserAssignedIdentityMapMatcher struct{}

func (systemOrUserAssignedIdentityMapMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemOrUserAssignedIdentityMap
}

func (systemOrUserAssignedIdentityMapMatcher) IsMatch(_ models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.Models[*definition.ReferenceName]
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
			// this should be a Map of an Object containing ClientId/PrincipalId
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionDictionary {
				continue
			}
			if fieldVal.ObjectDefinition.NestedItem == nil || fieldVal.ObjectDefinition.NestedItem.Type != models.ObjectDefinitionReference {
				continue
			}

			inlinedModel, ok := known.Models[*fieldVal.ObjectDefinition.NestedItem.ReferenceName]
			if !ok {
				continue
			}

			innerHasClientId := false
			innerHasPrincipalId := false
			for innerName, innerVal := range inlinedModel.Fields {
				if strings.EqualFold(innerName, "ClientId") {
					if innerVal.ObjectDefinition == nil {
						continue
					}
					if innerVal.ObjectDefinition.Type != models.ObjectDefinitionString {
						continue
					}

					innerHasClientId = true
					continue
				}

				if strings.EqualFold(innerName, "PrincipalId") {
					if innerVal.ObjectDefinition == nil {
						continue
					}
					if innerVal.ObjectDefinition.Type != models.ObjectDefinitionString {
						continue
					}

					innerHasPrincipalId = true
					continue
				}

				// if extra fields are returned within the UAI properties block then we ignore them for now
			}

			hasUserAssignedIdentities = innerHasClientId && innerHasPrincipalId
			continue
		}

		if strings.EqualFold(fieldName, "Type") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}
			constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
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

		// Per the API Definition, the `DelegatedResources` field is for `internal use only` - therefore we should ignore this if it's present
		if strings.EqualFold(fieldName, "DelegatedResources") {
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities && hasMatchingType && hasPrincipalId && hasTenantId
}
