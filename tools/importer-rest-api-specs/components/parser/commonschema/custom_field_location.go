// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = locationMatcher{}

type locationMatcher struct{}

func (l locationMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.LocationSDKObjectDefinitionType,
	}
}

func (l locationMatcher) IsMatch(field sdkModels.SDKField, _ internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "location") && field.ObjectDefinition.Type == sdkModels.StringSDKObjectDefinitionType
}
