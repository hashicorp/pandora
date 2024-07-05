// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

var _ FieldNameProcessor = fieldNamePluralToSingular{}

type fieldNamePluralToSingular struct{}

func (fieldNamePluralToSingular) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
		// do not singularize the field name if nested object is a basic/primitive type
		// TODO extend for other base types
		if metadata.Model.Fields[fieldName].ObjectDefinition.NestedItem.Type != models.StringSDKObjectDefinitionType {
			updatedName := cleanup.GetSingular(fieldName)
			return &updatedName, nil
		}
	}

	return nil, nil
}
