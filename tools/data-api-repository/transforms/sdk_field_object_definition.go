// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapSDKObjectDefinitionToRepository(details models.SDKObjectDefinition, constants map[string]models.SDKConstant, models map[string]models.SDKModel) (*dataapimodels.ObjectDefinition, error) {
	typeVal, ok := internalObjectDefinitionsToObjectDefinitionTypes[details.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the ObjectDefinition Type %q", string(details.Type))
	}

	output := dataapimodels.ObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if details.ReferenceName != nil {
		output.ReferenceName = details.ReferenceName
	}

	if details.NestedItem != nil {
		nestedItem, err := mapSDKObjectDefinitionToRepository(*details.NestedItem, constants, models)
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
	if output.Type == dataapimodels.DateTimeObjectDefinitionType {
		// TODO: support additional types of Date Formats (#8)
		output.DateFormat = pointer.To(dataapimodels.RFC3339DateFormat)
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped ObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateObjectDefinition(input dataapimodels.ObjectDefinition, constants map[string]models.SDKConstant, models map[string]models.SDKModel) error {
	requiresNestedItem := input.Type == dataapimodels.CsvObjectDefinitionType ||
		input.Type == dataapimodels.DictionaryObjectDefinitionType ||
		input.Type == dataapimodels.ListObjectDefinitionType
	requiresReference := input.Type == dataapimodels.ReferenceObjectDefinitionType
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

var internalObjectDefinitionsToObjectDefinitionTypes = map[models.SDKObjectDefinitionType]dataapimodels.ObjectDefinitionType{
	// Simple Types
	models.BooleanSDKObjectDefinitionType:  dataapimodels.BooleanObjectDefinitionType,
	models.DateTimeSDKObjectDefinitionType: dataapimodels.DateTimeObjectDefinitionType,
	models.IntegerSDKObjectDefinitionType:  dataapimodels.IntegerObjectDefinitionType,
	models.FloatSDKObjectDefinitionType:    dataapimodels.FloatObjectDefinitionType,
	models.StringSDKObjectDefinitionType:   dataapimodels.StringObjectDefinitionType,

	// Complex Types
	models.CSVSDKObjectDefinitionType:        dataapimodels.CsvObjectDefinitionType,
	models.DictionarySDKObjectDefinitionType: dataapimodels.DictionaryObjectDefinitionType,
	models.ListSDKObjectDefinitionType:       dataapimodels.ListObjectDefinitionType,
	models.RawFileSDKObjectDefinitionType:    dataapimodels.RawFileObjectDefinitionType,
	models.RawObjectSDKObjectDefinitionType:  dataapimodels.RawObjectObjectDefinitionType,
	models.ReferenceSDKObjectDefinitionType:  dataapimodels.ReferenceObjectDefinitionType,

	// Common Schema
	models.EdgeZoneSDKObjectDefinitionType:                                dataapimodels.EdgeZoneObjectDefinitionType,
	models.LocationSDKObjectDefinitionType:                                dataapimodels.LocationObjectDefinitionType,
	models.SystemAssignedIdentitySDKObjectDefinitionType:                  dataapimodels.SystemAssignedIdentityObjectDefinitionType,
	models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	models.UserAssignedIdentityListSDKObjectDefinitionType:                dataapimodels.UserAssignedIdentityListObjectDefinitionType,
	models.UserAssignedIdentityMapSDKObjectDefinitionType:                 dataapimodels.UserAssignedIdentityMapObjectDefinitionType,
	models.TagsSDKObjectDefinitionType:                                    dataapimodels.TagsObjectDefinitionType,
	models.SystemDataSDKObjectDefinitionType:                              dataapimodels.SystemDataObjectDefinitionType,
	models.ZoneSDKObjectDefinitionType:                                    dataapimodels.ZoneObjectDefinitionType,
	models.ZonesSDKObjectDefinitionType:                                   dataapimodels.ZonesObjectDefinitionType,
}
