package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestUpdateTemplateWithVariableNames_All(t *testing.T) {
	inputConfig := `
variable "primary_location" {}
variable "random_integer" {}
variable "random_string" {}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = var.primary_location
  static_val = "hello"
}
`
	actualConfig, actualVariables, err := updateTemplateWithVariableNames(inputConfig)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expectedConfig := `
variable "primary_location" {
  value = %q
}
variable "random_integer" {
  value = %d
}
variable "random_string" {
  value = %q
}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = var.primary_location
  static_val = "hello"
}
`
	expectedVariables := "data.Locations.Primary, data.RandomInteger, data.RandomString"
	testhelpers.AssertTemplatedCodeMatches(t, expectedConfig, *actualConfig)
	testhelpers.AssertTemplatedCodeMatches(t, expectedVariables, *actualVariables)
}

func TestUpdateTemplateWithVariableNames_AllReordered(t *testing.T) {
	inputConfig := `
variable "random_string" {}
variable "primary_location" {}
variable "random_integer" {}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = var.primary_location
  static_val = "hello"
}
`
	actualConfig, actualVariables, err := updateTemplateWithVariableNames(inputConfig)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expectedConfig := `
variable "random_string" {
  value = %q
}
variable "primary_location" {
  value = %q
}
variable "random_integer" {
  value = %d
}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = var.primary_location
  static_val = "hello"
}
`
	expectedVariables := "data.RandomString, data.Locations.Primary, data.RandomInteger"
	testhelpers.AssertTemplatedCodeMatches(t, expectedConfig, *actualConfig)
	testhelpers.AssertTemplatedCodeMatches(t, expectedVariables, *actualVariables)
}

func TestUpdateTemplateWithVariableNames_OnlyPrimaryLocation(t *testing.T) {
	inputConfig := `
variable "primary_location" {}

resource "example_test" "test" {
  name     = "val"
  location = var.primary_location
}
`
	actualConfig, actualVariables, err := updateTemplateWithVariableNames(inputConfig)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expectedConfig := `
variable "primary_location" {
  value = %q
}

resource "example_test" "test" {
  name     = "val"
  location = var.primary_location
}
`
	expectedVariables := "data.Locations.Primary"
	testhelpers.AssertTemplatedCodeMatches(t, expectedConfig, *actualConfig)
	testhelpers.AssertTemplatedCodeMatches(t, expectedVariables, *actualVariables)
}

func TestUpdateTemplateWithVariableNames_OnlyRandomInteger(t *testing.T) {
	inputConfig := `
variable "random_integer" {}

resource "example_test" "test" {
  name       = "val-${var.random_integer}"
  location   = "West Europe"
  static_val = "hello"
}
`
	actualConfig, actualVariables, err := updateTemplateWithVariableNames(inputConfig)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expectedConfig := `
variable "random_integer" {
  value = %d
}

resource "example_test" "test" {
  name       = "val-${var.random_integer}"
  location   = "West Europe"
  static_val = "hello"
}
`
	expectedVariables := "data.RandomInteger"
	testhelpers.AssertTemplatedCodeMatches(t, expectedConfig, *actualConfig)
	testhelpers.AssertTemplatedCodeMatches(t, expectedVariables, *actualVariables)
}

func TestUpdateTemplateWithVariableNames_OnlyRandomString(t *testing.T) {
	inputConfig := `
variable "random_string" {}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = "West Europe"
  static_val = "hello"
}
`
	actualConfig, actualVariables, err := updateTemplateWithVariableNames(inputConfig)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expectedConfig := `
variable "random_string" {
  value = %q
}

resource "example_test" "test" {
  name       = "val-${var.random_string}"
  location   = "West Europe"
  static_val = "hello"
}
`
	expectedVariables := "data.RandomString"
	testhelpers.AssertTemplatedCodeMatches(t, expectedConfig, *actualConfig)
	testhelpers.AssertTemplatedCodeMatches(t, expectedVariables, *actualVariables)
}
