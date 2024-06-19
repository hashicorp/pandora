// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"sync"

	"github.com/hashicorp/go-hclog"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// NewRepository returns an instance of Repository configured for the working directory.
func NewRepository(workingDirectory string, sourceDataType sdkModels.SourceDataType, serviceNamesToLimitTo *[]string, logger hclog.Logger) (Repository, error) {
	availableDataSources, err := populateAvailableServicesCache(workingDirectory, sourceDataType, serviceNamesToLimitTo, logger)
	if err != nil {
		return nil, err
	}

	return &repositoryImpl{
		availableDataSources:  *availableDataSources,
		cacheLock:             &sync.Mutex{},
		cachedServices:        make(map[string]sdkModels.Service),
		logger:                logger,
		serviceNamesToLimitTo: serviceNamesToLimitTo,
		sourceDataType:        sourceDataType,
		workingDirectory:      workingDirectory,
	}, nil
}

var _ Repository = &repositoryImpl{}

type repositoryImpl struct {
	// availableDataSources specifies the map of Service Name (key) to availableService (value)
	// representing the available data for this SourceDataType.
	availableDataSources map[string]availableService

	// cacheLock is a mutex used for populating items into the cache (cachedServices).
	cacheLock *sync.Mutex

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
