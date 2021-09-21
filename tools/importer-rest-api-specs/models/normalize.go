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
