// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func Constants(first, second map[string]sdkModels.SDKConstant) (map[string]sdkModels.SDKConstant, error) {
	output := make(map[string]sdkModels.SDKConstant)
	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		existingConst, ok := output[k]
		if !ok {
			output[k] = v
			continue
		}

		if existingConst.Type != v.Type {
			return nil, fmt.Errorf("combining constant %q - multiple field types defined as %q and %q", k, string(existingConst.Type), string(v.Type))
		}

		vals, err := maps(existingConst.Values, v.Values)
		if err != nil {
			return nil, fmt.Errorf("combining values: %+v", err)
		}
		existingConst.Values = vals
		output[k] = existingConst
	}

	return output, nil
}
