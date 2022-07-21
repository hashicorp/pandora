package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// normalizeAzureApiResource works through the parsed AzureApiResource and ensures
// that all the Names and References are consistent (TitleCase) as a final effort
// to ensure the Swagger Data is normalized.
func normalizeAzureApiResource(input models.AzureApiResource) models.AzureApiResource {
	normalizedConstants := make(map[string]models.ConstantDetails)
	for k, v := range input.Constants {
		name := NormalizeName(k)
		normalizedConstants[name] = v
	}

	normalizedModels := make(map[string]models.ModelDetails)
	for k, v := range input.Models {
		modelName := NormalizeName(k)
		fields := make(map[string]models.FieldDetails)
		for fieldName, fieldVal := range v.Fields {
			normalizedFieldName := NormalizeName(fieldName)

			if fieldVal.ObjectDefinition != nil {
				fieldVal.ObjectDefinition = normalizeObjectDefinition(*fieldVal.ObjectDefinition)
			}

			fields[normalizedFieldName] = fieldVal
		}
		v.Fields = fields

		if v.ParentTypeName != nil {
			val := NormalizeName(*v.ParentTypeName)
			v.ParentTypeName = &val
		}

		// Discriminators can be `@type` which get normalized to `Type` so we need to normalize the field name here
		if v.TypeHintIn != nil {
			val := NormalizeName(*v.TypeHintIn)
			v.TypeHintIn = &val
		}

		normalizedModels[modelName] = v
	}

	normalizedOperations := make(map[string]models.OperationDetails)
	for k, v := range input.Operations {
		if v.ResourceIdName != nil {
			normalized := NormalizeName(*v.ResourceIdName)
			v.ResourceIdName = &normalized
		}

		if v.RequestObject != nil {
			v.RequestObject = normalizeObjectDefinition(*v.RequestObject)
		}

		if v.ResponseObject != nil {
			v.ResponseObject = normalizeObjectDefinition(*v.ResponseObject)
		}

		normalizedOptions := make(map[string]models.OperationOption, 0)
		for optionKey, optionVal := range v.Options {
			optionKey = NormalizeName(optionKey)

			if optionVal.ObjectDefinition != nil {
				optionVal.ObjectDefinition = normalizeObjectDefinition(*optionVal.ObjectDefinition)
			}

			normalizedOptions[optionKey] = optionVal
		}
		v.Options = normalizedOptions

		normalizedOperations[k] = v
	}

	normalizedResourceIds := make(map[string]models.ParsedResourceId)
	for k, v := range input.ResourceIds {
		segments := make([]models.ResourceIdSegment, 0)

		normalizedConstants := make(map[string]models.ConstantDetails)
		for k, constant := range v.Constants {
			name := NormalizeName(k)
			normalizedConstants[name] = constant
		}
		v.Constants = normalizedConstants

		for _, segment := range v.Segments {
			if segment.ConstantReference != nil {
				normalized := NormalizeName(*segment.ConstantReference)
				segment.ConstantReference = &normalized
			}
			segments = append(segments, segment)
		}

		v.Segments = segments
		normalizedResourceIds[k] = v
	}

	return models.AzureApiResource{
		Constants:   normalizedConstants,
		Models:      normalizedModels,
		Operations:  normalizedOperations,
		ResourceIds: normalizedResourceIds,

		// TF Processing is handled elsewhere, so this should be nil in `input`
		// but let's be explicit here since it's another packages responsibility.
		Terraform: nil,
	}
}

func normalizeObjectDefinition(input models.ObjectDefinition) *models.ObjectDefinition {
	if input.ReferenceName != nil {
		normalized := NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		input.NestedItem = normalizeObjectDefinition(*input.NestedItem)
	}

	return &input
}
