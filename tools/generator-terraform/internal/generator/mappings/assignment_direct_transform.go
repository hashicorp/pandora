// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var directAssignmentTransforms = []directAssignmentTransform{
	directAssignmentTransformLocation{},
	directAssignmentTransformIdentitySystemAssigned{},
	directAssignmentTransformIdentitySystemAndUserAssignedMap{},
	directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy{},
	directAssignmentTransformIdentitySystemOrUserAssignedMap{},
	directAssignmentTransformIdentityUserAssignedList{},
	directAssignmentTransformTags{},
	directAssignmentTransformZones{},
}

type directAssignmentTransformFunc = func(outputAssignment, outputVariableName, inputAssignment string) string

type directAssignmentTransform interface {
	schemaFieldType() models.TerraformSchemaObjectDefinitionType
	sdkFieldType() models.SDKObjectDefinitionType

	requiredExpandFuncBody() directAssignmentTransformFunc
	optionalExpandFuncBody() directAssignmentTransformFunc

	requiredFlattenFuncBody() directAssignmentTransformFunc
	optionalFlattenFuncBody() directAssignmentTransformFunc
}

func findDirectAssignmentTransform(schemaFieldType models.TerraformSchemaObjectDefinitionType, sdkFieldType models.SDKObjectDefinitionType) directAssignmentTransform {
	for _, transform := range directAssignmentTransforms {
		if transform.schemaFieldType() == schemaFieldType && transform.sdkFieldType() == sdkFieldType {
			return transform
		}
	}

	return nil
}
