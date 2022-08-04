package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func flattenAssignmentCodeForField(assignmentVariable string, schemaFieldName string, field resourcemanager.TerraformSchemaFieldDefinition, currentModel resourcemanager.ModelDetails, models map[string]resourcemanager.ModelDetails) (*string, error) {
	// if it's a nested mapping (e.g. `Properties.Foo`) we need to pass `Properties` to
	// the flatten function, which in turn needs to check if `Foo` is nil (and return
	// whatever it needs too)
	topLevelFieldMapping := *field.Mappings.SdkPathForRead
	if strings.Contains(topLevelFieldMapping, ".") {
		split := strings.Split(topLevelFieldMapping, ".")
		topLevelFieldMapping = split[0]

		// TODO: generate that method which needs to split/nil-check on
		// remainingMapping := strings.Join(split[1:], ".")

		assignmentCode := fmt.Sprintf("r.flatten%[1]s(model.%[2]s)", schemaFieldName, topLevelFieldMapping)
		output := fmt.Sprintf("%s = %s", assignmentVariable, assignmentCode)
		return &output, nil
	}

	assignmentCode, err := flattenAssignmentCodeForFieldObjectDefinition(fmt.Sprintf("model.%[1]s", topLevelFieldMapping), field.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("building flatten assignment code for top level field %q: %+v", topLevelFieldMapping, err)
	}

	output := fmt.Sprintf("%s = %s", assignmentVariable, *assignmentCode)
	return &output, nil
}

func flattenAssignmentCodeForFieldObjectDefinition(mapping string, objectDefinition resourcemanager.TerraformSchemaFieldObjectDefinition) (*string, error) {
	directAssignments := map[resourcemanager.TerraformSchemaFieldType]struct{}{
		resourcemanager.TerraformSchemaFieldTypeBoolean:  {},
		resourcemanager.TerraformSchemaFieldTypeDateTime: {}, // TODO: confirm
		resourcemanager.TerraformSchemaFieldTypeInteger:  {},
		resourcemanager.TerraformSchemaFieldTypeFloat:    {},
		resourcemanager.TerraformSchemaFieldTypeString:   {},
	}
	if _, ok := directAssignments[objectDefinition.Type]; ok {
		// TODO: if the field is optional, conditionally output this as a pointer
		return &mapping, nil
	}

	switch objectDefinition.Type {
	case resourcemanager.TerraformSchemaFieldTypeLocation:
		{
			// TODO: find the field in the response and confirm if we need to call NormalizeNilable
			output := fmt.Sprintf("location.Normalize(%s)", mapping)
			return &output, nil
		}
	case resourcemanager.TerraformSchemaFieldTypeTags:
		{
			output := fmt.Sprintf("tags.Flatten(%s)", mapping)
			return &output, nil
		}
	}
	return nil, fmt.Errorf("internal-error: unimplemented field type %q for mapping %q", string(objectDefinition.Type), mapping)
}
