package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForSearchServiceHappyPathAllModelsTheSame(t *testing.T) {
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
			"ResourceType": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"SearchServices": "searchServices",
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
			"SharedPrivateLinkResourceProvisioningState": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Deleting":   "Deleting",
					"Failed":     "Failed",
					"Incomplete": "Incomplete",
					"Succeeded":  "Succeeded",
					"Updating":   "Updating",
				},
			},
			"SharedPrivateLinkResourceStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Approve":      "Approved",
					"Disconnected": "Disconnected",
					"Pending":      "Pending",
					"Rejected":     "Rejected",
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
			"UnavailableNameReasons": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"AlreadyExists": "AlreadyExists",
					"Invalid":       "Invalid",
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
					},
					"NetworkRuleSet": {
						JsonName: "networkRuleSet",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("NetworkRuleSet"),
						},
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
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SharedPrivateLinkResource"),
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
			"PrivateEndpointConnection": {
				Fields: map[string]resourcemanager.FieldDetails{
					// do we add props like id, name and type?
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"PrivateEndpointConnectionProperties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
							},
						},
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"PrivateEndpointConnectionProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateEndpoint": {
						JsonName: "privateEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpointPropertiesProperties"),
							},
						},
					},
					// todo chuck a breakpoint line 17 of dataapi generator
					"PrivateLinkServiceConnectionState": {
						JsonName: "privateLinkServiceConnectionState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
							},
						},
					},
				},
			},
			"PrivateLinkServiceConnectionState": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateEndpointConnectionProperties": {
						JsonName: "privateEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
							},
						},
					},
				},
			},
			"SharedPrivateLinkResource": {
				Fields: map[string]resourcemanager.FieldDetails{
					// do we add props like id, name and type?
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"SharedPrivateLinkResourceProperties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("SharedPrivateLinkResourceProperties"),
							},
						},
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"SharedPrivateLinkResourceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"GroupId": {
						JsonName: "groupId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"PrivateLinkResourceId": {
						JsonName: "privateLinkResourceId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"SharedPrivateLinkResourceProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ProvisioningState"),
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
					// This should actually be Status?
					"SharedPrivateLinkResourceStatus": {
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
		t.Fatalf("expected 3 models but got nil")
	}
	if len(*actual) != 3 {
		t.Fatalf("expected 3 models but got %d", len(*actual))
	}
	//testValidateResourceGroupSchema(t, actual)
}

func testValidateSearchServiceSchema(t *testing.T, actual *map[string]resourcemanager.TerraformSchemaModelDefinition) {
	if actual == nil {
		t.Fatalf("expected 1 model but got nil")
	}
	if len(*actual) != 1 {
		t.Fatalf("expected 1 model but got %d", len(*actual))
	}

	model := (*actual)["ResourceGroup"]
	if len(model.Fields) != 3 {
		t.Fatalf("expected 3 fields but got %d", len(model.Fields))
	}

	name, ok := model.Fields["Name"]
	if !ok {
		t.Fatalf("expected there to be a field 'Name' but didn't get one")
	}
	if name.HclName != "name" {
		t.Fatalf("expected the HclName for field 'Name' to be 'name' but got %q", name.HclName)
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected the field 'Name' to have the type `string` but got %q", string(name.ObjectDefinition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !name.Required {
		t.Fatalf("expected the field 'Name' to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field 'Name' to be ForceNew but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if name.Optional || name.Computed || name.WriteOnly {
	//	t.Fatalf("expected the field 'Name' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", name.Optional, name.Computed, name.WriteOnly)
	//}
	if name.Optional || name.Computed {
		t.Fatalf("expected the field 'Name' to be !Optional, !Computed but got %t / %t", name.Optional, name.Computed)
	}

	location, ok := model.Fields["Location"]
	if !ok {
		t.Fatalf("expected there to be a field 'Location' but didn't get one")
	}
	if location.HclName != "location" {
		t.Fatalf("expected the HclName for field 'Location' to be 'location' but got %q", location.HclName)
	}
	if location.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeLocation {
		t.Fatalf("expected the field 'Location' to have the type `location` but got %q", string(location.ObjectDefinition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !location.Required {
		t.Fatalf("expected the field 'Location' to be Required but it wasn't")
	}
	if !location.ForceNew {
		t.Fatalf("expected the field 'Location' to be ForceNew but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if location.Optional || location.Computed || location.WriteOnly {
	//	t.Fatalf("expected the field 'Location' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", location.Optional, location.Computed, location.WriteOnly)
	//}
	if location.Optional || location.Computed {
		t.Fatalf("expected the field 'Location' to be !Optional, !Computed but got %t / %t", location.Optional, location.Computed)
	}

	tags, ok := model.Fields["Tags"]
	if !ok {
		t.Fatalf("expected there to be a field 'Tags' but didn't get one")
	}
	if tags.HclName != "tags" {
		t.Fatalf("expected the HclName for field 'Tags' to be 'tags' but got %q", tags.HclName)
	}
	if tags.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeTags {
		t.Fatalf("expected the field 'Tags' to have the type `tags` but got %q", string(tags.ObjectDefinition.Type))
	}
	if !tags.Optional {
		t.Fatalf("expected the field 'Tags' to be Optional but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if tags.Required || tags.Computed || tags.ForceNew || tags.WriteOnly {
	//	t.Fatalf("expected the field 'Tags' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", tags.Required, tags.Computed, tags.ForceNew, tags.WriteOnly)
	//}
	if tags.Required || tags.Computed || tags.ForceNew {
		t.Fatalf("expected the field 'Tags' to be !Required, !Computed, !ForceNew but got %t / / %t / %t", tags.Required, tags.Computed, tags.ForceNew)
	}
}
