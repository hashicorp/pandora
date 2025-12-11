// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_CommonTypesModelNoChanges(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelAdded(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First": {},
	}
	updated := map[string]models.SDKModel{
		"First":  {},
		"Second": {},
	}
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesModelAdded{
			ApiVersion: "2020-01-01",
			ModelName:  "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelRemoved(t *testing.T) {
	initial := map[string]models.SDKModel{
		"First":  {},
		"Second": {},
	}
	updated := map[string]models.SDKModel{
		"First": {},
	}
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.CommonTypesModelRemoved{
			ApiVersion: "2020-01-01",
			ModelName:  "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelDiscriminatedParentTypeAdded(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeAdded{
			ServiceName:        commonTypesServiceName,
			ApiVersion:         "2020-01-01",
			ResourceName:       commonTypesServiceName,
			ModelName:          "First",
			NewParentModelName: "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelDiscriminatedParentTypeChanged(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeChanged{
			ServiceName:        commonTypesServiceName,
			ApiVersion:         "2020-01-01",
			ResourceName:       commonTypesServiceName,
			ModelName:          "First",
			OldParentModelName: "OldValue",
			NewParentModelName: "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelDiscriminatedParentTypeRemoved(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedParentTypeRemoved{
			ServiceName:        commonTypesServiceName,
			ApiVersion:         "2020-01-01",
			ResourceName:       commonTypesServiceName,
			ModelName:          "First",
			OldParentModelName: "OldValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelDiscriminatedFieldNameContainingDiscriminatedValueChanged(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedTypeHintInChanged{
			ServiceName:  commonTypesServiceName,
			ApiVersion:   "2020-01-01",
			ResourceName: commonTypesServiceName,
			ModelName:    "First",
			OldValue:     "OldValue",
			NewValue:     "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_CommonTypesModelDiscriminatedDiscriminatedValueChanged(t *testing.T) {
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
	actual, err := differ{}.changesForCommonTypesModels("2020-01-01", initial, updated)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := []changes.Change{
		changes.ModelDiscriminatedTypeValueChanged{
			ServiceName:  commonTypesServiceName,
			ApiVersion:   "2020-01-01",
			ResourceName: commonTypesServiceName,
			ModelName:    "First",
			OldValue:     "OldValue",
			NewValue:     "NewValue",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
