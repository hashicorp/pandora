// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// changesForServices determines the changes between the initial and updated set of Services.
func (d differ) changesForServices(initial, updated map[string]models.Service, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	// first pull out a unique list of Service names
	log.Logger.Info("Identifying a unique list of Service Names..")
	serviceNames := uniqueKeys(initial, updated)
	for _, serviceName := range serviceNames {
		log.Logger.Info(fmt.Sprintf("Detecting changes in Service %q..", serviceName))
		changesForService, err := d.changesForService(serviceName, initial, updated, includeNestedChangesWhenNew)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to the Service %q: %+v", serviceName, err)
		}
		output = append(output, *changesForService...)
	}
	return &output, nil
}

// changesForService determines the changes between two different Services.
func (d differ) changesForService(serviceName string, initial, updated map[string]models.Service, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	oldData, inOldData := initial[serviceName]
	updatedData, inUpdatedData := updated[serviceName]

	// if it's been removed
	if inOldData && !inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Service %q was removed", serviceName))
		output = append(output, changes.ServiceRemoved{
			ServiceName: serviceName,
		})
		// no point continuing to diff if it's gone
		return &output, nil
	}

	// is it a new Service?
	if !inOldData && inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("Service %q was added", serviceName))
		output = append(output, changes.ServiceAdded{
			ServiceName: serviceName,
		})
		// intentionally not returning here
	}

	// TODO: support raising if `Generate`, `ResourceProvider` or `TerraformPackageName` changes if required

	// the old set may not necessarily exist
	var oldApiVersions map[string]models.APIVersion
	if inOldData {
		oldApiVersions = oldData.APIVersions
	}
	changesForApiVersions, err := d.changesForApiVersions(serviceName, oldApiVersions, updatedData.APIVersions, includeNestedChangesWhenNew)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to the API Versions: %+v", err)
	}
	output = append(output, *changesForApiVersions...)

	return &output, nil
}
