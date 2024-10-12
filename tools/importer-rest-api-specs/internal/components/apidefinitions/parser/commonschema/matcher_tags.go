// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Matcher = tagsMatcher{}

type tagsMatcher struct{}

func (tagsMatcher) IsMatch(field sdkModels.SDKField, _ sdkModels.APIResource) bool {
	nameMatches := strings.EqualFold(field.JsonName, "tags")
	typeMatches := field.ObjectDefinition.Type == sdkModels.DictionarySDKObjectDefinitionType && field.ObjectDefinition.NestedItem.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}

func (tagsMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.TagsSDKObjectDefinitionType,
	}
}
