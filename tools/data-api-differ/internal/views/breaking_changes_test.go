// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// Since we're relying on the output to be clear, it's worth sanity-checking what we're outputting here.

func TestBreakingChangeView_Markdown_NoChanges(t *testing.T) {
	actual, err := NewBreakingChangesView(make([]changes.Change, 0)).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "## Breaking Changes\n\nNo Breaking Changes were found 👍"
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestBreakingChangeView_Markdown_WithOnlyBreakingChanges(t *testing.T) {
	diff := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "First",
		},
		changes.ServiceRemoved{
			ServiceName: "Second",
		},
		changes.ServiceRemoved{
			ServiceName: "Third",
		},
	}
	actual, err := NewBreakingChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
 ## Breaking Changes

🛑 **3 Breaking Changes** were detected.

---

Summary of changes:

* ❌ **Removed Service:** 'First'.
* ❌ **Removed Service:** 'Second'.
* ❌ **Removed Service:** 'Third'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestBreakingChangeView_Markdown_WithOnlyNonBreakingChanges(t *testing.T) {
	diff := []changes.Change{
		// Non-breaking changes should be filtered out
		changes.ServiceAdded{
			ServiceName: "Example",
		},
	}
	actual, err := NewBreakingChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `
## Breaking Changes

No Breaking Changes were found 👍
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestBreakingChangeView_Markdown_WithBreakingAndNonBreakingChanges(t *testing.T) {
	diff := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "First",
		},
		changes.ServiceAdded{ // the non-breaking change should be filtered out
			ServiceName: "Second",
		},
		changes.ServiceRemoved{
			ServiceName: "Third",
		},
	}
	actual, err := NewBreakingChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
 ## Breaking Changes

🛑 **2 Breaking Changes** were detected.

---

Summary of changes:

* ❌ **Removed Service:** 'First'.
* ❌ **Removed Service:** 'Third'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
