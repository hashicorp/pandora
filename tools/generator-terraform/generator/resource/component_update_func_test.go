package resource

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestComponentUpdate_HappyPathDisabled(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{})
	expected := ``
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_HappyPathDisabled_NoUpdateMethod(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{
		Details: resourcemanager.TerraformResourceDetails{
			UpdateMethod: nil,
		},
	})
	expected := ``
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_HappyPathEnabled_CommonId_SharedModels(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{
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
					"Example": {},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: stringPointer("SomeCommon"),
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "sdkresource",
		SdkServiceName:     "sdkservice",
	})
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.MyResourceClient
				id, err := commonids.ParseSomeCommonID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyResourceResourceModel
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
				// TODO: mapping from the Schema -> Payload
				if err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_HappyPathEnabled_CommonId_UniqueModels(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{
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
					"Example": {},
				},
			},
			"GetPayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {},
				},
			},
			"UpdatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("CreatePayload"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("UpdatePayload"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
		},
		ProviderPrefix: "fake",
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SomeResourceId": {
				CommonAlias: stringPointer("SomeCommon"),
			},
		},
		ResourceLabel:      "some_resource",
		ResourceTypeName:   "MyResource",
		ServiceName:        "Service1",
		ServicePackageName: "service1",
		SdkApiVersion:      "sdkapiversion",
		SdkResourceName:    "sdkresource",
		SdkServiceName:     "sdkservice",
	})
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.MyResourceClient
				id, err := commonids.ParseSomeCommonID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyResourceResourceModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				payload := sdkresource.UpdatePayload{}
				// TODO: mapping from the Schema -> Payload
				if err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_HappyPathEnabled_RegularResourceID_SharedModels(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{
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
					"Example": {},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
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
		SdkResourceName:    "sdkresource",
		SdkServiceName:     "sdkservice",
	})
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.MyResourceClient
				id, err := sdkresource.ParseSomeResourceID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyResourceResourceModel
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
				// TODO: mapping from the Schema -> Payload
				if err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_HappyPathEnabled_RegularResourceID_UniqueModels(t *testing.T) {
	actual := updateFuncForResource(ResourceInput{
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
					"Example": {},
				},
			},
			"GetPayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {},
				},
			},
			"UpdatePayload": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {},
				},
			},
		},
		Operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("CreatePayload"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Delete": {
				LongRunning:    true,
				ResourceIdName: stringPointer("SomeResourceId"),
			},
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("SomeResourceId"),
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("GetPayload"),
				},
			},
			"Update": {
				LongRunning: true,
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("UpdatePayload"),
				},
				ResourceIdName: stringPointer("SomeResourceId"),
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
		SdkResourceName:    "sdkresource",
		SdkServiceName:     "sdkservice",
	})
	expected := `
	func (r MyResourceResource) Update() sdk.ResourceFunc {
		return sdk.ResourceFunc{
			Timeout: 40 * time.Minute,
			Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
				client := metadata.Client.Service1.MyResourceClient
				id, err := sdkresource.ParseSomeResourceID(metadata.ResourceData.Id())
				if err != nil {
					return err
				}
				var config MyResourceResourceModel
				if err := metadata.Decode(&config); err != nil {
					return fmt.Errorf("decoding: %+v", err)
				}
				payload := sdkresource.UpdatePayload{}
				// TODO: mapping from the Schema -> Payload
				if err := client.UpdateThenPoll(ctx, *id, payload); err != nil {
					return fmt.Errorf("updating %s: %+v", *id, err)
				}
				return nil
			},
		}
	}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_MappingsFromSchema(t *testing.T) {
	actual := updateFuncHelpers{}.mappingsFromSchema()
	expected := `
			// TODO: mapping from the Schema -> Payload
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_ModelDecode(t *testing.T) {
	actual := updateFuncHelpers{
		resourceTypeName: "AwesomeResource",
	}.modelDecode()
	expected := `
			var config AwesomeResourceResourceModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %+v", err)
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_PayloadDefinition_ModelSharedBetweenCreateReadUpdate(t *testing.T) {
	actual := updateFuncHelpers{
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("SharedPayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		createMethodName: "Create",
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("SharedPayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("SharedPayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		updateMethodName: "Update",
		sdkResourceName:  "sdkresource",
	}.payloadDefinition()
	expected := `
	existing, err := client.Get(ctx, *id)
	if err != nil {
		return fmt.Errorf("retrieving existing %s: %+v", *id, err)
	}
	if existing.Model == nil {
		return fmt.Errorf("retrieving existing %s: properties was nil", *id)
	}
	payload := *existing.Model
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_PayloadDefinition_ModelSharedBetweenCreateReadUpdateThatIsNotAReference(t *testing.T) {
	actual := updateFuncHelpers{
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.ListApiObjectDefinitionType,
				NestedItem: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SharedListPayload"),
				},
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		createMethodName: "Create",
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.ListApiObjectDefinitionType,
				NestedItem: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SharedListPayload"),
				},
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.ListApiObjectDefinitionType,
				NestedItem: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SharedListPayload"),
				},
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		updateMethodName: "Update",
		sdkResourceName:  "sdkresource",
	}.payloadDefinition()
	expected := `
	payload := []sdkresource.SharedListPayload{}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_PayloadDefinition_UniqueModelsForCreateReadUpdate(t *testing.T) {
	actual := updateFuncHelpers{
		createMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("CreatePayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		createMethodName: "Create",
		readMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("ReadPayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		readMethodName: "Get",
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("UpdatePayload"),
			},
			ResourceIdName: stringPointer("SomeId"),
		},
		updateMethodName: "Update",
		sdkResourceName:  "sdkresource",
	}.payloadDefinition()
	expected := `
	payload := sdkresource.UpdatePayload{}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_ResourceIDParser(t *testing.T) {
	actual := updateFuncHelpers{
		resourceIdParseFuncName: "someresource.ParseTheParcel",
	}.resourceIdParser()
	expected := `
			id, err := someresource.ParseTheParcel(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_UpdateFunc_Immediate_PayloadResourceIdNoOptions(t *testing.T) {
	actual := updateFuncHelpers{
		updateMethod: resourcemanager.ApiOperation{
			LongRunning:    false,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
		},
		updateMethodName: "UpdateThing",
		sdkResourceName:  "sdkresource",
	}.update()
	expected := `
			if err := client.UpdateThing(ctx, *id, payload); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_UpdateFunc_Immediate_PayloadResourceIdOptions(t *testing.T) {
	actual := updateFuncHelpers{
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: false,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
		},
		updateMethodName: "UpdateThing",
		sdkResourceName:  "sdkresource",
	}.update()
	expected := `
			if err := client.UpdateThing(ctx, *id, payload, sdkresource.DefaultUpdateThingOperationOptions()); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_UpdateFunc_LongRunning_PayloadResourceIdNoOptions(t *testing.T) {
	actual := updateFuncHelpers{
		updateMethod: resourcemanager.ApiOperation{
			LongRunning:    true,
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
		},
		updateMethodName: "UpdateThing",
		sdkResourceName:  "sdkresource",
	}.update()
	expected := `
			if err := client.UpdateThingThenPoll(ctx, *id, payload); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentUpdate_UpdateFunc_LongRunning_PayloadResourceIdOptions(t *testing.T) {
	actual := updateFuncHelpers{
		updateMethod: resourcemanager.ApiOperation{
			LongRunning: true,
			Options: map[string]resourcemanager.ApiOperationOption{
				"example": {},
			},
			RequestObject:  &resourcemanager.ApiObjectDefinition{},
			ResourceIdName: stringPointer("SomeResourceId"),
			UriSuffix:      stringPointer("/example"),
		},
		updateMethodName: "UpdateThing",
		sdkResourceName:  "sdkresource",
	}.update()
	expected := `
			if err := client.UpdateThingThenPoll(ctx, *id, payload, sdkresource.DefaultUpdateThingOperationOptions()); err != nil {
				return fmt.Errorf("updating %s: %+v", *id, err)
			}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
