// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_APIResourceAdded_WithNestedDetails(t *testing.T) {
	initial := map[string]models.APIResource{
		"First": {},
	}
	updated := map[string]models.APIResource{
		"First": {},
		"Second": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
		changes.ConstantAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
			ConstantName: "SomeConst",
			ConstantType: string(models.StringSDKConstantType),
			KeysAndValues: map[string]string{
				"First": "first",
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIResourceAdded_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.APIResource{
		"First": {},
	}
	updated := map[string]models.APIResource{
		"First": {},
		"Second": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
		// the Constant shouldn't be output since we're skipping the nested items
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIResourceRemoved_WithNestedDetails(t *testing.T) {
	initial := map[string]models.APIResource{
		"First": {},
		"Second": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
		},
	}
	updated := map[string]models.APIResource{
		"First": {},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
		// the constant isn't output since the entire API Resource is removed
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_APIResourceRemoved_WithoutNestedDetails(t *testing.T) {
	initial := map[string]models.APIResource{
		"First": {},
		"Second": {
			Constants: map[string]models.SDKConstant{
				"SomeConst": {
					Type: models.StringSDKConstantType,
					Values: map[string]string{
						"First": "first",
					},
				},
			},
		},
	}
	updated := map[string]models.APIResource{
		"First": {},
	}
	actual, err := differ{}.changesForApiResources("Computer", "2020-01-01", initial, updated, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ApiResourceRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Second",
		},
		// the constant isn't output since the entire API Resource is removed
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
