// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func APIResourcesWith(resources, other map[string]sdkModels.APIResource) error {
	for k, v := range other {
		resource, ok := resources[k]
		if !ok {
			resources[k] = v
			continue
		}

		constants, err := Constants(resource.Constants, v.Constants)
		if err != nil {
			return fmt.Errorf("combining constants: %+v", err)
		}
		resource.Constants = constants

		models, err := Models(resource.Models, v.Models)
		if err != nil {
			return fmt.Errorf("combining models: %+v", err)
		}
		resource.Models = models

		if err = combineOperations(resource.Operations, v.Operations); err != nil {
			return fmt.Errorf("combining operations: %+v", err)
		}

		if err = combineResourceIds(resource.ResourceIDs, v.ResourceIDs); err != nil {
			return fmt.Errorf("combining resource ids: %+v", err)
		}

		resources[k] = resource
	}

	return nil
}
