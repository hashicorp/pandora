// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import "strings"

func generateTemplateForLocalVariables(variables testVariables) string {
	components := make([]string, 0)

	// TODO: switch to using a locals block
	// NOTE: we can only do this once the TF Generator is updated to parse the
	// test config to determine which locals/variables should be string-templated
	if variables.needsPrimaryLocation {
		components = append(components, `variable "primary_location" {}`)
	}
	if variables.needsRandomInteger {
		components = append(components, `variable "random_integer" {}`)
	}
	if variables.needsRandomString {
		components = append(components, `variable "random_string" {}`)
	}

	// TODO: more

	return strings.Join(components, "\n")
}
