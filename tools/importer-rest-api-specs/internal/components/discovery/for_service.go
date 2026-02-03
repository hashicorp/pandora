// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

// DiscoverForService discovers the Available Data Set for the specified Service.
// `workingDirectory` is the path to the `Azure/azure-rest-api-specs` dependency
// `service` is the Configuration File for the Service which should be loaded.
func DiscoverForService(service services.Service, workingDirectory string, threadID int) (*models.AvailableDataSet, error) {
	logging.Infof("ThreadID: %d - Discovering API Definitions for Service %q within %q", threadID, service.Name, workingDirectory)
	specificationsDirectory := filepath.Join(workingDirectory, "specification")
	serviceDirectory, err := filepath.Abs(filepath.Join(specificationsDirectory, service.Directory))
	if err != nil {
		return nil, fmt.Errorf("determining the absolute path to Service %q in %q: %+v", serviceDirectory, workingDirectory, err)
	}

	// pull out a list of files within the Service directory
	filePaths, err := filesWithinDirectory(serviceDirectory)
	if err != nil {
		return nil, fmt.Errorf("retrieving a list of files within %q: %+v", workingDirectory, err)
	}

	// determine the Resource Provider for this Resource Manager service
	resourceProvider := pointer.From(service.ResourceProvider)
	if service.ResourceProvider == nil {
		logging.Infof("ThreadID: %d - Determining the Resource Provider for Service %q in %q", threadID, service.Name, serviceDirectory)
		resourceProviderName, err := determineDefaultResourceProviderForService(serviceDirectory, service.Name, *filePaths)
		if err != nil {
			return nil, fmt.Errorf("determining the Resource Provider for Service %q in %q: %+v", service.Name, serviceDirectory, err)
		}
		resourceProvider = *resourceProviderName
	}
	logging.Tracef("ThreadID: %d - Identified %q as the Resource Provider for the Service %q", threadID, resourceProvider, service.Name)

	// now that we know the files within this directory, iterate over the API versions we're expecting and pull out those files
	dataSetsForAPIVersions := make(map[string]models.AvailableDataSetForAPIVersion)
	for _, apiVersion := range service.Available {
		// NOTE: information on the available paths can be found in the README for this package
		logging.Infof("ThreadID: %d - Discovering the available Data Set for API Version %q", threadID, apiVersion)
		dataSet, err := discoverDataSetForAPIVersion(apiVersion, *filePaths)
		if err != nil {
			return nil, fmt.Errorf("discovering the Data Set for the API Version %q for Service %q: %+v", apiVersion, service.Name, err)
		}
		logging.Tracef("ThreadID: %d - Identified %d API Definitions for API Version %q", threadID, len(dataSet.FilePathsContainingAPIDefinitions), apiVersion)

		dataSetsForAPIVersions[apiVersion] = *dataSet
	}

	return &models.AvailableDataSet{
		ServiceName:            service.Name,
		DataSetsForAPIVersions: dataSetsForAPIVersions,
		ResourceProvider:       pointer.To(resourceProvider),
	}, nil
}
