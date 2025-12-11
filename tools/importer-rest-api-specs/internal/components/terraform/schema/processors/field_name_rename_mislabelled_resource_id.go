// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ FieldNameProcessor = fieldNameRenameMislabelledResourceID{}

// The field `ResourceID` with `Type` in the same model containing a `Type` field with the value `UserAssigned` should
// get renamed to `UserAssignedIdentityId`

type fieldNameRenameMislabelledResourceID struct{}

func (f fieldNameRenameMislabelledResourceID) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if !strings.EqualFold(fieldName, "ResourceId") || len(metadata.Model.Fields) != 2 {
		return nil, nil
	}
	// do we have another field here called Type, and is it either a String or a Constant containing the value?
	typeField, exists := metadata.Model.Fields["Type"]
	if !exists {
		return nil, nil
	}

	typeMatches := false
	// either it's a String value
	if typeField.ObjectDefinition.Type == models.StringSDKObjectDefinitionType {
		typeMatches = true
	}
	// or it's a Constant which contains the value `UserAssigned`
	if typeField.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
		constant, exists := metadata.Constants[*typeField.ObjectDefinition.ReferenceName]
		if exists {
			for _, val := range constant.Values {
				if strings.EqualFold(val, "UserAssigned") {
					typeMatches = true
					break
				}
			}
		}
	}
	if !typeMatches {
		return nil, nil
	}

	newName := "UserAssignedIdentityId"
	return &newName, nil
}
