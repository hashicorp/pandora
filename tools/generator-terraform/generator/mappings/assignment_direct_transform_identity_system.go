// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ directAssignmentTransform = directAssignmentTransformIdentitySystemAssigned{}

type directAssignmentTransformIdentitySystemAssigned struct {
}

func (d directAssignmentTransformIdentitySystemAssigned) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned
}

func (d directAssignmentTransformIdentitySystemAssigned) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.SystemAssignedIdentityApiObjectDefinitionType
}

func (d directAssignmentTransformIdentitySystemAssigned) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAssigned) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAssignedFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAssigned) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s = identity.FlattenSystemAssignedToModel(%[2]s)
`, outputAssignment, inputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAssigned) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s = identity.FlattenSystemAssignedToModel(%[2]s)
`, outputAssignment, inputAssignment)
	}
}
