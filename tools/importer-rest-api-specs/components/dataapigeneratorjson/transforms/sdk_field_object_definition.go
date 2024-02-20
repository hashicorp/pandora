package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapSDKObjectDefinitionToRepository(details importerModels.FieldDetails, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataapimodels.ObjectDefinition, error) {
	// if it's a CustomFieldType then it can't contain another item
	if details.CustomFieldType != nil {
		typeVal, ok := customFieldTypesToObjectDefinitionTypes[*details.CustomFieldType]
		if !ok {
			return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the CustomFieldType %q", string(*details.CustomFieldType))
		}
		return &dataapimodels.ObjectDefinition{
			Type:          typeVal,
			ReferenceName: nil,
			NestedItem:    nil,
		}, nil
	}

	if details.ObjectDefinition == nil {
		return nil, fmt.Errorf("internal-error: neither a CustomFieldType or an ObjectDefinition was defined for this field")
	}

	objectDefinition, err := mapSDKFieldObjectDefinitionToRepositoryInternal(details.ObjectDefinition, constants, models)
	if err != nil {
		return nil, fmt.Errorf("mapping the object definition: %+v", err)
	}

	return objectDefinition, nil
}

func mapSDKFieldObjectDefinitionToRepositoryInternal(definition *importerModels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataapimodels.ObjectDefinition, error) {
	// NOTE: this method will in time become `MapSDKObjectDefinitionToRepository` but since the legacy importer models support both CustomFieldType and ObjectDefinition this differentiation is needed in the short-term.
	typeVal, ok := internalObjectDefinitionsToObjectDefinitionTypes[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no ObjectDefinition mapping is defined for the ObjectDefinition Type %q", string(definition.Type))
	}

	output := dataapimodels.ObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if definition.ReferenceName != nil {
		output.ReferenceName = definition.ReferenceName
	}

	if definition.NestedItem != nil {
		nestedItem, err := mapSDKFieldObjectDefinitionToRepositoryInternal(definition.NestedItem, constants, models)
		if err != nil {
			return nil, fmt.Errorf("mapping nested object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	if definition.Maximum != nil {
		output.MaxItems = definition.Maximum
	}
	if definition.Minimum != nil {
		output.MinItems = definition.Minimum
	}
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

func validateObjectDefinition(input dataapimodels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) error {
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

var internalObjectDefinitionsToObjectDefinitionTypes = map[importerModels.ObjectDefinitionType]dataapimodels.ObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:    dataapimodels.BooleanObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:        dataapimodels.CsvObjectDefinitionType,
	importerModels.ObjectDefinitionDateTime:   dataapimodels.DateTimeObjectDefinitionType,
	importerModels.ObjectDefinitionDictionary: dataapimodels.DictionaryObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:    dataapimodels.IntegerObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:      dataapimodels.FloatObjectDefinitionType,
	importerModels.ObjectDefinitionList:       dataapimodels.ListObjectDefinitionType,
	importerModels.ObjectDefinitionRawFile:    dataapimodels.RawFileObjectDefinitionType,
	importerModels.ObjectDefinitionRawObject:  dataapimodels.RawObjectObjectDefinitionType,
	importerModels.ObjectDefinitionReference:  dataapimodels.ReferenceObjectDefinitionType,
	importerModels.ObjectDefinitionString:     dataapimodels.StringObjectDefinitionType,
}

var customFieldTypesToObjectDefinitionTypes = map[importerModels.CustomFieldType]dataapimodels.ObjectDefinitionType{
	importerModels.CustomFieldTypeEdgeZone:                                dataapimodels.EdgeZoneObjectDefinitionType,
	importerModels.CustomFieldTypeLocation:                                dataapimodels.LocationObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAssignedIdentity:                  dataapimodels.SystemAssignedIdentityObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityList:       dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemAndUserAssignedIdentityMap:        dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityList: dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeLegacySystemAndUserAssignedIdentityMap:  dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityList:        dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeSystemOrUserAssignedIdentityMap:         dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityList:                dataapimodels.UserAssignedIdentityListObjectDefinitionType,
	importerModels.CustomFieldTypeUserAssignedIdentityMap:                 dataapimodels.UserAssignedIdentityMapObjectDefinitionType,
	importerModels.CustomFieldTypeTags:                                    dataapimodels.TagsObjectDefinitionType,
	importerModels.CustomFieldTypeSystemData:                              dataapimodels.SystemDataObjectDefinitionType,
	importerModels.CustomFieldTypeZone:                                    dataapimodels.ZoneObjectDefinitionType,
	importerModels.CustomFieldTypeZones:                                   dataapimodels.ZonesObjectDefinitionType,
}
