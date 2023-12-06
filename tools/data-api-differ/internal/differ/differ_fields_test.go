package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_FieldNoChanges(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_FieldAdded(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
		"Second": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_FieldRemoved(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
		"Second": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_FieldJsonNameChanged(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			JsonName: "someField",
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			JsonName: "SomeField", // casing differs == a breaking change
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldJsonNameChanged{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "First",
			OldValue:     "someField",
			NewValue:     "SomeField",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_FieldIsNowOptional(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			Optional: false,
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			Optional: true,
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldIsNowOptional{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "First",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_FieldIsNowRequired(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			Required: false,
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			Required: true,
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldIsNowRequired{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "First",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_FieldObjectDefinitionChanged(t *testing.T) {
	initial := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.FieldDetails{
		"First": {
			ObjectDefinition: resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SomeConstant"),
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.FieldObjectDefinitionChanged{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ModelName:    "SomeModel",
			FieldName:    "First",
			OldValue:     "string",
			NewValue:     "SomeConstant",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
