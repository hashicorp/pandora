package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/differ"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) applyOverridesFromExistingData(data models.AzureApiDefinition, dataApiEndpoint *string, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	if dataApiEndpoint != nil {
		logger.Trace("Retrieving current Data and Schema from the Data API..")

		differ := differ.NewDiffer(*dataApiEndpoint, logger.Named("Data API Differ"))
		existingApiDefinitions, err := differ.RetrieveExistingService(data.ServiceName, data.ApiVersion)
		if err != nil {
			return nil, fmt.Errorf("retrieving data from Data API: %+v", err)
		}

		logger.Trace("Applying Overrides from the Existing API Definitions to the Parsed Swagger Data..")
		data, err = differ.ApplyFromExistingAPIDefinitions(*existingApiDefinitions, data, logger)
		if err != nil {
			return nil, fmt.Errorf("applying Overrides from the existing API Definitions: %+v", err)
		}

		logger.Trace("Applied Overrides from the Existing API Definitions to the Parsed Swagger Data.")
	} else {
		logger.Trace("Skipping retrieving current schema from Data API..")
	}

	return &data, nil
}
