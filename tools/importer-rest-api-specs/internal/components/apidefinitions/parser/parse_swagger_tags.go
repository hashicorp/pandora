// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"sort"

	"golang.org/x/text/cases"
	"golang.org/x/text/language"
)

func (p *apiDefinitionsParser) ParseSwaggerTags() []string {
	tags := make(map[string]struct{})

	for _, operation := range p.context.SwaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				normalizedTag := cases.Title(language.AmericanEnglish, cases.NoLower).String(tag)
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
