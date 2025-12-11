// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
)

var _ View = ResourceIdSegmentsView{}

type ResourceIdSegmentsView struct {
	// staticIdentifierSegments is a unique, sorted list of the Static Identifiers present within
	// the detected set of Changes.
	staticIdentifierSegments []string
}

func NewResourceIdSegmentsView(input []changes.Change) ResourceIdSegmentsView {
	// First we need to identify any changes which contain Resource ID Segments that contain identifiers
	// As such let's build a unique list of Static Identifiers from the select Types of Changes that we need.
	uniqueIdentifiers := make(map[string]struct{})
	for _, change := range input {
		// When there's an entirely new Resource ID it can contain Static Identifiers
		if v, ok := change.(changes.ResourceIdAdded); ok {
			for _, segment := range v.StaticIdentifiersInNewValue {
				uniqueIdentifiers[segment] = struct{}{}
			}
		}

		// When the Resource ID Segment has changed value it can become a Static Identifier
		if v, ok := change.(changes.ResourceIdSegmentChangedValue); ok {
			if v.StaticIdentifierInNewValue != nil {
				uniqueIdentifiers[*v.StaticIdentifierInNewValue] = struct{}{}
			}
		}

		// When the Resource ID Segments change there can be new Static Identifiers present
		if v, ok := change.(changes.ResourceIdSegmentsChangedLength); ok {
			for _, segment := range v.StaticIdentifiersInNewValue {
				uniqueIdentifiers[segment] = struct{}{}
			}
		}
	}

	staticIdentifierSegments := make([]string, 0)
	for key := range uniqueIdentifiers {
		staticIdentifierSegments = append(staticIdentifierSegments, key)
	}
	sort.Strings(staticIdentifierSegments)
	return ResourceIdSegmentsView{
		staticIdentifierSegments: staticIdentifierSegments,
	}
}

func (v ResourceIdSegmentsView) RenderMarkdown() (*string, error) {
	if len(v.staticIdentifierSegments) == 0 {
		output := `
## New Resource ID Segments containing Static Identifiers

No new Resource ID Segments containing Static Identifiers were identified in the set of changes 🤙.
`
		return trimSpaceAround(output)
	}

	lines := make([]string, 0)
	for _, item := range v.staticIdentifierSegments {
		lines = append(lines, fmt.Sprintf("* `%s`", item))
	}
	output := fmt.Sprintf(`
## New Resource ID Segments containing Static Identifiers

The following new Static Identifiers were detected from the set of changes (new/updated Resource IDs).

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.

Please review the following list of Static Identifiers:

---

%s

---

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.
`, strings.Join(lines, "\n"))
	output = strings.ReplaceAll(output, "'", "`")
	//TODO: add a "see the link for how to fix this" to the comment above when the associated documentation is available
	return trimSpaceAround(output)
}
