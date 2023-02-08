package dataworkarounds

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundBatch21291{}

// workaroundBatch21291 works around the StorageAccountId property being marked as Required which means it isn't
// nullable/removable like it was with the Azure Track1 SDK.
// The Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21291
type workaroundBatch21291 struct {
}

func (workaroundBatch21291) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Batch"
	apiVersionMatches := apiDefinition.ApiVersion == "2022-01-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundBatch21291) Name() string {
	return "Batch / 21291"
}

func (workaroundBatch21291) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["BatchAccount"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource BatchAccount")
	}
	model, ok := resource.Models["AutoStorageBaseProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model AutoStorageBaseProperties")
	}
	field, ok := model.Fields["StorageAccountId"]
	if !ok {
		return nil, fmt.Errorf("couldn't find the field StorageAccountId within model AutoStorageProperties")
	}
	field.Required = false

	model.Fields["StorageAccountId"] = field
	resource.Models["AutoStorageBaseProperties"] = model
	apiDefinition.Resources["BatchAccount"] = resource
	return &apiDefinition, nil
}
