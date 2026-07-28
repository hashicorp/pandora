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

func TestChangesView_Markdown_NoChanges(t *testing.T) {
	actual, err := NewChangesView(make([]changes.Change, 0)).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := "## Summary of Changes\n\nNo Breaking or Non-Breaking Changes were found 👍"
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestChangesView_Markdown_WithOnlyBreakingChanges(t *testing.T) {
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
	actual, err := NewChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
 ## Summary of Changes

* 🛑 **3 Breaking Changes** were detected.
* 👍 No Non-Breaking Changes were detected.

---

## Breaking Changes

**3 Breaking Changes** were detected:

* ❌ **Removed Service:** 'First'.
* ❌ **Removed Service:** 'Second'.
* ❌ **Removed Service:** 'Third'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestChangesView_Markdown_WithOnlyNonBreakingChanges(t *testing.T) {
	diff := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "First",
		},
		changes.ServiceAdded{
			ServiceName: "Second",
		},
		changes.ServiceAdded{
			ServiceName: "Third",
		},
	}
	actual, err := NewChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
 ## Summary of Changes

* 👍 No Breaking Changes were detected.
* 👀 3 Non-Breaking Changes were detected.

---

## Non-Breaking Changes

**3 Non-Breaking Changes** were detected:

* ✅ **New Service:** 'First'.
* ✅ **New Service:** 'Second'.
* ✅ **New Service:** 'Third'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestChangesView_Markdown_WithBreakingAndNonBreakingChanges(t *testing.T) {
	diff := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "First",
		},
		changes.ServiceRemoved{
			ServiceName: "Second",
		},
		changes.ServiceAdded{
			ServiceName: "Third",
		},
	}
	actual, err := NewChangesView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
 ## Summary of Changes

* 🛑 **1 Breaking Changes** were detected.
* 👀 2 Non-Breaking Changes were detected.

---

## Breaking Changes

**1 Breaking Changes** were detected:

* ❌ **Removed Service:** 'Second'.

---

## Non-Breaking Changes

**2 Non-Breaking Changes** were detected:

* ✅ **New Service:** 'First'.
* ✅ **New Service:** 'Third'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
