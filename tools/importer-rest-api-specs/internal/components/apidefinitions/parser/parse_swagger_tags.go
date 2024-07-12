// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"sort"
	"strings"
)

func (p *apiDefinitionsParser) ParseSwaggerTags() []string {
	tags := make(map[string]struct{})

	// first we go through, assuming there are tags
	for _, operation := range p.context.SwaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				tags[tag] = struct{}{}
			}
		}
	}

	out := make([]string, 0)
	for key := range tags {
		out = append(out, strings.Title(key))
	}
	sort.Strings(out)
	return out
}
