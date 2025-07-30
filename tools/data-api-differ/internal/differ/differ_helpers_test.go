// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package differ

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

func init() {
	log.Logger = hclog.Default()
}

// determineAndValidateDiff runs a full diff of the two sets of data.
// This is intended to be used by tests covering the entire `diff` code path, simulating a real-world usage.
func determineAndValidateDiff(t *testing.T, initial, updated v1.LoadAllDataResult, expected []changes.Change, breakingChanges bool) {
	actual, err := performDiff(initial, updated, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual == nil {
		t.Fatalf("`actual` was unexpectedly nil")
	}
	if len(actual.Changes) != len(expected) {
		t.Fatalf("expected %d changes but got %d. Expected: %+v\n\nActual: %+v", len(expected), len(actual.Changes), expected, *actual)
	}
	if actual.ContainsBreakingChanges() != breakingChanges {
		t.Fatalf("expected `ContainsBreakingChanges` to return %t but got %t", breakingChanges, actual.ContainsBreakingChanges())
	}

	assertChanges(t, expected, actual.Changes)
}

// assertChanges is used to validate that the Changes returned match what's expected.
// This is intended to be used by tests to validate the individual diff stages (services, api versions)
// return the expected set of changes.
func assertChanges(t *testing.T, expected, actual []changes.Change) {
	if len(expected) != len(actual) {
		t.Fatalf("expected %d changes but got %d changes", len(expected), len(actual))
	}

	for i, expectedVal := range expected {
		actualVal := actual[i]
		if reflect.TypeOf(expectedVal).Name() != reflect.TypeOf(actualVal).Name() {
			t.Fatalf("Change at index %d differed by name - expected %q but got %q", i, reflect.TypeOf(expectedVal).Name(), reflect.TypeOf(actualVal).Name())
		}
		if !reflect.DeepEqual(expectedVal, actualVal) {
			t.Fatalf("Change at index %d didn't match - expected `%+v` got `%+v`", i, expectedVal, actualVal)
		}
	}
}

// assertContainsBreakingChanges is used to validate that the changes contain breaking changes
func assertContainsBreakingChanges(t *testing.T, actual []changes.Change) {
	breaking := false
	for _, item := range actual {
		if item.IsBreaking() {
			breaking = true
		}
	}

	if !breaking {
		t.Fatalf("expected `actual` to contain breaking changes but it didn't")
	}
}

// assertContainsNoBreakingChanges is used to validate that the changes contain no breaking changes
func assertContainsNoBreakingChanges(t *testing.T, actual []changes.Change) {
	for _, item := range actual {
		if item.IsBreaking() {
			t.Fatalf("expected `actual` to contain no breaking changes but got: %+v", item)
		}
	}
}
