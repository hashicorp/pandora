package dataworkarounds

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundLoadTest20961{}

// workaroundLoadTest20961 works around the Patch Model having no type for the Tags field (which is parsed
// as an Object instead).
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/20961
type workaroundLoadTest20961 struct {
}

func (workaroundLoadTest20961) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "LoadTestService"
	apiVersionMatches := apiDefinition.ApiVersion == "2021-12-01-preview" || apiDefinition.ApiVersion == "2022-04-15-preview" || apiDefinition.ApiVersion == "2022-12-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundLoadTest20961) Name() string {
	return "LoadTest / 20961"
}

func (workaroundLoadTest20961) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["LoadTests"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource LoadTests")
	}
	model, ok := resource.Models["LoadTestResourcePatchRequestBody"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model LoadTestResourcePatchRequestBody")
	}
	field, ok := model.Fields["Tags"]
	if !ok {
		return nil, fmt.Errorf("couldn't find field Tags within model LoadTestResourcePatchRequestBody")
	}
	tagsType := models.CustomFieldTypeTags
	field.CustomFieldType = &tagsType
	field.ObjectDefinition = nil

	model.Fields["Tags"] = field
	resource.Models["LoadTestResourcePatchRequestBody"] = model
	apiDefinition.Resources["LoadTests"] = resource
	return &apiDefinition, nil
}
