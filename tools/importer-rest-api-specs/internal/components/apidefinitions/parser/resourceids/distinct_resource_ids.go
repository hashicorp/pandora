// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"sort"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
)

func (p *Parser) distinctResourceIds(input map[string]processedResourceId) ([]sdkModels.ResourceID, map[string]sdkModels.SDKConstant) {
	out := make([]sdkModels.ResourceID, 0)

	allConstants := make(map[string]sdkModels.SDKConstant)
	for _, operation := range input {
		if operation.segments == nil {
			continue
		}

		uniqueConstantNames := make(map[string]struct{})
		for k := range operation.constants {
			v := operation.constants[k]
			uniqueConstantNames[k] = struct{}{}
			allConstants[k] = v
		}
		constantNames := make([]string, 0)
		for k := range uniqueConstantNames {
			constantNames = append(constantNames, k)
		}
		sort.Strings(constantNames)

		item := sdkModels.ResourceID{
			CommonIDAlias: nil,
			ConstantNames: constantNames,
			Segments:      *operation.segments,
		}
		item.ExampleValue = sdkHelpers.DisplayValueForResourceID(item)

		matchFound := false
		for _, existing := range out {
			if comparison.ResourceIDsMatch(item, existing) {
				matchFound = true
				break
			}
		}
		if !matchFound {
			out = append(out, item)
		}
	}

	return out, allConstants
}
