// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

// MapSDKOperations maps the ResourceOperations type from the repositories package into the V1 API Response Model.
func MapSDKOperations(input map[string]repositories.ResourceOperations) (*map[string]models.SDKOperation, error) {
	output := make(map[string]models.SDKOperation)
	for key, value := range input {
		mappedOperation, err := mapSDKOperation(value)
		if err != nil {
			return nil, fmt.Errorf("mapping Operation %q: %+v", key, err)
		}
		output[key] = *mappedOperation
	}
	return &output, nil
}

func mapSDKOperation(input repositories.ResourceOperations) (*models.SDKOperation, error) {
	output := models.SDKOperation{
		ContentType:                      input.ContentType,
		ExpectedStatusCodes:              input.ExpectedStatusCodes,
		LongRunning:                      input.LongRunning,
		Method:                           input.Method,
		ResourceIDName:                   input.ResourceIdName,
		FieldContainingPaginationDetails: input.FieldContainingPaginationDetails,
		URISuffix:                        input.UriSuffix,
	}

	if input.Options != nil {
		options, err := mapSDKOperationOptions(*input.Options)
		if err != nil {
			return nil, fmt.Errorf("mapping SDKOperationOption: %+v", err)
		}
		output.Options = *options
	}

	if input.RequestObject != nil {
		requestObject, err := mapSDKObjectDefinition(*input.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("mapping RequestObject: %+v", err)
		}

		output.RequestObject = requestObject
	}

	if input.ResponseObject != nil {
		responseObject, err := mapSDKObjectDefinition(*input.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("mapping ResponseObject: %+v", err)
		}

		output.ResponseObject = responseObject
	}

	return &output, nil
}
