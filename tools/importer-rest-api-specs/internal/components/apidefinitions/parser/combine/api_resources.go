// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func APIResourcesWith(first, other map[string]sdkModels.APIResource) (*map[string]sdkModels.APIResource, error) {
	resources := make(map[string]sdkModels.APIResource)
	for k, v := range first {
		resources[k] = v
	}

	for k, v := range other {
		existing, ok := resources[k]
		if !ok {
			resources[k] = v
			continue
		}

		constants, err := Constants(existing.Constants, v.Constants)
		if err != nil {
			return nil, fmt.Errorf("combining constants: %+v", err)
		}
		existing.Constants = *constants

		models, err := Models(existing.Models, v.Models)
		if err != nil {
			return nil, fmt.Errorf("combining models: %+v", err)
		}
		existing.Models = *models

		operations, err := operations(existing.Operations, v.Operations)
		if err != nil {
			return nil, fmt.Errorf("combining operations: %+v", err)
		}
		existing.Operations = *operations

		resourceIds, err := resourceIds(existing.ResourceIDs, v.ResourceIDs)
		if err != nil {
			return nil, fmt.Errorf("combining resource ids: %+v", err)
		}
		existing.ResourceIDs = *resourceIds

		resources[k] = existing
	}

	return &resources, nil
}
