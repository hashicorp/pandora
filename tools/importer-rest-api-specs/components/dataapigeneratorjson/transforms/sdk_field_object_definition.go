// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapSDKObjectDefinitionToRepository(details resourcemanager.ApiObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails) (*dataapimodels.ObjectDefinition, error) {
	// NOTE: this method will in time become `mapSDKObjectDefinitionToRepository` but since the legacy importer models support both CustomFieldType and ObjectDefinition this differentiation is needed in the short-term.
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

func validateObjectDefinition(input dataapimodels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails) error {
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

var internalObjectDefinitionsToObjectDefinitionTypes = map[resourcemanager.ApiObjectDefinitionType]dataapimodels.ObjectDefinitionType{
	resourcemanager.BooleanApiObjectDefinitionType:    dataapimodels.BooleanObjectDefinitionType,
	resourcemanager.CsvApiObjectDefinitionType:        dataapimodels.CsvObjectDefinitionType,
	resourcemanager.DateTimeApiObjectDefinitionType:   dataapimodels.DateTimeObjectDefinitionType,
	resourcemanager.DictionaryApiObjectDefinitionType: dataapimodels.DictionaryObjectDefinitionType,
	resourcemanager.IntegerApiObjectDefinitionType:    dataapimodels.IntegerObjectDefinitionType,
	resourcemanager.FloatApiObjectDefinitionType:      dataapimodels.FloatObjectDefinitionType,
	resourcemanager.ListApiObjectDefinitionType:       dataapimodels.ListObjectDefinitionType,
	resourcemanager.RawFileApiObjectDefinitionType:    dataapimodels.RawFileObjectDefinitionType,
	resourcemanager.RawObjectApiObjectDefinitionType:  dataapimodels.RawObjectObjectDefinitionType,
	resourcemanager.ReferenceApiObjectDefinitionType:  dataapimodels.ReferenceObjectDefinitionType,
	resourcemanager.StringApiObjectDefinitionType:     dataapimodels.StringObjectDefinitionType,

	// CommonSchema
	resourcemanager.EdgeZoneApiObjectDefinitionType:                                dataapimodels.EdgeZoneObjectDefinitionType,
	resourcemanager.LocationApiObjectDefinitionType:                                dataapimodels.LocationObjectDefinitionType,
	resourcemanager.SystemAssignedIdentityApiObjectDefinitionType:                  dataapimodels.SystemAssignedIdentityObjectDefinitionType,
	resourcemanager.SystemAndUserAssignedIdentityListApiObjectDefinitionType:       dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType:        dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	resourcemanager.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType: dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType:  dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	resourcemanager.SystemOrUserAssignedIdentityListApiObjectDefinitionType:        dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType:         dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	resourcemanager.UserAssignedIdentityListApiObjectDefinitionType:                dataapimodels.UserAssignedIdentityListObjectDefinitionType,
	resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType:                 dataapimodels.UserAssignedIdentityMapObjectDefinitionType,
	resourcemanager.TagsApiObjectDefinitionType:                                    dataapimodels.TagsObjectDefinitionType,
	resourcemanager.SystemData:                                                     dataapimodels.SystemDataObjectDefinitionType,
	resourcemanager.ZoneApiObjectDefinitionType:                                    dataapimodels.ZoneObjectDefinitionType,
	resourcemanager.ZonesApiObjectDefinitionType:                                   dataapimodels.ZonesObjectDefinitionType,
}
