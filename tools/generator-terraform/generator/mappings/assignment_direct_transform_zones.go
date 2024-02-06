// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ directAssignmentTransform = directAssignmentTransformZones{}

type directAssignmentTransformZones struct {
}

func (d directAssignmentTransformZones) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeZones
}

func (d directAssignmentTransformZones) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.ZonesApiObjectDefinitionType
}

func (d directAssignmentTransformZones) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = zones.Expand(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformZones) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = pointer.To(zones.Expand(%s))", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformZones) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = zones.Flatten(%s)", outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformZones) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf("%s = zones.Flatten(%s)", outputAssignment, inputAssignment)
	}
}
