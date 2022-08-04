package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func expandAssignmentCodeForCreateField(assignmentVariable string, schemaFieldName string, field resourcemanager.TerraformSchemaFieldDefinition, currentModel resourcemanager.ModelDetails, models map[string]resourcemanager.ModelDetails) (*string, error) {
	// if it's a nested mapping (e.g. `Properties.Foo`) we need to pass `Properties` to
	// the expand function, which in turn needs to check if `Foo` is nil (and return
	// whatever it needs too)
	topLevelFieldMapping := *field.Mappings.SdkPathForCreate
	if strings.Contains(topLevelFieldMapping, ".") {
		split := strings.Split(topLevelFieldMapping, ".")
		topLevelFieldMapping = split[0]

		// TODO: generate that method which needs to split/nil-check on
		// remainingMapping := strings.Join(split[1:], ".")

		assignmentCode := fmt.Sprintf("r.expand%[1]s(model.%[2]s)", schemaFieldName, topLevelFieldMapping)
		output := fmt.Sprintf("// TODO: - %s = %s", assignmentVariable, assignmentCode)
		return &output, nil
	}

	assignmentCode, err := expandAssignmentCodeForFieldObjectDefinition(fmt.Sprintf("config.%[1]s", schemaFieldName), field.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("building expand assignment code for top level field %q: %+v", schemaFieldName, err)
	}

	output := fmt.Sprintf("%s = %s", assignmentVariable, *assignmentCode)
	return &output, nil
}

func expandAssignmentCodeForFieldObjectDefinition(mapping string, objectDefinition resourcemanager.TerraformSchemaFieldObjectDefinition) (*string, error) {
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
			output := fmt.Sprintf("tags.Expand(%s)", mapping)
			return &output, nil
		}
	}
	return nil, fmt.Errorf("internal-error: unimplemented field type %q for expand mapping %q", string(objectDefinition.Type), mapping)
}
