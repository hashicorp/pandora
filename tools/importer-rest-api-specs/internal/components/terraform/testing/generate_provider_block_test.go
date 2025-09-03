// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"testing"

	"github.com/hashicorp/hcl/v2"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/zclconf/go-cty/cty"
)

// TODO: this is currently only a single acctest since we believe the features block may want to change in the future
// based on the dependencies provided, as such since this is threaded through in a number of places this makes sense
// to split out for now

func TestProviderBlock_AllUnset(t *testing.T) {
	details := sdkModels.TerraformResourceDefinition{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{},
	}
	builder := newTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}
`
	actual, err := builder.generateProviderBlock(&actualDependencies)
	if err != nil {
		t.Fatal(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
}
