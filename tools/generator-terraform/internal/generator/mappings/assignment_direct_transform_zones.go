// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ directAssignmentTransform = directAssignmentTransformZones{}

type directAssignmentTransformZones struct {
}

func (d directAssignmentTransformZones) schemaFieldType() models.TerraformSchemaObjectDefinitionType {
	return models.ZonesTerraformSchemaObjectDefinitionType
}

func (d directAssignmentTransformZones) sdkFieldType() models.SDKObjectDefinitionType {
	return models.ZonesSDKObjectDefinitionType
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
