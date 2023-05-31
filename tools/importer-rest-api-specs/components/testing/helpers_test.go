package testing

import (
	"testing"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/gohcl"
	"github.com/hashicorp/hcl/v2/hclparse"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/zclconf/go-cty/cty"
)

type resourceBlock struct {
	ResourceLabel string `hcl:"label,label"`
	Name          string `hcl:"name,label"`

	Fields hcl.Body `hcl:",remain"`
}
type testConfiguration struct {
	Resource []resourceBlock `hcl:"resource,block"`
}

func assertTerraformConfigurationsAreSemanticallyTheSame(t *testing.T, expected, actual string, ctx *hcl.EvalContext) {
	if actual == "" {
		t.Fatalf("actual is empty")
	}

	parser := hclparse.NewParser()
	var expectedParsed testConfiguration
	expectedFile, diags := parser.ParseHCL([]byte(expected), "expected.hcl")
	if diags.HasErrors() {
		t.Fatalf(diags.Error())
	}
	if diags := gohcl.DecodeBody(expectedFile.Body, ctx, &expectedParsed); diags != nil {
		t.Fatalf("decoding `expected`: %+v", diags.Error())
	}

	var actualParsed testConfiguration
	actualFile, diags := parser.ParseHCL([]byte(actual), "actual.hcl")
	if diags.HasErrors() {
		t.Fatalf(diags.Error())
	}
	if diags := gohcl.DecodeBody(actualFile.Body, ctx, &actualParsed); diags != nil {
		t.Fatalf("decoding `actual`: %+v", diags.Error())
	}

	if matches := validateParsedConfigsMatch(t, expectedParsed, actualParsed, ctx); !matches {
		t.Fatalf("expected and actual differ.\n\nExpected: %+v\n\nActual: %+v", expectedParsed, actualParsed)
	}
}

func validateParsedConfigsMatch(t *testing.T, expected testConfiguration, actual testConfiguration, ctx *hcl.EvalContext) bool {
	if len(expected.Resource) != len(actual.Resource) {
		t.Logf("expected and actual have different resource counts - expected %d but got %d", len(expected.Resource), len(actual.Resource))
		return false
	}

	for _, expectedResource := range expected.Resource {
		var actualResource *resourceBlock
		for _, v := range actual.Resource {
			if expectedResource.ResourceLabel == v.ResourceLabel && expectedResource.Name == v.Name {
				actualResource = &v
				break
			}
		}
		if actualResource == nil {
			t.Logf("expected resource `%s.%s` was not found in actual", expectedResource.ResourceLabel, expectedResource.Name)
			return false
		}

		// validate the fields match
		expectedBody := expectedResource.Fields.(*hclsyntax.Body)
		actualBody := actualResource.Fields.(*hclsyntax.Body)
		if match := validateAttributesMatch(t, expectedBody.Attributes, actualBody.Attributes, ctx); !match {
			return false
		}
		// TODO: validating blocks
	}

	return true
}

func validateAttributesMatch(t *testing.T, expected hclsyntax.Attributes, actual hclsyntax.Attributes, ctx *hcl.EvalContext) bool {
	if len(expected) != len(actual) {
		t.Fatalf("expected and actual have a different number of attributes - expected %d but got %d", len(expected), len(actual))
	}

	for key, expectedVal := range expected {
		if key == "name" || key == "label" {
			// checked elsewhere
			continue
		}

		actualVal, ok := actual[key]
		if !ok {
			t.Logf("the key %q exists in expected but not in actual", key)
		}

		expectedValue, diags := expectedVal.Expr.Value(ctx)
		if diags.HasErrors() {
			t.Fatalf("parsing the value for the expected attribute %q: %+v - value %+v", key, diags.Error(), expectedValue)
		}
		actualValue, diags := actualVal.Expr.Value(ctx)
		if diags.HasErrors() {
			t.Fatalf("parsing the value for the actual attribute %q: %+v - value: %+v", key, diags.Error(), actualValue)
		}
		if expectedValue.Equals(actualValue) != cty.True {
			t.Fatalf("the values differ for the attribute %q - expected `%+v` but got `%+v`", key, expectedValue, actualValue)
		}
	}

	return true
}
