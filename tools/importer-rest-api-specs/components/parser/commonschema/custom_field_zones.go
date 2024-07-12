// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = zonesFieldMatcher{}

type zonesFieldMatcher struct {
}

func (zonesFieldMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.ZonesSDKObjectDefinitionType,
	}
}

func (zonesFieldMatcher) IsMatch(field sdkModels.SDKField, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZones") || strings.EqualFold(field.JsonName, "zones")
	typesMatch := field.ObjectDefinition.Type == sdkModels.ListSDKObjectDefinitionType && field.ObjectDefinition.NestedItem != nil && field.ObjectDefinition.NestedItem.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typesMatch
}
