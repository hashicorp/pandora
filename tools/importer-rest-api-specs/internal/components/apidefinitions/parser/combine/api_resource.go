// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func APIResource(first, other sdkModels.APIResource) (*sdkModels.APIResource, error) {
	constants, err := Constants(first.Constants, other.Constants)
	if err != nil {
		return nil, fmt.Errorf("combining constants: %+v", err)
	}
	first.Constants = *constants

	models, err := Models(first.Models, other.Models)
	if err != nil {
		return nil, fmt.Errorf("combining models: %+v", err)
	}
	first.Models = *models

	combinedOperations, err := operations(first.Operations, other.Operations)
	if err != nil {
		return nil, fmt.Errorf("combining operations: %+v", err)
	}
	first.Operations = *combinedOperations

	combinedResourceIDs, err := resourceIds(first.ResourceIDs, other.ResourceIDs)
	if err != nil {
		return nil, fmt.Errorf("combining resource ids: %+v", err)
	}
	first.ResourceIDs = *combinedResourceIDs

	return &first, nil
}
