package repositories

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapObjectDefinition(input *dataapimodels.ObjectDefinition) (*ObjectDefinition, error) {
	if input == nil {
		return nil, nil
	}

	objectDefinitionType, err := mapObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}

	output := ObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          pointer.From(objectDefinitionType),
	}

	if input.NestedItem != nil {
		nestedItem, err := mapObjectDefinition(input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item for Object Definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	return &output, nil
}

func mapOptionObjectDefinition(input *dataapimodels.OptionObjectDefinition, constants map[string]ConstantDetails, apiModels map[string]ModelDetails) (*OptionObjectDefinition, error) {
	optionObjectType, err := mapOptionObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}

	output := OptionObjectDefinition{
		ReferenceName: input.ReferenceName,
		Type:          pointer.From(optionObjectType),
	}

	if input.NestedItem != nil {
		nestedItem, err := mapOptionObjectDefinition(input.NestedItem, constants, apiModels)
		if err != nil {
			return nil, fmt.Errorf("mapping Nested Item for Option Object Definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	if err := validateOptionObjectDefinition(output, constants, apiModels); err != nil {
		return nil, fmt.Errorf("validating mapped Option Object Definition: %+v", err)
	}

	return &output, nil
}

func mapDateFormatType(input dataapimodels.DateFormat) (*DateFormat, error) {
	mappings := map[dataapimodels.DateFormat]DateFormat{
		dataapimodels.RFC3339DateFormat: RFC3339DateFormat,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Date Format Type %q", string(input))
}

func mapObjectDefinitionType(input dataapimodels.ObjectDefinitionType) (*ObjectDefinitionType, error) {
	mappings := map[dataapimodels.ObjectDefinitionType]ObjectDefinitionType{
		dataapimodels.BooleanObjectDefinitionType:    BooleanObjectDefinitionType,
		dataapimodels.DateTimeObjectDefinitionType:   DateTimeObjectDefinitionType,
		dataapimodels.IntegerObjectDefinitionType:    IntegerObjectDefinitionType,
		dataapimodels.FloatObjectDefinitionType:      FloatObjectDefinitionType,
		dataapimodels.RawFileObjectDefinitionType:    RawFileObjectDefinitionType,
		dataapimodels.RawObjectObjectDefinitionType:  RawObjectObjectDefinitionType,
		dataapimodels.ReferenceObjectDefinitionType:  ReferenceObjectDefinitionType,
		dataapimodels.StringObjectDefinitionType:     StringObjectDefinitionType,
		dataapimodels.CsvObjectDefinitionType:        CsvObjectDefinitionType,
		dataapimodels.DictionaryObjectDefinitionType: DictionaryObjectDefinitionType,
		dataapimodels.ListObjectDefinitionType:       ListObjectDefinitionType,

		dataapimodels.EdgeZoneObjectDefinitionType:                                EdgeZoneObjectDefinitionType,
		dataapimodels.LocationObjectDefinitionType:                                LocationObjectDefinitionType,
		dataapimodels.TagsObjectDefinitionType:                                    TagsObjectDefinitionType,
		dataapimodels.SystemAssignedIdentityObjectDefinitionType:                  SystemAssignedIdentityObjectDefinitionType,
		dataapimodels.SystemAndUserAssignedIdentityListObjectDefinitionType:       SystemAndUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.SystemAndUserAssignedIdentityMapObjectDefinitionType:        SystemAndUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.SystemOrUserAssignedIdentityListObjectDefinitionType:        SystemOrUserAssignedIdentityListObjectDefinitionType,
		dataapimodels.SystemOrUserAssignedIdentityMapObjectDefinitionType:         SystemOrUserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.UserAssignedIdentityListObjectDefinitionType:                UserAssignedIdentityListObjectDefinitionType,
		dataapimodels.UserAssignedIdentityMapObjectDefinitionType:                 UserAssignedIdentityMapObjectDefinitionType,
		dataapimodels.SystemDataObjectDefinitionType:                              SystemDataObjectDefinitionType,
		dataapimodels.ZoneObjectDefinitionType:                                    ZoneObjectDefinitionType,
		dataapimodels.ZonesObjectDefinitionType:                                   ZonesObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Object Definition Type %q", string(input))
}

func mapOptionObjectDefinitionType(input dataapimodels.OptionObjectDefinitionType) (*OptionObjectDefinitionType, error) {
	mappings := map[dataapimodels.OptionObjectDefinitionType]OptionObjectDefinitionType{
		dataapimodels.BooleanOptionObjectDefinitionType:   BooleanOptionObjectDefinition,
		dataapimodels.IntegerOptionObjectDefinitionType:   IntegerOptionObjectDefinition,
		dataapimodels.FloatOptionObjectDefinitionType:     FloatOptionObjectDefinitionType,
		dataapimodels.StringOptionObjectDefinitionType:    StringOptionObjectDefinitionType,
		dataapimodels.CsvOptionObjectDefinitionType:       CsvOptionObjectDefinitionType,
		dataapimodels.ListOptionObjectDefinitionType:      ListOptionObjectDefinitionType,
		dataapimodels.ReferenceOptionObjectDefinitionType: ReferenceOptionObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Options Object Definition Type %q", string(input))
}

func mapConstantFieldType(input dataapimodels.ConstantType) (*ConstantType, error) {
	mappings := map[dataapimodels.ConstantType]ConstantType{
		dataapimodels.FloatConstant:   FloatConstant,
		dataapimodels.IntegerConstant: IntegerConstant,
		dataapimodels.StringConstant:  StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapResourceIdSegmentType(input dataapimodels.ResourceIdSegmentType) (*ResourceIdSegmentType, error) {
	mappings := map[dataapimodels.ResourceIdSegmentType]ResourceIdSegmentType{
		dataapimodels.ConstantResourceIdSegmentType:         ConstantResourceIdSegmentType,
		dataapimodels.ResourceGroupResourceIdSegmentType:    ResourceGroupResourceIdSegmentType,
		dataapimodels.ResourceProviderResourceIdSegmentType: ResourceProviderResourceIdSegmentType,
		dataapimodels.ScopeResourceIdSegmentType:            ScopeResourceIdSegmentType,
		dataapimodels.StaticResourceIdSegmentType:           StaticResourceIdSegmentType,
		dataapimodels.SubscriptionIdResourceIdSegmentType:   SubscriptionIdResourceIdSegmentType,
		dataapimodels.UserSpecifiedResourceIdSegmentType:    UserSpecifiedResourceIdSegmentType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Resource Id Segment Type %q", string(input))
}

func mapApiDefinitionSourceType(input dataapimodels.ApiDefinitionsSource) (*ApiDefinitionSourceType, error) {
	mappings := map[dataapimodels.ApiDefinitionsSource]ApiDefinitionSourceType{
		dataapimodels.HandWrittenApiDefinitionsSource:                      HandWrittenApiDefinitionsSource,
		dataapimodels.AzureRestApiSpecsRepositoryApiDefinitionsSource:      ResourceManagerRestApiSpecsApiDefinitionsSource,
		dataapimodels.MicrosoftGraphMetaDataRepositoryApiDefinitionsSource: MicrosoftGraphMetadataApiDefinitionsSource,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Data Source Type %q", string(input))
}
