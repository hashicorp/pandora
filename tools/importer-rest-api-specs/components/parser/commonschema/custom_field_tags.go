// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = tagsMatcher{}

type tagsMatcher struct{}

func (tagsMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.TagsSDKObjectDefinitionType,
	}
}

func (tagsMatcher) IsMatch(field sdkModels.SDKField, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "tags")
	typeMatches := field.ObjectDefinition.Type == sdkModels.DictionarySDKObjectDefinitionType && field.ObjectDefinition.NestedItem.Type == sdkModels.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}
