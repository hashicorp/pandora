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
			if fieldVal.ConstantReference != nil {
				normalized := cleanup.NormalizeName(*fieldVal.ConstantReference)
				fieldVal.ConstantReference = &normalized
			}

			if fieldVal.ModelReference != nil {
				normalized := cleanup.NormalizeName(*fieldVal.ModelReference)
				fieldVal.ModelReference = &normalized
			}

			fields[normalizedFieldName] = fieldVal
		}
		v.Fields = fields

		if v.AdditionalProperties != nil {
			additionalProperties := *v.AdditionalProperties
			if additionalProperties.ConstantReference != nil {
				normalized := cleanup.NormalizeName(*additionalProperties.ConstantReference)
				additionalProperties.ConstantReference = &normalized
			}
			if additionalProperties.ModelReference != nil {
				normalized := cleanup.NormalizeName(*additionalProperties.ModelReference)
				additionalProperties.ModelReference = &normalized
			}
			v.AdditionalProperties = &additionalProperties
		}

		normalizedModels[modelName] = v
	}
	r.Models = normalizedModels
}
