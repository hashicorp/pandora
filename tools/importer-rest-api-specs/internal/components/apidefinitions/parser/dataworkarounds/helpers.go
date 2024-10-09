package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func markFieldAsComputed(input sdkModels.APIVersion, apiResourceName, modelName, fieldName string) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources[apiResourceName]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource %q but didn't get one", apiResourceName)
	}
	model, ok := resource.Models[modelName]
	if !ok {
		return nil, fmt.Errorf("expected a Model %q but didn't get one", modelName)
	}
	field, ok := model.Fields[fieldName]
	if !ok {
		return nil, fmt.Errorf("expected a Field %q but didn't get one", fieldName)
	}
	field.Optional = false
	field.ReadOnly = true
	field.Required = false
	field.Sensitive = false
	model.Fields[fieldName] = field

	resource.Models[modelName] = model
	input.Resources[apiResourceName] = resource
	return &input, nil
}
