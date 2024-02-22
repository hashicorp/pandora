// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = zonesFieldMatcher{}

type zonesFieldMatcher struct {
}

func (e zonesFieldMatcher) CustomFieldType() importerModels.CustomFieldType {
	return importerModels.CustomFieldTypeZones
}

func (e zonesFieldMatcher) IsMatch(field importerModels.FieldDetails, definition importerModels.ObjectDefinition, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZones") || strings.EqualFold(field.JsonName, "zones")
	typesMatch := definition.Type == importerModels.ObjectDefinitionList && definition.NestedItem != nil && definition.NestedItem.Type == importerModels.ObjectDefinitionString
	return nameMatches && typesMatch
}
