// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKOperationOptionObjectDefinitionFromRepository(input repositoryModels.OptionObjectDefinition, knownData helpers.KnownData) (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	typeVal, ok := sdkOperationOptionsFromRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the SDKOperationOptionType %q", string(input.Type))
	}

	output := sdkModels.SDKOperationOptionObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if input.ReferenceName != nil {
		if !strings.HasPrefix(*input.ReferenceName, "odata.") {
			isConstant := knownData.ConstantExists(*input.ReferenceName)
			isModel := knownData.ModelExists(*input.ReferenceName)
			if !isConstant && !isModel {
				return nil, fmt.Errorf("the Reference %q was not found as either a Constant or a Model", *input.ReferenceName)
			}
			if isConstant && isModel {
				return nil, fmt.Errorf("the Reference %q was found as both a Constant or a Model", *input.ReferenceName)
			}
		}

		output.ReferenceName = input.ReferenceName
	}

	if input.NestedItem != nil {
		nestedItem, err := mapSDKOperationOptionObjectDefinitionFromRepository(*input.NestedItem, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping nested option object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	return &output, nil
}

func mapSDKOperationOptionObjectDefinitionToRepository(input sdkModels.SDKOperationOptionObjectDefinition, knownData helpers.KnownData) (*repositoryModels.OptionObjectDefinition, error) {
	typeVal, ok := sdkOperationOptionsToRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for the SDKOperationOptionType %q", string(input.Type))
	}

	output := repositoryModels.OptionObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if input.ReferenceName != nil {
		output.ReferenceName = input.ReferenceName
	}

	if input.NestedItem != nil {
		nestedItem, err := mapSDKOperationOptionObjectDefinitionToRepository(*input.NestedItem, knownData)
		if err != nil {
			return nil, fmt.Errorf("mapping nested option object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	// let's do some sanity-checking to ensure the data being output looks legit
	if err := validateSDKOperationOptionObjectDefinition(output, knownData); err != nil {
		return nil, fmt.Errorf("validating mapped OptionObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateSDKOperationOptionObjectDefinition(input repositoryModels.OptionObjectDefinition, knownData helpers.KnownData) error {
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

		if strings.HasPrefix(*input.ReferenceName, "odata.") {
			return nil
		}

		isConstant := knownData.ConstantExists(*input.ReferenceName)
		isModel := knownData.ModelExists(*input.ReferenceName)
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

var sdkOperationOptionsFromRepository = map[repositoryModels.OptionObjectDefinitionType]sdkModels.SDKOperationOptionObjectDefinitionType{
	repositoryModels.BooleanOptionObjectDefinitionType:   sdkModels.BooleanSDKOperationOptionObjectDefinitionType,
	repositoryModels.CsvOptionObjectDefinitionType:       sdkModels.CSVSDKOperationOptionObjectDefinitionType,
	repositoryModels.IntegerOptionObjectDefinitionType:   sdkModels.IntegerSDKOperationOptionObjectDefinitionType,
	repositoryModels.FloatOptionObjectDefinitionType:     sdkModels.FloatSDKOperationOptionObjectDefinitionType,
	repositoryModels.ListOptionObjectDefinitionType:      sdkModels.ListSDKOperationOptionObjectDefinitionType,
	repositoryModels.ReferenceOptionObjectDefinitionType: sdkModels.ReferenceSDKOperationOptionObjectDefinitionType,
	repositoryModels.StringOptionObjectDefinitionType:    sdkModels.StringSDKOperationOptionObjectDefinitionType,
}

var sdkOperationOptionsToRepository = map[sdkModels.SDKOperationOptionObjectDefinitionType]repositoryModels.OptionObjectDefinitionType{
	sdkModels.BooleanSDKOperationOptionObjectDefinitionType:   repositoryModels.BooleanOptionObjectDefinitionType,
	sdkModels.CSVSDKOperationOptionObjectDefinitionType:       repositoryModels.CsvOptionObjectDefinitionType,
	sdkModels.IntegerSDKOperationOptionObjectDefinitionType:   repositoryModels.IntegerOptionObjectDefinitionType,
	sdkModels.FloatSDKOperationOptionObjectDefinitionType:     repositoryModels.FloatOptionObjectDefinitionType,
	sdkModels.ListSDKOperationOptionObjectDefinitionType:      repositoryModels.ListOptionObjectDefinitionType,
	sdkModels.ReferenceSDKOperationOptionObjectDefinitionType: repositoryModels.ReferenceOptionObjectDefinitionType,
	sdkModels.StringSDKOperationOptionObjectDefinitionType:    repositoryModels.StringOptionObjectDefinitionType,
}
