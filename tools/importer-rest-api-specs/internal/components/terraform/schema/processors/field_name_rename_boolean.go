// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ FieldNameProcessor = fieldNameRenameBoolean{}

type fieldNameRenameBoolean struct{}

func (fieldNameRenameBoolean) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == models.BooleanSDKObjectDefinitionType {
		// change the Prefix -> Suffix
		// NOTE: ordering matters due to `enabled` getting trimmed to `ed` if `enable` is trimmed before `enabled`
		if strings.HasPrefix(strings.ToLower(fieldName), "enabled") {
			updated := fmt.Sprintf("%sEnabled", fieldName[7:])
			return &updated, nil
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "enable") {
			updated := fmt.Sprintf("%sEnabled", fieldName[6:])
			return &updated, nil
		}

		if strings.HasPrefix(strings.ToLower(fieldName), "disabled") {
			updated := fmt.Sprintf("%sDisabled", fieldName[7:])
			return &updated, nil
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "disable") {
			updated := fmt.Sprintf("%sDisabled", fieldName[7:])
			return &updated, nil
		}

		if strings.HasPrefix(strings.ToLower(fieldName), "allowed") {
			updated := fmt.Sprintf("%sEnabled", fieldName[7:])
			return &updated, nil
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "allow") {
			updated := fmt.Sprintf("%sEnabled", fieldName[5:])
			return &updated, nil
		}
	}
	return nil, nil
}
