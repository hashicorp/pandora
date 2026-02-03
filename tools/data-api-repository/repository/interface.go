// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// Repository is an interface defining how to load and save API Definitions from disk.
// Each Repository instance should be scoped to a single SourceDataType (which may in turn support
// multiple SourceDataOrigins).
// This interface is designed to allow the implementation to be switched out for testing purposes if needed.
type Repository interface {
	// GetService returns the specified Service by its `name` if it exists.
	// When the Service doesn't exist, `nil` will be returned.
	GetService(name string) (*sdkModels.Service, error)

	// GetAllServices returns all the Services supported for this SourceDataType as a map of
	// Service Name (key) to Service (value).
	GetAllServices() (*map[string]sdkModels.Service, error)

	// GetCommonTypes returns all the Common Types (Constants and Models) for this SourceDataType
	// this returns a map of APIVersion (key) to CommonTypes (value).
	GetCommonTypes() (*map[string]sdkModels.CommonTypes, error)

	// PurgeExistingData purges the existing Source Data for this SourceDataOrigin.
	PurgeExistingData(sourceDataOrigin sdkModels.SourceDataOrigin) error

	// RemoveCommonTypes removes the existing Common Types for the current SourceDataType/SourceDataOrigin combination.
	RemoveCommonTypes(opts RemoveCommonTypesOptions) error

	// RemoveService removes any existing API Definitions for the Service specified in opts.
	RemoveService(opts RemoveServiceOptions) error

	// SaveCommonTypes persists the Common Types for the current SourceDataType/SourceDataOrigin combination.
	SaveCommonTypes(opts SaveCommonTypesOptions) error

	// SaveService persists the API Definitions for the Service specified in opts.
	SaveService(opts SaveServiceOptions, threadId int) error
}
