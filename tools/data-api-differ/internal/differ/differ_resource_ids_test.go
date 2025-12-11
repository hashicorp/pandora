// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestDiff_ResourceIdNoChanges(t *testing.T) {
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
		},
	}
	actual := differ{}.changesForResourceIds("Computer", "2020-01-01", "Example", oldIds, newIds)
	expected := make([]changes.Change, 0)
	assertChanges(t, expected, actual)
	assertContainsNoBreakingChanges(t, actual)
}

func TestDiff_ResourceIdAdded(t *testing.T) {
	oldIds := make(map[string]models.ResourceID)
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
			Segments: []models.ResourceIDSegment{
				// NOTE: it's not strictly representative to have 3 static segments and no user configurable
				// segments in a Resource ID - but its worth it in this instance for a simpler/shorter testcase.
				models.NewStaticValueResourceIDSegment("staticSome", "some"),
				models.NewStaticValueResourceIDSegment("staticResource", "resource"),
				models.NewStaticValueResourceIDSegment("staticId", "id"),
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			CommonIDAlias: pointer.To("SomeCommonAlias"),
			ExampleValue:  "/some/resource/id",
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			CommonIDAlias: pointer.To("SomeCommonAlias"),
			ExampleValue:  "/some/resource/id",
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			CommonIDAlias: pointer.To("SomeOtherAlias"),
			ExampleValue:  "/some/resource/id",
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			CommonIDAlias: pointer.To("SomeCommonAlias"),
			ExampleValue:  "/some/resource/id",
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/example/{name}",
			Segments: []models.ResourceIDSegment{
				models.NewUserSpecifiedResourceIDSegment("name", "exampleName"),
			},
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/{name}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticExample", "example"),
				models.NewUserSpecifiedResourceIDSegment("name", "exampleName"),
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
				`Name "name" / Type "UserSpecified" / ExampleValue "exampleName"`,
			},
			NewValue: []string{
				`Name "staticExample" / Type "Static" / FixedValue "example" / ExampleValue "example"`,
				`Name "name" / Type "UserSpecified" / ExampleValue "exampleName"`,
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/first",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticExample", "first"),
			},
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/second",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticExample", "second"),
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
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/first",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticExample", "first"),
			},
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/first",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("updatedName", "first"),
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

	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/{skuName}",
			Segments: []models.ResourceIDSegment{
				models.NewUserSpecifiedResourceIDSegment("skuName", "skuValue"),
			},
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/{skuName}",
			Segments: []models.ResourceIDSegment{
				models.NewConstantResourceIDSegment("skuName", "SomeConstant", "Basic"),
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
			OldValue:       `Name "skuName" / Type "UserSpecified" / ExampleValue "skuValue"`,
			NewValue:       `Name "skuName" / Type "Constant" / ConstantReference "SomeConstant" / ExampleValue "Basic"`,
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdSegmentsRemoved(t *testing.T) {
	// NOTE: when Segments are removed this should still get surfaced as `ResourceIdSegmentsChangedLength`
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/example/{name}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("staticExample", "example"),
				models.NewUserSpecifiedResourceIDSegment("name", "exampleValue"),
			},
		},
	}
	newIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/{name}",
			Segments: []models.ResourceIDSegment{
				models.NewUserSpecifiedResourceIDSegment("name", "exampleValue"),
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
				`Name "name" / Type "UserSpecified" / ExampleValue "exampleValue"`,
			},
			NewValue: []string{
				`Name "name" / Type "UserSpecified" / ExampleValue "exampleValue"`,
			},
			StaticIdentifiersInNewValue: []string{},
		},
	}
	assertChanges(t, expected, actual)
	assertContainsBreakingChanges(t, actual)
}

func TestDiff_ResourceIdRemoved(t *testing.T) {
	oldIds := map[string]models.ResourceID{
		"SomeId": {
			ExampleValue: "/some/resource/id",
		},
	}
	newIds := make(map[string]models.ResourceID)
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
