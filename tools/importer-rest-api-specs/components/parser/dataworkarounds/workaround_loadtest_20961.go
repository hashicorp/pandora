// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundLoadTest20961{}

// workaroundLoadTest20961 works around the Patch Model having no type for the Tags field (which is parsed
// as an Object instead).
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/20961
type workaroundLoadTest20961 struct {
}

func (workaroundLoadTest20961) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "LoadTestService"
	apiVersionMatches := apiDefinition.ApiVersion == "2021-12-01-preview" || apiDefinition.ApiVersion == "2022-04-15-preview" || apiDefinition.ApiVersion == "2022-12-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundLoadTest20961) Name() string {
	return "LoadTest / 20961"
}

func (workaroundLoadTest20961) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["LoadTests"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource LoadTests")
	}
	model, ok := resource.Models["LoadTestResourceUpdate"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model LoadTestResourceUpdate")
	}
	field, ok := model.Fields["Tags"]
	if !ok {
		return nil, fmt.Errorf("couldn't find field Tags within model LoadTestResourceUpdate")
	}
	field.ObjectDefinition = models.SDKObjectDefinition{
		Type: models.TagsSDKObjectDefinitionType,
	}

	model.Fields["Tags"] = field
	resource.Models["LoadTestResourceUpdate"] = model
	apiDefinition.Resources["LoadTests"] = resource
	return &apiDefinition, nil
}
