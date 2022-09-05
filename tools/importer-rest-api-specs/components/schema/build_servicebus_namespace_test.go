package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForServiceBusNamespaceHappyPath(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")

	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{
			"SkuName": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Basic":    "Basic",
					"Premium":  "Premium",
					"Standard": "Standard",
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SBNamespace": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
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
							ReferenceName: StringPointer("SBNamespaceProperties"),
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("Sku"),
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
			"SBNamespaceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("SkuName"),
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
					ReferenceName: StringPointer("SBNamespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: StringPointer("SBNamespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: StringPointer("SBNamespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"NamespaceId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: StringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: StringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
					{
						Name:       "providers",
						FixedValue: StringPointer("providers"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name:       "microsoftServiceBus",
						FixedValue: StringPointer("Microsoft.ServiceBus"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "namespaces",
						FixedValue: StringPointer("namespaces"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "namespaceName",
						Type: resourcemanager.UserSpecifiedSegment,
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
		DisplayName:  "ServiceBus Namespace",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "Namespaces",
		ResourceIdName:  "NamespaceId",
		ResourceName:    "Namespace",
		SchemaModelName: "Namespace",
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

	namespaceModel := (*actual)["Namespace"]
	if len(namespaceModel.Fields) != 7 {
		t.Fatalf("expected 7 fields but got %d", len(namespaceModel.Fields))
	}

	name, ok := namespaceModel.Fields["Name"]
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

	location, ok := namespaceModel.Fields["Location"]
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

	// DisableLocalAuth should be transformed / inverted when mapped
	// TODO: confirm mappings
	localAuthEnabled, ok := namespaceModel.Fields["LocalAuthEnabled"]
	if !ok {
		t.Fatalf("expected there to be a field 'LocalAuthEnabled' but didn't get one")
	}
	if localAuthEnabled.HclName != "local_auth_enabled" {
		t.Fatalf("expected the HclName for field 'LocalAuthEnabled' to be 'local_auth_enabled' but got %q", localAuthEnabled.HclName)
	}
	if localAuthEnabled.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeBoolean {
		t.Fatalf("expected the field 'LocalAuthEnabled' to have the type `Boolean` but got %q", string(localAuthEnabled.ObjectDefinition.Type))
	}
	if !localAuthEnabled.Optional {
		t.Fatalf("expected the field 'LocalAuthEnabled' to be Optional but it wasn't")
	}
	if localAuthEnabled.Required || localAuthEnabled.Optional || localAuthEnabled.ForceNew {
		t.Fatalf("expected the field 'LocalAuthEnabled' to be !Required, !Optional, !ForceNew but got %t / %t / %t", localAuthEnabled.Required, localAuthEnabled.Optional, localAuthEnabled.ForceNew)
	}

	serviceBusEndpoint, ok := namespaceModel.Fields["ServiceBusEndpoint"]
	if !ok {
		t.Fatalf("expected there to be a field 'ServiceBusEndpoint' but didn't get one")
	}
	if serviceBusEndpoint.HclName != "service_bus_endpoint" {
		t.Fatalf("expected the HclName for field 'ServiceBusEndpoint' to be 'service_bus_endpoint' but got %q", serviceBusEndpoint.HclName)
	}
	if serviceBusEndpoint.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected the field 'ServiceBusEndpoint' to have the type `String` but got %q", string(serviceBusEndpoint.ObjectDefinition.Type))
	}
	if !serviceBusEndpoint.Computed {
		t.Fatalf("expected the field 'ServiceBusEndpoint' to be Computed but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if serviceBusEndpoint.Required || serviceBusEndpoint.Computed || serviceBusEndpoint.ForceNew || serviceBusEndpoint.WriteOnly {
	//	t.Fatalf("expected the field 'ServiceBusEndpoint' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", serviceBusEndpoint.Required, serviceBusEndpoint.Computed, serviceBusEndpoint.ForceNew, serviceBusEndpoint.WriteOnly)
	//}
	if serviceBusEndpoint.Required || serviceBusEndpoint.Optional || serviceBusEndpoint.ForceNew {
		t.Fatalf("expected the field 'ServiceBusEndpoint' to be !Required, !Optional, !ForceNew but got %t / %t / %t", serviceBusEndpoint.Required, serviceBusEndpoint.Optional, serviceBusEndpoint.ForceNew)
	}

	tags, ok := namespaceModel.Fields["Tags"]
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

	zoneRedundant, ok := namespaceModel.Fields["ZoneRedundant"]
	if !ok {
		t.Fatalf("expected there to be a field 'ZoneRedundant' but didn't get one")
	}
	if zoneRedundant.HclName != "zone_redundant" {
		t.Fatalf("expected the HclName for field 'ZoneRedundant' to be 'zone_redundant' but got %q", zoneRedundant.HclName)
	}
	if zoneRedundant.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeBoolean {
		t.Fatalf("expected the field 'ZoneRedundant' to have the type `Boolean` but got %q", string(zoneRedundant.ObjectDefinition.Type))
	}
	if !zoneRedundant.Optional {
		t.Fatalf("expected the field 'ZoneRedundant' to be Optional but it wasn't")
	}
	if zoneRedundant.Required || zoneRedundant.Computed || zoneRedundant.ForceNew {
		t.Fatalf("expected the field 'ZoneRedundant' to be !Required, !Computed, !ForceNew but got %t / %t / %t", zoneRedundant.Required, zoneRedundant.Computed, zoneRedundant.ForceNew)
	}
}

func TestBuildForServiceBusNamespaceUsingRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")

	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{
			"EndPointProvisioningState": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canceled":  "Canceled",
					"Creating":  "Creating",
					"Deleting":  "Deleting",
					"Failed":    "Failed",
					"Succeeded": "Succeeded",
					"Updating":  "Updating",
				},
			},
			"KeySource": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"MicrosoftPointKeyVault": "Microsoft.KeyVault",
				},
			},
			"PrivateLinkConnectionStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Approved":     "Approved",
					"Disconnected": "Disconnected",
					"Pending":      "Pending",
					"Rejected":     "Rejected",
				},
			},
			"SkuName": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Basic":    "Basic",
					"Premium":  "Premium",
					"Standard": "Standard",
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"ConnectionState": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Description": {
						JsonName: "description",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("PrivateLinkConnectionStatus"),
						},
						Optional: true,
					},
				},
			},
			"Encryption": {
				Fields: map[string]resourcemanager.FieldDetails{
					"KeySource": {
						JsonName: "keySource",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("KeySource"),
						},
						Optional: true,
					},
					"KeyVaultProperties": {
						JsonName: "keyVaultProperties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: StringPointer("KeyVaultProperties"),
							},
						},
						Optional: true,
					},
					"RequireInfrastructureEncryption": {
						JsonName: "requireInfrastructureEncryption",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"KeyVaultProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("UserAssignedIdentityProperties"),
						},
						Optional: true,
					},
					"KeyName": {
						JsonName: "keyName",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"KeyVaultUri": {
						JsonName: "keyVaultUri",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"KeyVersion": {
						JsonName: "keyVersion",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpointConnection": {
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
							ReferenceName: StringPointer("PrivateEndpointConnectionProperties"),
						},
					},
					"SystemData": {
						JsonName: "systemData",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemData,
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
			"PrivateEndpointConnectionProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateEndpoint": {
						JsonName: "privateEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("PrivateEndpoint"),
						},
						Optional: true,
					},
					"PrivateLinkServiceConnectionState": {
						JsonName: "privateLinkServiceConnectionState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("ConnectionState"),
						},
						Optional: true,
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("EndPointProvisioningState"),
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpoint": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"SBNamespace": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
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
							ReferenceName: StringPointer("SBNamespaceProperties"),
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("Sku"),
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
			"SBNamespaceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"AlternateName": {
						JsonName: "alternateName",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"CreatedAt": {
						JsonName: "createdAt",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DateTimeApiObjectDefinitionType,
						},
						Optional: true,
					},
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("Encryption"),
						},
						Optional: true,
					},
					"MetricId": {
						JsonName: "metricId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: StringPointer("PrivateEndpointConnection"),
							},
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"UpdatedAt": {
						JsonName: "updatedAt",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DateTimeApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"SBNamespaceUpdateParameters": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
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
							ReferenceName: StringPointer("SBNamespaceUpdateProperties"),
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("Sku"),
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
			"SBNamespaceUpdateProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"AlternateName": {
						JsonName: "alternateName",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"CreatedAt": {
						JsonName: "createdAt",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DateTimeApiObjectDefinitionType,
						},
						Optional: true,
					},
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("Encryption"),
						},
						Optional: true,
					},
					"MetricId": {
						JsonName: "metricId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: StringPointer("PrivateEndpointConnection"),
							},
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"UpdatedAt": {
						JsonName: "updatedAt",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DateTimeApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: StringPointer("SkuName"),
						},
						Required: true,
					},
				},
			},
			"UserAssignedIdentityProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"UserAssignedIdentity": {
						JsonName: "userAssignedIdentity",
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
					ReferenceName: StringPointer("SBNamespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: StringPointer("SBNamespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: StringPointer("SBNamespaceUpdateParameters"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: StringPointer("NamespaceId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"NamespaceId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						FixedValue: StringPointer("subscriptions"),
						Name:       "subscriptions",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "subscriptionId",
						Type: resourcemanager.SubscriptionIdSegment,
					},
					{
						FixedValue: StringPointer("providers"),
						Name:       "providers",
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "resourceGroupName",
						Type: resourcemanager.ResourceGroupSegment,
					},
					{
						Name:       "providers",
						FixedValue: StringPointer("providers"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name:       "microsoftServiceBus",
						FixedValue: StringPointer("Microsoft.ServiceBus"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "namespaces",
						FixedValue: StringPointer("namespaces"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "namespaceName",
						Type: resourcemanager.UserSpecifiedSegment,
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
		DisplayName:  "ServiceBus Namespace",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "Namespaces",
		ResourceIdName:  "NamespaceId",
		ResourceName:    "Namespace",
		SchemaModelName: "Namespace",
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
	// TODO: validate the result
}
