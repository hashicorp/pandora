// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKObjectDefinitionToRepository(details sdkModels.SDKObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel, commonTypes sdkModels.CommonTypes) (*repositoryModels.ObjectDefinition, error) {
	typeVal, ok := internalObjectDefinitionsToObjectDefinitionTypes[details.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the ObjectDefinition Type %q", string(details.Type))
	}

	output := repositoryModels.ObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if details.ReferenceName != nil {
		output.ReferenceName = details.ReferenceName
	}

	if details.ReferenceNameIsCommonType != nil {
		output.ReferenceNameIsCommonType = details.ReferenceNameIsCommonType
	}

	if details.NestedItem != nil {
		nestedItem, err := mapSDKObjectDefinitionToRepository(*details.NestedItem, constants, models, commonTypes)
		if err != nil {
			return nil, fmt.Errorf("mapping nested object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	// TODO: come back to these after the SDK switch
	//if definition.Maximum != nil {
	//	output.MaxItems = definition.Maximum
	//}
	//if definition.Minimum != nil {
	//	output.MinItems = definition.Minimum
	//}
	if output.Type == repositoryModels.DateTimeObjectDefinitionType {
		// TODO: support additional types of Date Formats (#8)
		output.DateFormat = pointer.To(repositoryModels.RFC3339DateFormat)
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateObjectDefinition(output, constants, models, commonTypes); err != nil {
		return nil, fmt.Errorf("validating mapped ObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateObjectDefinition(input repositoryModels.ObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel, commonTypes sdkModels.CommonTypes) error {
	requiresNestedItem := input.Type == repositoryModels.CsvObjectDefinitionType ||
		input.Type == repositoryModels.DictionaryObjectDefinitionType ||
		input.Type == repositoryModels.ListObjectDefinitionType
	requiresReference := input.Type == repositoryModels.ReferenceObjectDefinitionType
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

		_, isLocalConstant := constants[*input.ReferenceName]
		_, isLocalModel := models[*input.ReferenceName]
		var isCommonConstant, isCommonModel bool
		if commonTypes.Constants != nil {
			_, isCommonConstant = commonTypes.Constants[*input.ReferenceName]
		}
		if commonTypes.Models != nil {
			_, isCommonModel = commonTypes.Models[*input.ReferenceName]
		}

		if input.ReferenceNameIsCommonType != nil && *input.ReferenceNameIsCommonType {
			if !isCommonConstant && !isCommonModel {
				return fmt.Errorf("reference %q was not found as a common constant or model", *input.ReferenceName)
			}
			if isCommonConstant && isCommonModel {
				return fmt.Errorf("internal-error: %q was found as BOTH a common constant and model", *input.ReferenceName)
			}
		} else {
			if !isLocalConstant && !isLocalModel {
				return fmt.Errorf("reference %q was not found as a local constant or model", *input.ReferenceName)
			}
			if isLocalConstant && isLocalModel {
				return fmt.Errorf("internal-error: %q was found as BOTH a local constant and model", *input.ReferenceName)
			}
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}

var internalObjectDefinitionsToObjectDefinitionTypes = map[sdkModels.SDKObjectDefinitionType]repositoryModels.ObjectDefinitionType{
	// Simple Types
	sdkModels.BooleanSDKObjectDefinitionType:  repositoryModels.BooleanObjectDefinitionType,
	sdkModels.DateTimeSDKObjectDefinitionType: repositoryModels.DateTimeObjectDefinitionType,
	sdkModels.IntegerSDKObjectDefinitionType:  repositoryModels.IntegerObjectDefinitionType,
	sdkModels.FloatSDKObjectDefinitionType:    repositoryModels.FloatObjectDefinitionType,
	sdkModels.StringSDKObjectDefinitionType:   repositoryModels.StringObjectDefinitionType,

	// Complex Types
	sdkModels.CSVSDKObjectDefinitionType:        repositoryModels.CsvObjectDefinitionType,
	sdkModels.DictionarySDKObjectDefinitionType: repositoryModels.DictionaryObjectDefinitionType,
	sdkModels.ListSDKObjectDefinitionType:       repositoryModels.ListObjectDefinitionType,
	sdkModels.RawFileSDKObjectDefinitionType:    repositoryModels.RawFileObjectDefinitionType,
	sdkModels.RawObjectSDKObjectDefinitionType:  repositoryModels.RawObjectObjectDefinitionType,
	sdkModels.ReferenceSDKObjectDefinitionType:  repositoryModels.ReferenceObjectDefinitionType,

	// Common Schema
	sdkModels.EdgeZoneSDKObjectDefinitionType:                                repositoryModels.EdgeZoneObjectDefinitionType,
	sdkModels.LocationSDKObjectDefinitionType:                                repositoryModels.LocationObjectDefinitionType,
	sdkModels.SystemAssignedIdentitySDKObjectDefinitionType:                  repositoryModels.SystemAssignedIdentityObjectDefinitionType,
	sdkModels.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       repositoryModels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	sdkModels.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        repositoryModels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	sdkModels.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: repositoryModels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	sdkModels.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  repositoryModels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	sdkModels.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        repositoryModels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         repositoryModels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	sdkModels.UserAssignedIdentityListSDKObjectDefinitionType:                repositoryModels.UserAssignedIdentityListObjectDefinitionType,
	sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType:                 repositoryModels.UserAssignedIdentityMapObjectDefinitionType,
	sdkModels.TagsSDKObjectDefinitionType:                                    repositoryModels.TagsObjectDefinitionType,
	sdkModels.SystemDataSDKObjectDefinitionType:                              repositoryModels.SystemDataObjectDefinitionType,
	sdkModels.ZoneSDKObjectDefinitionType:                                    repositoryModels.ZoneObjectDefinitionType,
	sdkModels.ZonesSDKObjectDefinitionType:                                   repositoryModels.ZonesObjectDefinitionType,
}
