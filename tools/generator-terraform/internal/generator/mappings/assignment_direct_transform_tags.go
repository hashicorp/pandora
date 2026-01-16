// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ directAssignmentTransform = directAssignmentTransformTags{}

type directAssignmentTransformTags struct {
}

func (d directAssignmentTransformTags) schemaFieldType() models.TerraformSchemaObjectDefinitionType {
	return models.TagsTerraformSchemaObjectDefinitionType
}

func (d directAssignmentTransformTags) sdkFieldType() models.SDKObjectDefinitionType {
	return models.TagsSDKObjectDefinitionType
}

func (d directAssignmentTransformTags) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Expand(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformTags) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Expand(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformTags) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Flatten(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformTags) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = tags.Flatten(%s)", outputAssignment, inputAssignment)
	}
}
