// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = edgeZoneFieldMatcher{}

type edgeZoneFieldMatcher struct {
}

func (e edgeZoneFieldMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeEdgeZone
}

func (e edgeZoneFieldMatcher) IsMatch(_ models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.Models[*definition.ReferenceName]
	if !ok {
		return false
	}

	hasName := false
	hasMatchingType := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "Name") {
			hasName = true
			continue
		}

		if strings.EqualFold(fieldName, "Type") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}
			constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
			if !ok || len(constant.Values) != 1 {
				continue
			}
			for k, v := range constant.Values {
				if strings.EqualFold(k, "EdgeZone") && strings.EqualFold(v, "EdgeZone") {
					hasMatchingType = true
				}
			}
			continue
		}

		// other fields
		return false
	}

	return hasName && hasMatchingType
}
