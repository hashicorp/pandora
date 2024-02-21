// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapAPIVersionToRepository(apiVersion string, isPreview bool, resources map[string]models.APIResource, sourceDataOrigin models.SourceDataOrigin, shouldGenerate bool) (*dataapimodels.ApiVersionDefinition, error) {
	dataOrigin, ok := sourceDataOriginsToRepository[sourceDataOrigin]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(sourceDataOrigin))
	}

	versionDefinition := dataapimodels.ApiVersionDefinition{
		ApiVersion: apiVersion,
		IsPreview:  isPreview,
		Generate:   shouldGenerate,
		Source:     dataOrigin,
	}

	names := make([]string, 0)
	for name, value := range resources {
		// skip ones which are filtered out
		if len(value.Operations) == 0 {
			continue
		}
		names = append(names, name)
	}
	sort.Strings(names)

	versionDefinition.Resources = names

	return &versionDefinition, nil
}

var sourceDataOriginsToRepository = map[models.SourceDataOrigin]dataapimodels.ApiDefinitionsSource{
	models.AzureRestAPISpecsSourceDataOrigin:      dataapimodels.AzureRestApiSpecsRepositoryApiDefinitionsSource,
	models.MicrosoftGraphMetaDataSourceDataOrigin: dataapimodels.MicrosoftGraphMetaDataRepositoryApiDefinitionsSource,
	models.HandWrittenSourceDataOrigin:            dataapimodels.HandWrittenApiDefinitionsSource,
}
