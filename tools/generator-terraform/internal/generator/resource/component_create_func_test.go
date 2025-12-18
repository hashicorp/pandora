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

// Create is complex enough that testing every permutation at the top level is complicated
// so we'll test the happy path and then each individual component

func TestComponentCreate_HappyPathDisabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Constants: nil,
		Details: models.TerraformResourceDefinition{
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "GetThing",
				TimeoutInMinutes: 10,
			},
			APIResource:    "SdkResource",
			ResourceIDName: "SomeResourceId",
			ResourceName:   "SomeResource",
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
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"CreateThing": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewUserSpecifiedResourceIDSegment("resourceGroupName", "resource-group-value"),
				},
			},
		},
		ResourceLabel:      "example",
		ResourceTypeName:   "Example",
		ServiceName:        "ExampleService",
		ServicePackageName: "svcpkg",
		SdkApiVersion:      "2020-01-01",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "ExampleResource",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleResource": {
				Fields: map[string]models.TerraformSchemaField{
					"ResourceGroupName": {
						ForceNew: true,
						HCLName:  "resource_group_name",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						ForceNew: true,
						HCLName:  "some_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := createFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentCreate_HappyPathFieldsInModelEnabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Constants: nil,
		Details: models.TerraformResourceDefinition{
			APIResource: "SdkResource",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			Mappings: models.TerraformMappingDefinition{
				Fields: []models.TerraformFieldMappingDefinition{},
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "ResourceGroupName",
					},
				},
			},
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "GetThing",
				TimeoutInMinutes: 10,
			},
			ResourceIDName:  "SomeResourceId",
			ResourceName:    "SomeResource",
			SchemaModelName: "ExampleResource",
			SchemaModels: map[string]models.TerraformSchemaModel{
				"ExampleResource": {
					Fields: map[string]models.TerraformSchemaField{
						"ResourceGroupName": {
							ForceNew: true,
							HCLName:  "resource_group_name",
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
							Required: true,
						},
					},
				},
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
			"CreateThing": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		ResourceLabel:      "example",
		ResourceTypeName:   "Example",
		ServiceName:        "ExampleService",
		ServicePackageName: "svcpkg",
		SdkApiVersion:      "2020-01-01",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "ExampleResource",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleResource": {
				Fields: map[string]models.TerraformSchemaField{
					"ResourceGroupName": {
						ForceNew: true,
						HCLName:  "resource_group_name",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						ForceNew: true,
						HCLName:  "some_field",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := createFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Create() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: 20 * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.ExampleService.V20200101.SdkResource
			var config ExampleResource
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %+v", err)
			}
			subscriptionId := metadata.Client.Account.SubscriptionId
			id := sdkresource.NewSomeResourceID(subscriptionId, config.ResourceGroupName)
			existing, err := client.GetThing(ctx, id)
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %s: %+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}

			var payload sdkresource.SomeModel
			if err := r.mapExampleResourceToSomeModel(config, &payload); err != nil {
				return fmt.Errorf("mapping schema model to sdk model: %+v", err)
			}
			if err := client.CreateThingThenPoll(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
			metadata.SetID(id)
			return nil
		},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_HappyPathResourceIdFieldsOnlyEnabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		Constants: nil,
		Details: models.TerraformResourceDefinition{
			APIResource: "SdkResource",
			CreateMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIDValidation: false,
			Mappings: models.TerraformMappingDefinition{
				Fields: []models.TerraformFieldMappingDefinition{},
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "ResourceGroupName",
					},
				},
			},
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "GetThing",
				TimeoutInMinutes: 10,
			},
			ResourceIDName:  "SomeResourceId",
			ResourceName:    "SomeResource",
			SchemaModelName: "ExampleResource",
			SchemaModels: map[string]models.TerraformSchemaModel{
				"ExampleResource": {
					Fields: map[string]models.TerraformSchemaField{
						"ResourceGroupName": {
							ForceNew: true,
							HCLName:  "resource_group_name",
							ObjectDefinition: models.TerraformSchemaObjectDefinition{
								Type: models.StringTerraformSchemaObjectDefinitionType,
							},
							Required: true,
						},
					},
				},
			},
		},
		Models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
					"Example": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "example",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"CreateThing": {
				LongRunning: true,
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("SomeModel"),
				},
				ResourceIDName: pointer.To("SomeResourceId"),
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"SomeResourceId": {
				CommonIDAlias: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		ResourceLabel:      "example",
		ResourceTypeName:   "Example",
		ServiceName:        "ExampleService",
		ServicePackageName: "svcpkg",
		SdkApiVersion:      "2020-01-01",
		SdkResourceName:    "SdkResource",
		SdkServiceName:     "SdkService",
		SchemaModelName:    "ExampleResource",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleResource": {
				Fields: map[string]models.TerraformSchemaField{
					"ResourceGroupName": {
						ForceNew: true,
						HCLName:  "resource_group_name",
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := createFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Create() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: 20 * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.ExampleService.V20200101.SdkResource
			var config ExampleResource
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %+v", err)
			}
			subscriptionId := metadata.Client.Account.SubscriptionId
			id := sdkresource.NewSomeResourceID(subscriptionId, config.ResourceGroupName)
			existing, err := client.GetThing(ctx, id)
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %s: %+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}
			var payload sdkresource.SomeModel
			if err := r.mapExampleResourceToSomeModel(config, &payload); err != nil {
				return fmt.Errorf("mapping schema model to sdk model: %+v", err)
			}
			if err := client.CreateThingThenPoll(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
			metadata.SetID(id)
			return nil
		},
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_Immediate_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: models.SDKOperation{
			LongRunning:    false,
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		createMethodName:       "CreateThing",
		sdkResourceNameLowered: "sdkresource",
	}.create()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.CreateThing(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_Immediate_PayloadResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: models.SDKOperation{
			LongRunning: false,
			Options: map[string]models.SDKOperationOption{
				"example": {},
			},
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		createMethodName:       "CreateThing",
		sdkResourceNameLowered: "sdkresource",
	}.create()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if _, err := client.CreateThing(ctx, id, payload, sdkresource.DefaultCreateThingOperationOptions()); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_LongRunning_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: models.SDKOperation{
			LongRunning:    true,
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		createMethodName:       "CreateThing",
		sdkResourceNameLowered: "sdkresource",
	}.create()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if err := client.CreateThingThenPoll(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_LongRunning_PayloadResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: models.SDKOperation{
			LongRunning: true,
			Options: map[string]models.SDKOperationOption{
				"example": {},
			},
			RequestObject:  &models.SDKObjectDefinition{},
			ResourceIDName: pointer.To("SomeResourceId"),
			URISuffix:      pointer.To("/example"),
		},
		createMethodName:       "CreateThing",
		sdkResourceNameLowered: "sdkresource",
	}.create()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			if err := client.CreateThingThenPoll(ctx, id, payload, sdkresource.DefaultCreateThingOperationOptions()); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_RequiresImport_ResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		readMethod: models.SDKOperation{
			LongRunning:    false,
			ResourceIDName: pointer.To("SomeResourceId"),
		},
		readMethodName:         "GetThing",
		sdkResourceNameLowered: "sdkresource",
	}.requiresImport()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			existing, err := client.GetThing(ctx, id)
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %s: %+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_RequiresImport_ResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		readMethod: models.SDKOperation{
			LongRunning: false,
			Options: map[string]models.SDKOperationOption{
				"example": {},
			},
			ResourceIDName: pointer.To("SomeResourceId"),
		},
		readMethodName:         "GetThing",
		sdkResourceNameLowered: "sdkresource",
	}.requiresImport()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			existing, err := client.GetThing(ctx, id, sdkresource.DefaultGetThingOperationOptions())
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %s: %+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_CommonResourceIDWithSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "commonids.NewCommonResourceID",
		resourceId: models.ResourceID{
			CommonIDAlias: pointer.To("CommonResource"),
			ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					ForceNew: true,
					HCLName:  "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "Name",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	subscriptionId := metadata.Client.Account.SubscriptionId
	id := commonids.NewCommonResourceID(subscriptionId, config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_CommonResourceIDWithoutSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "commonids.NewCommonResourceID",
		resourceId: models.ResourceID{
			CommonIDAlias: pointer.To("CommonResource"),
			ExampleValue:  "/resourceGroups/{resourceGroupName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					ForceNew: true,
					HCLName:  "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "Name",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	id := commonids.NewCommonResourceID(config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDWithSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "sdkresource.NewSomeResourceID",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					ForceNew: true,
					HCLName:  "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "Name",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	subscriptionId := metadata.Client.Account.SubscriptionId
	id := sdkresource.NewSomeResourceID(subscriptionId, config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDWithoutSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "sdkresource.NewSomeResourceID",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/resourceGroups/{resourceGroupName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewUserSpecifiedResourceIDSegment("resourceGroupName", "resource-group-value"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					ForceNew: true,
					HCLName:  "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "Name",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	id := sdkresource.NewSomeResourceID(config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDConstantSegment(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName:  "sdkresource.NewSomeResourceID",
		sdkResourceNameLowered: "sdkresource",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/animals/{animalType}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("animals", "animals"),
				models.NewConstantResourceIDSegment("animalType", "AnimalType", "panda"),
			},
			ConstantNames: []string{"AnimalType"},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Animal": {
					ForceNew: true,
					HCLName:  "animal",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "animalType",
					TerraformSchemaFieldName: "Animal",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	id := sdkresource.NewSomeResourceID(sdkresource.AnimalType(config.Animal))
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_ParentResourceID(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "sdkresource.NewSomeResourceID",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/parentResource/{parentResourceName}/resource/{resourceName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				models.NewStaticValueResourceIDSegment("parentResource", "parentResource"),
				models.NewUserSpecifiedResourceIDSegment("parentResourceName", "parent-resource-value"),
				models.NewStaticValueResourceIDSegment("resource", "resource"),
				models.NewUserSpecifiedResourceIDSegment("resourceName", "resource-value"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					ForceNew: true,
					HCLName:  "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
				"ParentResourceId": {
					ForceNew: true,
					HCLName:  "parent_resource_id",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "resourceName",
					TerraformSchemaFieldName: "Name",
				},
				{
					ParsedFromParentID:       true,
					SegmentName:              "parentResourceName",
					TerraformSchemaFieldName: "ParentResourceId",
				},
				{
					ParsedFromParentID:       true,
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "ParentResourceId",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	subscriptionId := metadata.Client.Account.SubscriptionId
	parentResourceId, err := commonids.ParseParentResourceID(config.ParentResourceId)
	if err != nil {
		return err
	}
	id := sdkresource.NewSomeResourceID(subscriptionId, parentResourceId.ResourceGroupName, parentResourceId.parentResourceName, config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_ParentResourceIDKubernetesExample(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "trustedAccess.NewTrustedAccessRoleBindingID",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}/trustedAccessRoleBindings/{trustedAccessRoleBindingName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				models.NewStaticValueResourceIDSegment("providers", "providers"),
				models.NewStaticValueResourceIDSegment("resourceProvider", "Microsoft.ContainerService"),
				models.NewStaticValueResourceIDSegment("managedClusters", "managedClusters"),
				models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managed-cluster-value"),
				models.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
				models.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trusted-access-role-binding-value"),
			},
		},
		terraformModel: models.TerraformSchemaModel{
			Fields: map[string]models.TerraformSchemaField{
				"Name": {
					HCLName: "name",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
					ForceNew: true,
				},
				"ManagedClusterId": {
					HCLName: "kubernetes_cluster_id",
					ObjectDefinition: models.TerraformSchemaObjectDefinition{
						Type: models.StringTerraformSchemaObjectDefinitionType,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: models.TerraformMappingDefinition{
			ResourceID: []models.TerraformResourceIDMappingDefinition{
				{
					SegmentName:              "trustedAccessRoleBindingName",
					TerraformSchemaFieldName: "Name",
				},
				{
					ParsedFromParentID:       true,
					SegmentName:              "managedClusterName",
					TerraformSchemaFieldName: "ManagedClusterId",
				},
				{
					ParsedFromParentID:       true,
					SegmentName:              "resourceGroupName",
					TerraformSchemaFieldName: "ManagedClusterId",
				},
			},
		},
	}.idDefinitionAndMapping()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	subscriptionId := metadata.Client.Account.SubscriptionId
	managedClusterId, err := commonids.ParseManagedClusterID(config.ManagedClusterId)
	if err != nil {
		return err
	}
	id := trustedaccess.NewTrustedAccessRoleBindingID(subscriptionId, managedClusterId.ResourceGroupName, managedClusterId.ManagedClusterName, config.Name)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_PayloadDefinition(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: models.SDKOperation{
			RequestObject: &models.SDKObjectDefinition{
				ReferenceName: pointer.To("SomeModel"),
				Type:          models.ReferenceSDKObjectDefinitionType,
			},
		},
		terraformModelName:     "TerraformModel",
		sdkResourceNameLowered: "sdkresource",
	}.payloadDefinition()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	var payload sdkresource.SomeModel
	if err := r.mapTerraformModelToSomeModel(config, &payload); err != nil {
		return fmt.Errorf("mapping schema model to sdk model: %+v", err)
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_SchemaDeserialization(t *testing.T) {
	actual, err := createFunctionComponents{
		resourceTypeName:   "AwesomeResource",
		terraformModelName: "AwesomeResourceTypedModel",
	}.schemaDeserialization()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			var config AwesomeResourceTypedModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %+v", err)
			}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
