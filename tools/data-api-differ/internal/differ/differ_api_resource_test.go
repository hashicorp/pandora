package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
)

func TestDiff_APIResourceAdded(t *testing.T) {
	initial := map[string]dataapi.ApiResourceData{
		"First": {},
	}
	updated := map[string]dataapi.ApiResourceData{
		"First":  {},
		"Second": {},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIResourceRemoved(t *testing.T) {
	initial := map[string]dataapi.ApiResourceData{
		"First":  {},
		"Second": {},
	}
	updated := map[string]dataapi.ApiResourceData{
		"First": {},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
