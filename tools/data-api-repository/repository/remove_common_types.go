// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"os"
	"path/filepath"

	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type RemoveCommonTypesOptions struct {
	// SourceDataOrigin specifies the SourceDataOrigin for which the Common Types should be removed
	SourceDataOrigin models.SourceDataOrigin
}

// RemoveCommonTypes removes the existing Common Types for the current SourceDataType/SourceDataOrigin combination.
func (r *repositoryImpl) RemoveCommonTypes(opts RemoveCommonTypesOptions) error {
	r.cacheLock.Lock()
	defer r.cacheLock.Unlock()

	dataDirectory, err := r.defaultDirectoryForSourceDataOrigin(opts.SourceDataOrigin)
	if err != nil {
		return fmt.Errorf("determining the default data directory for the Source Data Origin %q: %+v", opts.SourceDataOrigin, err)
	}

	// We'll remove all Common Types for now (i.e. all versions), but it might be worth revisiting this as needed
	commonTypesDirectory := filepath.Join(*dataDirectory, helpers.CommonTypesDirectoryName)
	r.logger.Info("Removing any existing Common Types Directory..")
	_ = os.RemoveAll(commonTypesDirectory)
	r.logger.Info("Recreating the Common Types Directory..")
	_ = os.MkdirAll(commonTypesDirectory, helpers.DirectoryPermissions)

	r.logger.Trace("Refreshing the cache..")
	if err := r.populateCacheInternal(); err != nil {
		return fmt.Errorf("refreshing the Cache: %+v", err)
	}

	return nil
}
