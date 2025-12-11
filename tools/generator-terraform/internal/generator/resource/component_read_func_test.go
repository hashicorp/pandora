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

func TestComponentReadFunc_CommonId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentReadFunc_RegularResourceId_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         false,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentReadFunc_CommonId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2021-01-01",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetModel"),
				},
			},
		},
		Models: map[string]models.SDKModel{
			"GetModel": {
				Fields: map[string]models.SDKField{
					"Name": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName:  "some_field",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20210101.SdkResource
			schema := ExampleModel{}
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
				schema.Name = id.ResourceGroupName
				if err := r.mapGetModelToExampleModel(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %+v", err)
				}
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CommonId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		SdkApiVersion:      "2021-01-01",
		ServicePackageName: "sdkservicepackage",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetModel"),
				},
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
		Models: map[string]models.SDKModel{
			"GetModel": {
				Fields: map[string]models.SDKField{
					"Name": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName:  "some_field",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20210101.SdkResource
			schema := ExampleModel{}
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
				schema.Name = id.ResourceGroupName
				if err := r.mapGetModelToExampleModel(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %+v", err)
				}
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_RegularResourceId_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2021-01-01",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetModel"),
				},
			},
		},
		Models: map[string]models.SDKModel{
			"GetModel": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"SomeSdkField": {
						JsonName: "someSdkField",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				ExampleValue: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Name": {
						HCLName:  "name",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
					"SomeField": {
						HCLName:  "some_field",
						ForceNew: true,
						ObjectDefinition: models.TerraformSchemaObjectDefinition{
							Type: models.StringTerraformSchemaObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
	}
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20210101.SdkResource
			schema := ExampleModel{}
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
				schema.Name = id.ResourceGroupName
				if err := r.mapGetModelToExampleModel(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %+v", err)
				}
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_RegularResourceId_Constant_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
		ServiceName:      "Resources",
		SdkApiVersion:    "2021-01-01",
		Constants: map[string]models.SDKConstant{
			"AnimalType": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"Cow":   "Cow",
					"Panda": "Panda",
				},
			},
		},
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "animalType",
						TerraformSchemaFieldName: "Animal",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetModel"),
				},
			},
		},
		Models: map[string]models.SDKModel{
			"GetModel": {
				Fields: map[string]models.SDKField{
					"Name": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				ExampleValue: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("animals", "animals"),
					models.NewConstantResourceIDSegment("animalType", "AnimalType", "Panda"),
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Animal": {
						ForceNew: true,
						HCLName:  "animal",
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20210101.SdkResource
			schema := ExampleModel{}
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
				schema.Animal = string(id.AnimalType)
				if err := r.mapGetModelToExampleModel(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %+v", err)
				}
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_RegularResourceId_Options_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
		ServiceName:        "Resources",
		ServicePackageName: "sdkservicepackage",
		SdkApiVersion:      "2021-01-01",
		Details: models.TerraformResourceDefinition{
			ReadMethod: models.TerraformMethodDefinition{
				Generate:         true,
				SDKOperationName: "Get",
				TimeoutInMinutes: 10,
			},
			ResourceIDName: "CustomSubscriptionId",
			Mappings: models.TerraformMappingDefinition{
				ResourceID: []models.TerraformResourceIDMappingDefinition{
					{
						SegmentName:              "resourceGroupName",
						TerraformSchemaFieldName: "Name",
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: pointer.To("CustomSubscriptionId"),
				ResponseObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: pointer.To("GetModel"),
				},
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
		Models: map[string]models.SDKModel{
			"GetModel": {
				Fields: map[string]models.SDKField{
					"Name": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				ExampleValue: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]models.TerraformSchemaModel{
			"ExampleModel": {
				Fields: map[string]models.TerraformSchemaField{
					"Name": {
						ForceNew: true,
						HCLName:  "name",
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.V20210101.SdkResource
			schema := ExampleModel{}
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
				schema.Name = id.ResourceGroupName
				if err := r.mapGetModelToExampleModel(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %+v", err)
				}
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForIDParser(t *testing.T) {
	actual, err := readFunctionComponents{
		idParseLine: "plz.Parse",
	}.codeForIDParser()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	id, err := plz.Parse(metadata.ResourceData.Id())
	if err != nil {
		return err
	}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForIDParserWithParentResourceKubernetesExample(t *testing.T) {
	actual, err := readFunctionComponents{
		idParseLine:    "trustedaccess.ParseTrustedAccessRoleBindingID",
		parentResource: "ManagedClusterId",
		parentSegment:  "managedClusterName",
		resourceId: models.ResourceID{
			CommonIDAlias: nil,
			ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}/trustedAccessRoleBindings/{trustedAccessRoleBindingName}",
			Segments: []models.ResourceIDSegment{
				models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
				models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
				models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				models.NewStaticValueResourceIDSegment("providers", "providers"),
				models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.ContainerService"),
				models.NewStaticValueResourceIDSegment("managedClusters", "managedClusters"),
				models.NewUserSpecifiedResourceIDSegment("managedClusterName", "managed-cluster-value"),
				models.NewStaticValueResourceIDSegment("trustedAccessRoleBindings", "trustedAccessRoleBindings"),
				models.NewUserSpecifiedResourceIDSegment("trustedAccessRoleBindingName", "trusted-access-role-binding-value"),
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
				"ManagedClusterId": {
					ForceNew: true,
					HCLName:  "kubernetes_cluster_id",
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
	}.codeForIDParser()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	id, err := trustedaccess.ParseTrustedAccessRoleBindingID(metadata.ResourceData.Id())
	if err != nil {
		return err
	}
	managedClusterId := commonids.NewManagedClusterID(id.SubscriptionId, id.ResourceGroupName, id.ManagedClusterName)
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForGet(t *testing.T) {
	actual, err := readFunctionComponents{
		readMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		readOperation: models.SDKOperation{
			ResourceIDName: pointer.To("SomeResourceId"),
		},
		sdkResourceName: "SdkResource",
	}.codeForGet()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
		resp, err := client.Get(ctx, *id)
		if err != nil {
			if response.WasNotFound(resp.HttpResponse) {
				return metadata.MarkAsGone(*id)
			}
			return fmt.Errorf("retrieving %s: %+v", *id, err)
		}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForGet_Options(t *testing.T) {
	actual, err := readFunctionComponents{
		readMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		readOperation: models.SDKOperation{
			ResourceIDName: pointer.To("SomeResourceId"),
			Options: map[string]models.SDKOperationOption{
				"Example": {},
			},
		},
		sdkResourceName: "SdkResource",
	}.codeForGet()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
		resp, err := client.Get(ctx, *id, sdkresource.DefaultGetOperationOptions())
		if err != nil {
			if response.WasNotFound(resp.HttpResponse) {
				return metadata.MarkAsGone(*id)
			}
			return fmt.Errorf("retrieving %s: %+v", *id, err)
		}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
