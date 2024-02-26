// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p *Parser) distinctResourceIds(input map[string]processedResourceId) ([]models.ResourceID, map[string]models.SDKConstant) {
	out := make([]models.ResourceID, 0)

	allConstants := make(map[string]models.SDKConstant)
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

		item := models.ResourceID{
			CommonIDAlias: nil,
			ConstantNames: constantNames,
			Segments:      *operation.segments,
		}
		item.ExampleValue = helpers.DisplayValueForResourceID(item)

		matchFound := false
		for _, existing := range out {
			if ResourceIdsMatch(item, existing) {
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
