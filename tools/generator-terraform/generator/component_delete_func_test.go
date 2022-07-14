package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: with/without Options etc
// we have to have a Resource ID else we wouldn't be here, so that much is predictable
// when options are present we can use `DefaultXXXOptions`

func TestComponentDeleteFunc_Immediate_CommonId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethodName: "PewPew",
			GenerateDelete:   false,
			ResourceIdName:   "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("SubscriptionId"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Disabled(t *testing.T) {
	t.Fatal("not yet implemented")
}

func TestComponentDeleteFunc_Immediate_CommonId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethodName: "PewPew",
			GenerateDelete:   false,
			ResourceIdName:   "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("SubscriptionId"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Enabled(t *testing.T) {
	t.Fatal("not yet implemented")
}

func TestComponentDeleteFunc_LongRunning_CommonId_Disabled(t *testing.T) {
	t.Fatal("not yet implemented")
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Disabled(t *testing.T) {
	t.Fatal("not yet implemented")
}

func TestComponentDeleteFunc_LongRunning_CommonId_Enabled(t *testing.T) {
	t.Fatal("not yet implemented")
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Enabled(t *testing.T) {
	t.Fatal("not yet implemented")
}
