// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapAPIVersionFromRepository(input repositoryModels.ApiVersionDefinition, apiResources map[string]sdkModels.APIResource) (*sdkModels.APIVersion, error) {
	dataOrigin, ok := sourceDataOriginsFromRepository[input.Source]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(input.Source))
	}

	return &sdkModels.APIVersion{
		APIVersion: input.ApiVersion,
		Generate:   input.Generate,
		Preview:    input.IsPreview,
		Resources:  apiResources,
		Source:     dataOrigin,
	}, nil
}

func MapAPIVersionToRepository(input sdkModels.APIVersion) (*repositoryModels.ApiVersionDefinition, error) {
	dataOrigin, ok := sourceDataOriginsToRepository[input.Source]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(input.Source))
	}

	apiResourceNames := make([]string, 0)
	for name, value := range input.Resources {
		// skip ones which are filtered out
		if len(value.Operations) == 0 {
			continue
		}
		apiResourceNames = append(apiResourceNames, name)
	}
	sort.Strings(apiResourceNames)

	versionDefinition := repositoryModels.ApiVersionDefinition{
		ApiVersion: input.APIVersion,
		IsPreview:  input.Preview,
		Generate:   input.Generate,
		Resources:  apiResourceNames,
		Source:     dataOrigin,
	}

	return &versionDefinition, nil
}
