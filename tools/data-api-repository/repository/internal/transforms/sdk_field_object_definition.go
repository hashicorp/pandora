// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapSDKFieldObjectDefinitionFromRepository(input repositoryModels.ObjectDefinition) (*sdkModels.SDKObjectDefinition, error) {
	typeVal, ok := repositoryFromSDKObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing a mapping for the ObjectDefinitionType %q", string(input.Type))
	}
	output := sdkModels.SDKObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          typeVal,
	}

	if input.NestedItem != nil {
		nested, err := mapSDKFieldObjectDefinitionFromRepository(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item: %+v", err)
		}
		output.NestedItem = nested
	}
	return &output, nil
}

func mapSDKFieldObjectDefinitionToRepository(input sdkModels.SDKObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel) (*repositoryModels.ObjectDefinition, error) {
	typeVal, ok := repositoryToSDKObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing a mapping for the ObjectDefinitionType %q", string(input.Type))
	}

	output := repositoryModels.ObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if input.ReferenceName != nil {
		output.ReferenceName = input.ReferenceName
	}

	if input.NestedItem != nil {
		nestedItem, err := mapSDKFieldObjectDefinitionToRepository(*input.NestedItem, constants, models)
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
	if err := validateObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped ObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateObjectDefinition(input repositoryModels.ObjectDefinition, constants map[string]sdkModels.SDKConstant, models map[string]sdkModels.SDKModel) error {
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

var repositoryFromSDKObjectDefinitionTypes = map[repositoryModels.ObjectDefinitionType]sdkModels.SDKObjectDefinitionType{
	// Simple Types
	repositoryModels.BooleanObjectDefinitionType:  sdkModels.BooleanSDKObjectDefinitionType,
	repositoryModels.DateTimeObjectDefinitionType: sdkModels.DateTimeSDKObjectDefinitionType,
	repositoryModels.IntegerObjectDefinitionType:  sdkModels.IntegerSDKObjectDefinitionType,
	repositoryModels.FloatObjectDefinitionType:    sdkModels.FloatSDKObjectDefinitionType,
	repositoryModels.StringObjectDefinitionType:   sdkModels.StringSDKObjectDefinitionType,

	// Complex Types
	repositoryModels.CsvObjectDefinitionType:        sdkModels.CSVSDKObjectDefinitionType,
	repositoryModels.DictionaryObjectDefinitionType: sdkModels.DictionarySDKObjectDefinitionType,
	repositoryModels.ListObjectDefinitionType:       sdkModels.ListSDKObjectDefinitionType,
	repositoryModels.RawFileObjectDefinitionType:    sdkModels.RawFileSDKObjectDefinitionType,
	repositoryModels.RawObjectObjectDefinitionType:  sdkModels.RawObjectSDKObjectDefinitionType,
	repositoryModels.ReferenceObjectDefinitionType:  sdkModels.ReferenceSDKObjectDefinitionType,

	// Common Schema
	repositoryModels.EdgeZoneObjectDefinitionType:                                sdkModels.EdgeZoneSDKObjectDefinitionType,
	repositoryModels.LocationObjectDefinitionType:                                sdkModels.LocationSDKObjectDefinitionType,
	repositoryModels.SystemAssignedIdentityObjectDefinitionType:                  sdkModels.SystemAssignedIdentitySDKObjectDefinitionType,
	repositoryModels.SystemAndUserAssignedIdentityListObjectDefinitionType:       sdkModels.SystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	repositoryModels.SystemAndUserAssignedIdentityMapObjectDefinitionType:        sdkModels.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	repositoryModels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: sdkModels.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	repositoryModels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  sdkModels.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	repositoryModels.SystemOrUserAssignedIdentityListObjectDefinitionType:        sdkModels.SystemOrUserAssignedIdentityListSDKObjectDefinitionType,
	repositoryModels.SystemOrUserAssignedIdentityMapObjectDefinitionType:         sdkModels.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
	repositoryModels.UserAssignedIdentityListObjectDefinitionType:                sdkModels.UserAssignedIdentityListSDKObjectDefinitionType,
	repositoryModels.UserAssignedIdentityMapObjectDefinitionType:                 sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType,
	repositoryModels.TagsObjectDefinitionType:                                    sdkModels.TagsSDKObjectDefinitionType,
	repositoryModels.SystemDataObjectDefinitionType:                              sdkModels.SystemDataSDKObjectDefinitionType,
	repositoryModels.ZoneObjectDefinitionType:                                    sdkModels.ZoneSDKObjectDefinitionType,
	repositoryModels.ZonesObjectDefinitionType:                                   sdkModels.ZonesSDKObjectDefinitionType,
}

var repositoryToSDKObjectDefinitionTypes = map[sdkModels.SDKObjectDefinitionType]repositoryModels.ObjectDefinitionType{
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
