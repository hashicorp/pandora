package testing

import (
	"testing"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

// TODO: this is currently only a single acctest since we believe the features block may want to change in the future
// based on the dependencies provided, as such since this is threaded through in a number of places this makes sense
// to split out for now

func TestProviderBlock_AllUnset(t *testing.T) {
	details := resourcemanager.TerraformResourceDetails{}
	actualDependencies := testDependencies{
		variables: testVariables{},
	}
	hclContext := &hcl.EvalContext{
		Variables: map[string]cty.Value{},
	}
	builder := NewTestBuilder("example", "resource", details)
	expected := `
provider "example" {
  features {}
}
`
	actual, err := builder.generateProviderBlock(&actualDependencies)
	if err != nil {
		t.Fatalf(err.Error())
	}

	assertTerraformConfigurationsAreSemanticallyTheSame(t, expected, *actual, hclContext)
}
