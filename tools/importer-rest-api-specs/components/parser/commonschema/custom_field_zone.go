// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = zoneFieldMatcher{}

type zoneFieldMatcher struct {
}

func (zoneFieldMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.ZoneSDKObjectDefinitionType,
	}
}

func (zoneFieldMatcher) IsMatch(field sdkModels.SDKField, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZone") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := field.ObjectDefinition.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}
