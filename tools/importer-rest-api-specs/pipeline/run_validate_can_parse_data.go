// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"log"
	"os"
	"sync"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func validateCanParseData(generationData []discovery.ServiceInput) error {
	var wg sync.WaitGroup
	for _, v := range generationData {
		wg.Add(1)
		go func(v discovery.ServiceInput) {
			logging.Infof("Importer Service %q / API Version %q", v.ServiceName, v.ApiVersion)
			task := pipelineTask{}
			if _, err := task.parseDataForApiVersion(v); err != nil {
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
