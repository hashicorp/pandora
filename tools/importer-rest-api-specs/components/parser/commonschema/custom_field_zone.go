// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = zoneFieldMatcher{}

type zoneFieldMatcher struct {
}

func (e zoneFieldMatcher) CustomFieldType() importerModels.CustomFieldType {
	return importerModels.CustomFieldTypeZone
}

func (e zoneFieldMatcher) IsMatch(field importerModels.FieldDetails, definition importerModels.ObjectDefinition, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZone") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := definition.Type == importerModels.ObjectDefinitionString
	return nameMatches && typeMatches
}
