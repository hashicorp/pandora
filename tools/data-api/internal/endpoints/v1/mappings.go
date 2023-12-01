package v1

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func mapObjectDefinition(input *repositories.ObjectDefinition) (*models.ApiObjectDefinition, error) {
	if input == nil {
		return nil, nil
	}

	var err error
	output := models.ApiObjectDefinition{}
	if input.NestedItem != nil {
		output.NestedItem, err = mapObjectDefinition(input.NestedItem)
		if err != nil {
			return nil, err
		}

	}
	output.ReferenceName = input.ReferenceName
	objectDefinitionType, err := mapObjectDefinitionType(input.Type)
	if err != nil {
		return nil, err
	}
	output.Type = *objectDefinitionType

	return &output, nil
}

func mapSchemaFields(input map[string]repositories.FieldDetails) (map[string]models.FieldDetails, error) {
	fields := make(map[string]models.FieldDetails, 0)

	for k, field := range input {

		objectDefinition, err := mapObjectDefinition(&field.ObjectDefinition)
		if err != nil {
			return nil, err
		}
		dateFormat, err := mapDateFormat(field.DateFormat)
		if err != nil {
			return nil, err
		}

		fields[k] = models.FieldDetails{
			DateFormat:       dateFormat,
			ForceNew:         field.ForceNew,
			IsTypeHint:       field.IsTypeHint,
			JsonName:         field.JsonName,
			ObjectDefinition: pointer.From(objectDefinition),
			Optional:         field.Optional,
			Required:         field.Required,
			Validation:       mapFieldValidation(field.Validation),
			Description:      field.Description,
		}
	}

	return fields, nil
}

func mapFieldValidation(input *repositories.FieldValidationDetails) *models.FieldValidationDetails {
	if input == nil {
		return nil
	}
	output := models.FieldValidationDetails{}
	output.Type = models.FieldValidationType(input.Type)
	output.Values = input.Values

	return &output
}

func mapDateFormat(input *repositories.DateFormat) (*models.DateFormat, error) {
	if input != nil {
		mappings := map[repositories.DateFormat]models.DateFormat{
			repositories.RFC3339DateFormat: models.RFC3339,
		}
		if v, ok := mappings[*input]; ok {
			return &v, nil
		}
		return nil, fmt.Errorf("unmapped date format %+v", input)
	}

	return nil, nil
}

func mapConstantType(input repositories.ConstantType) (*models.ConstantType, error) {
	mappings := map[repositories.ConstantType]models.ConstantType{
		repositories.FloatConstant:   models.FloatConstant,
		repositories.IntegerConstant: models.IntegerConstant,
		repositories.StringConstant:  models.StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped constant type %q", input)
}

func mapObjectDefinitionType(input repositories.ObjectDefinitionType) (*models.ApiObjectDefinitionType, error) {
	mappings := map[repositories.ObjectDefinitionType]models.ApiObjectDefinitionType{
		repositories.ReferenceObjectDefinitionType:  models.ReferenceApiObjectDefinitionType,
		repositories.StringObjectDefinitionType:     models.StringApiObjectDefinitionType,
		repositories.BooleanObjectDefinitionType:    models.BooleanApiObjectDefinitionType,
		repositories.DateTimeObjectDefinitionType:   models.DateTimeApiObjectDefinitionType,
		repositories.IntegerObjectDefinitionType:    models.IntegerApiObjectDefinitionType,
		repositories.FloatObjectDefinitionType:      models.FloatApiObjectDefinitionType,
		repositories.RawFileObjectDefinitionType:    models.RawFileApiObjectDefinitionType,
		repositories.RawObjectObjectDefinitionType:  models.RawObjectApiObjectDefinitionType,
		repositories.CsvObjectDefinitionType:        models.CsvApiObjectDefinitionType,
		repositories.DictionaryObjectDefinitionType: models.DictionaryApiObjectDefinitionType,
		repositories.ListObjectDefinitionType:       models.ListApiObjectDefinitionType,

		repositories.EdgeZoneObjectDefinitionType:                                models.EdgeZoneApiObjectDefinitionType,
		repositories.LocationObjectDefinitionType:                                models.LocationApiObjectDefinitionType,
		repositories.TagsObjectDefinitionType:                                    models.TagsApiObjectDefinitionType,
		repositories.SystemAssignedIdentityObjectDefinitionType:                  models.SystemAssignedIdentityApiObjectDefinitionType,
		repositories.SystemAndUserAssignedIdentityListObjectDefinitionType:       models.SystemAndUserAssignedIdentityListApiObjectDefinitionType,
		repositories.SystemAndUserAssignedIdentityMapObjectDefinitionType:        models.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
		repositories.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: models.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType,
		repositories.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  models.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType,
		repositories.SystemOrUserAssignedIdentityListObjectDefinitionType:        models.SystemOrUserAssignedIdentityListApiObjectDefinitionType,
		repositories.SystemOrUserAssignedIdentityMapObjectDefinitionType:         models.SystemOrUserAssignedIdentityMapApiObjectDefinitionType,
		repositories.UserAssignedIdentityListObjectDefinitionType:                models.UserAssignedIdentityListApiObjectDefinitionType,
		repositories.UserAssignedIdentityMapObjectDefinitionType:                 models.UserAssignedIdentityMapApiObjectDefinitionType,
		repositories.SystemDataObjectDefinitionType:                              models.SystemData,
		repositories.ZoneObjectDefinitionType:                                    models.ZoneApiObjectDefinitionType,
		repositories.ZonesObjectDefinitionType:                                   models.ZonesApiObjectDefinitionType,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped object definition type %q", input)
}

func mapResourceIdSegments(input []repositories.ResourceIdSegment) []models.ResourceIdSegment {
	segments := make([]models.ResourceIdSegment, 0)

	for _, segment := range input {
		outputSegment := models.ResourceIdSegment{
			ConstantReference: segment.ConstantReference,
			ExampleValue:      segment.ExampleValue,
			FixedValue:        segment.FixedValue,
			Name:              segment.Name,
			Type:              models.ResourceIdSegmentType(segment.Type),
		}
		segments = append(segments, outputSegment)
	}

	return segments
}

func mapOptionObjectDefinition(input *repositories.OptionObjectDefinition) *models.ApiObjectDefinition {
	if input == nil {
		return nil
	}

	output := models.ApiObjectDefinition{}
	if input.NestedItem != nil {
		output.NestedItem = mapOptionObjectDefinition(input.NestedItem)
	}
	output.ReferenceName = input.ReferenceName
	output.Type = models.ApiObjectDefinitionType(input.Type)

	return &output
}
