// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var sourceDataOriginsFromRepository = map[repositoryModels.ApiDefinitionsSource]sdkModels.SourceDataOrigin{
	repositoryModels.AzureRestApiSpecsRepositoryApiDefinitionsSource:      sdkModels.AzureRestAPISpecsSourceDataOrigin,
	repositoryModels.MicrosoftGraphMetaDataRepositoryApiDefinitionsSource: sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
	repositoryModels.HandWrittenApiDefinitionsSource:                      sdkModels.HandWrittenSourceDataOrigin,
}

var sourceDataOriginsToRepository = map[sdkModels.SourceDataOrigin]repositoryModels.ApiDefinitionsSource{
	sdkModels.AzureRestAPISpecsSourceDataOrigin:      repositoryModels.AzureRestApiSpecsRepositoryApiDefinitionsSource,
	sdkModels.MicrosoftGraphMetaDataSourceDataOrigin: repositoryModels.MicrosoftGraphMetaDataRepositoryApiDefinitionsSource,
	sdkModels.HandWrittenSourceDataOrigin:            repositoryModels.HandWrittenApiDefinitionsSource,
}
