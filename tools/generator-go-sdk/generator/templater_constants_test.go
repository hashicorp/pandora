package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTemplateConstantsSingle(t *testing.T) {
	actual, err := constantsTemplater{
		// output the bare minimum for testing
		constantTemplateFunc: func(name string, details resourcemanager.ConstantDetails) (*string, error) {
			out := fmt.Sprintf("// template for %s", name)
			return &out, nil
		},
	}.template(ServiceGeneratorData{
		constants: map[string]resourcemanager.ConstantDetails{
			"first": {
				Type:   resourcemanager.StringConstant,
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
		constantTemplateFunc: func(name string, details resourcemanager.ConstantDetails) (*string, error) {
			out := fmt.Sprintf("// template for %s", name)
			return &out, nil
		},
	}.template(ServiceGeneratorData{
		constants: map[string]resourcemanager.ConstantDetails{
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
