package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestComponentReadFunc_CommonId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
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
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentReadFunc_RegularResourceId_Disabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: resourcemanager.TerraformResourceDetails{
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
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
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentReadFunc_CommonId_Enabled(t *testing.T) {
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
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			resp, err := client.Get(ctx, *id)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %s: %+v", *id, err)
			}
			if model := resp.Model; model != nil {
				// TODO: set the ID fields into the Schema
				// TODO: set the fields from 'model' into the schema
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentReadFunc_CommonId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
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
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			resp, err := client.Get(ctx, *id, sdkresource.DefaultGetOperationOptions())
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %s: %+v", *id, err)
			}
			if model := resp.Model; model != nil {
				// TODO: set the ID fields into the Schema
				// TODO: set the fields from 'model' into the schema
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentReadFunc_RegularResourceId_Enabled(t *testing.T) {
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
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			resp, err := client.Get(ctx, *id)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %s: %+v", *id, err)
			}
			if model := resp.Model; model != nil {
				// TODO: set the ID fields into the Schema
				// TODO: set the fields from 'model' into the schema
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentReadFunc_RegularResourceId_Options_Enabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "sdkresource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
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
	actual := strings.TrimSpace(readFunctionForResource(input))
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.ExampleClient
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			resp, err := client.Get(ctx, *id, sdkresource.DefaultGetOperationOptions())
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %s: %+v", *id, err)
			}
			if model := resp.Model; model != nil {
				// TODO: set the ID fields into the Schema
				// TODO: set the fields from 'model' into the schema
			}
			return nil
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
