// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (p *Parser) distinctResourceIds(input map[string]processedResourceId) []importerModels.ParsedResourceId {
	out := make([]importerModels.ParsedResourceId, 0)

	for _, operation := range input {
		if operation.segments == nil {
			continue
		}

		item := importerModels.ParsedResourceId{
			CommonAlias: nil,
			Constants:   operation.constants,
			Segments:    *operation.segments,
		}

		matchFound := false
		for _, existing := range out {
			if item.Matches(existing) {
				matchFound = true
			}
		}
		if !matchFound {
			out = append(out, item)
		}
	}

	return out
}
