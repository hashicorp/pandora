package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/featureflags"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: re-introduce Mappings for both Resource ID <-> Schema and Schema <-> SDK

func TestComponentReadFunc_CommonId_Disabled(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentReadFunc_RegularResourceId_Disabled(t *testing.T) {
	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentReadFunc_CommonId_Enabled(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
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
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetModel"),
				},
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"GetModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
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
						Type: resourcemanager.ResourceGroupSegment,
						Name: "resourceGroupName",
					},
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName: "name",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.SdkResource
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

				schema.SomeField = model.SomeSdkField
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CommonId_Options_Enabled(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
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
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetModel"),
				},
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
		Models: map[string]resourcemanager.ModelDetails{
			"GetModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
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
						Type: resourcemanager.ResourceGroupSegment,
						Name: "resourceGroupName",
					},
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName: "name",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.SdkResource
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

				schema.SomeField = model.SomeSdkField
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_RegularResourceId_Enabled(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "SdkResource",
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
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetModel"),
				},
			},
		},
		Models: map[string]resourcemanager.ModelDetails{
			"GetModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Id: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
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
						Type: resourcemanager.ResourceGroupSegment,
						Name: "resourceGroupName",
					},
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName: "name",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.SdkResource
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

				schema.SomeField = model.SomeSdkField
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_RegularResourceId_Options_Enabled(t *testing.T) {
	// TODO: remove this once the feature-flag is properly threaded through
	if !featureflags.OutputMappings {
		t.Skip("@tombuildsstuff: skipping until fully implemented")
	}

	input := models.ResourceInput{
		ResourceTypeName:   "Example",
		SdkResourceName:    "SdkResource",
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
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetModel"),
				},
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
		Models: map[string]resourcemanager.ModelDetails{
			"GetModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
						JsonName: "name",
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
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Id: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
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
						Type: resourcemanager.ResourceGroupSegment,
						Name: "resourceGroupName",
					},
				},
			},
		},
		SchemaModelName: "ExampleModel",
		SchemaModels: map[string]resourcemanager.TerraformSchemaModelDefinition{
			"ExampleModel": {
				Fields: map[string]resourcemanager.TerraformSchemaFieldDefinition{
					"Name": {
						HclName: "name",
						ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
							Type: resourcemanager.TerraformSchemaFieldTypeString,
						},
						Required: true,
						ForceNew: true,
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
	actual, err := readFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := `
func (r ExampleResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
        Timeout: 10 * time.Minute,
        Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.Resources.SdkResource
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

				schema.SomeField = model.SomeSdkField
			}
			return metadata.Encode(&schema)
        },
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForGet(t *testing.T) {
	actual, err := readFunctionComponents{
		readMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		readOperation: resourcemanager.ApiOperation{
			ResourceIdName: stringPointer("SomeResourceId"),
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
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentReadFunc_CodeForGet_Options(t *testing.T) {
	actual, err := readFunctionComponents{
		readMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		readOperation: resourcemanager.ApiOperation{
			ResourceIdName: stringPointer("SomeResourceId"),
			Options: map[string]resourcemanager.ApiOperationOption{
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
	assertTemplatedCodeMatches(t, expected, *actual)
}
