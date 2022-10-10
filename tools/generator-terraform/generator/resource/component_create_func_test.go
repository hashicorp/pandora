package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/featureflags"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: re-introduce Mappings for Schema <-> SDK

// Create is complex enough that testing every permutation at the top level is complicated
// so we'll test the happy path and then each individual component

func TestComponentCreate_HappyPathDisabled(t *testing.T) {
	input := models.ResourceInput{
		Constants: nil,
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "GetThing",
				TimeoutInMinutes: 10,
			},
			Resource:       "SdkResource",
			ResourceIdName: "SomeResourceId",
			ResourceName:   "SomeResource",
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
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"CreateThing": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: nil,
				Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "subscriptions",
						FixedValue: stringPointer("subscriptions"),
					},
					{
						Type: resourcemanager.SubscriptionIdSegment,
						Name: "subscriptionId",
					},
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "resourceGroups",
						FixedValue: stringPointer("resourceGroups"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "resourceGroupName",
						ExampleValue: "resource-group-value",
					},
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
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		Constants: nil,
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "GetThing",
				TimeoutInMinutes: 10,
			},
			Resource:        "SdkResource",
			ResourceIdName:  "SomeResourceId",
			ResourceName:    "SomeResource",
			SchemaModelName: "ExampleResource",
			SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"ExampleResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"ResourceGroupName": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
							Required: true,
							ForceNew: true,
							HclName:  "resource_group_name",
						},
					},
				},
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
			"CreateThing": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: nil,
				Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "subscriptions",
						FixedValue: stringPointer("subscriptions"),
					},
					{
						Type: resourcemanager.SubscriptionIdSegment,
						Name: "subscriptionId",
					},
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "resourceGroups",
						FixedValue: stringPointer("resourceGroups"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "resourceGroupName",
						ExampleValue: "resource-group-value",
					},
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleResource": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroupName": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
						HclName:  "resource_group_name",
					},
					"SomeField": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
						HclName:  "some_field",
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
			client := metadata.Client.ExampleService.SdkResource
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
			payload := sdkresource.SomeModel{}
			payload.SomeSdkField = config.SomeField
			if err := client.CreateThingThenPoll(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
			metadata.SetID(id)
			return nil
		},
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_HappyPathResourceIdFieldsOnlyEnabled(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		Constants: nil,
		Details: resourcemanager.TerraformResourceDetails{
			CreateMethod: resourcemanager.MethodDefinition{
				Generate:         true,
				MethodName:       "CreateThing",
				TimeoutInMinutes: 20,
			},
			DisplayName:          "Some Resource",
			Generate:             true,
			GenerateSchema:       false,
			GenerateIdValidation: false,
			ReadMethod: resourcemanager.MethodDefinition{
				Generate:         false,
				MethodName:       "GetThing",
				TimeoutInMinutes: 10,
			},
			Resource:        "SdkResource",
			ResourceIdName:  "SomeResourceId",
			ResourceName:    "SomeResource",
			SchemaModelName: "ExampleResource",
			SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
				"ExampleResource": {
					Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
						"ResourceGroupName": {
							ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
								Type: resourcemanager.TerraformSchemaFieldTypeString,
							},
							Required: true,
							ForceNew: true,
							HclName:  "resource_group_name",
						},
					},
				},
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
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"CreateThing": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"GetThing": {
				LongRunning: false,
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: nil,
				Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "subscriptions",
						FixedValue: stringPointer("subscriptions"),
					},
					{
						Type: resourcemanager.SubscriptionIdSegment,
						Name: "subscriptionId",
					},
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "resourceGroups",
						FixedValue: stringPointer("resourceGroups"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "resourceGroupName",
						ExampleValue: "resource-group-value",
					},
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
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleResource": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"ResourceGroupName": {
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
						HclName:  "resource_group_name",
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
			client := metadata.Client.ExampleService.SdkResource
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
			payload := sdkresource.SomeModel{}
			if err := client.CreateThingThenPoll(ctx, id, payload); err != nil {
				return fmt.Errorf("creating %s: %+v", id, err)
			}
			metadata.SetID(id)
			return nil
		},
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_Immediate_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: resourcemanager.ApiOperation{
			LongRunning:    false,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_Immediate_PayloadResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_LongRunning_PayloadResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: resourcemanager.ApiOperation{
			LongRunning:    true,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_CreateFunc_LongRunning_PayloadResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: resourcemanager.ApiOperation{
			LongRunning: true,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_RequiresImport_ResourceIdNoOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		readMethod: resourcemanager.ApiOperation{
			LongRunning:    false,
			ResourceIdName: stringPointer("SomeResourceId"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_RequiresImport_ResourceIdOptions(t *testing.T) {
	actual, err := createFunctionComponents{
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			ResourceIdName: stringPointer("SomeResourceId"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_CommonResourceIDWithSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "commonids.NewCommonResourceID",
		resourceId: resourcemanager.ResourceIdDefinition{
			CommonAlias: stringPointer("CommonResource"),
			Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "subscriptions",
					FixedValue: stringPointer("subscriptions"),
				},
				{
					Type: resourcemanager.SubscriptionIdSegment,
					Name: "subscriptionId",
				},
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "resourceGroups",
					FixedValue: stringPointer("resourceGroups"),
				},
				{
					Type:         resourcemanager.UserSpecifiedSegment,
					Name:         "resourceGroupName",
					ExampleValue: "resource-group-value",
				},
			},
		},
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Name": {
					HclName: "name",
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: resourcemanager.MappingDefinition{
			ResourceId: []resourcemanager.ResourceIdMappingDefinition{
				{
					SchemaFieldName: "Name",
					SegmentName:     "resourceGroupName",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_CommonResourceIDWithoutSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "commonids.NewCommonResourceID",
		resourceId: resourcemanager.ResourceIdDefinition{
			CommonAlias: stringPointer("CommonResource"),
			Id:          "/resourceGroups/{resourceGroupName}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "resourceGroups",
					FixedValue: stringPointer("resourceGroups"),
				},
				{
					Type:         resourcemanager.UserSpecifiedSegment,
					Name:         "resourceGroupName",
					ExampleValue: "resource-group-value",
				},
			},
		},
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Name": {
					HclName: "name",
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: resourcemanager.MappingDefinition{
			ResourceId: []resourcemanager.ResourceIdMappingDefinition{
				{
					SchemaFieldName: "Name",
					SegmentName:     "resourceGroupName",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDWithSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "sdkresource.NewSomeResourceID",
		resourceId: resourcemanager.ResourceIdDefinition{
			CommonAlias: nil,
			Id:          "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "subscriptions",
					FixedValue: stringPointer("subscriptions"),
				},
				{
					Type: resourcemanager.SubscriptionIdSegment,
					Name: "subscriptionId",
				},
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "resourceGroups",
					FixedValue: stringPointer("resourceGroups"),
				},
				{
					Type:         resourcemanager.UserSpecifiedSegment,
					Name:         "resourceGroupName",
					ExampleValue: "resource-group-value",
				},
			},
		},
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Name": {
					HclName: "name",
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: resourcemanager.MappingDefinition{
			ResourceId: []resourcemanager.ResourceIdMappingDefinition{
				{
					SchemaFieldName: "Name",
					SegmentName:     "resourceGroupName",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDWithoutSubscription(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName: "sdkresource.NewSomeResourceID",
		resourceId: resourcemanager.ResourceIdDefinition{
			CommonAlias: nil,
			Id:          "/resourceGroups/{resourceGroupName}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "resourceGroups",
					FixedValue: stringPointer("resourceGroups"),
				},
				{
					Type:         resourcemanager.UserSpecifiedSegment,
					Name:         "resourceGroupName",
					ExampleValue: "resource-group-value",
				},
			},
		},
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Name": {
					HclName: "name",
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: resourcemanager.MappingDefinition{
			ResourceId: []resourcemanager.ResourceIdMappingDefinition{
				{
					SchemaFieldName: "Name",
					SegmentName:     "resourceGroupName",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_IdDefinitionAndMapping_RegularResourceIDConstantSegment(t *testing.T) {
	actual, err := createFunctionComponents{
		newResourceIdFuncName:  "sdkresource.NewSomeResourceID",
		sdkResourceNameLowered: "sdkresource",
		resourceId: resourcemanager.ResourceIdDefinition{
			CommonAlias: nil,
			Id:          "/animals/{animalType}",
			Segments: []resourcemanager.ResourceIdSegment{
				{
					Type:       resourcemanager.StaticSegment,
					Name:       "animals",
					FixedValue: stringPointer("animals"),
				},
				{
					ConstantReference: stringPointer("AnimalType"),
					ExampleValue:      "panda",
					Name:              "animalType",
					Type:              resourcemanager.ConstantSegment,
				},
			},
			ConstantNames: []string{"AnimalType"},
		},
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"Animal": {
					HclName: "animal",
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
					ForceNew: true,
				},
			},
		},
		mappings: resourcemanager.MappingDefinition{
			ResourceId: []resourcemanager.ResourceIdMappingDefinition{
				{
					SchemaFieldName: "Animal",
					SegmentName:     "animalType",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_PayloadDefinition(t *testing.T) {
	actual, err := createFunctionComponents{
		createMethod: resourcemanager.ApiOperation{
			RequestObject: &resourcemanager.ApiObjectDefinition{
				ReferenceName: stringPointer("SomeModel"),
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
			},
		},
		sdkResourceNameLowered: "sdkresource",
	}.payloadDefinition()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
			payload := sdkresource.SomeModel{}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_MappingsFromSchema_NoFields(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("skipping since `featureflags.OutputMappings` is disabled")
	}

	actual, err := createFunctionComponents{
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{},
		},
	}.mappingsFromSchema()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := ``
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_MappingsFromSchema_TopLevelFields(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("skipping since `featureflags.OutputMappings` is disabled")
	}

	actual, err := createFunctionComponents{
		terraformModel: resourcemanager.TerraformSchemaModelDefinition{
			Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
				"SomeField": {
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeString,
					},
					Required: true,
				},
			},
		},
	}.mappingsFromSchema()
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
	payload.SomeSchemaField = config.SomeField
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentCreate_SchemaDeserialization(t *testing.T) {
	actual, err := createFunctionComponents{
		resourceTypeName: "AwesomeResource",
		schemaModelName:  "AwesomeResourceTypedModel",
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
	assertTemplatedCodeMatches(t, expected, *actual)
}
