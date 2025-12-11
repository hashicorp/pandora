// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import "fmt"

var _ FieldNameProcessor = fieldNameExists{}

type fieldNameExists struct{}

func (fieldNameExists) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	_, ok := metadata.Model.Fields[fieldName]
	if !ok {
		return nil, fmt.Errorf("%s was not found in %+v", fieldName, metadata.Model.Fields)
	}
	return nil, nil
}
