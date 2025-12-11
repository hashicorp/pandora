// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

// InnerMostSDKOperationOptionObjectDefinition returns the inner most SDKOperationOptionObjectDefinition.
//
// In the event of an SDKOperationOptionObjectDefinition with no NestedItem, the current item will be returned.
// In the event of a NestedItem being present, or a NestedItem having a NestedItem, this method
// will recurse until it finds the SDKOperationOptionObjectDefinition without a NestedItem.
//
// This is useful for obtaining the inner type for assignment purposes.
func InnerMostSDKOperationOptionObjectDefinition(input models.SDKOperationOptionObjectDefinition) models.SDKOperationOptionObjectDefinition {
	if input.NestedItem != nil {
		return InnerMostSDKOperationOptionObjectDefinition(*input.NestedItem)
	}

	return input
}
