// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: support for SystemOrUserAssigned List

var _ directAssignmentTransform = directAssignmentTransformIdentitySystemOrUserAssignedMap{}

type directAssignmentTransformIdentitySystemOrUserAssignedMap struct {
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemOrUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemOrUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemOrUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemOrUserAssignedMap) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemOrUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemOrUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}
