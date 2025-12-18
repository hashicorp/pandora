// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

var _ View = ChangesView{}

// ChangesView renders the UI when any Changes are detected.
type ChangesView struct {
	// breakingChanges is a slice of the breaking changes that should be rendered
	breakingChanges []changes.Change

	// nonBreakingChanges is a slice of the non-breaking changes that should be rendered
	nonBreakingChanges []changes.Change
}

func NewChangesView(input []changes.Change) ChangesView {
	breakingChanges := make([]changes.Change, 0)
	nonBreakingChanges := make([]changes.Change, 0)
	for _, item := range input {
		if item.IsBreaking() {
			breakingChanges = append(breakingChanges, item)
			continue
		}

		nonBreakingChanges = append(nonBreakingChanges, item)
		continue
	}

	return ChangesView{
		breakingChanges:    breakingChanges,
		nonBreakingChanges: nonBreakingChanges,
	}
}

// RenderMarkdown renders the Changes View using Markdown, intended for both display
// in a Terminal and to be output as a GitHub Comment.
func (v ChangesView) RenderMarkdown() (*string, error) {
	if len(v.breakingChanges) == 0 && len(v.nonBreakingChanges) == 0 {
		return trimSpaceAround(`
## Summary of Changes

No Breaking or Non-Breaking Changes were found 👍
`)
	}

	summaryLines := make([]string, 0)
	if len(v.breakingChanges) > 0 {
		summaryLines = append(summaryLines, fmt.Sprintf("* 🛑 **%d Breaking Changes** were detected.", len(v.breakingChanges)))
	} else {
		summaryLines = append(summaryLines, "* 👍 No Breaking Changes were detected.")
	}
	if len(v.nonBreakingChanges) > 0 {
		summaryLines = append(summaryLines, fmt.Sprintf("* 👀 %d Non-Breaking Changes were detected.", len(v.nonBreakingChanges)))
	} else {
		summaryLines = append(summaryLines, "* 👍 No Non-Breaking Changes were detected.")
	}

	sections := []string{
		fmt.Sprintf(`
## Summary of Changes

%s
`, strings.Join(summaryLines, "\n")),
	}

	// TODO: we should look to format this output based on "groupings" of Data Source x Service so this is clearer
	// but for an MVP this is sufficient

	breakingChangesLines := make([]string, 0)
	for i, change := range v.breakingChanges {
		log.Logger.Trace(fmt.Sprintf("Rendering Breaking Change %d", i))
		markdown, err := renderChangeToMarkdown(change)
		if err != nil {
			return nil, fmt.Errorf("rendering Breaking Change %d: %+v", i, err)
		}
		breakingChangesLines = append(breakingChangesLines, fmt.Sprintf("* ❌ %s", *markdown))
	}
	if len(breakingChangesLines) > 0 {
		sections = append(sections, fmt.Sprintf(`
## Breaking Changes

**%[1]d Breaking Changes** were detected:

%[2]s
`, len(v.breakingChanges), strings.Join(breakingChangesLines, "\n")))
	}

	nonBreakingChangesSummary := make([]string, 0)
	for i, change := range v.nonBreakingChanges {
		log.Logger.Trace(fmt.Sprintf("Rendering Non-Breaking Change %d", i))
		markdown, err := renderChangeToMarkdown(change)
		if err != nil {
			return nil, fmt.Errorf("rendering Breaking Change %d: %+v", i, err)
		}

		nonBreakingChangesSummary = append(nonBreakingChangesSummary, fmt.Sprintf("* ✅ %s", *markdown))
	}
	if len(nonBreakingChangesSummary) > 0 {
		sections = append(sections, fmt.Sprintf(`
## Non-Breaking Changes

**%d Non-Breaking Changes** were detected:

%[2]s
`, len(v.nonBreakingChanges), strings.Join(nonBreakingChangesSummary, "\n")))
	}

	output := strings.Join(sections, "\n---\n\n")
	return trimSpaceAround(output)
}
