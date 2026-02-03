// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func (p *Pipeline) parseDataForService(input services.Service, threadId int) (*sdkModels.Service, error) {
	logging.Debugf("ThreadID: %d - Discovering Data for Service %q in %q..", threadId, input.Name, p.opts.RestAPISpecsDirectory)
	data, err := discovery.DiscoverForService(input, p.opts.RestAPISpecsDirectory, threadId)
	if err != nil {
		return nil, fmt.Errorf("discovering for Service %q: %+v", input.Name, err)
	}
	logging.Tracef("ThreadID: %d - Resource Provider is %q for the Service %q", threadId, *data.ResourceProvider, input.Name)
	logging.Debugf("ThreadID: %d - Discovering Data for Service %q in %q - Completed", threadId, input.Name, p.opts.RestAPISpecsDirectory)

	logging.Debugf("ThreadID: %d - Parsing Data for Service %q..", threadId, input.Name)
	service, err := apidefinitions.ParseService(*data, threadId)
	if err != nil {
		return nil, fmt.Errorf("parsing Data for Service %q: %+v", input.Name, err)
	}
	logging.Debugf("ThreadID: %d - Parsing Data for Service %q - Completed", threadId, input.Name)
	return service, nil
}
