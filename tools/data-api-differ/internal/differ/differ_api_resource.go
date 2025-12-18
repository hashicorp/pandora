// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// changesForApiResources determines the changes between the API Resources within the specified API Version.
func (d differ) changesForApiResources(serviceName, apiVersion string, initial, updated map[string]models.APIResource, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	apiResources := uniqueKeys(initial, updated)
	for _, apiResource := range apiResources {
		log.Logger.Trace(fmt.Sprintf("Detecting changes in API Resource %q..", apiResource))
		changesForApiResource, err := d.changesForApiResource(serviceName, apiVersion, apiResource, initial, updated, includeNestedChangesWhenNew)
		if err != nil {
			return nil, fmt.Errorf("detecting changes to the API Resource %q: %+v", apiResource, err)
		}
		output = append(output, *changesForApiResource...)
	}
	return &output, nil
}

// changesForApiResource determines the changes between two versions of the specified API Resource.
func (d differ) changesForApiResource(serviceName, apiVersion, apiResource string, initial, updated map[string]models.APIResource, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)

	oldData, inOldData := initial[apiResource]
	updatedData, inUpdatedData := updated[apiResource]
	if inOldData && !inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("API Resource %q in API Version %q in Service %q was removed", apiResource, apiVersion, serviceName))
		output = append(output, changes.ApiResourceRemoved{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
		})
		// no point continuing to diff if it's gone
		return &output, nil
	}
	if !inOldData && inUpdatedData {
		log.Logger.Trace(fmt.Sprintf("API Resource %q in API Version %q in Service %q is a new API Version", apiResource, apiVersion, serviceName))
		output = append(output, changes.ApiResourceAdded{
			ServiceName:  serviceName,
			ApiVersion:   apiVersion,
			ResourceName: apiResource,
		})
		if !includeNestedChangesWhenNew {
			return &output, nil
		}
		// Otherwise we'll include the full list of nested changes (for example any new Constants, Models,
		// Operations and Resource IDs contained within the [new] API Resource) - which will be a large
		// number of changes - but is needed for certain kinds of diff's (e.g. detecting new Static Identifiers).
	}

	// we then need to diff each of the individual components - however note that the old version may not exist
	initialConstants := make(map[string]models.SDKConstant)
	initialModels := make(map[string]models.SDKModel)
	initialOperations := make(map[string]models.SDKOperation)
	initialResourceIds := make(map[string]models.ResourceID)
	if inOldData {
		initialConstants = oldData.Constants
		initialModels = oldData.Models
		initialOperations = oldData.Operations
		initialResourceIds = oldData.ResourceIDs
	}
	log.Logger.Trace("Detecting changes to Constants..")
	changesInConstants := d.changesForConstants(serviceName, apiVersion, apiResource, initialConstants, updatedData.Constants)
	output = append(output, changesInConstants...)

	log.Logger.Trace("Detecting changes to Models..")
	changesInModels, err := d.changesForModels(serviceName, apiVersion, apiResource, initialModels, updatedData.Models)
	if err != nil {
		return nil, fmt.Errorf("determining the changes to Models: %+v", err)
	}
	output = append(output, *changesInModels...)

	log.Logger.Trace("Detecting changes to Operations..")
	changesInOperations, err := d.changesForOperations(serviceName, apiVersion, apiResource, initialOperations, updatedData.Operations, initialResourceIds, updatedData.ResourceIDs)
	if err != nil {
		return nil, fmt.Errorf("determining the changes to Operations: %+v", err)
	}
	output = append(output, *changesInOperations...)

	log.Logger.Trace("Detecting changes to Resource Ids..")
	changesInResourceIds := d.changesForResourceIds(serviceName, apiVersion, apiResource, initialResourceIds, updatedData.ResourceIDs)
	output = append(output, changesInResourceIds...)

	return &output, nil
}
