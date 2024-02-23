// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = tagsMatcher{}

type tagsMatcher struct{}

func (tagsMatcher) ReplacementObjectDefinition() models.SDKObjectDefinition {
	return models.SDKObjectDefinition{
		Type: models.TagsSDKObjectDefinitionType,
	}
}

func (tagsMatcher) IsMatch(field models.SDKField, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "tags") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := field.ObjectDefinition.Type == models.DictionarySDKObjectDefinitionType && field.ObjectDefinition.NestedItem.Type == models.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}
