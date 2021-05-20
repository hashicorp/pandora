package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// normalizeResources works through the Constants, Models, Operations and Resource ID's and
// normalizes the names used for these to ensure they're TitleCase and consistent
func normalizeResources(input map[string]models.AzureApiResource) map[string]models.AzureApiResource {
	output := make(map[string]models.AzureApiResource)
	for resourceName, resource := range input {
		normalizedResourceName := cleanup.NormalizeName(resourceName)
		normalizedResource := normalizeResource(resource)
		output[normalizedResourceName] = normalizedResource
	}
	return output
}

type normalizer struct{}

func normalizeResource(input models.AzureApiResource) models.AzureApiResource {
	n := normalizer{}

	// TODO: it'd be nice to trim the resource name out of any nested models since
	// these are ultimately grouped by the Service Package too (e.g. StaticSites)

	normalizedConstants := n.constants(input.Constants)
	normalizedModels := n.models(input.Models)
	normalizedOperations := n.operations(input.Operations)
	normalizedResourceIds := n.resourceIds(input.ResourceIds)

	return models.AzureApiResource{
		Constants:   normalizedConstants,
		Models:      normalizedModels,
		Operations:  normalizedOperations,
		ResourceIds: normalizedResourceIds,
	}
}

func (n normalizer) constants(input map[string]models.ConstantDetails) map[string]models.ConstantDetails {
	output := make(map[string]models.ConstantDetails)

	for key, value := range input {
		normalizedKey := cleanup.NormalizeName(key)
		// TODO: we shouldn't need to normalize the values but maybe?
		output[normalizedKey] = value
	}

	return output
}

func (n normalizer) models(input map[string]models.ModelDetails) map[string]models.ModelDetails {
	output := make(map[string]models.ModelDetails)

	for key, value := range input {
		normalizedFields := make(map[string]models.FieldDefinition)
		for fieldName, fieldVal := range value.Fields {
			if v := fieldVal.ConstantReference; v != nil {
				normalized := cleanup.NormalizeName(*v)
				fieldVal.ConstantReference = &normalized
			}
			if v := fieldVal.ModelReference; v != nil {
				normalized := cleanup.NormalizeName(*v)
				fieldVal.ModelReference = &normalized
			}

			normalizedFieldName := cleanup.NormalizeName(fieldName)
			normalizedFields[normalizedFieldName] = fieldVal
		}

		normalizedModelName := cleanup.NormalizeName(key)
		output[normalizedModelName] = models.ModelDetails{
			Description: value.Description,
			Fields:      normalizedFields,
		}
	}

	return output
}

func (n normalizer) operations(input map[string]models.OperationDetails) map[string]models.OperationDetails {
	output := make(map[string]models.OperationDetails)

	for key, value := range input {
		normalizedKey := cleanup.NormalizeName(key)

		if v := value.RequestObjectName; v != nil {
			normalized := cleanup.NormalizeName(*v)
			value.RequestObjectName = &normalized
		}

		if v := value.ResponseObjectName; v != nil {
			normalized := cleanup.NormalizeName(*v)
			value.ResponseObjectName = &normalized
		}

		//for opKey, opVal := range value.Options {
		//	// TODO: normalize
		//}

		// TODO: Resource ID?

		output[normalizedKey] = value
	}

	return output
}

func (n normalizer) resourceIds(input map[string]string) map[string]string {
	output := make(map[string]string)

	for key, value := range input {
		normalizedKey := cleanup.NormalizeName(key)
		output[normalizedKey] = value
	}

	return output
}

func removeModelsWithoutFields(input map[string]models.AzureApiResource) map[string]models.AzureApiResource {
	output := make(map[string]models.AzureApiResource)
	for resourceName, resource := range input {
		for modelName, model := range resource.Models {
			if len(model.Fields) == 0 {
				delete(resource.Models, modelName)
			}
		}
		output[resourceName] = resource
	}

	return output
}