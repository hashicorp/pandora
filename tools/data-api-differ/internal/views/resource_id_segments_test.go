package views

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// Since we're relying on the output to be clear, it's worth sanity-checking what we're outputting here.

func TestResourceIdSegmentsView_Markdown_NoChanges(t *testing.T) {
	actual, err := NewResourceIdSegmentsView(make([]changes.Change, 0)).RenderMarkdown()
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "No New Resource ID Segments were found 👍"
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
