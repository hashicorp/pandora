package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: support for SystemAndUserAssigned List

var _ directAssignmentTransform = directAssignmentTransformIdentitySystemAndUserAssignedMap{}

type directAssignmentTransformIdentitySystemAndUserAssignedMap struct {
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandSystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMap) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenSystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = *%[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}
