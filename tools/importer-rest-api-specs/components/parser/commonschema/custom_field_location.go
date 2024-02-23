// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = locationMatcher{}

type locationMatcher struct{}

func (l locationMatcher) IsMatch(field importerModels.FieldDetails, definition importerModels.ObjectDefinition, known internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "location") && definition.Type == importerModels.ObjectDefinitionString
}

func (locationMatcher) CustomFieldType() importerModels.CustomFieldType {
	return importerModels.CustomFieldTypeLocation
}
