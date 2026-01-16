// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

// InnerMostSDKObjectDefinition returns the inner most SDKObjectDefinition.
//
// In the event of an SDKObjectDefinition with no NestedItem, the current item will be returned.
// In the event of a NestedItem being present, or a NestedItem having a NestedItem, this method
// will recurse until it finds the SDKObjectDefinition without a NestedItem.
//
// This is useful for obtaining the inner type for assignment purposes.
func InnerMostSDKObjectDefinition(input models.SDKObjectDefinition) models.SDKObjectDefinition {
	if input.NestedItem != nil {
		return InnerMostSDKObjectDefinition(*input.NestedItem)
	}

	return input
}
