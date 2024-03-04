// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapMetaDataToRepository(gitRevision *string, sourceDataType sdkModels.SourceDataType, sourceDataOrigin sdkModels.SourceDataOrigin) (*repositoryModels.MetaData, error) {
	dataType, ok := sourceDataTypesToRepository[sourceDataType]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Type %q", string(sourceDataType))
	}
	dataOrigin, ok := sourceDataOriginsToRepository[sourceDataOrigin]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(sourceDataOrigin))
	}

	return &repositoryModels.MetaData{
		DataSource:        dataType,
		SourceInformation: dataOrigin,
		GitRevision:       gitRevision,
	}, nil
}

var sourceDataTypesToRepository = map[sdkModels.SourceDataType]repositoryModels.DataSource{
	sdkModels.ResourceManagerSourceDataType: repositoryModels.AzureResourceManagerDataSource,
	sdkModels.MicrosoftGraphSourceDataType:  repositoryModels.MicrosoftGraphDataSource,
}
