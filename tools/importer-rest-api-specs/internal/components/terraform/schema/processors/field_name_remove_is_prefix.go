// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import "regexp"

var _ FieldNameProcessor = fieldNameRemoveIsPrefix{}

type fieldNameRemoveIsPrefix struct{}

func (fieldNameRemoveIsPrefix) ProcessField(fieldName string, _ FieldMetadata) (*string, error) {
	re := regexp.MustCompile("^Is[A-Z][a-z]*")
	if re.MatchString(fieldName) {
		updatedName := fieldName[2:]
		return &updatedName, nil
	}
	return nil, nil
}
