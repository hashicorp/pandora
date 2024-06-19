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

	// For Common Types we can just recreate the data directory for all of these, since doing this for
	// a single API Version feels not worthwhile?
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
