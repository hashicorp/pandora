// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
)

func operations(first map[string]sdkModels.SDKOperation, second map[string]sdkModels.SDKOperation) (*map[string]sdkModels.SDKOperation, error) {
	output := make(map[string]sdkModels.SDKOperation, 0)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		// if there's duplicate operations named the same thing in different Swaggers, this is likely a data issue
		other, ok := output[k]
		if !ok {
			output[k] = v
			continue
		}

		if ok, err := comparison.OperationsMatch(v, other); !ok {
			return nil, fmt.Errorf("differing Operations named %q. First: %+v / Second %+v / Error: %+v", k, v, other, err)
		}
	}

	return &output, nil
}
