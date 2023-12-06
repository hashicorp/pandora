package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
)

func TestDiff_APIVersionAdded(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ApiVersionAdded{
			ServiceName: "Computer",
			ApiVersion:  "2023-01-01",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIVersionRemoved(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ApiVersionRemoved{
			ServiceName: "Computer",
			ApiVersion:  "2023-01-01",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
