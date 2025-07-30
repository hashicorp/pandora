// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package apidefinitions

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

// parseAPIVersion parses the information for this APIVersion from the AvailableDataSetForAPIVersion.
func parseAPIVersion(serviceName string, input discoveryModels.AvailableDataSetForAPIVersion, resourceProvider *string) (*sdkModels.APIVersion, error) {
	// First we need to pull out a list of each of the Resource IDs within this API Version
	// This is required to ensure we have consistent naming of these across the API Version which
	// makes for a better user experience
	foundResourceIDs := resourceids.ParseResult{
		OperationIdsToParsedResourceIds: make(map[string]resourceids.ParsedOperation),
		NamesToResourceIDs:              make(map[string]sdkModels.ResourceID),
		Constants:                       make(map[string]sdkModels.SDKConstant),
	}
	for _, filePath := range input.FilePathsContainingAPIDefinitions {
		logging.Tracef("Loading the Resource IDs from %q..", filePath)
		parser, err := parser.NewAPIDefinitionsParser(filePath)
		if err != nil {
			return nil, fmt.Errorf("parsing the API Definitions within %q: %+v", filePath, err)
		}
		parsedResourceIds, err := parser.ParseResourceIds()
		if err != nil {
			return nil, fmt.Errorf("parsing the Resource IDs from %q: %+v", filePath, err)
		}
		if err := foundResourceIDs.Append(*parsedResourceIds); err != nil {
			return nil, fmt.Errorf("appending the Resource IDs from %q: %+v", filePath, err)
		}
		logging.Tracef("Load the Resource IDs from %q - Completed.", filePath)
	}
	logging.Tracef("Loaded a total of %d Resource IDs (with %d Constants)", len(foundResourceIDs.NamesToResourceIDs), len(foundResourceIDs.Constants))

	// Next let's go through and process each of the API Definitions to give us a map of APIResource name (key) to APIResource (value)
	apiResources := make(map[string]sdkModels.APIResource)
	for _, filePath := range input.FilePathsContainingAPIDefinitions {
		logging.Tracef("Processing API Definitions from file %q..", filePath)
		var err error
		if apiResources, err = parseAPIResourcesFromFile(filePath, serviceName, resourceProvider, apiResources, foundResourceIDs); err != nil {
			return nil, fmt.Errorf("parsing the APIResources from the API Definitions within %q: %+v", filePath, err)
		}

		logging.Tracef("There are now %d APIResources", len(apiResources))
		logging.Tracef("Processing API Definitions from file %q - Completed.", filePath)
	}

	// Normalize names of all operations, resource IDs, constants, models, and field names, ensuring they are
	// appropriately Pascal cased. We are doing this after building out all the resources, since some references
	// can get updated out-of-band and would subsequently be missed if we normalized immediately after parsing
	// each resource.
	for resourceName, resource := range apiResources {
		apiResources[resourceName] = cleanup.NormalizeAPIResource(resource)
	}

	// Now that we have a canonical list of resources - can we simplify the Operation names at all?
	for resourceName, resource := range apiResources {
		logging.Tracef("Simplifying operation names for resource %q", resourceName)
		updated := cleanup.SimplifyOperationNamesForAPIResource(resourceName, resource)
		apiResources[resourceName] = updated
	}

	apiVersion := sdkModels.APIVersion{
		APIVersion: input.APIVersion,
		Generate:   true,
		Preview:    !input.ContainsStableAPIVersion,
		Resources:  apiResources,
		Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
	}

	// Next let's apply any data workarounds
	logging.Debug("Applying Data Workarounds..")
	withFixesApplied, err := dataworkarounds.Apply(serviceName, apiVersion)
	if err != nil {
		return nil, fmt.Errorf("applying Data Workarounds for Service %q / API Version %q: %+v", serviceName, input.APIVersion, err)
	}
	logging.Debug("Applying Data Workarounds - Complete.")

	// Finally let's remove any unused items
	logging.Debug("Removing unused items..")
	output := cleanup.RemoveUnusedItems(*withFixesApplied)
	logging.Debug("Removing unused items - Complete.")

	return &output, nil
}
