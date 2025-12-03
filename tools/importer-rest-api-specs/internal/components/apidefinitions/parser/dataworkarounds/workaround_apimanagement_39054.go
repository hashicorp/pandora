// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundApiManagement39054{}

// workaroundApiManagement39054 works around WorkspaceApi_Delete returning 202 status code
// and being a long-running operation but not marked as such in the API definition.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/39054
type workaroundApiManagement39054 struct{}

func (workaroundApiManagement39054) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "ApiManagement"
	apiVersionMatches := apiVersion.APIVersion == "2024-05-01"
	return serviceMatches && apiVersionMatches
}

func (workaroundApiManagement39054) Name() string {
	return "ApiManagement / 39054"
}

func (workaroundApiManagement39054) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Api"]
	if !ok {
		return nil, errors.New("expected a resource named `Api` but didn't get one")
	}

	operation, ok := resource.Operations["WorkspaceApiDelete"]
	if !ok {
		return nil, errors.New("expected an operation named `WorkspaceApiDelete` but didn't get one")
	}

	if operation.LongRunning {
		return nil, fmt.Errorf("expected operation WorkspaceApiDelete to not be marked as `LongRunning`. The workaround for this operation should be removed")
	}

	operation.LongRunning = true
	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, http.StatusAccepted)

	resource.Operations["WorkspaceApiDelete"] = operation
	input.Resources["Api"] = resource

	return &input, nil
}
