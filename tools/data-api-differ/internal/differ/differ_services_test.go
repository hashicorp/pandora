package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
)

func TestDiff_ServiceAdded(t *testing.T) {
	initial := map[string]dataapi.ServiceData{
		// intentionally empty
	}
	updated := map[string]dataapi.ServiceData{
		"Computer": {},
	}
	actual, err := differ{}.changesForService("Computer", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "Computer",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ServiceRemoved(t *testing.T) {
	initial := map[string]dataapi.ServiceData{
		"Computer": {},
	}
	updated := map[string]dataapi.ServiceData{
		// intentionally empty
	}
	actual, err := differ{}.changesForService("Computer", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "Computer",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
