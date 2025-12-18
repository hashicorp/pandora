// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type MetaData struct {
	GitRevision      *string
	SourceDataType   sdkModels.SourceDataType
	SourceDataOrigin sdkModels.SourceDataOrigin
}

func MapMetaDataFromRepository(input repositoryModels.MetaData) (*MetaData, error) {
	dataType, ok := sourceDataTypesFromRepository[input.DataSource]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Type %q", string(input.DataSource))
	}
	dataOrigin, ok := sourceDataOriginsFromRepository[input.SourceInformation]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(input.SourceInformation))
	}

	return &MetaData{
		GitRevision:      input.GitRevision,
		SourceDataType:   dataType,
		SourceDataOrigin: dataOrigin,
	}, nil
}

func MapMetaDataToRepository(input MetaData) (*repositoryModels.MetaData, error) {
	dataType, ok := sourceDataTypesToRepository[input.SourceDataType]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Type %q", string(input.SourceDataType))
	}
	dataOrigin, ok := sourceDataOriginsToRepository[input.SourceDataOrigin]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Source Data Origin %q", string(input.SourceDataOrigin))
	}

	return &repositoryModels.MetaData{
		DataSource:        dataType,
		SourceInformation: dataOrigin,
		GitRevision:       input.GitRevision,
	}, nil
}
