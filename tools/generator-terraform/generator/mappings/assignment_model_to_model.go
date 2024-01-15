package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ assignmentType = modelToModelAssignmentLine{}

type modelToModelAssignmentLine struct {
}

func (m modelToModelAssignmentLine) assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, _ resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, _ *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if mapping.Type != resourcemanager.ModelToModelMappingDefinitionType {
		return nil, fmt.Errorf("expected a ModelToModel Mapping but got %q", string(mapping.Type))
	}

	sdkField, ok := sdkModel.Fields[mapping.ModelToModel.SdkFieldName]
	if !ok {
		return nil, fmt.Errorf("couldn't find SDK Field %q in Model %q", mapping.ModelToModel.SdkFieldName, mapping.ModelToModel.SdkModelName)
	}
	if sdkField.ObjectDefinition.Type != resourcemanager.ReferenceApiObjectDefinitionType {
		return nil, fmt.Errorf("a ModelToModel mapping must be a Reference but got %q", string(sdkField.ObjectDefinition.Type))
	}
	outputModelName := *sdkField.ObjectDefinition.ReferenceName
	sdkFieldType, err := sdkField.ObjectDefinition.GolangTypeName(&apiResourcePackageName)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type Name for SDK Field: %+v", err)
	}

	// the variable `output` is a pointer here, so we don't need to pass it by reference
	output := fmt.Sprintf(`
		if err := r.map%[1]sTo%[2]s(input, &output.%[3]s); err != nil {
			return fmt.Errorf("mapping Schema to SDK Field %%q / Model %%q: %%+v", %[2]q, %[3]q, err)
		}
`, mapping.ModelToModel.SchemaModelName, outputModelName, mapping.ModelToModel.SdkFieldName)
	if sdkField.Optional {
		output = fmt.Sprintf(`
		if output.%[3]s == nil {
			output.%[3]s = &%[4]s{}
		}
		if err := r.map%[1]sTo%[2]s(input, output.%[3]s); err != nil {
			return fmt.Errorf("mapping Schema to SDK Field %%q / Model %%q: %%+v", %[2]q, %[3]q, err)
		}
`, mapping.ModelToModel.SchemaModelName, outputModelName, mapping.ModelToModel.SdkFieldName, *sdkFieldType)
	}
	return &output, nil
}

func (m modelToModelAssignmentLine) assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	if mapping.Type != resourcemanager.ModelToModelMappingDefinitionType {
		return nil, fmt.Errorf("expected a ModelToModel Mapping but got %q", string(mapping.Type))
	}

	sdkField, ok := sdkModel.Fields[mapping.ModelToModel.SdkFieldName]
	if !ok {
		return nil, fmt.Errorf("couldn't find SDK Field %q in Model %q", mapping.ModelToModel.SdkFieldName, mapping.ModelToModel.SdkModelName)
	}
	if sdkField.ObjectDefinition.Type != resourcemanager.ReferenceApiObjectDefinitionType {
		return nil, fmt.Errorf("a ModelToModel mapping must be a Reference but got %q", string(sdkField.ObjectDefinition.Type))
	}
	outputModelName := *sdkField.ObjectDefinition.ReferenceName
	sdkFieldType, err := sdkField.ObjectDefinition.GolangTypeName(&apiResourcePackageName)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type Name for SDK Field: %+v", err)
	}

	// the variable `output` is a pointer here, so we don't need to pass it by reference
	output := fmt.Sprintf(`
		if err := r.map%[2]sTo%[1]s(input.%[3]s, output); err != nil {
			return fmt.Errorf("mapping SDK Field %%q / Model %%q to Schema: %%+v", %[2]q, %[3]q, err)
		}
`, mapping.ModelToModel.SchemaModelName, outputModelName, mapping.ModelToModel.SdkFieldName)
	if sdkField.Optional {
		output = fmt.Sprintf(`
		if input.%[3]s == nil {
			input.%[3]s = &%[4]s{}
		}
		if err := r.map%[2]sTo%[1]s(*input.%[3]s, output); err != nil {
			return fmt.Errorf("mapping SDK Field %%q / Model %%q to Schema: %%+v", %[2]q, %[3]q, err)
		}
`, mapping.ModelToModel.SchemaModelName, outputModelName, mapping.ModelToModel.SdkFieldName, *sdkFieldType)
	}
	return &output, nil
}
