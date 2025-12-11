// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (r *repositoryImpl) populateCacheInternal() error {
	r.logger.Trace("Refreshing the cache of Available Services..")
	availableDataSources, err := populateAvailableServicesCache(r.workingDirectory, r.sourceDataType, r.serviceNamesToLimitTo, r.logger)
	if err != nil {
		return fmt.Errorf("populating the Available Services: %+v", err)
	}
	r.availableDataSources = *availableDataSources

	commonTypes, err := discoverCommonTypesWithin(r.workingDirectory, r.sourceDataType, r.logger)
	if err != nil {
		return fmt.Errorf("populating the Common Types: %+v", err)
	}
	r.cachedCommonTypes = *commonTypes

	return nil
}

func populateAvailableServicesCache(workingDirectory string, sourceDataType sdkModels.SourceDataType, serviceNamesToLimitTo *[]string, logger hclog.Logger) (*map[string]availableService, error) {
	availableDataSources, err := discoverAvailableSourceDataWithin(workingDirectory, sourceDataType, logger)
	if err != nil {
		return nil, fmt.Errorf("discovering the available data sources within %q: %+v", workingDirectory, err)
	}

	if serviceNamesToLimitTo != nil && len(*serviceNamesToLimitTo) > 0 {
		filtered := make(map[string]availableService)

		for _, serviceName := range *serviceNamesToLimitTo {
			if v, ok := (*availableDataSources)[serviceName]; ok {
				filtered[serviceName] = v
			}
		}

		availableDataSources = &filtered
	}

	return availableDataSources, nil
}
