// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package examples

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/zclconf/go-cty/cty"
)

var variableReplacements = map[string]cty.Value{
	"primary_location": cty.StringVal("West Europe"),
	"random_integer":   cty.NumberIntVal(int64(21)),
	"random_string":    cty.StringVal("example"),
	// TODO: bools etc, when implemented in the test generator
}

func updatedValueForAttribute(resourceKey, fieldKey string, value string) (*hclwrite.Tokens, error) {
	// if it's entirely a reference to a value, then let's just output the example value for that
	if strings.HasPrefix(value, "var.") {
		variableName := strings.TrimPrefix(value, "var.")
		replacement, ok := variableReplacements[variableName]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing a replacement value for the variable %q", variableName)
		}
		out := hclwrite.TokensForValue(replacement)
		return &out, nil
	}

	// NOTE: name is special-case since we add the resource name to it, we could regex this but it's
	// possible to use different kinds of variables too, so a string check is simpler
	if fieldKey == "name" && strings.HasPrefix(value, "\"acctest") && strings.Contains(value, "var.") {
		out := hclwrite.TokensForValue(cty.StringVal("example"))
		if resourceKey == "azurerm_resource_group" {
			out = hclwrite.TokensForValue(cty.StringVal("example-resources"))
		}
		return &out, nil
	}

	if strings.Contains(value, "var.") {
		// then we need to parse each variable out and replace it
		for key, replacement := range variableReplacements {
			val := ""
			if replacement.Type().Equals(cty.Bool) {
				val = fmt.Sprintf("%t", replacement.RawEquals(cty.True))
			}
			if replacement.Type().Equals(cty.Number) {
				val = replacement.AsBigFloat().String()
			}
			if replacement.Type().Equals(cty.String) {
				val = replacement.AsString()
			}
			if val == "" {
				return nil, fmt.Errorf("internal-error: missing replacement for cty.Type %q", replacement.Type().GoString())
			}
			value = strings.ReplaceAll(value, fmt.Sprintf("${var.%s}", key), val)
		}
		value = strings.TrimPrefix(value, "\"")
		value = strings.TrimSuffix(value, "\"")
		out := hclwrite.TokensForValue(cty.StringVal(value))
		return &out, nil
	}

	if strings.Contains(value, ".test.") {
		// if this is a reference to another resource, we should transform that and return it
		updatedValue := hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: strings.ReplaceAll(value, ".test.", ".example."),
			},
		})
		return &updatedValue, nil
	}

	out := hclwrite.TokensForValue(cty.StringVal("example-value"))
	return &out, nil
}
