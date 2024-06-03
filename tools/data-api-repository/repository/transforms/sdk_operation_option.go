// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var sdkOperationOptionsToRepository = map[sdkModels.SDKOperationOptionObjectDefinitionType]repositoryModels.OptionObjectDefinitionType{
	sdkModels.BooleanSDKOperationOptionObjectDefinitionType:   repositoryModels.BooleanOptionObjectDefinitionType,
	sdkModels.CSVSDKOperationOptionObjectDefinitionType:       repositoryModels.CsvOptionObjectDefinitionType,
	sdkModels.IntegerSDKOperationOptionObjectDefinitionType:   repositoryModels.IntegerOptionObjectDefinitionType,
	sdkModels.FloatSDKOperationOptionObjectDefinitionType:     repositoryModels.FloatOptionObjectDefinitionType,
	sdkModels.ListSDKOperationOptionObjectDefinitionType:      repositoryModels.ListOptionObjectDefinitionType,
	sdkModels.ReferenceSDKOperationOptionObjectDefinitionType: repositoryModels.ReferenceOptionObjectDefinitionType,
	sdkModels.StringSDKOperationOptionObjectDefinitionType:    repositoryModels.StringOptionObjectDefinitionType,
}

func mapSDKOperationOptionToRepository(definition sdkModels.SDKOperationOptionObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel) (*repositoryModels.OptionObjectDefinition, error) {
	typeVal, ok := sdkOperationOptionsToRepository[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no OptionObjectDefinition mapping is defined for the OptionObjectDefinition Type %q", string(definition.Type))
	}

	output := repositoryModels.OptionObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if definition.ReferenceName != nil {
		output.ReferenceName = definition.ReferenceName
	}

	if definition.NestedItem != nil {
		nestedItem, err := mapSDKOperationOptionToRepository(*definition.NestedItem, constants, models)
		if err != nil {
			return nil, fmt.Errorf("mapping nested option object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateSDKOperationOptionObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped OptionObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateSDKOperationOptionObjectDefinition(input repositoryModels.OptionObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel) error {
	requiresNestedItem := input.Type == repositoryModels.CsvOptionObjectDefinitionType || input.Type == repositoryModels.ListOptionObjectDefinitionType
	requiresReference := input.Type == repositoryModels.ReferenceOptionObjectDefinitionType
	if requiresNestedItem && input.NestedItem == nil {
		return fmt.Errorf("a Nested Object Definition must be specified for a %q type but didn't get one", string(input.Type))
	}
	if !requiresNestedItem && input.NestedItem != nil {
		return fmt.Errorf("a Nested Object Definition must not be specified for a %q type but got %q", string(input.Type), string(input.NestedItem.Type))
	}
	if requiresReference {
		if input.ReferenceName == nil {
			return fmt.Errorf("a Reference must be specified for a %q type but didn't get one", string(input.Type))
		}

		_, isConstant := constants[*input.ReferenceName]
		_, isModel := models[*input.ReferenceName]
		if !isConstant && !isModel {
			return fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
		}
		if isConstant && isModel {
			return fmt.Errorf("internal-error: %q was found as BOTH a Constant and a Model", *input.ReferenceName)
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}
