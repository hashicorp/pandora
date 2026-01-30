// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func TestBuildForResourceGroupHappyPathAllModelsTheSame(t *testing.T) {
	t.Parallel()
	apiResource := sdkModels.APIResource{
		Constants: map[string]sdkModels.SDKConstant{},
		Models: map[string]sdkModels.SDKModel{
			"ResourceGroup": {
				Fields: map[string]sdkModels.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.LocationSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]sdkModels.SDKField{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						// Computed
						Optional: false,
						Required: false,
					},
				},
			},
		},
		Operations: map[string]sdkModels.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
		},
		ResourceIDs: map[string]sdkModels.ResourceID{
			"ResourceGroupId": {
				CommonIDAlias: pointer.To("ResourceGroup"),
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []sdkModels.ResourceIDSegment{
					sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
	}

	builder := NewBuilder(apiResource)

	input := sdkModels.TerraformResourceDefinition{
		APIResource: "ResourceGroups",
		APIVersion:  "2020-01-01",
		CreateMethod: sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: sdkModels.TerraformMethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		ResourceIDName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroupResource",
		UpdateMethod: &sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Update",
			TimeoutInMinutes: 30,
		},
	}

	resourceDefinition := definitions.ResourceDefinition{}
	actualModels, actualMappings, err := builder.Build(input, resourceDefinition)
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	testValidateResourceGroupSchema(t, actualModels, actualMappings)
}

func TestBuildForResourceGroupUsingRealData(t *testing.T) {
	t.Parallel()
	t.Skipf("TODO: update schema gen & re-enable this test")

	apiResource := sdkModels.APIResource{
		Constants: map[string]sdkModels.SDKConstant{},
		Models: map[string]sdkModels.SDKModel{
			"ResourceGroup": {
				Fields: map[string]sdkModels.SDKField{
					"Id": {
						JsonName: "id",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.LocationSDKObjectDefinitionType,
						},
						Required: true,
					},
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupPatchable": {
				Fields: map[string]sdkModels.SDKField{
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]sdkModels.SDKField{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: sdkModels.SDKObjectDefinition{
							Type: sdkModels.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		Operations: map[string]sdkModels.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &sdkModels.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroupPatchable"),
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
		},
		ResourceIDs: map[string]sdkModels.ResourceID{
			"ResourceGroupId": {
				CommonIDAlias: pointer.To("ResourceGroup"),
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []sdkModels.ResourceIDSegment{
					sdkModels.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					sdkModels.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					sdkModels.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					sdkModels.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)

	input := sdkModels.TerraformResourceDefinition{
		APIResource: "ResourceGroups",
		APIVersion:  "2020-01-01",
		CreateMethod: sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: sdkModels.TerraformMethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		ResourceIDName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroup",
		UpdateMethod: &sdkModels.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Update",
			TimeoutInMinutes: 30,
		},
	}

	resourceDefinition := definitions.ResourceDefinition{}
	actualModels, actualMappings, err := builder.Build(input, resourceDefinition)
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	testValidateResourceGroupSchema(t, actualModels, actualMappings)
}

func testValidateResourceGroupSchema(t *testing.T, actualModels map[string]sdkModels.TerraformSchemaModel, actualMappings *sdkModels.TerraformMappingDefinition) {
	r := resourceUnderTest{
		Name: "Resource Group",
	}

	if actualModels == nil {
		t.Fatalf("expected 1 model but got nil")
	}
	if len(actualModels) != 1 {
		t.Errorf("expected 1 model but got %d", len(actualModels))
	}
	r.CurrentModel = "ResourceGroupResource"
	currentModel, ok := (actualModels)[r.CurrentModel]
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
	currentModel, ok = (actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	if actualMappings == nil {
		t.Fatalf("expected some mappings but got nil")
	}

	t.Logf("Checking Resource ID Mappings..")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceID, "Name", "resourceGroupName", false)

	t.Logf("Checking Field Mappings..")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Fields, "ResourceGroupResource", "Location", "ResourceGroup", "Location")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Fields, "ResourceGroupResource", "Tags", "ResourceGroup", "Tags")
}
