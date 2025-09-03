// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package views

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// Since we're relying on the output to be clear, it's worth sanity-checking what we're outputting here.

func TestResourceIdSegmentsView_Markdown_NoChanges(t *testing.T) {
	actual, err := NewResourceIdSegmentsView(make([]changes.Change, 0)).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `
## New Resource ID Segments containing Static Identifiers

No new Resource ID Segments containing Static Identifiers were identified in the set of changes 🤙.
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceIdSegmentsView_Markdown_WithChanges(t *testing.T) {
	// if the changes aren't adding a Resource ID Segment with a Static Identifier it should be ignored.
	diff := []changes.Change{
		changes.ResourceIdAdded{
			ResourceIdValue: "/subscriptions/{subscriptionId}/machineTypes/physical/machines/{machineName}",
			StaticIdentifiersInNewValue: []string{
				"subscriptions",
				"machineTypes",
				"physical",
				"machines",
			},
		},
		changes.ResourceIdAdded{
			// here to test uniqueness
			ResourceIdValue: "/subscriptions/{subscriptionId}",
			StaticIdentifiersInNewValue: []string{
				"subscriptions",
			},
		},
		changes.ResourceIdSegmentChangedValue{
			StaticIdentifierInNewValue: pointer.To("customLocations"),
		},
	}
	actual, err := NewResourceIdSegmentsView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
## New Resource ID Segments containing Static Identifiers

The following new Static Identifiers were detected from the set of changes (new/updated Resource IDs).

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.

Please review the following list of Static Identifiers:

---

* 'customLocations'
* 'machineTypes'
* 'machines'
* 'physical'
* 'subscriptions'

---

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceIdSegmentsView_Markdown_WithIrrelevantChanges(t *testing.T) {
	// if the changes aren't adding a Resource ID Segment with a Static Identifier it should be ignored.
	diff := []changes.Change{
		changes.ConstantAdded{
			ServiceName:  "Compute",
			ApiVersion:   "2020-01-01",
			ResourceName: "VirtualMachines",
			ConstantName: "Performance",
			ConstantType: "String",
			KeysAndValues: map[string]string{
				"Slow":     "Slow",
				"Fast":     "Fast",
				"VaVaVoom": "ZoomZoom",
			},
		},
	}
	actual, err := NewResourceIdSegmentsView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `
## New Resource ID Segments containing Static Identifiers

No new Resource ID Segments containing Static Identifiers were identified in the set of changes 🤙.
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestResourceIdSegmentsView_Markdown_WithRelevantAndIrrelevantChanges(t *testing.T) {
	// Only the relevant changes (i.e. those adding a Resource ID Segment with a Static Identifier)
	// should be output
	diff := []changes.Change{
		changes.ResourceIdAdded{
			ResourceIdValue: "/subscriptions/{subscriptionId}/machineTypes/physical/machines/{machineName}",
			StaticIdentifiersInNewValue: []string{
				"subscriptions",
				"machineTypes",
				"physical",
				"machines",
			},
		},
		changes.ResourceIdAdded{
			// here to test uniqueness
			ResourceIdValue: "/subscriptions/{subscriptionId}",
			StaticIdentifiersInNewValue: []string{
				"subscriptions",
			},
		},
		changes.ConstantAdded{
			ServiceName:  "Compute",
			ApiVersion:   "2020-01-01",
			ResourceName: "VirtualMachines",
			ConstantName: "Performance",
			ConstantType: "String",
			KeysAndValues: map[string]string{
				"Slow":     "Slow",
				"Fast":     "Fast",
				"VaVaVoom": "ZoomZoom",
			},
		},
		changes.ResourceIdSegmentChangedValue{
			StaticIdentifierInNewValue: pointer.To("customLocations"),
		},
	}
	actual, err := NewResourceIdSegmentsView(diff).RenderMarkdown()
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`
## New Resource ID Segments containing Static Identifiers

The following new Static Identifiers were detected from the set of changes (new/updated Resource IDs).

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.

Please review the following list of Static Identifiers:

---

* 'customLocations'
* 'machineTypes'
* 'machines'
* 'physical'
* 'subscriptions'

---

> ⚠️ Note: Resource ID segments should **always** be 'camelCased' and not 'TitleCased', 'lowercased' or 'kebab-cased'.
`, "'", "`")
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
