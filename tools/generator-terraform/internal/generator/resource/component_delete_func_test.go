// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentDeleteFunc_Immediate_CommonId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentDeleteFunc_Immediate_CommonId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if _, err := client.PewPew(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_Immediate_CommonId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		SdkApiVersion:      "2023-05-25-preview",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				Options: map[string]models.SDKOperationOption{
					"SomeOption": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						HeaderName: pointer.To("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525Preview.SdkResource
			id, err := commonids.ParseSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if _, err := client.PewPew(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if _, err := client.PewPew(ctx, *id); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_Immediate_RegularResourceId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		SdkApiVersion:      "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				Options: map[string]models.SDKOperationOption{
					"SomeOption": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						HeaderName: pointer.To("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: 10 * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
			id, err := sdkresource.ParseCustomSubscriptionID(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
			if _, err := client.PewPew(ctx, *id, sdkresource.DefaultPewPewOperationOptions()); err != nil {
				return fmt.Errorf("deleting %s: %+v", *id, err)
			}
			return nil
		},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_LongRunning_CommonId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentDeleteFunc_LongRunning_CommonId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
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
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_LongRunning_CommonId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		SdkApiVersion:      "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				Options: map[string]models.SDKOperationOption{
					"SomeOption": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						HeaderName: pointer.To("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
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
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
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
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentDeleteFunc_LongRunning_RegularResourceId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		SdkApiVersion:      "2023-05-25",
		Details: models.TerraformResourceDefinition{
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "PewPew",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
		},
		Operations: map[string]models.SDKOperation{
			"PewPew": {
				LongRunning:    true,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				Options: map[string]models.SDKOperationOption{
					"SomeOption": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						HeaderName: pointer.To("X-Some-Option"),
						Required:   false,
					},
				},
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				Segments: []models.ResourceIDSegment{},
			},
		},
	}
	actual, err := deleteFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20230525.SdkResource
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
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
