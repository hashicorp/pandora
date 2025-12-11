// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// GetAllServices returns all the Services supported for this SourceDataType as a map of
// Service Name (key) to Service (value).
func (r *repositoryImpl) GetAllServices() (*map[string]sdkModels.Service, error) {
	r.cacheLock.Lock()
	defer r.cacheLock.Unlock()

	output := make(map[string]sdkModels.Service)
	for serviceName := range r.availableDataSources {
		service, exists := r.cachedServices[serviceName]
		if !exists {
			// otherwise let's populate it in the cache
			svc, err := r.loadService(serviceName)
			if err != nil {
				return nil, err
			}
			if svc == nil {
				return nil, nil
			}
			r.cachedServices[serviceName] = *svc
			service = *svc
		}

		output[serviceName] = service
	}
	return &output, nil
}
