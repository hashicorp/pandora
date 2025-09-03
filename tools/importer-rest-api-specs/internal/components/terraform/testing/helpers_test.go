// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"reflect"
	"strings"
	"testing"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/gohcl"
	"github.com/hashicorp/hcl/v2/hclparse"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/zclconf/go-cty/cty"
)

type providerBlock struct {
	Name string `hcl:"name,label"`

	Fields hcl.Body `hcl:",remain"`
}

type resourceBlock struct {
	ResourceLabel string `hcl:"label,label"`
	Name          string `hcl:"name,label"`

	Fields hcl.Body `hcl:",remain"`
}

type testConfiguration struct {
	Provider []providerBlock `hcl:"provider,block"`
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
		t.Fatal(diags.Error())
	}
	if diags := gohcl.DecodeBody(expectedFile.Body, ctx, &expectedParsed); diags != nil {
		t.Fatalf("decoding content for `expected`: %+v\n\nContent:\n\n%s", diags.Error(), actual)
	}

	var actualParsed testConfiguration
	actualFile, diags := parser.ParseHCL([]byte(actual), "actual.hcl")
	if diags.HasErrors() {
		t.Fatalf("decoding content for `actual`: %+v\n\nContent:\n\n%s", diags.Error(), actual)
	}
	if diags := gohcl.DecodeBody(actualFile.Body, ctx, &actualParsed); diags != nil {
		t.Fatalf("decoding `actual`: %+v", diags.Error())
	}

	if matches := validateParsedConfigsMatch(t, expectedParsed, actualParsed, ctx); !matches {
		t.Fatalf("expected and actual differ.\n\nExpected: %+v\n\nActual: %+v", expectedParsed, actualParsed)
	}
}

func validateParsedConfigsMatch(t *testing.T, expected testConfiguration, actual testConfiguration, ctx *hcl.EvalContext) bool {
	// Validate the Provider blocks
	if len(expected.Provider) != len(actual.Provider) {
		t.Logf("expected and actual have different provider counts - expected %d but got %d", len(expected.Resource), len(actual.Resource))
		return false
	}
	for _, expectedProvider := range expected.Provider {
		var actualResource *providerBlock
		for _, v := range actual.Provider {
			if expectedProvider.Name == v.Name {
				actualResource = &v
				break
			}
		}
		if actualResource == nil {
			t.Logf("expected provider `%s` was not found in actual", expectedProvider.Name)
			return false
		}

		// validate the fields match
		expectedBody := expectedProvider.Fields.(*hclsyntax.Body)
		actualBody := actualResource.Fields.(*hclsyntax.Body)
		if match := validateAttributesMatch(t, expectedBody.Attributes, actualBody.Attributes, ctx); !match {
			return false
		}
		if match := validateBlocksMatch(t, expectedBody.Blocks, actualBody.Blocks, ctx); !match {
			return false
		}
	}

	// Validate the Resources
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
		if match := validateBlocksMatch(t, expectedBody.Blocks, actualBody.Blocks, ctx); !match {
			return false
		}
	}

	return true
}

func validateBlocksMatch(t *testing.T, expected hclsyntax.Blocks, actual hclsyntax.Blocks, ctx *hcl.EvalContext) bool {
	if len(expected) != len(actual) {
		t.Logf("expected %d blocks but got %d blocks", len(expected), len(actual))
		return false
	}

	for _, expectedBlock := range expected {
		var actualBlock *hclsyntax.Block
		for _, v := range actual {
			if expectedBlock.Type == v.Type && labelsMatch(expectedBlock.Labels, v.Labels) {
				actualBlock = v
				break
			}
		}
		if actualBlock == nil {
			t.Fatalf("expected to find the block %q with labels %q in actual but didn't", expectedBlock.Type, strings.Join(expectedBlock.Labels, ", "))
		}

		t.Logf("validating the nested attributes match for the block %q with labels %q", expectedBlock.Type, strings.Join(expectedBlock.Labels, ", "))
		validateAttributesMatch(t, expectedBlock.Body.Attributes, actualBlock.Body.Attributes, ctx)

		t.Logf("validating the nested blocks match for the block %q with labels %q", expectedBlock.Type, strings.Join(expectedBlock.Labels, ", "))
		validateBlocksMatch(t, expectedBlock.Body.Blocks, actualBlock.Body.Blocks, ctx)
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

func assertDependenciesMatch(t *testing.T, expected testDependencies, actual testDependencies) {
	if !reflect.DeepEqual(expected, actual) {
		t.Fatalf("expected and actual dependencies differ - expected:\n\n%+v\n\ngot:\n\n%+v", expected, actual)
	}
}

func labelsMatch(expected []string, actual []string) bool {
	if len(expected) != len(actual) {
		return false
	}

	for i, expectedVal := range expected {
		actualVal := actual[i]
		if expectedVal != actualVal {
			return false
		}
	}

	return true
}

func renderBlocksToHcl(input []*hclwrite.Block) string {
	// why can't we reuse validateBlocksMatch? `hclsyntax` and `hclwrite` contain entirely separate implementations
	// in this case we can render the output and compare that
	f := hclwrite.NewEmptyFile()
	for _, block := range input {
		f.Body().AppendBlock(block)
	}
	body := hclwrite.Format(f.Bytes())
	return string(body)
}
