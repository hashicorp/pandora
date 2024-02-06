// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"net/http"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundMachineLearning25142{}

// workaroundMachineLearning25142 works around the missed 202 status code.
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/25142
type workaroundMachineLearning25142 struct {
}

func (workaroundMachineLearning25142) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "MachineLearningServices"
	apiVersionMatches := apiDefinition.ApiVersion == "2023-04-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundMachineLearning25142) Name() string {
	return "MachineLearningServices / 25142"
}

func (workaroundMachineLearning25142) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["RegistryManagement"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource RegistryManagement")
	}

	operation, ok := resource.Operations["RegistriesCreateOrUpdate"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Operation RegistriesCreateOrUpdate")
	}

	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, http.StatusAccepted)
	resource.Operations["RegistriesCreateOrUpdate"] = operation

	apiDefinition.Resources["RegistryManagement"] = resource
	return &apiDefinition, nil
}
