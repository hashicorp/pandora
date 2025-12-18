// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"
)

func TestFieldNameMaxToMaximum_Valid(t *testing.T) {
	result, err := fieldNameMaxToMaximum{}.ProcessField("MaxValue", FieldMetadata{})
	if err != nil {
		t.Fatal(err.Error())
	}

	if result == nil {
		t.Fatalf("expected result to be non-nil but it was")
	}
	if *result != "MaximumValue" {
		t.Fatalf("expected result to be `MaximumValue` but got %q", *result)
	}
}

func TestFieldNameMaxToMaximum_Invalid(t *testing.T) {
	result, err := fieldNameMaxToMaximum{}.ProcessField("Maximillian", FieldMetadata{})
	if err != nil {
		t.Fatal(err.Error())
	}

	if result != nil {
		t.Fatalf("expected result to be nil but got %q", *result)
	}
}

func TestFieldNameMaxToMaximum_LiteralValueOfMax(t *testing.T) {
	result, err := fieldNameMaxToMaximum{}.ProcessField("Max", FieldMetadata{})
	if err != nil {
		t.Fatal(err.Error())
	}
	if result == nil {
		t.Fatalf("expected result to be non-nil but it was")
	}
	if *result != "Maximum" {
		t.Fatalf("expected result to be `Maximum` but got %q", *result)
	}
}

func TestFieldNameMaxToMaximum_LiteralValueOfMaxLowerCase(t *testing.T) {
	result, err := fieldNameMaxToMaximum{}.ProcessField("max", FieldMetadata{})
	if err != nil {
		t.Fatal(err.Error())
	}
	if result == nil {
		t.Fatalf("expected result to be non-nil but it was")
	}
	if *result != "Maximum" {
		t.Fatalf("expected result to be `Maximum` but got %q", *result)
	}
}
