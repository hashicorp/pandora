// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_FieldNoChanges(t *testing.T) {
	initial := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_FieldAdded(t *testing.T) {
	initial := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
		"Second": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
	initial := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
		"Second": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
	initial := map[string]models.SDKField{
		"First": {
			JsonName: "someField",
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			JsonName: "SomeField", // casing differs == a breaking change
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
	initial := map[string]models.SDKField{
		"First": {
			Optional: false,
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			Optional: true,
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
	initial := map[string]models.SDKField{
		"First": {
			Required: false,
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			Required: true,
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
	initial := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
		},
	}
	updated := map[string]models.SDKField{
		"First": {
			ObjectDefinition: models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("SomeConstant"),
			},
		},
	}
	actual, err := differ{}.changesForFields("Computer", "2020-01-01", "Example", "SomeModel", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
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
