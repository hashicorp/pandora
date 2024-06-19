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

	// PurgeExistingData purges the existing Source Data for this SourceDataOrigin.
	PurgeExistingData(sourceDataOrigin sdkModels.SourceDataOrigin) error

	// RemoveService removes any existing API Definitions for the Service specified in opts.
	RemoveService(opts RemoveServiceOptions) error

	// SaveService persists the API Definitions for the Service specified in opts.
	SaveService(opts SaveServiceOptions) error
}
