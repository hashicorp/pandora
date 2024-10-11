// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = userAssignedIdentityMapMatcher{}

type userAssignedIdentityMapMatcher struct{}

func (userAssignedIdentityMapMatcher) IsMatch(field sdkModels.SDKField, resource sdkModels.APIResource) bool {
	if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
		return false
	}

	// retrieve the model from the reference
	model, ok := resource.Models[*field.ObjectDefinition.ReferenceName]
	if !ok {
		return false
	}

	hasUserAssignedIdentities := false
	hasTypeMatch := false

	for fieldName, fieldVal := range model.Fields {
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

				// if extra fields this can't be a match
				return false
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
				"UserAssigned": "UserAssigned",
			}
			hasTypeMatch = validateIdentityConstantValues(constant, expected)
			continue
		}

		// some services expose tenant ID or/and principal ID in the definition for a user assigned identity - we should recognise it as a user assigned identity but ignore the field
		// This model exposed "tenantId": https://github.com/Azure/azure-rest-api-specs/blob/5a9afce8360020c46b38841e04179447a28118b2/specification/postgresql/resource-manager/Microsoft.DBforPostgreSQL/stable/2022-12-01/FlexibleServers.json#L812-L834
		// This model exposed both "tenantId" and "principalId": https://github.com/Azure/azure-rest-api-specs/blob/14d24d17491d8c2bde24532cb8cc2d663c0ffd9f/specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2023-05-01/amlfilesystem.json#L565
		if strings.EqualFold(fieldName, "TenantId") || strings.EqualFold(fieldName, "PrincipalId") {
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities && hasTypeMatch
}

func (userAssignedIdentityMapMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType,
	}
}
