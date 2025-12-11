// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: support for User Assigned Map

var _ directAssignmentTransform = directAssignmentTransformIdentityUserAssignedList{}

type directAssignmentTransformIdentityUserAssignedList struct {
}

func (d directAssignmentTransformIdentityUserAssignedList) schemaFieldType() models.TerraformSchemaObjectDefinitionType {
	return models.UserAssignedIdentityTerraformSchemaObjectDefinitionType
}

func (d directAssignmentTransformIdentityUserAssignedList) sdkFieldType() models.SDKObjectDefinitionType {
	return models.UserAssignedIdentityListSDKObjectDefinitionType
}

func (d directAssignmentTransformIdentityUserAssignedList) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandUserAssignedListFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentityUserAssignedList) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandUserAssignedListFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentityUserAssignedList) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenUserAssignedListToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentityUserAssignedList) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenUserAssignedListToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening UserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}
