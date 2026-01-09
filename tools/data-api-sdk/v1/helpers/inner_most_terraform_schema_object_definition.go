// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package helpers

//

import "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

// InnerMostTerraformSchemaObjectDefinition returns the inner most TerraformSchemaObjectDefinition.
//
// In the event of a TerraformSchemaObjectDefinition with no NestedObject, the current item will be returned.
// In the event of a NestedObject being present, or a NestedItem having a NestedObject, this method
// will recurse until it finds the TerraformSchemaObjectDefinition without a NestedObject.
//
// This is useful for obtaining the inner type for assignment purposes.
func InnerMostTerraformSchemaObjectDefinition(input models.TerraformSchemaObjectDefinition) models.TerraformSchemaObjectDefinition {
	if input.NestedObject != nil {
		return InnerMostTerraformSchemaObjectDefinition(*input.NestedObject)
	}

	return input
}
