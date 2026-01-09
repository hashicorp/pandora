// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// changesForApiVersions determines the changes between the different API versions for the provided Service.
func (d differ) changesForApiVersions(serviceName string, initial, updated map[string]models.APIVersion, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	apiVersions := uniqueKeys(initial, updated)
	for _, apiVersion := range apiVersions {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in API Version %q..", apiVersion))
		changesForApiVersion, err := d.changesForApiVersion(serviceName, apiVersion, initial, updated, includeNestedChangesWhenNew)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to API Version %q: %+v", apiVersion, err)
		}
		output = append(output, *changesForApiVersion...)
	}
	return &output, nil
}

// changesForApiVersion determines the changes between two different API Versions within a given Service.
func (d differ) changesForApiVersion(serviceName, apiVersion string, initial, updated map[string]models.APIVersion, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, inOldData := initial[apiVersion]
	updatedData, inUpdatedData := updated[apiVersion]
	if inOldData && !inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("API Version %q in Service %q is not present in the updated data", apiVersion, serviceName))
		output = append(output, changes.ApiVersionRemoved{
			ServiceName: serviceName,
			ApiVersion:  apiVersion,
		})
		// no point continuing to diff if it's gone
		return &output, nil
	}
	if !inOldData && inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("API Version %q in Service %q is a new API Version", apiVersion, serviceName))
		output = append(output, changes.ApiVersionAdded{
			ServiceName: serviceName,
			ApiVersion:  apiVersion,
		})
		// intentionally not returning here
	}

	// TODO: support diffing `initial.Generate` / `initial.Preview` and `initial.Source` if needed in the future

	// diff the API Resources within this API version - however note that the old version may not exist
	initialResources := make(map[string]models.APIResource)
	if inOldData {
		initialResources = oldData.Resources
	}
	changesInApiResources, err := d.changesForApiResources(serviceName, apiVersion, initialResources, updatedData.Resources, includeNestedChangesWhenNew)
	if err != nil {
		return nil, fmt.Errorf("detecting changes to the API Resources: %+v", err)
	}
	output = append(output, *changesInApiResources...)

	return &output, nil
}
