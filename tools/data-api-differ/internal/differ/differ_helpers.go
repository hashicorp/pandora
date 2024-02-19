// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// stringifySDKObjectDefinition returns a human readable, string version of this SDKObjectDefinition.
func (d differ) stringifySDKObjectDefinition(input models.SDKObjectDefinition) (*string, error) {
	return helpers.GolangTypeForSDKObjectDefinition(input, nil)
}

// stringifySDKOperationOptionObjectDefinition returns a human readable, string version of this Object Definition.
func (d differ) stringifySDKOperationOptionObjectDefinition(input models.SDKOperationOptionObjectDefinition) (*string, error) {
	return helpers.GolangTypeForSDKOperationOptionObjectDefinition(input)
}

// uniqueConstantNames returns a unique, sorted list of Keys from initial and updated.
func (d differ) uniqueKeys(initial, updated map[string]string) []string {
	uniqueNames := make(map[string]struct{})
	for name := range initial {
		uniqueNames[name] = struct{}{}
	}
	for name := range updated {
		uniqueNames[name] = struct{}{}
	}

	output := make([]string, 0)
	for k := range uniqueNames {
		output = append(output, k)
	}
	sort.Strings(output)
	return output
}
