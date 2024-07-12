// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
)

func resourceIds(first, second map[string]sdkModels.ResourceID) (*map[string]sdkModels.ResourceID, error) {
	output := make(map[string]sdkModels.ResourceID)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		// if there's duplicate Resource ID's named the same thing in different Swaggers, this is likely a data issue
		otherVal, ok := output[k]
		if ok && !comparison.ResourceIDsMatch(v, otherVal) {
			return nil, fmt.Errorf("duplicate Resource ID named %q (First %q / Second %q)", k, sdkHelpers.DisplayValueForResourceID(v), sdkHelpers.DisplayValueForResourceID(otherVal))
		}

		output[k] = v
	}

	return &output, nil
}
