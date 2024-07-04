// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = zoneFieldMatcher{}

type zoneFieldMatcher struct {
}

func (zoneFieldMatcher) IsMatch(field sdkModels.SDKField, _ sdkModels.APIResource) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZone") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := field.ObjectDefinition.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}

func (zoneFieldMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.ZoneSDKObjectDefinitionType,
	}
}
