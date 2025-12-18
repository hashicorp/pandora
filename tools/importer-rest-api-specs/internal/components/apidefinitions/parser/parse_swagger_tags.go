// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

func (p *apiDefinitionsParser) ParseSwaggerTags() []string {
	tags := make(map[string]struct{})

	for _, operation := range p.context.SwaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				normalizedTag := cleanup.Title(tag)
				tags[normalizedTag] = struct{}{}
			}
		}
	}

	out := make([]string, 0)
	for key := range tags {
		out = append(out, key)
	}
	sort.Strings(out)
	return out
}
