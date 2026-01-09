// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_CommonTypesConstantNoChanges(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantAdded(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {},
	}
	updated := map[string]models.SDKConstant{
		"First": {},
		"Second": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantAdded{
			ApiVersion:   "2020-01-01",
			ConstantName: "Second",
			ConstantType: string(models.IntegerSDKConstantType),
			KeysAndValues: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantRemoved(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {},
		"Second": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"First": {},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantRemoved{
			ApiVersion:   "2020-01-01",
			ConstantName: "Second",
			ConstantType: string(models.IntegerSDKConstantType),
			KeysAndValues: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantKeyValueAdded(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
				"Four":  "4",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantKeyValueAdded{
			ApiVersion:    "2020-01-01",
			ConstantName:  "First",
			ConstantKey:   "Four",
			ConstantValue: "4",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantKeyValueChanged(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"SkuName": {
			Type: models.StringSDKConstantType,
			Values: map[string]string{
				"Basic":    "basic",
				"Premium":  "premium",
				"Standard": "standard",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"SkuName": {
			Type: models.StringSDKConstantType,
			Values: map[string]string{
				"Basic":    "Basic",
				"Premium":  "Premium",
				"Standard": "Standard",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantKeyValueChanged{
			ApiVersion:       "2020-01-01",
			ConstantName:     "SkuName",
			ConstantKey:      "Basic",
			OldConstantValue: "basic",
			NewConstantValue: "Basic",
		},
		changes.CommonTypesConstantKeyValueChanged{
			ApiVersion:       "2020-01-01",
			ConstantName:     "SkuName",
			ConstantKey:      "Premium",
			OldConstantValue: "premium",
			NewConstantValue: "Premium",
		},
		changes.CommonTypesConstantKeyValueChanged{
			ApiVersion:       "2020-01-01",
			ConstantName:     "SkuName",
			ConstantKey:      "Standard",
			OldConstantValue: "standard",
			NewConstantValue: "Standard",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantKeyValueRemoved(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
				"Four":  "4",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantKeyValueRemoved{
			ApiVersion:    "2020-01-01",
			ConstantName:  "First",
			ConstantKey:   "Four",
			ConstantValue: "4",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_CommonTypesConstantTypeChanged(t *testing.T) {
	initial := map[string]models.SDKConstant{
		"First": {
			Type: models.IntegerSDKConstantType,
			Values: map[string]string{
				"One": "1",
			},
		},
	}
	updated := map[string]models.SDKConstant{
		"First": {
			Type: models.StringSDKConstantType,
			Values: map[string]string{
				"One": "one",
			},
		},
	}
	actual := differ{}.changesForCommonTypesConstants("2020-01-01", initial, updated)
	expected := []changes.Change{
		changes.CommonTypesConstantTypeChanged{
			ApiVersion:   "2020-01-01",
			ConstantName: "First",
			OldType:      string(models.IntegerSDKConstantType),
			NewType:      string(models.StringSDKConstantType),
		},
		changes.CommonTypesConstantKeyValueChanged{
			ApiVersion:       "2020-01-01",
			ConstantName:     "First",
			ConstantKey:      "One",
			OldConstantValue: "1",
			NewConstantValue: "one",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}
