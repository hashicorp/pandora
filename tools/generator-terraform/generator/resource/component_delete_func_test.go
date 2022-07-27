package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestComponentDeleteFunc_Immediate_CommonId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
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
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
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
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_CommonId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
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
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPew(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_CommonId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"SomeOption": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						HeaderName: stringPointer("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPew(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
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
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPew(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"SomeOption": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						HeaderName: stringPointer("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPew(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_CommonId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_CommonId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPewThenPoll(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_CommonId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"SomeOption": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						HeaderName: stringPointer("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPewThenPoll(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPewThenPoll(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		Details: resourcemanager.TerraformResourceDetails{
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIdName: "CustomSubscriptionId",
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIdName: stringPointer("CustomSubscriptionId"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"SomeOption": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						HeaderName: stringPointer("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Segments: []resourcemanager.ResourceIdSegment{},
			},
		},
	}
	actual := strings.TrimSpace(deleteFunctionForResource(input))
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if err := client.PewPewThenPoll(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
