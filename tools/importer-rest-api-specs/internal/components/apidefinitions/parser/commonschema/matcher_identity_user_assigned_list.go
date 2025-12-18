// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = userAssignedIdentityListMatcher{}

type userAssignedIdentityListMatcher struct{}

func (userAssignedIdentityListMatcher) IsMatch(field sdkModels.SDKField, resource sdkModels.APIResource) bool {
	if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
		return false
	}

	// retrieve the model from the reference
	model, ok := resource.Models[*field.ObjectDefinition.ReferenceName]
	if !ok {
		return false
	}

	hasUserAssignedIdentities := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "UserAssignedIdentities") {
			// this should be a List of Strings
			if fieldVal.ObjectDefinition.Type != sdkModels.ListSDKObjectDefinitionType {
				continue
			}
			if fieldVal.ObjectDefinition.NestedItem == nil || fieldVal.ObjectDefinition.NestedItem.Type != sdkModels.StringSDKObjectDefinitionType {
				continue
			}

			hasUserAssignedIdentities = true
			continue
		}

		// Type is an optional check due to some badly defined Swaggers
		// https://github.com/Azure/azure-rest-api-specs/blob/c803720c6bcfcb0fcf4c97f3463ec33a18f9e55c/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabricManagedClusters/stable/2021-05-01/nodetype.json#L763
		// as such we're only concerned if it's defined and doesn't match
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
			if !validateIdentityConstantValues(constant, expected) {
				return false
			}
			continue
		}

		// other fields
		return false
	}

	return hasUserAssignedIdentities
}

func (userAssignedIdentityListMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.UserAssignedIdentityListSDKObjectDefinitionType,
	}
}
