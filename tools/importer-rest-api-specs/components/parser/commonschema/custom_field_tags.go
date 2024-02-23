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

func (tagsMatcher) IsMatch(field models.SDKField, definition models.SDKObjectDefinition, known internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "tags") && definition.Type == models.DictionarySDKObjectDefinitionType && definition.NestedItem.Type == models.StringSDKObjectDefinitionType
}
