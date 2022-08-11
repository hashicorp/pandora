package pipeline

import (
	"fmt"
	"log"
	"os"
	"sync"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
)

func runImporter(input RunInput, generationData []discovery.ServiceInput, swaggerGitSha string) error {
	var wg sync.WaitGroup
	for _, v := range generationData {
		wg.Add(1)
		go func(v discovery.ServiceInput) {
			logger := input.Logger.Named(fmt.Sprintf("Importer Service %q / API Version %q", v.ServiceName, v.ApiVersion))

			task := pipelineTask{}
			logger.Trace("Task: Parsing Data..")
			data, err := task.parseDataForApiVersion(v, logger)
			if err != nil {
				logger.Error("parsing data for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				os.Exit(1)
				return
			}
			if data == nil {
				// e.g. service is ignored
				logger.Trace("no data returned - ignored etc - skipping")
				wg.Done()
				return
			}

			// generate the schema
			logger.Trace(fmt.Sprintf("generating Terraform Details for Service %q / Version %q", v.ServiceName, v.ApiVersion))
			terraformDetails, err := task.generateTerraformDetails(v, data, logger.Named("TerraformDetails"))
			if err != nil {
				logger.Error(fmt.Sprintf("generating Terraform Details for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err))
				wg.Done()
				os.Exit(1)
				return
			}
			// TODO: stuff n things @stephybun
			log.Printf("Got Stuff: %+v", terraformDetails)

			// build the tests
			logger.Trace(fmt.Sprintf("generating Terraform Tests for Service %q / Version %q", v.ServiceName, v.ApiVersion))
			terraformDetails, err = task.generateTerraformTests(v, *terraformDetails, logger.Named("TerraformTests"))
			if err != nil {
				logger.Error(fmt.Sprintf("generating Terraform Tests for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err))
				wg.Done()
				os.Exit(1)
				return
			}

			logger.Trace("Task: Applying Overrides from Existing Data..")
			data, err = task.applyOverridesFromExistingData(*data, input.DataApiEndpoint, logger)
			if err != nil {
				logger.Error("applying overrides for existing data for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				os.Exit(1)
				return
			}

			logger.Trace("Task: Generating Data API Definitions..")
			if err := task.generateApiDefinitions(v, *data, swaggerGitSha, logger); err != nil {
				log.Printf("generating API Definitions for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				os.Exit(1)
				return
			}

			wg.Done()
		}(v)
	}

	wg.Wait()
	return nil
}
