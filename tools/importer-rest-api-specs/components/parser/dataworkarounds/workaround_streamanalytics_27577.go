// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// workaroundStreamAnalytics27577 is a workaround to account for StreamAnalytics containing its own
// `Identity` type when it should be picked up as a Common Type. This is because the API Definition
// doesn't fully describe the object - which is what https://github.com/Azure/azure-rest-api-specs/pull/27577
// looks to fix.
type workaroundStreamAnalytics27577 struct {
}

func (w workaroundStreamAnalytics27577) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "StreamAnalytics"
	apiVersionMatches := apiDefinition.ApiVersion == "2020-03-01" || apiDefinition.ApiVersion == "2021-10-01-preview"
	return serviceMatches && apiVersionMatches
}

func (w workaroundStreamAnalytics27577) Name() string {
	return "StreamAnalytics / 27577"
}

func (w workaroundStreamAnalytics27577) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	apiResourcesToFix := []string{
		"StreamingJobs",
	}
	// API version 2021-10-01-preview and (presumably) later contain the full `StreamingJob` object - however
	// API version `2020-03-01` doesn't define it
	if apiDefinition.ApiVersion != "2020-03-01" {
		apiResourcesToFix = append(apiResourcesToFix, "Subscriptions")
	}

	for _, apiResource := range apiResourcesToFix {
		resource, ok := apiDefinition.Resources[apiResource]
		if !ok {
			return nil, fmt.Errorf("expected to find the API Resource %q but didn't", apiResource)
		}

		model, ok := resource.Models["StreamingJob"]
		if !ok {
			return nil, fmt.Errorf("expected the API Resource %q to contain Model `StreamingJob` it didn't", apiResource)
		}

		field, ok := model.Fields["Identity"]
		if !ok {
			return nil, fmt.Errorf("expected the Model `StreamingJob` to contain a field `Identity` but it didn't")
		}

		// update the reference to be a System OR UserAssigned identity
		field.ObjectDefinition = models.SDKObjectDefinition{
			Type: models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
		}
		if apiDefinition.ApiVersion == "2020-03-01" {
			// however API version 2020-03-01 only supports SystemAssigned
			field.ObjectDefinition.Type = models.SystemAssignedIdentitySDKObjectDefinitionType
		}

		model.Fields["Identity"] = field
		resource.Models["StreamingJob"] = model

		// then delete the standalone identity model
		delete(resource.Models, "Identity")

		apiDefinition.Resources[apiResource] = resource
	}
	return &apiDefinition, nil
}
