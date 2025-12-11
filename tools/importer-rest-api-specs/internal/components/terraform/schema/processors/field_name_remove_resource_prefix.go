// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"strings"
)

var _ FieldNameProcessor = fieldNameRemoveResourcePrefix{}

type fieldNameRemoveResourcePrefix struct{}

func (fieldNameRemoveResourcePrefix) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if strings.HasPrefix(fieldName, metadata.TerraformDetails.ResourceName) {
		updatedName := strings.Replace(fieldName, metadata.TerraformDetails.ResourceName, "", 1)

		// However `Uri` is not a great name for the field, and whilst `DataPlaneUri` or `ServiceUri`
		// could make sense, this can create inconsistencies within the Service Package with different
		// resources exposing different names for attributes - as such there we use the original name.
		if strings.EqualFold(updatedName, "Uri") {
			return nil, nil
		}

		return &updatedName, nil
	}
	return nil, nil
}
