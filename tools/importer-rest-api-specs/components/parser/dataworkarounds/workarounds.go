package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var workarounds = []workaround{
	workaroundAuthorization25080{},
	workaroundDigitalTwins25120{},
	workaroundAutomation25108{},
	workaroundAutomation25435{},
	workaroundBatch21291{},
	workaroundContainerService21394{},
	workaroundDataFactory23013{},
	workaroundDevCenter26189{},
	workaroundHDInsight26838{},
	workaroundLoadTest20961{},
	workaroundRedis22407{},
	workaroundMachineLearning25142{},

	workaroundRecoveryServicesSiteRecovery26680{},

	// @tombuildsstuff: this is an odd place for this however this allows working around inconsistencies in the Swagger
	// we should look at moving this into the `resourceids` package when time allows.
	workaroundInconsistentlyDefinedSegments{},

	// @tombuildsstuff: we also have to account for package names which aren't valid in Go:
	workaroundInvalidGoPackageNames{},

	workaroundOperationalinsights26678{},
}

func ApplyWorkarounds(input []models.AzureApiDefinition, logger hclog.Logger) (*[]models.AzureApiDefinition, error) {
	output := make([]models.AzureApiDefinition, 0)
	logger.Trace("Processing Swagger Data Workarounds..")
	for _, item := range input {
		for _, fix := range workarounds {
			if fix.IsApplicable(&item) {
				logger.Trace(fmt.Sprintf("Applying Swagger Data Workaround %q to Service %q / API Version %q", fix.Name(), item.ServiceName, item.ApiVersion))
				updated, err := fix.Process(item)
				if err != nil {
					return nil, fmt.Errorf("applying Swagger Data Workaround %q to Service %q / API Version %q: %+v", fix.Name(), item.ServiceName, item.ApiVersion, err)
				}

				item = *updated
			}
		}
		output = append(output, item)
	}

	return &output, nil
}
