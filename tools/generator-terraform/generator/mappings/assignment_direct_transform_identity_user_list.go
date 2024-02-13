// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: support for User Assigned Map

var _ directAssignmentTransform = directAssignmentTransformIdentityUserAssignedList{}

type directAssignmentTransformIdentityUserAssignedList struct {
}

func (d directAssignmentTransformIdentityUserAssignedList) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned
}

func (d directAssignmentTransformIdentityUserAssignedList) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.UserAssignedIdentityListApiObjectDefinitionType
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
