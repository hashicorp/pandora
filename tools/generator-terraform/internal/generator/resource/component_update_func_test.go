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

func TestComponentUpdate_HappyPathDisabled(t *testing.T) {
	input := generatorModels.ResourceInput{}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentUpdate_HappyPathDisabled_NoUpdateMethod(t *testing.T) {
	input := generatorModels.ResourceInput{
		Details: models.TerraformResourceDefinition{
			UpdateMethod: nil,
		},
	}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentUpdate_HappyPathEnabled_CommonId_SharedModels(t *testing.T) {
	t.Skip("TODO: add conditional update support?")

	input := generatorModels.ResourceInput{
		Constants: map[string]models.SDKConstant{},
		Details: models.TerraformResourceDefinition{
			APIResource: "Resources",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 30,
			},
			ResourceIDName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("SomeResourceId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: pointer.To("SomeCommon"),
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "MyTypedModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"MyTypedModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName: "some_sdk_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.SdkResource
				id, err := commonids.ParseSomeCommonID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyTypedModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				existing, err := client.Get(ctx, *id)
				if err != nil {
					return fmt.Errorf("retrieving existing %s: %+v", *id, err)
				}
				if existing.Model == nil {
					return fmt.Errorf("retrieving existing %s: properties was nil", *id)
				}
				payload := *existing.Model
				if metadata.ResourceData.HasChange("example") {
					payload.Example = config.Example
				}
				if metadata.ResourceData.HasChange("some_sdk_field") {
					payload.SomeSdkField = config.SomeField
				}
				if _, err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_HappyPathEnabled_CommonId_UniqueModels(t *testing.T) {
	t.Skip("TODO: add conditional update support?")

	input := generatorModels.ResourceInput{
		Constants: map[string]models.SDKConstant{},
		Details: models.TerraformResourceDefinition{
			APIResource: "Resources",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 30,
			},
			ResourceIDName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]models.SDKModel{
			"CreatePayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"GetPayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"UpdatePayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("CreatePayload"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("SomeResourceId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("UpdatePayload"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: pointer.To("SomeCommon"),
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "MyTypedModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"MyTypedModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName: "some_sdk_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.SdkResource
				id, err := commonids.ParseSomeCommonID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyTypedModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				payload := sdkresource.UpdatePayload{}
				if metadata.ResourceData.HasChange("example") {
					payload.Example = config.Example
				}
				if metadata.ResourceData.HasChange("some_sdk_field") {
					payload.SomeSdkField = config.SomeField
				}
				if _, err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_HappyPathEnabled_RegularResourceID_SharedModels(t *testing.T) {
	t.Skip("TODO: add conditional update support?")

	input := generatorModels.ResourceInput{
		Constants: map[string]models.SDKConstant{},
		Details: models.TerraformResourceDefinition{
			APIResource: "Resources",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 30,
			},
			ResourceIDName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("SomeResourceId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: nil,
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "MyTypedModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"MyTypedModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName: "some_sdk_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.SdkResource
				id, err := sdkresource.ParseSomeResourceID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyTypedModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				existing, err := client.Get(ctx, *id)
				if err != nil {
					return fmt.Errorf("retrieving existing %s: %+v", *id, err)
				}
				if existing.Model == nil {
					return fmt.Errorf("retrieving existing %s: properties was nil", *id)
				}
				payload := *existing.Model
				if metadata.ResourceData.HasChange("example") {
					payload.Example = config.Example
				}
				if metadata.ResourceData.HasChange("some_sdk_field") {
					payload.SomeSdkField = config.SomeField
				}
				if _, err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_HappyPathEnabled_RegularResourceID_UniqueModels(t *testing.T) {
	t.Skip("TODO: add conditional update support?")

	input := generatorModels.ResourceInput{
		Constants: map[string]models.SDKConstant{},
		Details: models.TerraformResourceDefinition{
			APIResource: "Resources",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 30,
			},
			ResourceIDName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]models.SDKModel{
			"CreatePayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"GetPayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"UpdatePayload": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("CreatePayload"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("SomeResourceId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("UpdatePayload"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: nil,
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "MyTypedModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"MyTypedModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Example": {
						HCLName: "example",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName: "some_sdk_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.SdkResource
				id, err := sdkresource.ParseSomeResourceID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyTypedModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				payload := sdkresource.UpdatePayload{}
				if metadata.ResourceData.HasChange("example") {
					payload.Example = config.Example
				}
				if metadata.ResourceData.HasChange("some_sdk_field") {
					payload.SomeSdkField = config.SomeField
				}
				if _, err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_ModelDecode(t *testing.T) {
	actual, err := updateFuncHelpers{
		resourceTypeName: "AwesomeResource",
		schemaModelName:  "MyTypedModel",
	}.modelDecode()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			var config MyTypedModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %+v", err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_PayloadDefinition_ModelSharedBetweenCreateReadUpdate(t *testing.T) {
	actual, err := updateFuncHelpers{
		createMethod: models.SDKOperation{
			LongRunning: false,
			RequestObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		createMethodName: "Create",
		readMethod: models.SDKOperation{
			LongRunning: false,
			ResponseObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: models.SDKOperation{
			LongRunning: false,
			RequestObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		updateMethodName:       "Update",
		sdkResourceNameLowered: "sdkresource",
	}.payloadDefinition()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	existing, err := client.Get(ctx, *id)
	if err != nil {
		return fmt.Errorf("retrieving existing %s: %+v", *id, err)
	}
	if existing.Model == nil {
		return fmt.Errorf("retrieving existing %s: properties was nil", *id)
	}
	payload := *existing.Model
	if err := r.mapToSharedPayload(config, &payload); err != nil {
		return fmt.Errorf("mapping schema model to sdk model: %+v", err)
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_PayloadDefinition_UniqueModelsForCreateReadUpdate(t *testing.T) {
	actual, err := updateFuncHelpers{
		createMethod: models.SDKOperation{
			LongRunning: false,
			RequestObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("CreatePayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		createMethodName: "Create",
		readMethod: models.SDKOperation{
			LongRunning: false,
			ResponseObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("ReadPayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: models.SDKOperation{
			LongRunning: false,
			RequestObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: pointer.To("UpdatePayload"),
			},
			ResourceIDName: pointer.To("SomeId"),
		},
		updateMethodName:       "Update",
		sdkResourceNameLowered: "sdkresource",
	}.payloadDefinition()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	var payload sdkresource.UpdatePayload
	if err := r.mapToUpdatePayload(config, &payload); err != nil {
		return fmt.Errorf("mapping schema model to sdk model: %+v", err)
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_ResourceIDParser(t *testing.T) {
	actual, err := updateFuncHelpers{
		resourceIdParseFuncName: "someresource.ParseTheParcel",
	}.resourceIdParser()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			id, err := someresource.ParseTheParcel(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_UpdateFunc_Immediate_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := updateFuncHelpers{
		updateMethod: models.SDKOperation{
			LongRunning:    false,
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		updateMethodName:       "UpdateThing",
		sdkResourceNameLowered: "sdkresource",
	}.update()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.UpdateThing(ctx, *id, payload); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_UpdateFunc_Immediate_PayloadResourceIdOptions(t *testing.T) {
	actual, err := updateFuncHelpers{
		updateMethod: models.SDKOperation{
			LongRunning: false,
			Options: map[string]models.SDKOperationOption{
				"example": {},
			},
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		updateMethodName:       "UpdateThing",
		sdkResourceNameLowered: "sdkresource",
	}.update()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.UpdateThing(ctx, *id, payload, sdkresource.DefaultUpdateThingOperationOptions()); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_UpdateFunc_LongRunning_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := updateFuncHelpers{
		updateMethod: models.SDKOperation{
			LongRunning:    true,
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		updateMethodName:       "UpdateThing",
		sdkResourceNameLowered: "sdkresource",
	}.update()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.UpdateThingThenPoll(ctx, *id, payload); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentUpdate_UpdateFunc_LongRunning_PayloadResourceIdOptions(t *testing.T) {
	actual, err := updateFuncHelpers{
		updateMethod: models.SDKOperation{
			LongRunning: true,
			Options: map[string]models.SDKOperationOption{
				"example": {},
			},
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		updateMethodName:       "UpdateThing",
		sdkResourceNameLowered: "sdkresource",
	}.update()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.UpdateThingThenPoll(ctx, *id, payload, sdkresource.DefaultUpdateThingOperationOptions()); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
