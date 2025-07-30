// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_ServiceNoChanges(t *testing.T) {
	initial := map[string]models.Service{
		"Computer": {},
	}
	updated := map[string]models.Service{
		"Computer": {},
	}
	actual, err := differ{}.changesForService("Computer", initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ServiceAdded_WithNestedDetails(t *testing.T) {
	initial := map[string]models.Service{
		// intentionally empty
	}
	updated := map[string]models.Service{
		"Computer": {
			APIVersions: map[string]models.APIVersion{
				"2020-01-01": {},
			},
		},
	}
	actual, err := differ{}.changesForService("Computer", initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "Computer",
		},
		changes.ApiVersionAdded{
			ServiceName: "Computer",
			ApiVersion:  "2020-01-01",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ServiceAdded_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.Service{
		// intentionally empty
	}
	updated := map[string]models.Service{
		"Computer": {},
	}
	actual, err := differ{}.changesForService("Computer", initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceAdded{
			ServiceName: "Computer",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ServiceRemoved_WithNestedDetails(t *testing.T) {
	initial := map[string]models.Service{
		"Computer": {},
	}
	updated := map[string]models.Service{
		// intentionally empty
	}
	actual, err := differ{}.changesForService("Computer", initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "Computer",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ServiceRemoved_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.Service{
		"Computer": {},
	}
	updated := map[string]models.Service{
		// intentionally empty
	}
	actual, err := differ{}.changesForService("Computer", initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ServiceRemoved{
			ServiceName: "Computer",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
