package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_ResourceIdNoChanges(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_ResourceIdAdded(t *testing.T) {
	oldIds := make(map[string]resourcemanager.ResourceIdDefinition)
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					// NOTE: it's not strictly representative to have 3 static segments and no user configurable
					// segments in a Resource ID - but its worth it in this instance for a simpler/shorter testcase.
					Name:         "staticSome",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("some"),
					ExampleValue: "some",
				},
				{
					Name:         "staticResource",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("resource"),
					ExampleValue: "resource",
				},
				{
					Name:         "staticId",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("id"),
					ExampleValue: "id",
				},
			},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdAdded{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Example",
			ResourceIdName:  "SomeId",
			ResourceIdValue: "/some/resource/id",
			StaticIdentifiersInNewValue: []string{
				// this list is ordered
				"id",
				"resource",
				"some",
			},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_ResourceIdCommonIdAdded(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id:          "/some/resource/id",
			CommonAlias: pointer.To("SomeCommonAlias"),
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdCommonIdAdded{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Example",
			ResourceIdName:  "SomeId",
			CommonAliasName: "SomeCommonAlias",
			ResourceIdValue: "/some/resource/id",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdCommonIdChanged(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id:          "/some/resource/id",
			CommonAlias: pointer.To("SomeCommonAlias"),
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id:          "/some/resource/id",
			CommonAlias: pointer.To("SomeOtherAlias"),
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdCommonIdChanged{
			ServiceName:        "Computer",
			ApiVersion:         "2020-01-01",
			ResourceName:       "Example",
			ResourceIdName:     "SomeId",
			OldCommonAliasName: "SomeCommonAlias",
			OldValue:           "/some/resource/id",
			NewCommonAliasName: "SomeOtherAlias",
			NewValue:           "/some/resource/id",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdCommonIdRemoved(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id:          "/some/resource/id",
			CommonAlias: pointer.To("SomeCommonAlias"),
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdCommonIdRemoved{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Example",
			ResourceIdName:  "SomeId",
			CommonAliasName: "SomeCommonAlias",
			ResourceIdValue: "/some/resource/id",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsAdded(t *testing.T) {
	// NOTE: when Segments are added this should still get surfaced as `ResourceIdSegmentsChangedLength`
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/example/{name}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "name",
					Type:         resourcemanager.UserSpecifiedSegment,
					ExampleValue: "someName",
				},
			},
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/{name}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "staticExample",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("example"),
					ExampleValue: "example",
				},
				{
					Name:         "name",
					Type:         resourcemanager.UserSpecifiedSegment,
					ExampleValue: "someName",
				},
			},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdSegmentsChangedLength{
			ServiceName:    "Computer",
			ApiVersion:     "2020-01-01",
			ResourceName:   "Example",
			ResourceIdName: "SomeId",
			OldValue: []string{
				`Name "name" / Type "UserSpecified" / ExampleValue "someName"`,
			},
			NewValue: []string{
				`Name "staticExample" / Type "Static" / FixedValue "example" / ExampleValue "example"`,
				`Name "name" / Type "UserSpecified" / ExampleValue "someName"`,
			},
			StaticIdentifiersInNewValue: []string{
				"example",
			},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsChangedFixedValue(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/first",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "staticExample",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("first"),
					ExampleValue: "first",
				},
			},
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/second",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "staticExample",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("second"),
					ExampleValue: "second",
				},
			},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdSegmentChangedValue{
			ServiceName:                "Computer",
			ApiVersion:                 "2020-01-01",
			ResourceName:               "Example",
			ResourceIdName:             "SomeId",
			SegmentIndex:               0,
			OldValue:                   `Name "staticExample" / Type "Static" / FixedValue "first" / ExampleValue "first"`,
			NewValue:                   `Name "staticExample" / Type "Static" / FixedValue "second" / ExampleValue "second"`,
			StaticIdentifierInNewValue: pointer.To("second"),
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsChangedName(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/first",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "staticExample",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("first"),
					ExampleValue: "first",
				},
			},
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/first",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "updatedName",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("first"),
					ExampleValue: "first",
				},
			},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdSegmentChangedValue{
			ServiceName:                "Computer",
			ApiVersion:                 "2020-01-01",
			ResourceName:               "Example",
			ResourceIdName:             "SomeId",
			SegmentIndex:               0,
			OldValue:                   `Name "staticExample" / Type "Static" / FixedValue "first" / ExampleValue "first"`,
			NewValue:                   `Name "updatedName" / Type "Static" / FixedValue "first" / ExampleValue "first"`,
			StaticIdentifierInNewValue: pointer.To("first"),
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsChangedType(t *testing.T) {
	// This test covers when the Resource ID segment has changed type (e.g. a String to a Constant)

	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/{skuName}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "skuName",
					Type:         resourcemanager.UserSpecifiedSegment,
					ExampleValue: "first",
				},
			},
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/{skuName}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:              "skuName",
					Type:              resourcemanager.ConstantSegment,
					ConstantReference: pointer.To("SomeConstant"),
					ExampleValue:      "Basic",
				},
			},
			ConstantNames: []string{"SomeConstant"},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdSegmentChangedValue{
			ServiceName:    "Computer",
			ApiVersion:     "2020-01-01",
			ResourceName:   "Example",
			ResourceIdName: "SomeId",
			SegmentIndex:   0,
			OldValue:       `Name "skuName" / Type "UserSpecified" / ExampleValue "first"`,
			NewValue:       `Name "skuName" / Type "Constant" / ConstantReference "SomeConstant" / ExampleValue "Basic"`,
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsRemoved(t *testing.T) {
	// NOTE: when Segments are removed this should still get surfaced as `ResourceIdSegmentsChangedLength`
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/example/{name}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "staticExample",
					Type:         resourcemanager.StaticSegment,
					FixedValue:   pointer.To("example"),
					ExampleValue: "example",
				},
				{
					Name:         "name",
					Type:         resourcemanager.UserSpecifiedSegment,
					ExampleValue: "someName",
				},
			},
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/{name}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Name:         "name",
					Type:         resourcemanager.UserSpecifiedSegment,
					ExampleValue: "someName",
				},
			},
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdSegmentsChangedLength{
			ServiceName:    "Computer",
			ApiVersion:     "2020-01-01",
			ResourceName:   "Example",
			ResourceIdName: "SomeId",
			OldValue: []string{
				`Name "staticExample" / Type "Static" / FixedValue "example" / ExampleValue "example"`,
				`Name "name" / Type "UserSpecified" / ExampleValue "someName"`,
			},
			NewValue: []string{
				`Name "name" / Type "UserSpecified" / ExampleValue "someName"`,
			},
			StaticIdentifiersInNewValue: []string{},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdRemoved(t *testing.T) {
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	newIds := make(map[string]resourcemanager.ResourceIdDefinition)
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := []changes.Change{
		changes.ResourceIdRemoved{
			ServiceName:     "Computer",
			ApiVersion:      "2020-01-01",
			ResourceName:    "Example",
			ResourceIdName:  "SomeId",
			ResourceIdValue: "/some/resource/id",
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}
