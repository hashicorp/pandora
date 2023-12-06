package differ

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_ConstantAdded(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"First": {},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"First": {},
		"Second": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantAdded{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ConstantName: "Second",
			ConstantType: string(resourcemanager.IntegerConstant),
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

func TestDiff_ConstantRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"First": {},
		"Second": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"First": {},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantRemoved{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ConstantName: "Second",
			ConstantType: string(resourcemanager.IntegerConstant),
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

func TestDiff_ConstantKeyValueAdded(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
				"Four":  "4",
			},
		},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantKeyValueAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			ConstantName:  "First",
			ConstantKey:   "Four",
			ConstantValue: "4",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_ConstantKeyValueChanged(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"SkuName": {
			Type: resourcemanager.StringConstant,
			Values: map[string]string{
				"Basic":    "basic",
				"Premium":  "premium",
				"Standard": "standard",
			},
		},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"SkuName": {
			Type: resourcemanager.StringConstant,
			Values: map[string]string{
				"Basic":    "Basic",
				"Premium":  "Premium",
				"Standard": "Standard",
			},
		},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantKeyValueChanged{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			ConstantName:     "SkuName",
			ConstantKey:      "Basic",
			OldConstantValue: "basic",
			NewConstantValue: "Basic",
		},
		changes.ConstantKeyValueChanged{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			ConstantName:     "SkuName",
			ConstantKey:      "Premium",
			OldConstantValue: "premium",
			NewConstantValue: "Premium",
		},
		changes.ConstantKeyValueChanged{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			ConstantName:     "SkuName",
			ConstantKey:      "Standard",
			OldConstantValue: "standard",
			NewConstantValue: "Standard",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ConstantKeyValueRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
				"Four":  "4",
			},
		},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One":   "1",
				"Two":   "2",
				"Three": "3",
			},
		},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantKeyValueRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			ConstantName:  "First",
			ConstantKey:   "Four",
			ConstantValue: "4",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ConstantTypeChanged(t *testing.T) {
	initial := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.IntegerConstant,
			Values: map[string]string{
				"One": "1",
			},
		},
	}
	updated := map[string]resourcemanager.ConstantDetails{
		"First": {
			Type: resourcemanager.StringConstant,
			Values: map[string]string{
				"One": "one",
			},
		},
	}
	actual := differ{}.changesForConstants("Computer", "2020-01-01", "Example", initial, updated)
	expected := []changes.Change{
		changes.ConstantTypeChanged{
			ServiceName:  "Computer",
			ApiVersion:   "2020-01-01",
			ResourceName: "Example",
			ConstantName: "First",
			OldType:      string(resourcemanager.IntegerConstant),
			NewType:      string(resourcemanager.StringConstant),
		},
		changes.ConstantKeyValueChanged{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			ConstantName:     "First",
			ConstantKey:      "One",
			OldConstantValue: "1",
			NewConstantValue: "one",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}
