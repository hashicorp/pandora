package generator

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"strings"
	"testing"
)

func TestExistsFuncForResourceTest_CommonId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(existsFuncForResourceTest(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}


func TestExistsFuncForResourceTest_RegularResourceId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(existsFuncForResourceTest(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}


func TestExistsFuncForResourceTest_CommonId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(existsFuncForResourceTest(input))
	expected := `
func (r ExampleResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := commonids.ParseSubscriptionID(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.Resources.ExampleClient.Get(ctx, *id)
	if err != nil {
		return fmt.Errorf("reading %s: %+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestExistsFuncForResourceTest_RegularResourceId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(existsFuncForResourceTest(input))
	expected := `
func (r ExampleResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := sdkresource.ParseCustomSubscriptionID(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.Resources.ExampleClient.Get(ctx, *id)
	if err != nil {
		return fmt.Errorf("reading %s: %+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
