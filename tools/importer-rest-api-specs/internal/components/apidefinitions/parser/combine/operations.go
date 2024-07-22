// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
)

func combineOperations(operations map[string]sdkModels.SDKOperation, other map[string]sdkModels.SDKOperation) error {
	for k, v := range other {
		// if there's duplicate combineOperations named the same thing in different Swaggers, this is likely a data issue
		operation, ok := operations[k]
		if !ok {
			operations[k] = v
			continue
		}

		if ok, err := comparison.OperationsMatch(v, operation); !ok {
			return fmt.Errorf("differing Operations named %q. First: %+v / Second %+v / Error: %+v", k, v, operation, err)
		}
	}

	return nil
}
