// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package apidefinitions

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func ParseService(input discoveryModels.AvailableDataSet) (*sdkModels.Service, error) {
	// Some Services have been deprecated or should otherwise be ignored - check before proceeding
	if ignore.Services(input.ServiceName) {
		logging.Debugf("Service %q should be ignored - skipping", input.ServiceName)
		return nil, nil
	}

	logging.Infof("Parsing Data for Service %q..", input.ServiceName)
	apiVersions := make(map[string]sdkModels.APIVersion)

	for apiVersionName, dataSet := range input.DataSetsForAPIVersions {
		logging.Infof("Parsing Data for API Version %q..", apiVersionName)
		parsed, err := parseAPIVersion(input.ServiceName, dataSet, input.ResourceProvider)
		if err != nil {
			return nil, fmt.Errorf("parsing API Version %q: %+v", apiVersionName, err)
		}

		apiVersions[apiVersionName] = *parsed
		logging.Infof("Parsing Data for API Version %q - Completed", apiVersionName)
	}

	logging.Infof("Parsing Data for Service %q - Completed", input.ServiceName)
	return &sdkModels.Service{
		APIVersions:         apiVersions,
		Generate:            true,
		Name:                input.ServiceName,
		ResourceProvider:    input.ResourceProvider,
		TerraformDefinition: nil, // built-up later in the process
	}, nil
}
