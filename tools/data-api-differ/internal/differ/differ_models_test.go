package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_ModelNoChanges(t *testing.T) {
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			Fields: map[string]resourcemanager.FieldDetails{
				"Example": {
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			Fields: map[string]resourcemanager.FieldDetails{
				"Example": {
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_ModelAdded(t *testing.T) {
	initial := map[string]resourcemanager.ModelDetails{
		"First": {},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First":  {},
		"Second": {},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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
	initial := map[string]resourcemanager.ModelDetails{
		"First":  {},
		"Second": {},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintIn: nil,
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			ParentTypeName: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			ParentTypeName: pointer.To("OldValue"),
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			ParentTypeName: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			ParentTypeName: pointer.To("OldValue"),
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintIn: nil,
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestDiff_ModelDiscriminatedTypeHintInChanged(t *testing.T) {
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintIn: pointer.To("OldValue"),
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintIn: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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

func TestDiff_ModelDiscriminatedTypeHintValueChanged(t *testing.T) {
	initial := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintValue: pointer.To("OldValue"),
		},
	}
	updated := map[string]resourcemanager.ModelDetails{
		"First": {
			TypeHintValue: pointer.To("NewValue"),
		},
	}
	actual, err := differ{}.changesForModels("Computer", "2020-01-01", "Example", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
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
