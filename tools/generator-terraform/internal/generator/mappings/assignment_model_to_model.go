// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ assignmentType = modelToModelAssignmentLine{}

type modelToModelAssignmentLine struct {
}

func (m modelToModelAssignmentLine) assignmentForCreateUpdateMapping(mapping models.TerraformFieldMappingDefinition, _ models.TerraformSchemaModel, sdkModel models.SDKModel, _ *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	modelToModel, ok := mapping.(models.TerraformModelToModelFieldMappingDefinition)
	if !ok {
		return nil, fmt.Errorf("internal-error: expected a ModelToModel mapping but got %+v", mapping)
	}

	sdkField, ok := sdkModel.Fields[modelToModel.ModelToModel.SDKFieldName]
	if !ok {
		return nil, fmt.Errorf("couldn't find SDK Field %q in Model %q", modelToModel.ModelToModel.SDKFieldName, modelToModel.ModelToModel.SDKModelName)
	}
	if sdkField.ObjectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
		return nil, fmt.Errorf("a ModelToModel mapping must be a Reference but got %q", string(sdkField.ObjectDefinition.Type))
	}
	outputModelName := *sdkField.ObjectDefinition.ReferenceName
	sdkFieldType, err := helpers.GolangTypeForSDKObjectDefinition(sdkField.ObjectDefinition, &apiResourcePackageName, nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type Name for SDK Field: %+v", err)
	}

	// the variable `output` is a pointer here, so we don't need to pass it by reference
	output := fmt.Sprintf(`
		if err := r.map%[1]sTo%[2]s(input, &output.%[3]s); err != nil {
			return fmt.Errorf("mapping Schema to SDK Field %%q / Model %%q: %%+v", %[2]q, %[3]q, err)
		}
`, modelToModel.ModelToModel.TerraformSchemaModelName, outputModelName, modelToModel.ModelToModel.SDKFieldName)
	if sdkField.Optional {
		output = fmt.Sprintf(`
		if output.%[3]s == nil {
			output.%[3]s = &%[4]s{}
		}
		if err := r.map%[1]sTo%[2]s(input, output.%[3]s); err != nil {
			return fmt.Errorf("mapping Schema to SDK Field %%q / Model %%q: %%+v", %[2]q, %[3]q, err)
		}
`, modelToModel.ModelToModel.TerraformSchemaModelName, outputModelName, modelToModel.ModelToModel.SDKFieldName, *sdkFieldType)
	}
	return &output, nil
}

func (m modelToModelAssignmentLine) assignmentForReadMapping(mapping models.TerraformFieldMappingDefinition, schemaModel models.TerraformSchemaModel, sdkModel models.SDKModel, sdkConstant *assignmentConstantDetails, apiResourcePackageName string) (*string, error) {
	modelToModel, ok := mapping.(models.TerraformModelToModelFieldMappingDefinition)
	if !ok {
		return nil, fmt.Errorf("internal-error: expected a ModelToModel mapping but got %+v", mapping)
	}

	sdkField, ok := sdkModel.Fields[modelToModel.ModelToModel.SDKFieldName]
	if !ok {
		return nil, fmt.Errorf("couldn't find SDK Field %q in Model %q", modelToModel.ModelToModel.SDKFieldName, modelToModel.ModelToModel.SDKModelName)
	}
	if sdkField.ObjectDefinition.Type != models.ReferenceSDKObjectDefinitionType {
		return nil, fmt.Errorf("a ModelToModel mapping must be a Reference but got %q", string(sdkField.ObjectDefinition.Type))
	}

	outputModelName := *sdkField.ObjectDefinition.ReferenceName
	sdkFieldType, err := helpers.GolangTypeForSDKObjectDefinition(sdkField.ObjectDefinition, &apiResourcePackageName, nil)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type Name for SDK Field: %+v", err)
	}

	// the variable `output` is a pointer here, so we don't need to pass it by reference
	output := fmt.Sprintf(`
		if err := r.map%[2]sTo%[1]s(input.%[3]s, output); err != nil {
			return fmt.Errorf("mapping SDK Field %%q / Model %%q to Schema: %%+v", %[2]q, %[3]q, err)
		}
`, modelToModel.ModelToModel.TerraformSchemaModelName, outputModelName, modelToModel.ModelToModel.SDKFieldName)

	if sdkField.Optional {
		output = fmt.Sprintf(`
		if input.%[3]s == nil {
			input.%[3]s = &%[4]s{}
		}
		if err := r.map%[2]sTo%[1]s(*input.%[3]s, output); err != nil {
			return fmt.Errorf("mapping SDK Field %%q / Model %%q to Schema: %%+v", %[2]q, %[3]q, err)
		}
`, modelToModel.ModelToModel.TerraformSchemaModelName, outputModelName, modelToModel.ModelToModel.SDKFieldName, *sdkFieldType)
	}
	return &output, nil
}
