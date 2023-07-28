package resourcemanager

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func mapObjectDefinition(input *repositories.ObjectDefinition) *models.ApiObjectDefinition {
	if input == nil {
		return nil
	}

	output := models.ApiObjectDefinition{}
	if input.NestedItem != nil {
		output.NestedItem = mapObjectDefinition(input.NestedItem)
	}
	output.ReferenceName = input.ReferenceName
	output.Type = models.ApiObjectDefinitionType(input.Type)

	return &output
}

func mapSchemaFields(input map[string]repositories.FieldDetails) map[string]models.FieldDetails {
	fields := make(map[string]models.FieldDetails, 0)

	for k, field := range input {

		fields[k] = models.FieldDetails{
			Default:          field.Default,
			DateFormat:       pointer.To(models.DateFormat(pointer.From(field.DateFormat))),
			ForceNew:         field.ForceNew,
			IsTypeHint:       field.IsTypeHint,
			JsonName:         field.JsonName,
			ObjectDefinition: pointer.From(mapObjectDefinition(&field.ObjectDefinition)),
			Optional:         field.Optional,
			Required:         field.Required,
			Validation:       mapFieldValidation(field.Validation),
			Description:      field.Description,
		}
	}

	return fields
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
