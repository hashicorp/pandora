// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	terraformModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForResourceGroupHappyPathAllModelsTheSame(t *testing.T) {
	apiResource := models.APIResource{
		Constants: map[string]models.SDKConstant{},
		Models: map[string]models.SDKModel{
			"ResourceGroup": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.LocationSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]models.SDKField{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						// Computed
						Optional: false,
						Required: false,
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          models.ReferenceSDKObjectDefinitionType,
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
				ResponseObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
		},
		ResourceIDs: map[string]models.ResourceID{
			"ResourceGroupId": {
				CommonIDAlias: pointer.To("ResourceGroup"),
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
	}

	builder := NewBuilder(apiResource)

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2020-01-01",
		CreateMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: models.TerraformMethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "ResourceGroups",
		ResourceIdName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroupResource",
		UpdateMethod: &models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Update",
			TimeoutInMinutes: 30,
		},
	}

	var inputResourceBuildInfo *terraformModels.ResourceBuildInfo

	actualModels, actualMappings, err := builder.Build(input, inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	testValidateResourceGroupSchema(t, actualModels, actualMappings, true)
}

func TestBuildForResourceGroupUsingRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")

	apiResource := models.APIResource{
		Constants: map[string]models.SDKConstant{},
		Models: map[string]models.SDKModel{
			"ResourceGroup": {
				Fields: map[string]models.SDKField{
					"Id": {
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.LocationSDKObjectDefinitionType,
						},
						Required: true,
					},
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupPatchable": {
				Fields: map[string]models.SDKField{
					"ManagedBy": {
						JsonName: "managedBy",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ResourceGroupProperties"),
						},
						Optional: true,
					},
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.TagsSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ResourceGroupProperties": {
				Fields: map[string]models.SDKField{
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		Operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          models.ReferenceSDKObjectDefinitionType,
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
				ResponseObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroup"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("ResourceGroupPatchable"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ResourceGroupId"),
			},
		},
		ResourceIDs: map[string]models.ResourceID{
			"ResourceGroupId": {
				CommonIDAlias: pointer.To("ResourceGroup"),
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
				},
			},
		},
	}
	builder := NewBuilder(apiResource)

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2020-01-01",
		CreateMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: models.TerraformMethodDefinition{},
		DisplayName:  "Resource Groups",
		ReadMethod: models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "ResourceGroups",
		ResourceIdName:  "ResourceGroupId",
		ResourceName:    "ResourceGroup",
		SchemaModelName: "ResourceGroup",
		UpdateMethod: &models.TerraformMethodDefinition{
			Generate:         true,
			SDKOperationName: "Update",
			TimeoutInMinutes: 30,
		},
	}

	var inputResourceBuildInfo *terraformModels.ResourceBuildInfo

	actualModels, actualMappings, err := builder.Build(input, inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
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
		t.Fatalf("expected some mappings but got nil")
	}

	t.Logf("Checking Resource ID Mappings..")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "resourceGroupName", false)

	t.Logf("Checking Field Mappings..")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Fields, "ResourceGroupResource", "Location", "ResourceGroup", "Location")
	checkDirectAssignmentMappingExistsBetween(t, actualMappings.Fields, "ResourceGroupResource", "Tags", "ResourceGroup", "Tags")
}
