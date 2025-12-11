// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = systemOrUserAssignedIdentityMapMatcher{}

type systemOrUserAssignedIdentityMapMatcher struct{}

func (systemOrUserAssignedIdentityMapMatcher) IsMatch(field sdkModels.SDKField, resource sdkModels.APIResource) bool {
	if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
		return false
	}

	// retrieve the model from the reference
	model, ok := resource.Models[*field.ObjectDefinition.ReferenceName]
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
			if fieldVal.ObjectDefinition.Type != sdkModels.DictionarySDKObjectDefinitionType {
				continue
			}
			if fieldVal.ObjectDefinition.NestedItem == nil || fieldVal.ObjectDefinition.NestedItem.Type != sdkModels.ReferenceSDKObjectDefinitionType {
				continue
			}

			inlinedModel, ok := resource.Models[*fieldVal.ObjectDefinition.NestedItem.ReferenceName]
			if !ok {
				continue
			}

			innerHasClientId := false
			innerHasPrincipalId := false
			for innerName, innerVal := range inlinedModel.Fields {
				if strings.EqualFold(innerName, "ClientId") {
					if innerVal.ObjectDefinition.Type != sdkModels.StringSDKObjectDefinitionType {
						continue
					}

					innerHasClientId = true
					continue
				}

				if strings.EqualFold(innerName, "PrincipalId") {
					if innerVal.ObjectDefinition.Type != sdkModels.StringSDKObjectDefinitionType {
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
			if fieldVal.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
				continue
			}
			constant, ok := resource.Constants[*fieldVal.ObjectDefinition.ReferenceName]
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

func (systemOrUserAssignedIdentityMapMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
	}
}
