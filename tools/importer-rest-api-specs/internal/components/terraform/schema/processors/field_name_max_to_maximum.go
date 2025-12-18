// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"fmt"
	"strings"
	"unicode"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
)

var _ FieldNameProcessor = fieldNameMaxToMaximum{}

type fieldNameMaxToMaximum struct{}

func (fieldNameMaxToMaximum) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if strings.HasPrefix(strings.ToLower(fieldName), "max") {
		// if this is the literal value `Max`
		if strings.EqualFold(fieldName, "max") {
			return pointer.To("Maximum"), nil
		}

		// at this point the word must be longer than 3 words, so we can safely trim it
		trimmedValue := fieldName[3:]
		firstChar := trimmedValue[0]
		if !unicode.IsUpper(rune(firstChar)) {
			return nil, nil
		}

		// If this was `Max{Something}` (being another word) then we should swap this out:
		trimmedValue = fmt.Sprintf("Maximum%s", trimmedValue)
		return pointer.To(trimmedValue), nil
	}

	return nil, nil
}
