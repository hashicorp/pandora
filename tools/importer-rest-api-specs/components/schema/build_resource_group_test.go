package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForResourceGroupHappyPathAllModelsTheSame(t *testing.T) {
	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{},
		models: map[string]resourcemanager.ModelDetails{
			"ResourceGroup": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.LocationApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.TagsApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						// Computed
						Optional: false,
						Required: false,
					},
				},
			},
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroup"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroup"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroup"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"ResourceGroupId": {
				CommonAlias:   stringPointer("ResourceGroup"),
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: stringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: stringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
				},
			},
		},
	}

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2020-01-01",
		CreateMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: resourcemanager.MethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "ResourceGroups",
		ResourceIdName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroupResource",
		UpdateMethod: &resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Update",
			TimeoutInMinutes: 30,
		},
	}
	actualModels, actualMappings, err := builder.Build(input, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	testValidateResourceGroupSchema(t, actualModels, actualMappings, true)
}

func TestBuildForResourceGroupUsingRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")

	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{},
		models: map[string]resourcemanager.ModelDetails{
			"ResourceGroup": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.LocationApiObjectDefinitionType,
						},
						Required: true,
					},
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.TagsApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupPatchable": {
				Fields: map[string]resourcemanager.FieldDetails{
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.TagsApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroup"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroup"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ResourceGroupPatchable"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ResourceGroupId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"ResourceGroupId": {
				CommonAlias:   stringPointer("ResourceGroup"),
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: stringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: stringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
				},
			},
		},
	}

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2020-01-01",
		CreateMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: resourcemanager.MethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "ResourceGroups",
		ResourceIdName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroup",
		UpdateMethod: &resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Update",
			TimeoutInMinutes: 30,
		},
	}
	actualModels, actualMappings, err := builder.Build(input, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	testValidateResourceGroupSchema(t, actualModels, actualMappings, false)
}

func testValidateResourceGroupSchema(t *testing.T, actualModels *map[string]resourcemanager.TerraformSchemaModelDefinition, actualMappings *resourcemanager.MappingDefinition, allModelsAreTheSame bool) {
	r := resourceUnderTest{
		Name: "Resource Group",
	}

	if actualModels == nil {
		t.Fatalf("expected 1 model but got nil")
	}
	if len(*actualModels) != 1 {
		t.Errorf("expected 1 model but got %d", len(*actualModels))
	}
	r.CurrentModel = "ResourceGroupResource"
	currentModel, ok := (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("top level model %q missing", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 3 {
			t.Errorf("expected 3 fields but got %d", len(currentModel.Fields))
		}
		r.checkFieldName(t, currentModel)
		r.checkFieldLocation(t, currentModel)
		r.checkFieldTags(t, currentModel)
	}

	r.CurrentModel = "ResourceGroupResourceGroupProperties"
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	if actualMappings == nil {
		// TODO: tests for Mappings
		t.Fatalf("expected some mappings but got nil")
	}

	t.Logf("Checking Resource ID Mappings..")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "resourceGroupName")

	t.Logf("Checking Create Mappings..")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Create, "ResourceGroupResource", "Location", "ResourceGroup", "Location")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Create, "ResourceGroupResource", "Tags", "ResourceGroup", "Tags")

	t.Logf("Checking Update Mappings..")
	if actualMappings.Update == nil {
		t.Fatalf("expected update mappings but they were nil")
	}
	if allModelsAreTheSame {
		checkDirectAssignmentMappingExistsBetween(t, *actualMappings.Update, "ResourceGroupResource", "Tags", "ResourceGroup", "Tags")
	} else {
		checkDirectAssignmentMappingExistsBetween(t, *actualMappings.Update, "ResourceGroupResource", "Tags", "ResourceGroupPatchable", "Tags")
	}

	t.Logf("Checking Read Mappings..")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Read, "ResourceGroupResource", "Location", "ResourceGroup", "Location")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Read, "ResourceGroupResource", "Tags", "ResourceGroup", "Tags")
}
