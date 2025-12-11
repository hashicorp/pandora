// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"sync"

	"github.com/hashicorp/go-hclog"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// NewRepository returns an instance of Repository configured for the working directory.
func NewRepository(workingDirectory string, sourceDataType sdkModels.SourceDataType, serviceNamesToLimitTo *[]string, logger hclog.Logger) (Repository, error) {
	repo := &repositoryImpl{
		availableDataSources:  make(map[string]availableService),
		cacheLock:             &sync.Mutex{},
		cachedServices:        make(map[string]sdkModels.Service),
		logger:                logger,
		serviceNamesToLimitTo: serviceNamesToLimitTo,
		sourceDataType:        sourceDataType,
		workingDirectory:      workingDirectory,
	}

	repo.logger.Trace("Building the cache..")
	if err := repo.populateCacheInternal(); err != nil {
		return nil, fmt.Errorf("building the cache: %+v", err)
	}

	return repo, nil
}

var _ Repository = &repositoryImpl{}

type repositoryImpl struct {
	// availableDataSources specifies the map of Service Name (key) to availableService (value)
	// representing the available data for this SourceDataType.
	availableDataSources map[string]availableService

	// cacheLock is a mutex used for populating items into the cache (cachedServices).
	cacheLock *sync.Mutex

	// cachedCommonTypes is a cache containing the cached common types for this SourceDataType.
	// This is a map of APIVersion (Key) to CommonTypes (value) and is Optional
	cachedCommonTypes map[string]sdkModels.CommonTypes

	// cachedServices is a cache containing the cached information for this SourceDataType.
	// This is a map of Service Name (Key, which must be unique across all SourceDataOrigins
	// within this SourceDataType) to Service.
	cachedServices map[string]sdkModels.Service

	// logger is an instance of the logger which should be used for logging purposes.
	logger hclog.Logger

	// serviceNamesToLimitTo specifies the names of the only Services which we should load, this is used
	// when populating the cache of available Services
	serviceNamesToLimitTo *[]string

	// sourceDataType specifies the Source Data Type that this Repository instance is related to.
	sourceDataType sdkModels.SourceDataType

	// workingDirectory specifies the directory where the API Definitions exist/should be written to.
	// This is the path to the `./api-definitions` directory.
	workingDirectory string
}
