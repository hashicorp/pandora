// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = locationMatcher{}

type locationMatcher struct{}

func (locationMatcher) IsMatch(field sdkModels.SDKField, _ sdkModels.APIResource) bool {
	return strings.EqualFold(field.JsonName, "location") && field.ObjectDefinition.Type == sdkModels.StringSDKObjectDefinitionType
}

func (locationMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.LocationSDKObjectDefinitionType,
	}
}
