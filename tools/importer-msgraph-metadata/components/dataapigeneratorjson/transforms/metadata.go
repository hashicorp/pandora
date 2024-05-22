// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapMetaDataToRepository(gitRevision *string, sourceDataType models.SourceDataType, sourceDataOrigin models.SourceDataOrigin) (*dataapimodels.MetaData, error) {
	dataType, ok := sourceDataTypesToRepository[sourceDataType]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Type %q", string(sourceDataType))
	}
	dataOrigin, ok := sourceDataOriginsToRepository[sourceDataOrigin]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(sourceDataOrigin))
	}

	return &dataapimodels.MetaData{
		DataSource:        dataType,
		SourceInformation: dataOrigin,
		GitRevision:       gitRevision,
	}, nil
}

var sourceDataTypesToRepository = map[models.SourceDataType]dataapimodels.DataSource{
	models.ResourceManagerSourceDataType: dataapimodels.AzureResourceManagerDataSource,
	models.MicrosoftGraphSourceDataType:  dataapimodels.MicrosoftGraphDataSource,
}
