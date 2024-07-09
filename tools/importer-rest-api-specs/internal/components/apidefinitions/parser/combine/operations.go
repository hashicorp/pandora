// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func operations(first map[string]sdkModels.SDKOperation, second map[string]sdkModels.SDKOperation) (*map[string]sdkModels.SDKOperation, error) {
	output := make(map[string]sdkModels.SDKOperation, 0)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		// if there's duplicate operations named the same thing in different Swaggers, this is likely a data issue
		_, ok := output[k]
		if ok {
			return nil, fmt.Errorf("duplicate operations named %q", k)
		}

		output[k] = v
	}

	return &output, nil
}
