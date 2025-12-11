// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// PurgeExistingData purges the existing Source Data for this SourceDataOrigin.
func (r *repositoryImpl) PurgeExistingData(sourceDataOrigin sdkModels.SourceDataOrigin) error {
	r.cacheLock.Lock()
	defer r.cacheLock.Unlock()

	directory, err := r.defaultDirectoryForSourceDataOrigin(sourceDataOrigin)
	if err != nil {
		return fmt.Errorf("determining the default directory for the Source Data Origin %q: %+v", sourceDataOrigin, err)
	}

	r.logger.Trace(fmt.Sprintf("Removing any existing Directory at %q..", *directory))
	_ = os.RemoveAll(*directory)

	r.logger.Trace(fmt.Sprintf("Re-creating the Directory at %q..", *directory))
	_ = os.MkdirAll(*directory, helpers.DirectoryPermissions)

	r.logger.Trace("Refreshing the cache..")
	if err := r.populateCacheInternal(); err != nil {
		return fmt.Errorf("refreshing the cache: %+v", err)
	}

	return nil
}
