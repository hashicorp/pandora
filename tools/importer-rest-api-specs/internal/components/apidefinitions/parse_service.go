// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package apidefinitions

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func ParseService(input discoveryModels.AvailableDataSet, threadId int) (*sdkModels.Service, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if ignore.Services(input.ServiceName) {
		logging.Debugf("ThreadID: %d - Service %q should be ignored - skipping", threadId, input.ServiceName)
		return nil, nil
	}

	logging.Infof("ThreadID: %d - Parsing Data for Service %q..", threadId, input.ServiceName)
	apiVersions := make(map[string]sdkModels.APIVersion)

	for apiVersionName, dataSet := range input.DataSetsForAPIVersions {
		logging.Infof("ThreadID: %d - Parsing Data for %q API Version %q..", threadId, input.ServiceName, apiVersionName)
		parsed, err := parseAPIVersion(input.ServiceName, dataSet, input.ResourceProvider)
		if err != nil {
			return nil, fmt.Errorf("parsing %q API Version %q: %+v", input.ServiceName, apiVersionName, err)
		}

		apiVersions[apiVersionName] = *parsed
		logging.Infof("ThreadID: %d - Parsing Data for API Version %q - Completed", threadId, apiVersionName)
	}

	logging.Infof("ThreadID: %d - Parsing Data for Service %q - Completed", threadId, input.ServiceName)
	return &sdkModels.Service{
		APIVersions:         apiVersions,
		Generate:            true,
		Name:                input.ServiceName,
		ResourceProvider:    input.ResourceProvider,
		TerraformDefinition: nil, // built-up later in the process
	}, nil
}
