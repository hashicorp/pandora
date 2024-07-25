// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestTemplateConstantsSingle(t *testing.T) {
	actual, err := constantsTemplater{
		// output the bare minimum for testing
		constantTemplateFunc: func(name string, details models.SDKConstant, generateNormalizationFunction, usedInAResourceId bool) (*string, error) {
			out := fmt.Sprintf("// template for %s", name)
			return &out, nil
		},
	}.template(GeneratorData{
		constants: map[string]models.SDKConstant{
			"first": {
				Type:   models.StringSDKConstantType,
				Values: map[string]string{
					// just a placeholder
				},
			},
		},
		packageName: "somepackage",
		source:      AccTestLicenceType,
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `package somepackage

import "strings"

// acctests licence placeholder
// template for first
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateConstantsMultiple(t *testing.T) {
	// asserting these are output alphabetically
	actual, err := constantsTemplater{
		// output the bare minimum for testing
		constantTemplateFunc: func(name string, details models.SDKConstant, generateNormalizationFunction, usedInAResourceId bool) (*string, error) {
			out := fmt.Sprintf("// template for %s", name)
			return &out, nil
		},
	}.template(GeneratorData{
		constants: map[string]models.SDKConstant{
			"third":  {},
			"first":  {},
			"second": {},
		},
		packageName: "somepackage",
		source:      AccTestLicenceType,
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `package somepackage

import "strings"

// acctests licence placeholder
// template for first
// template for second
// template for third
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
