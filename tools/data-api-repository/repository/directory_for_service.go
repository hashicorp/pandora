// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"
	"path/filepath"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (r *repositoryImpl) directoryForService(serviceName string, sourceDataOrigin sdkModels.SourceDataOrigin) (*string, error) {
	// use the existing directory if we've parsed it
	if dataSource, ok := r.availableDataSources[serviceName]; ok {
		if dataSource.sourceDataOrigin != sourceDataOrigin {
			return nil, fmt.Errorf("an existing Service named %q uses the SourceDataOrigin %q but found a duplicate for the SourceDataOrigin %q", serviceName, dataSource.sourceDataOrigin, sourceDataOrigin)
		}

		return &dataSource.workingDirectory, nil
	}

	// else fallback to the default ones
	path, err := r.defaultDirectoryForSourceDataOrigin(sourceDataOrigin)
	if err != nil {
		return nil, err
	}
	serviceDirectory := filepath.Join(*path, serviceName)
	return &serviceDirectory, nil
}

func (r *repositoryImpl) defaultDirectoryForSourceDataOrigin(sourceDataOrigin sdkModels.SourceDataOrigin) (*string, error) {
	sourceDataOriginsToDefaultDirectories, ok := defaultDataDirectories[r.sourceDataType]
	if !ok {
		return nil, fmt.Errorf("missing a default directory for SourceDataType %q", string(r.sourceDataType))
	}
	defaultDirectory, ok := sourceDataOriginsToDefaultDirectories[sourceDataOrigin]
	if !ok {
		return nil, fmt.Errorf("missing a default directory for SourceDataOrigin %q within SourceDataType %q", sourceDataOrigin, string(r.sourceDataType))
	}
	dataDirectory := filepath.Join(r.workingDirectory, defaultDirectory)
	return &dataDirectory, nil
}

var defaultDataDirectories = map[sdkModels.SourceDataType]map[sdkModels.SourceDataOrigin]string{
	// NOTE: the ordering matters here, we want to load the imported data before any handwritten data
	// This is to ensure that if the imported data contains a Discriminated Parent Type that we can add
	// additional Implementations within the HandWritten Data which inherits from that, so this is automatically
	// unmarshalled as required.
	sdkModels.MicrosoftGraphSourceDataType: {
		sdkModels.MicrosoftGraphMetaDataSourceDataOrigin: "microsoft-graph",
	},
	sdkModels.ResourceManagerSourceDataType: {
		sdkModels.AzureRestAPISpecsSourceDataOrigin: "resource-manager",
		sdkModels.HandWrittenSourceDataOrigin:       "handwritten-resource-manager",
	},
	sdkModels.DataPlaneSourceDataType: {
		sdkModels.AzureRestAPISpecsSourceDataOrigin: "data-plane",
	},
}
