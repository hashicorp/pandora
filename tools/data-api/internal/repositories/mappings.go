// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repositories

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
)

func mapObjectDefinition(input *repositoryModels.ObjectDefinition) (*ObjectDefinition, error) {
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

func mapOptionObjectDefinition(input *repositoryModels.OptionObjectDefinition, constants map[string]ConstantDetails, apiModels map[string]ModelDetails) (*OptionObjectDefinition, error) {
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

func mapDateFormatType(input repositoryModels.DateFormat) (*DateFormat, error) {
	mappings := map[repositoryModels.DateFormat]DateFormat{
		repositoryModels.RFC3339DateFormat: RFC3339DateFormat,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Date Format Type %q", string(input))
}

func mapObjectDefinitionType(input repositoryModels.ObjectDefinitionType) (*ObjectDefinitionType, error) {
	mappings := map[repositoryModels.ObjectDefinitionType]ObjectDefinitionType{
		repositoryModels.BooleanObjectDefinitionType:    BooleanObjectDefinitionType,
		repositoryModels.DateTimeObjectDefinitionType:   DateTimeObjectDefinitionType,
		repositoryModels.IntegerObjectDefinitionType:    IntegerObjectDefinitionType,
		repositoryModels.FloatObjectDefinitionType:      FloatObjectDefinitionType,
		repositoryModels.RawFileObjectDefinitionType:    RawFileObjectDefinitionType,
		repositoryModels.RawObjectObjectDefinitionType:  RawObjectObjectDefinitionType,
		repositoryModels.ReferenceObjectDefinitionType:  ReferenceObjectDefinitionType,
		repositoryModels.StringObjectDefinitionType:     StringObjectDefinitionType,
		repositoryModels.CsvObjectDefinitionType:        CsvObjectDefinitionType,
		repositoryModels.DictionaryObjectDefinitionType: DictionaryObjectDefinitionType,
		repositoryModels.ListObjectDefinitionType:       ListObjectDefinitionType,

		repositoryModels.EdgeZoneObjectDefinitionType:                                EdgeZoneObjectDefinitionType,
		repositoryModels.LocationObjectDefinitionType:                                LocationObjectDefinitionType,
		repositoryModels.TagsObjectDefinitionType:                                    TagsObjectDefinitionType,
		repositoryModels.SystemAssignedIdentityObjectDefinitionType:                  SystemAssignedIdentityObjectDefinitionType,
		repositoryModels.SystemAndUserAssignedIdentityListObjectDefinitionType:       SystemAndUserAssignedIdentityListObjectDefinitionType,
		repositoryModels.SystemAndUserAssignedIdentityMapObjectDefinitionType:        SystemAndUserAssignedIdentityMapObjectDefinitionType,
		repositoryModels.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: LegacySystemAndUserAssignedIdentityListObjectDefinitionType,
		repositoryModels.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  LegacySystemAndUserAssignedIdentityMapObjectDefinitionType,
		repositoryModels.SystemOrUserAssignedIdentityListObjectDefinitionType:        SystemOrUserAssignedIdentityListObjectDefinitionType,
		repositoryModels.SystemOrUserAssignedIdentityMapObjectDefinitionType:         SystemOrUserAssignedIdentityMapObjectDefinitionType,
		repositoryModels.UserAssignedIdentityListObjectDefinitionType:                UserAssignedIdentityListObjectDefinitionType,
		repositoryModels.UserAssignedIdentityMapObjectDefinitionType:                 UserAssignedIdentityMapObjectDefinitionType,
		repositoryModels.SystemDataObjectDefinitionType:                              SystemDataObjectDefinitionType,
		repositoryModels.ZoneObjectDefinitionType:                                    ZoneObjectDefinitionType,
		repositoryModels.ZonesObjectDefinitionType:                                   ZonesObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Object Definition Type %q", string(input))
}

func mapOptionObjectDefinitionType(input repositoryModels.OptionObjectDefinitionType) (*OptionObjectDefinitionType, error) {
	mappings := map[repositoryModels.OptionObjectDefinitionType]OptionObjectDefinitionType{
		repositoryModels.BooleanOptionObjectDefinitionType:   BooleanOptionObjectDefinition,
		repositoryModels.IntegerOptionObjectDefinitionType:   IntegerOptionObjectDefinition,
		repositoryModels.FloatOptionObjectDefinitionType:     FloatOptionObjectDefinitionType,
		repositoryModels.StringOptionObjectDefinitionType:    StringOptionObjectDefinitionType,
		repositoryModels.CsvOptionObjectDefinitionType:       CsvOptionObjectDefinitionType,
		repositoryModels.ListOptionObjectDefinitionType:      ListOptionObjectDefinitionType,
		repositoryModels.ReferenceOptionObjectDefinitionType: ReferenceOptionObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Options Object Definition Type %q", string(input))
}

func mapConstantFieldType(input repositoryModels.ConstantType) (*ConstantType, error) {
	mappings := map[repositoryModels.ConstantType]ConstantType{
		repositoryModels.FloatConstant:   FloatConstant,
		repositoryModels.IntegerConstant: IntegerConstant,
		repositoryModels.StringConstant:  StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func mapResourceIdSegmentType(input repositoryModels.ResourceIdSegmentType) (*ResourceIdSegmentType, error) {
	mappings := map[repositoryModels.ResourceIdSegmentType]ResourceIdSegmentType{
		repositoryModels.ConstantResourceIdSegmentType:         ConstantResourceIdSegmentType,
		repositoryModels.ResourceGroupResourceIdSegmentType:    ResourceGroupResourceIdSegmentType,
		repositoryModels.ResourceProviderResourceIdSegmentType: ResourceProviderResourceIdSegmentType,
		repositoryModels.ScopeResourceIdSegmentType:            ScopeResourceIdSegmentType,
		repositoryModels.StaticResourceIdSegmentType:           StaticResourceIdSegmentType,
		repositoryModels.SubscriptionIdResourceIdSegmentType:   SubscriptionIdResourceIdSegmentType,
		repositoryModels.UserSpecifiedResourceIdSegmentType:    UserSpecifiedResourceIdSegmentType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Resource Id Segment Type %q", string(input))
}

func mapApiDefinitionSourceType(input repositoryModels.ApiDefinitionsSource) (*ApiDefinitionSourceType, error) {
	mappings := map[repositoryModels.ApiDefinitionsSource]ApiDefinitionSourceType{
		repositoryModels.HandWrittenApiDefinitionsSource:                      HandWrittenApiDefinitionsSource,
		repositoryModels.AzureRestApiSpecsRepositoryApiDefinitionsSource:      ResourceManagerRestApiSpecsApiDefinitionsSource,
		repositoryModels.MicrosoftGraphMetaDataRepositoryApiDefinitionsSource: MicrosoftGraphMetadataApiDefinitionsSource,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Definition Source Type %q", string(input))
}

func mapValidationPossibleValueTypes(input repositoryModels.TerraformSchemaValidationPossibleValuesType) (*TerraformSchemaValidationPossibleValueType, error) {
	mappings := map[repositoryModels.TerraformSchemaValidationPossibleValuesType]TerraformSchemaValidationPossibleValueType{
		repositoryModels.FloatTerraformSchemaValidationPossibleValuesType:   TerraformSchemaValidationPossibleValueTypeFloat,
		repositoryModels.IntegerTerraformSchemaValidationPossibleValuesType: TerraformSchemaValidationPossibleValueTypeInt,
		repositoryModels.StringTerraformSchemaValidationPossibleValuesType:  TerraformSchemaValidationPossibleValueTypeString,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Validation Posssible Values Type %q", string(input))
}
