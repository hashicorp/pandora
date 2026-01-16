// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// SDKObjectDefinitionsMatch returns whether two different SDKObjectDefinitions match.
func SDKObjectDefinitionsMatch(first models.SDKObjectDefinition, second models.SDKObjectDefinition) bool {
	if first.Type != second.Type {
		return false
	}

	if first.NestedItem != nil && second.NestedItem != nil {
		nestedMatch := SDKObjectDefinitionsMatch(*first.NestedItem, *second.NestedItem)
		if !nestedMatch {
			return false
		}
	}
	if first.NestedItem != nil && second.NestedItem == nil {
		return false
	}
	if first.NestedItem == nil && second.NestedItem != nil {
		return false
	}

	if first.ReferenceName != nil && second.ReferenceName != nil {
		if *first.ReferenceName != *second.ReferenceName {
			return false
		}
	}
	if first.ReferenceName != nil && second.ReferenceName == nil {
		return false
	}
	if first.ReferenceName == nil && second.ReferenceName != nil {
		return false
	}

	return true
}
