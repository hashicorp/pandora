package models

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"

func (r *AzureApiResource) Normalize() {
	normalizedConstants := make(map[string]ConstantDetails)
	for k, v := range r.Constants {
		name := cleanup.NormalizeName(k)
		normalizedConstants[name] = v
	}
	r.Constants = normalizedConstants

	normalizedModels := make(map[string]ModelDetails)
	for k, v := range r.Models {
		modelName := cleanup.NormalizeName(k)
		fields := make(map[string]FieldDetails)
		for fieldName, fieldVal := range v.Fields {
			normalizedFieldName := cleanup.NormalizeName(fieldName)

			if fieldVal.ObjectDefinition != nil {
				fieldVal.ObjectDefinition = normalizeObjectDefinition(*fieldVal.ObjectDefinition)
			}

			fields[normalizedFieldName] = fieldVal
		}
		v.Fields = fields

		if v.ParentTypeName != nil {
			val := cleanup.NormalizeName(*v.ParentTypeName)
			v.ParentTypeName = &val
		}

		// Discriminators can be `@type` which get normalized to `Type` so we need to normalize the field name here
		if v.TypeHintIn != nil {
			val := cleanup.NormalizeName(*v.TypeHintIn)
			v.TypeHintIn = &val
		}

		normalizedModels[modelName] = v
	}
	r.Models = normalizedModels

	for k, v := range r.Operations {
		if v.ResourceIdName != nil {
			normalized := cleanup.NormalizeName(*v.ResourceIdName)
			v.ResourceIdName = &normalized
		}

		if v.RequestObject != nil {
			v.RequestObject = normalizeObjectDefinition(*v.RequestObject)
		}

		if v.ResponseObject != nil {
			v.ResponseObject = normalizeObjectDefinition(*v.ResponseObject)
		}

		normalizedOptions := make(map[string]OperationOption, 0)
		for optionKey, optionVal := range v.Options {
			optionKey = cleanup.NormalizeName(optionKey)

			if optionVal.ObjectDefinition != nil {
				optionVal.ObjectDefinition = normalizeObjectDefinition(*optionVal.ObjectDefinition)
			}

			normalizedOptions[optionKey] = optionVal
		}
		v.Options = normalizedOptions

		r.Operations[k] = v
	}

	for k, v := range r.ResourceIds {
		segments := make([]ResourceIdSegment, 0)

		normalizedConstants := make(map[string]ConstantDetails)
		for k, constant := range v.Constants {
			name := cleanup.NormalizeName(k)
			normalizedConstants[name] = constant
		}
		v.Constants = normalizedConstants

		for _, segment := range v.Segments {
			if segment.ConstantReference != nil {
				normalized := cleanup.NormalizeName(*segment.ConstantReference)
				segment.ConstantReference = &normalized
			}
			segments = append(segments, segment)
		}

		v.Segments = segments
		r.ResourceIds[k] = v
	}
}

func normalizeObjectDefinition(input ObjectDefinition) *ObjectDefinition {
	if input.ReferenceName != nil {
		normalized := cleanup.NormalizeName(*input.ReferenceName)
		input.ReferenceName = &normalized
	}

	if input.NestedItem != nil {
		input.NestedItem = normalizeObjectDefinition(*input.NestedItem)
	}

	return &input
}
