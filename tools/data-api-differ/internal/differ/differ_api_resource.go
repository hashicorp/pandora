package differ

import (
	"fmt"
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// changesForApiResources determines the changes between the API Resources within the specified API Version.
func (d differ) changesForApiResources(serviceName, apiVersion string, initial, updated map[string]dataapi.ApiResourceData, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
	output := make([]changes.Change, 0)
	apiResources := d.uniqueApiResources(initial, updated)
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
func (d differ) changesForApiResource(serviceName, apiVersion, apiResource string, initial, updated map[string]dataapi.ApiResourceData, includeNestedChangesWhenNew bool) (*[]changes.Change, error) {
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
		// Otherwise we intentionally don't returning here to return the full output - needed to detect any new
		// Static Identifiers found within the Resource ID Segments
	}

	// we then need to diff each of the individual components - however note that the old version may not exist
	// TODO: switch to using the updated types once in the SDK
	initialConstants := make(map[string]resourcemanager.ConstantDetails)
	initialModels := make(map[string]resourcemanager.ModelDetails)
	initialOperations := make(map[string]resourcemanager.ApiOperation)
	initialResourceIds := make(map[string]resourcemanager.ResourceIdDefinition)
	if inOldData {
		initialConstants = oldData.Constants
		initialModels = oldData.Models
		initialOperations = oldData.Operations
		initialResourceIds = oldData.ResourceIds
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
	changesInOperations, err := d.changesForOperations(serviceName, apiVersion, apiResource, initialOperations, updatedData.Operations, initialResourceIds, updatedData.ResourceIds)
	if err != nil {
		return nil, fmt.Errorf("determining the changes to Operations: %+v", err)
	}
	output = append(output, *changesInOperations...)

	log.Logger.Trace("Detecting changes to Resource Ids..")
	changesInResourceIds := d.changesForResourceIds(serviceName, apiVersion, apiResource, initialResourceIds, updatedData.ResourceIds)
	output = append(output, changesInResourceIds...)

	return &output, nil
}

// uniqueApiResources returns a unique, sorted list of API Resources from the keys of initial and updated.
func (d differ) uniqueApiResources(initial map[string]dataapi.ApiResourceData, updated map[string]dataapi.ApiResourceData) []string {
	uniqueNames := make(map[string]struct{})
	for name := range initial {
		uniqueNames[name] = struct{}{}
	}
	for name := range updated {
		uniqueNames[name] = struct{}{}
	}

	output := make([]string, 0)
	for k := range uniqueNames {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}
