// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ directAssignmentTransform = directAssignmentTransformTags{}

type directAssignmentTransformTags struct {
}

func (d directAssignmentTransformTags) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeTags
}

func (d directAssignmentTransformTags) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.TagsApiObjectDefinitionType
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
