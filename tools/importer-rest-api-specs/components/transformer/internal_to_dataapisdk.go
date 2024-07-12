// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transformer

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// NOTE: this file contains temporary glue code to enable refactoring this tool gradually, component-by-component.

func MapInternalTypesToDataAPISDKTypes(serviceName string, inputApiVersions []importerModels.AzureApiDefinition, resourceProvider *string) (*sdkModels.Service, error) {
	apiVersions := make(map[string]sdkModels.APIVersion)

	logging.Debugf("Mapping API Versions..")
	for _, item := range inputApiVersions {
		logging.Tracef("Mapping Service %q / API Version %q", item.ServiceName, item.ApiVersion)
		mapped, err := mapInternalAPIVersionTypeToDataAPISDKType(item.ApiVersion, item)
		if err != nil {
			return nil, fmt.Errorf("mapping API Version %q: %+v", item.ApiVersion, err)
		}

		if mapped == nil {
			// handle there being only Constants and Models but no data
			continue
		}

		apiVersions[item.ApiVersion] = *mapped
	}

	output := sdkModels.Service{
		APIVersions:      apiVersions,
		Generate:         true,
		Name:             serviceName,
		ResourceProvider: resourceProvider,
	}

	return &output, nil
}

func mapInternalAPIVersionTypeToDataAPISDKType(apiVersion string, input importerModels.AzureApiDefinition) (*sdkModels.APIVersion, error) {
	resources := make(map[string]sdkModels.APIResource)

	for apiResource, apiResourceDetails := range input.Resources {
		// Skip outputting APIResources containing only Constants/Models
		// since these aren't usable without Operations
		if len(apiResourceDetails.Operations) == 0 {
			continue
		}

		resources[apiResource] = sdkModels.APIResource{
			Constants:   apiResourceDetails.Constants,
			Models:      apiResourceDetails.Models,
			Operations:  apiResourceDetails.Operations,
			ResourceIDs: apiResourceDetails.ResourceIDs,
		}
	}

	// if all of the APIResources have been filtered out, let's ignore this APIVersion
	if len(resources) == 0 {
		return nil, nil
	}

	return &sdkModels.APIVersion{
		APIVersion: apiVersion,
		Generate:   true,
		Preview:    input.IsPreviewVersion(),
		Resources:  resources,
		Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
	}, nil
}
