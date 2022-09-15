package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForSearchServiceUsingRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{
		Name: "search_service",
	}
	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{
			"AdminKeyKind": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Primary":   "primary",
					"Secondary": "secondary",
				},
			},
			"HostingMode": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Default":     "default",
					"HighDensity": "highDensity",
				},
			},
			"PrivateLinkServiceConnectionStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Approved":     "Approved",
					"Disconnected": "Disconnected",
					"Pending":      "Pending",
					"Rejected":     "Rejected",
				},
			},
			"ProvisioningState": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Failed":       "failed",
					"Provisioning": "provisioning",
					"Succeeded":    "succeeded",
				},
			},
			"PublicNetworkAccess": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Disabled": "disabled",
					"Enabled":  "enabled",
				},
			},
			"SearchServiceStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Degraded":     "degraded",
					"Deleting":     "deleting",
					"Disabled":     "disabled",
					"Error":        "error",
					"Provisioning": "provisioning",
					"Running":      "running",
				},
			},
			"SharedPrivateLinkResourceStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Pending":      "Pending",
					"Approved":     "Approved",
					"Rejected":     "Rejected",
					"Disconnected": "Disconnected",
				},
			},
			"SkuName": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Free":                 "free",
					"Basic":                "basic",
					"Standard":             "standard",
					"StandardTwo":          "standard2",
					"StandardThree":        "standard3",
					"StorageOptimizedLOne": "storage_optimized_l1",
					"StorageOptimizedLTwo": "storage_optimized_l2",
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SearchService": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemAssignedIdentityApiObjectDefinitionType,
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
							ReferenceName: stringPointer("SearchServiceProperties"),
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Sku"),
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
			"IPRule": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Value": {
						JsonName: "value",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"NetworkRuleSet": {
				Fields: map[string]resourcemanager.FieldDetails{
					"IPRules": {
						JsonName: "ipRules",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							// Note: This is a collapsed tree to a list of strings, rather than a list of models.
							Type:          resourcemanager.ListApiObjectDefinitionType,
							ReferenceName: stringPointer("IPRule"),
						},
					},
				},
			},
			"SearchServiceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"HostingMode": {
						JsonName: "hostingMode",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("HostingMode"),
						},
						Optional: true,
					},
					"NetworkRuleSet": {
						JsonName: "networkRuleSet",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("NetworkRuleSet"),
						},
						Optional: true,
					},
					"PartitionCount": {
						JsonName: "partitionCount",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.IntegerApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpointConnection"),
							},
						},
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ProvisioningState"),
						},
					},
					"PublicNetworkAccess": {
						JsonName: "publicNetworkAccess",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("PublicNetworkAccess"),
						},
						Optional: true,
					},
					"ReplicaCount": {
						JsonName: "replicaCount",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.IntegerApiObjectDefinitionType,
						},
						Optional: true,
					},
					"SharedPrivateLinkResources": {
						JsonName: "sharedPrivateLinkResources",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("SharedPrivateLinkResource"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
						},
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SearchServiceStatus"),
						},
					},
					"StatusDetails": {
						JsonName: "statusDetails",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpoint": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("PrivateEndpointProperties"),
						},
					},
				},
			},
			"PrivateEndpointProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"PrivateEndpointConnection": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
				},
			},
			"PrivateEndpointConnectionProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("PrivateEndpointConnectionPropertiesProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
				},
			},
			"PrivateEndpointConnectionPropertiesProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateEndpoint": {
						JsonName: "privateEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpoint"),
							},
						},
					},
					"PrivateLinkServiceConnectionState": {
						JsonName: "privateLinkServiceConnectionState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateLinkServiceConnectionState"),
							},
						},
					},
				},
			},
			"PrivateLinkServiceConnectionState": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateLinkServiceConnectionStateProperties"),
							},
						},
					},
				},
			},
			"PrivateLinkServiceConnectionStateProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("PrivateLinkServiceConnectionStatus"),
						},
					},
					"Description": {
						JsonName: "description",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"ActionsRequired": {
						JsonName: "actions_required",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"SharedPrivateLinkResource": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("SharedPrivateLinkResourceProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
				},
			},
			"SharedPrivateLinkResourceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("SharedPrivateLinkResourcePropertiesProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
				},
			},
			"SharedPrivateLinkResourcePropertiesProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateLinkResourceId": {
						JsonName: "privateLinkResourceId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"GroupId": {
						JsonName: "groupId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"RequestMessage": {
						JsonName: "requestMessage",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"ResourceRegion": {
						JsonName: "resourceRegion",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SharedPrivateLinkResourceStatus"),
						},
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SkuName"),
						},
						Required: true,
					},
				},
			},
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("SearchService"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("SearchServiceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("SearchServiceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("SearchService"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("SearchServiceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("SearchService"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("SearchServiceId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"SearchServiceId": {
				CommonAlias:   stringPointer("ResourceGroup"),
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Search/searchServices/{searchServiceName}",
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
					{
						Name:       "providers",
						FixedValue: stringPointer("providers"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name:       "microsoftSearch",
						FixedValue: stringPointer("Microsoft.Search"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "searchServices",
						FixedValue: stringPointer("searchServices"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "searchServiceName",
						Type: resourcemanager.UserSpecifiedSegment,
					},
				},
			},
		},
	}

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2020-08-01",
		CreateMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: resourcemanager.MethodDefinition{},
		DisplayName:  "Search Service",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "SearchService",
		ResourceIdName:  "SearchServiceId",
		ResourceName:    "SearchService",
		SchemaModelName: "SearchService",
		UpdateMethod: &resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Update",
			TimeoutInMinutes: 30,
		},
	}

	actual, err := builder.Build(input, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	if actual == nil {
		t.Fatalf("expected 6 models but got nil")
	}
	if len(*actual) != 14 { // TODO - Revise this when we have a "definitive" rules list...
		t.Errorf("expected 14 models but got %d", len(*actual))
	}

	r.CurrentModel = "SearchService"
	currentModel, ok := (*actual)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		r.checkFieldName(t, currentModel)
		r.checkFieldLocation(t, currentModel)
		r.checkFieldTags(t, currentModel)

		r.checkField(t, currentModel, expected{
			FieldName: "SkuName",
			HclName:   "sku_name",
			Required:  true,
			ForceNew:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
			Validation: &expectedValidation{
				Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
				PossibleValueCount: 7,
			},
		})
		r.checkField(t, currentModel, expected{
			FieldName:     "HostingMode",
			HclName:       "hosting_mode",
			Optional:      true,
			FieldType:     resourcemanager.TerraformSchemaFieldTypeString,
			ReferenceName: stringPointer("HostingMode"),
			Validation: &expectedValidation{
				Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
				PossibleValueCount: 2,
			},
		})
		r.checkField(t, currentModel, expected{
			FieldName:     "AllowedIPs",
			HclName:       "allowed_ips",
			Optional:      true,
			FieldType:     resourcemanager.TerraformSchemaFieldTypeList,
			ReferenceName: stringPointer("IPRules"),
		})
		r.checkField(t, currentModel, expected{
			FieldName: "PartitionCount",
			HclName:   "partition_count",
			Optional:  true,
			ForceNew:  false,
			FieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "PrivateEndpointId", // Note: This is a really deep collapse of models
			HclName:   "private_endpoint_id",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "PublicNetworkAccess",
			HclName:   "public_network_access",
			Optional:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "ReplicaCount",
			HclName:   "replica_count",
			Optional:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		})
		r.checkField(t, currentModel, expected{
			FieldName:           "SharedPrivateLinkResource",
			HclName:             "shared_private_link_resource",
			Computed:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
			NestedReferenceName: stringPointer("SearchServiceSharedPrivateLinkResource"),
			NestedReferenceType: resourcemanager.TerraformSchemaFieldTypeReference,
		})
		r.checkField(t, currentModel, expected{
			FieldName:           "AllowedIPs",
			HclName:             "allowed_ips",
			Optional:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
			NestedReferenceType: resourcemanager.TerraformSchemaFieldTypeString,
		})
	}

	r.CurrentModel = "SearchServiceProperties"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "IPRule"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "NetworkRuleSet"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "SearchServicePrivateEndpointConnection"
	currentModel, ok = (*actual)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		r.checkField(t, currentModel, expected{
			FieldName: "Id",
			HclName:   "id",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "Name",
			HclName:   "name",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})
		r.checkField(t, currentModel, expected{
			FieldName:     "PrivateEndpoint",
			HclName:       "private_endpoint",
			Computed:      true,
			FieldType:     resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: stringPointer("PrivateEndpoint"),
		})
	}

	r.CurrentModel = "SearchServicePrivateEndpoint"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "SearchServicePrivateEndpointConnectionProperties"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "SearchServicePrivateLinkServiceConnectionStateProperties"
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected there not to be a model %q, but there was", r.CurrentModel)
	}

	r.CurrentModel = "SearchServiceSharedPrivateLinkResource"
	currentModel, ok = (*actual)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {

	}
}
