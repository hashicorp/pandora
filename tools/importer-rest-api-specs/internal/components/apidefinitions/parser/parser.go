package parser

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/dataworkarounds"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func ParseAPIVersion(serviceName string, input discoveryModels.AvailableDataSetForAPIVersion) (*sdkModels.APIVersion, error) {
	apiResource := make(map[string]sdkModels.APIResource)

	// Firstly let's go through and process each of the Supplementary Files
	for _, filePath := range input.FilePathsContainingSupplementaryData {
		logging.Tracef("Processing Supplementary Data from file %q..", filePath)
	}

	// Next let's go through and process each of the API Definitions
	for _, filePath := range input.FilePathsContainingAPIDefinitions {
		logging.Tracef("Processing API Definitions from file %q..", filePath)
	}

	apiVersion := sdkModels.APIVersion{
		APIVersion: input.APIVersion,
		Generate:   true,
		Preview:    !input.ContainsStableAPIVersion,
		Resources:  apiResource,
		Source:     sdkModels.AzureRestAPISpecsSourceDataOrigin,
	}

	// Finally let's apply any data workarounds
	logging.Debugf("Applying Data Workarounds..")
	output, err := dataworkarounds.Apply(serviceName, apiVersion)
	if err != nil {
		return nil, fmt.Errorf("applying Data Workarounds for Service %q / API Version %q: %+v", serviceName, input.APIVersion, err)
	}
	logging.Debugf("Applying Data Workarounds - Complete.")

	return output, nil
}
