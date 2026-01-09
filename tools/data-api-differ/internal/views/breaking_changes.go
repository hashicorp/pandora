// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
)

var _ View = BreakingChangeView{}

// BreakingChangeView renders the UI when Breaking Changes are detected.
type BreakingChangeView struct {
	// breakingChanges is a slice of the breaking changes that should be rendered
	breakingChanges []changes.Change
}

func NewBreakingChangesView(input []changes.Change) BreakingChangeView {
	// filter the list of changes to only breaking ones
	breakingChanges := make([]changes.Change, 0)
	for _, change := range input {
		if change.IsBreaking() {
			breakingChanges = append(breakingChanges, change)
		}
	}

	return BreakingChangeView{
		breakingChanges: breakingChanges,
	}
}

// RenderMarkdown renders the Breaking Changes View using Markdown, intended for both display
// in a Terminal and to be output as a GitHub Comment.
func (v BreakingChangeView) RenderMarkdown() (*string, error) {
	if len(v.breakingChanges) == 0 {
		return trimSpaceAround(`
## Breaking Changes

No Breaking Changes were found 👍
`)
	}

	diff := make([]string, 0)
	for i, change := range v.breakingChanges {
		log.Logger.Trace(fmt.Sprintf("Rendering Breaking Change %d", i))
		markdown, err := renderChangeToMarkdown(change)
		if err != nil {
			return nil, fmt.Errorf("rendering Breaking Change %d: %+v", i, err)
		}
		diff = append(diff, fmt.Sprintf("* ❌ %s", *markdown))
	}

	output := fmt.Sprintf(`
## Breaking Changes

🛑 **%d Breaking Changes** were detected.

---

Summary of changes:

%s

`, len(v.breakingChanges), strings.Join(diff, "\n"))
	return trimSpaceAround(output)
}
