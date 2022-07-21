package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d Differ) ApplyFromExistingAPIDefinitions(existing []models.AzureApiDefinition, parsed models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	// we should work through and ensure that all Existing items are present within Parsed
	// Each of the Stages to apply can be found in ApplyStages()

	// TODO: apply these
	return nil, fmt.Errorf("TODO: implement ApplyFromExistingAPIDefinitions")
}
