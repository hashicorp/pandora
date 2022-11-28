package dataworkarounds

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ workaround = workaroundMedia21581{}

// workaroundMedia21581 works around the Update operation having the incorrect Swagger Tag
// (StreamingEndpoint rather than StreamingEndpoints).
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21581
type workaroundMedia21581 struct {
}

func (workaroundMedia21581) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "Media" && apiDefinition.ApiVersion == "2020-05-01"
}

func (workaroundMedia21581) Name() string {
	return "Media / 21581"
}

func (workaroundMedia21581) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	singular, singularExists := apiDefinition.Resources["StreamingEndpoint"]
	plural, pluralExists := apiDefinition.Resources["StreamingEndpoints"]
	if singularExists && pluralExists {
		updateOperation, ok := singular.Operations["Update"]
		if ok {
			// NOTE: we should be moving the Model too, but as it's the same as for Create this should be fine
			plural.Operations["Update"] = updateOperation
			apiDefinition.Resources["StreamingEndpoints"] = plural
			delete(apiDefinition.Resources, "StreamingEndpoint")
		}
	}
	return &apiDefinition, nil
}
