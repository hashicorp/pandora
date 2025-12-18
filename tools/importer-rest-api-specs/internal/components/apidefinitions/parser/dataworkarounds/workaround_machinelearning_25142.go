// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundMachineLearning25142{}

// workaroundMachineLearning25142 works around the missed 202 status code.
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/25142
type workaroundMachineLearning25142 struct {
}

func (workaroundMachineLearning25142) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "MachineLearningServices"
	apiVersionMatches := apiVersion.APIVersion == "2023-04-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundMachineLearning25142) Name() string {
	return "MachineLearningServices / 25142"
}

func (workaroundMachineLearning25142) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["RegistryManagement"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource RegistryManagement")
	}

	operation, ok := resource.Operations["RegistriesCreateOrUpdate"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Operation RegistriesCreateOrUpdate")
	}

	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, http.StatusAccepted)
	resource.Operations["RegistriesCreateOrUpdate"] = operation

	input.Resources["RegistryManagement"] = resource
	return &input, nil
}
