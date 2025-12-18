// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// GetService returns the specified Service by its `name` if it exists.
// When the Service doesn't exist, `nil` will be returned.
func (r *repositoryImpl) GetService(name string) (*sdkModels.Service, error) {
	r.cacheLock.Lock()
	defer r.cacheLock.Unlock()

	service, exists := r.cachedServices[name]
	if !exists {
		// otherwise let's populate the cache
		svc, err := r.loadService(name)
		if err != nil {
			return nil, err
		}
		if svc == nil {
			return nil, nil
		}
		r.cachedServices[name] = *svc
		service = *svc
	}
	return &service, nil
}
