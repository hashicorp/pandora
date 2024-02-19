// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var sourceDataOrigins = map[repositories.ApiDefinitionSourceType]models.SourceDataOrigin{
	repositories.HandWrittenApiDefinitionsSource:                 models.HandWrittenSourceDataOrigin,
	repositories.MicrosoftGraphMetadataApiDefinitionsSource:      models.MicrosoftGraphMetaDataSourceDataOrigin,
	repositories.ResourceManagerRestApiSpecsApiDefinitionsSource: models.AzureRestAPISpecsSourceDataOrigin,
}

func MapSourceDataOrigin(input repositories.ApiDefinitionSourceType) (*models.SourceDataOrigin, error) {
	if v, ok := sourceDataOrigins[input]; ok {
		return pointer.To(v), nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for SourceDataOrigin %q", string(input))
}
