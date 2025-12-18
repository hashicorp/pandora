// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = zonesFieldMatcher{}

type zonesFieldMatcher struct {
}

func (zonesFieldMatcher) IsMatch(field sdkModels.SDKField, _ sdkModels.APIResource) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZones") || strings.EqualFold(field.JsonName, "zones")
	typesMatch := field.ObjectDefinition.Type == sdkModels.ListSDKObjectDefinitionType && field.ObjectDefinition.NestedItem != nil && field.ObjectDefinition.NestedItem.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typesMatch
}

func (zonesFieldMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.ZonesSDKObjectDefinitionType,
	}
}
