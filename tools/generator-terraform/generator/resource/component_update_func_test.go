// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentUpdate_HappyPathDisabled(t *testing.T) {
	input := models.ResourceInput{}
	actual, err := updateFuncForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentUpdate_HappyPathDisabled_NoUpdateMethod(t *testing.T) {
	input := models.ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
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

	input := models.ResourceInput{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
				TimeoutInMinutes: 30,
			},
			Resource:       "Resources",
			ResourceIdName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: pointer.To("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: pointer.To("SomeCommon"),
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"MyTypedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Example": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "example",
						Required: true,
					},
					"SomeField": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "some_sdk_field",
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

	input := models.ResourceInput{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
				TimeoutInMinutes: 30,
			},
			Resource:       "Resources",
			ResourceIdName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"CreatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"GetPayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"UpdatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("CreatePayload"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: pointer.To("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("UpdatePayload"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: pointer.To("SomeCommon"),
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"MyTypedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Example": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "example",
						Required: true,
					},
					"SomeField": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "some_sdk_field",
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

	input := models.ResourceInput{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
				TimeoutInMinutes: 30,
			},
			Resource:       "Resources",
			ResourceIdName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: pointer.To("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: nil,
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"MyTypedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Example": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "example",
						Required: true,
					},
					"SomeField": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "some_sdk_field",
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

	input := models.ResourceInput{
		Constants: map[string]resourcemanager.ConstantDetails{},
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Create",
				TimeoutInMinutes: 10,
			},
			DeleteMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Delete",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Get",
				TimeoutInMinutes: 30,
			},
			Resource:       "Resources",
			ResourceIdName: "SomeResourceId",
			ResourceName:   "SomeResource",
			UpdateMethod: &resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "Update",
				TimeoutInMinutes: 40,
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"CreatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"GetPayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
			"UpdatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
					"SomeSdkField": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "someSdkField",
					},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("CreatePayload"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: pointer.To("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: pointer.To("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: pointer.To("UpdatePayload"),
				},
				ResourceIdName: pointer.To("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: nil,
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"MyTypedModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Example": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "example",
						Required: true,
					},
					"SomeField": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						HclName:  "some_sdk_field",
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
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
		},
		createMethodName: "Create",
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SharedPayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
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
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("CreatePayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
		},
		createMethodName: "Create",
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("ReadPayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("UpdatePayload"),
			},
			ResourceIdName: pointer.To("SomeId"),
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
		updateMethod: resourcemanager.ApiOperation{
			LongRunning:    false,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: pointer.To("SomeResourceId"),
			UriSuffix:      pointer.To("/example"),
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
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: pointer.To("SomeResourceId"),
			UriSuffix:      pointer.To("/example"),
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
		updateMethod: resourcemanager.ApiOperation{
			LongRunning:    true,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: pointer.To("SomeResourceId"),
			UriSuffix:      pointer.To("/example"),
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
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: true,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: pointer.To("SomeResourceId"),
			UriSuffix:      pointer.To("/example"),
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
