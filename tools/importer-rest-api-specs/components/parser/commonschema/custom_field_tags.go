// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = tagsMatcher{}

type tagsMatcher struct{}

func (tagsMatcher) IsMatch(field importerModels.FieldDetails, definition importerModels.ObjectDefinition, known internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "tags") && definition.Type == importerModels.ObjectDefinitionDictionary && definition.NestedItem.Type == importerModels.ObjectDefinitionString
}

func (tagsMatcher) CustomFieldType() importerModels.CustomFieldType {
	return importerModels.CustomFieldTypeTags
}
