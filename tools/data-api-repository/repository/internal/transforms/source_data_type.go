// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var sourceDataTypesFromRepository = map[repositoryModels.DataSource]sdkModels.SourceDataType{
	repositoryModels.AzureResourceManagerDataSource: sdkModels.ResourceManagerSourceDataType,
	repositoryModels.MicrosoftGraphDataSource:       sdkModels.MicrosoftGraphSourceDataType,
}

var sourceDataTypesToRepository = map[sdkModels.SourceDataType]repositoryModels.DataSource{
	sdkModels.ResourceManagerSourceDataType: repositoryModels.AzureResourceManagerDataSource,
	sdkModels.MicrosoftGraphSourceDataType:  repositoryModels.MicrosoftGraphDataSource,
}
