// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ directAssignmentTransform = directAssignmentTransformLocation{}

type directAssignmentTransformLocation struct {
}

func (d directAssignmentTransformLocation) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeLocation
}

func (d directAssignmentTransformLocation) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.LocationApiObjectDefinitionType
}

func (d directAssignmentTransformLocation) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.Normalize(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformLocation) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = pointer.To(location.Normalize(%s))", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformLocation) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.Normalize(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformLocation) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = location.NormalizeNilable(%s)", outputAssignment, inputAssignment)
	}
}
