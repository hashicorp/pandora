// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = legacySystemAndUserAssignedIdentityMapMatcher{}

type legacySystemAndUserAssignedIdentityMapMatcher struct{}

func (legacySystemAndUserAssignedIdentityMapMatcher) CustomFieldType() importerModels.CustomFieldType {
	return importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap
}

func (legacySystemAndUserAssignedIdentityMapMatcher) IsMatch(_ importerModels.FieldDetails, definition importerModels.ObjectDefinition, known internal.ParseResult) bool {
	if definition.Type != importerModels.ObjectDefinitionReference {
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
			if fieldVal.ObjectDefinition == nil {
				continue
			}
			if fieldVal.ObjectDefinition.Type == importerModels.ObjectDefinitionDictionary {
				// however some Swaggers don't define the internals e.g. DataFactory
				//type FactoryIdentity struct {
				//	PrincipalId            *string                 `json:"principalId,omitempty"`
				//	TenantId               *string                 `json:"tenantId,omitempty"`
				//	Type                   FactoryIdentityType     `json:"type"`
				//	UserAssignedIdentities *map[string]interface{} `json:"userAssignedIdentities,omitempty"`
				//}
				hasUserAssignedIdentities = true
				continue
			}
			if fieldVal.ObjectDefinition.NestedItem == nil || fieldVal.ObjectDefinition.NestedItem.Type != importerModels.ObjectDefinitionReference {
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
					if innerVal.ObjectDefinition.Type != importerModels.ObjectDefinitionString {
						continue
					}

					innerHasClientId = true
					continue
				}

				if strings.EqualFold(innerName, "PrincipalId") {
					if innerVal.ObjectDefinition == nil {
						continue
					}
					if innerVal.ObjectDefinition.Type != importerModels.ObjectDefinitionString {
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
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != importerModels.ObjectDefinitionReference {
				continue
			}
			constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
			if !ok {
				continue
			}
			expected := map[string]string{
				"SystemAssigned":             "SystemAssigned",
				"SystemAssignedUserAssigned": "SystemAssigned,UserAssigned",
				"UserAssigned":               "UserAssigned",
			}
			hasMatchingType = validateIdentityConstantValues(constant, expected)
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities && hasMatchingType && hasPrincipalId && hasTenantId
}
