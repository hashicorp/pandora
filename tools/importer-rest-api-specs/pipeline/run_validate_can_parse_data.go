package pipeline

import (
	"fmt"
	"log"
	"os"
	"sync"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
)

func validateCanParseData(input RunInput, generationData []discovery.ServiceInput) error {
	var wg sync.WaitGroup
	for _, v := range generationData {
		wg.Add(1)
		go func(v discovery.ServiceInput) {
			logger := input.Logger.Named(fmt.Sprintf("Importer Service %q / API Version %q", v.ServiceName, v.ApiVersion))
			task := pipelineTask{}
			if _, err := task.parseDataForApiVersion(v, logger); err != nil {
				log.Printf("validating that data can be processed for Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
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
