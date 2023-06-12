package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ directAssignmentTransform = directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy{}

type directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy struct {
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) schemaFieldType() resourcemanager.TerraformSchemaFieldType {
	return resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) sdkFieldType() resourcemanager.ApiObjectDefinitionType {
	return resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) requiredExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandLegacySystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding Legacy SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) optionalExpandFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.ExpandLegacySystemAndUserAssignedMapFromModel(%[2]s)
	if err != nil {
		return fmt.Errorf("expanding Legacy SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) requiredFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenLegacySystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening Legacy SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}

func (d directAssignmentTransformIdentitySystemAndUserAssignedMapLegacy) optionalFlattenFuncBody() directAssignmentTransformFunc {
	return func(outputAssignment, outputVariableName, inputAssignment string) string {
		return fmt.Sprintf(`
	%[1]s, err := identity.FlattenLegacySystemAndUserAssignedMapToModel(%[2]s)
	if err != nil {
		return fmt.Errorf("flattening Legacy SystemAndUserAssigned Identity: %%+v", err)
	}
	%[3]s = %[1]s
`, outputVariableName, inputAssignment, outputAssignment)
	}
}
