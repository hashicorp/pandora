// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package repository

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// loadService is an internal function which retrieves the information for the specified Service.
// This function assumes that the necessary locks have already been obtained, done via the exported
// functions GetService and GetAllServices.
func (r *repositoryImpl) loadService(name string) (*sdkModels.Service, error) {
	info, ok := r.availableDataSources[name]
	if !ok {
		// if the Service doesn't exist then return nil so that upstream can return
		// a 404 rather than an error, as required.
		return nil, nil
	}

	r.logger.Trace("Retrieving the Common Types..")
	commonTypes, err := r.GetCommonTypes()
	if err != nil {
		return nil, fmt.Errorf("retrieving the Common Types in order to load Service %q: %+v", name, err)
	}

	r.logger.Trace(fmt.Sprintf("Parsing the Service Definition within %q..", info.workingDirectory))
	serviceDefinition, err := parseServiceDefinitionWithin(info.workingDirectory, r.logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Service Definition for the Service within %q: %+v", info.workingDirectory, err)
	}

	r.logger.Trace(fmt.Sprintf("Parsing the Service within %q..", info.workingDirectory))
	service, err := parseServiceWithin(info.workingDirectory, *serviceDefinition, *commonTypes, r.logger)
	if err != nil {
		return nil, fmt.Errorf("parsing the Service within %q: %+v", info.workingDirectory, err)
	}
	return service, nil
}
