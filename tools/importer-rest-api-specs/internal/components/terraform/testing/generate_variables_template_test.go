// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestVariablesTemplate_NoVariablesShouldOutputNothing(t *testing.T) {
	variables := testVariables{}
	expected := ""
	actual := generateTemplateForLocalVariables(variables)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestVariablesTemplate_EnablingEverything(t *testing.T) {
	variables := testVariables{
		needsRandomInteger:   true,
		needsRandomString:    true,
		needsPrimaryLocation: true,
	}
	expected := `
variable "primary_location" {}
variable "random_integer" {}
variable "random_string" {}
`
	actual := generateTemplateForLocalVariables(variables)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestVariablesTemplate_PrimaryLocation(t *testing.T) {
	variables := testVariables{
		needsPrimaryLocation: true,
	}
	expected := `
variable "primary_location" {}
`
	actual := generateTemplateForLocalVariables(variables)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestVariablesTemplate_RandomInteger(t *testing.T) {
	variables := testVariables{
		needsRandomInteger: true,
	}
	expected := `
variable "random_integer" {}
`
	actual := generateTemplateForLocalVariables(variables)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestVariablesTemplate_RandomString(t *testing.T) {
	variables := testVariables{
		needsRandomString: true,
	}
	expected := `
variable "random_string" {}
`
	actual := generateTemplateForLocalVariables(variables)
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
