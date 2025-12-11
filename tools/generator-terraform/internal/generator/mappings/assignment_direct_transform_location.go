// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ directAssignmentTransform = directAssignmentTransformLocation{}

type directAssignmentTransformLocation struct {
}

func (d directAssignmentTransformLocation) schemaFieldType() models.TerraformSchemaObjectDefinitionType {
	return models.LocationTerraformSchemaObjectDefinitionType
}

func (d directAssignmentTransformLocation) sdkFieldType() models.SDKObjectDefinitionType {
	return models.LocationSDKObjectDefinitionType
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
