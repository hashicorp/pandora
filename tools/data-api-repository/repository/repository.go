// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repository

import "github.com/hashicorp/go-hclog"

// Repository is an interface defining how to load and save API Definitions from disk.
// This interface is designed to allow the implementation to be switched out for testing purposes if needed.
type Repository interface {
	// PurgeExistingDefinitions removes any existing API Definitions.
	PurgeExistingDefinitions(opts PurgeExistingDefinitionsOptions) error

	// SaveCommonTypes persists the Common Types Definitions.
	SaveCommonTypes(opts SaveCommonTypesOptions) error

	// SaveService persists the API Definitions for the Service specified in opts.
	SaveService(opts SaveServiceOptions) error

	// TODO: LoadService
	// TODO: LoadServices
}

// NewRepository returns an instance of Repository configured for the working directory.
func NewRepository(workingDirectory string, logger hclog.Logger) Repository {
	return repositoryImpl{
		logger:           logger,
		workingDirectory: workingDirectory,
	}
}

var _ Repository = &repositoryImpl{}

type repositoryImpl struct {
	// logger is an instance of the logger which should be used for logging purposes
	logger hclog.Logger

	// workingDirectory specifies the directory where the API Definitions exist/should be written to.
	// This is the path to the `./api-definitions` directory.
	workingDirectory string
}
