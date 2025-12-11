// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_ModelNoChanges(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			Fields: map[string]models.SDKField{
				"Example": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			Fields: map[string]models.SDKField{
				"Example": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ModelAdded(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {},
	}
	updated := map[string]models.SDKModel{
		"First":  {},
		"Second": {},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ModelRemoved(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First":  {},
		"Second": {},
	}
	updated := map[string]models.SDKModel{
		"First": {},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ModelDiscriminatedParentTypeAdded(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			ParentTypeName: nil,
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			ParentTypeName: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeAdded{
			ServiceName:        "Computer",
			ApiVersion:         "2020-01-01",
			ResourceName:       "Example",
			ModelName:          "First",
			NewParentModelName: "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ModelDiscriminatedParentTypeChanged(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			ParentTypeName: pointer.To("OldValue"),
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			ParentTypeName: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeChanged{
			ServiceName:        "Computer",
			ApiVersion:         "2020-01-01",
			ResourceName:       "Example",
			ModelName:          "First",
			OldParentModelName: "OldValue",
			NewParentModelName: "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ModelDiscriminatedParentTypeRemoved(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			ParentTypeName: pointer.To("OldValue"),
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			ParentTypeName: nil,
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeRemoved{
			ServiceName:        "Computer",
			ApiVersion:         "2020-01-01",
			ResourceName:       "Example",
			ModelName:          "First",
			OldParentModelName: "OldValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ModelDiscriminatedFieldNameContainingDiscriminatedValueChanged(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			FieldNameContainingDiscriminatedValue: pointer.To("OldValue"),
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			FieldNameContainingDiscriminatedValue: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedTypeHintInChanged{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "First",
			OldValue:     "OldValue",
			NewValue:     "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_ModelDiscriminatedDiscriminatedValueChanged(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {
			DiscriminatedValue: pointer.To("OldValue"),
		},
	}
	updated := map[string]models.SDKModel{
		"First": {
			DiscriminatedValue: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedTypeValueChanged{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "First",
			OldValue:     "OldValue",
			NewValue:     "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
