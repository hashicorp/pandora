package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/dataapi"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_APIVersionAdded_WithNestedDetails(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {
			Resources: map[string]dataapi.ApiResourceData{
				"Example": {
					Constants: map[string]resourcemanager.ConstantDetails{
						"SomeConst": {
							Type: resourcemanager.StringConstant,
							Values: map[string]string{
								"First": "first",
							},
						},
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated, true)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.ApiVersionAdded{
			ServiceName: "Computer",
			ApiVersion:  "2023-01-01",
		},
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2023-01-01",
			ResourceName: "Example",
		},
		changes.ConstantAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2023-01-01",
			ResourceName: "Example",
			ConstantName: "SomeConst",
			ConstantType: string(resourcemanager.StringConstant),
			KeysAndValues: map[string]string{
				"First": "first",
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIVersionAdded_WithoutNestedDetails(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {
			Resources: map[string]dataapi.ApiResourceData{
				"Example": {
					Constants: map[string]resourcemanager.ConstantDetails{
						"SomeConst": {
							Type: resourcemanager.StringConstant,
							Values: map[string]string{
								"First": "first",
							},
						},
					},
				},
			},
		},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated, false)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		// we should get the API Version and API Resource but nothing under it
		changes.ApiVersionAdded{
			ServiceName: "Computer",
			ApiVersion:  "2023-01-01",
		},
		changes.ApiResourceAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2023-01-01",
			ResourceName: "Example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_APIVersionRemoved_WithNestedDetails(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {
			Resources: map[string]dataapi.ApiResourceData{
				"Example": {
					// this won't be surfaced because the entire API Version has been removed
					Constants: map[string]resourcemanager.ConstantDetails{
						"SomeConst": {
							Type: resourcemanager.StringConstant,
							Values: map[string]string{
								"First": "first",
							},
						},
					},
				},
			},
		},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated, true)
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

func TestDiff_APIVersionRemoved_WithoutNestedDetails(t *testing.T) {
	initial := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
		"2023-01-01": {
			Resources: map[string]dataapi.ApiResourceData{
				"Example": {
					// this won't be surfaced because the entire API Version has been removed
					Constants: map[string]resourcemanager.ConstantDetails{
						"SomeConst": {
							Type: resourcemanager.StringConstant,
							Values: map[string]string{
								"First": "first",
							},
						},
					},
				},
			},
		},
	}
	updated := map[string]dataapi.ApiVersionData{
		"2020-01-01": {},
	}
	actual, err := differ{}.changesForApiVersions("Computer", initial, updated, false)
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
