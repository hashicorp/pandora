package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForServiceBusNamespaceHappyPath(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "service_bus_namespace"}
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
			"Namespace": {
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
						Required: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.LocationApiObjectDefinitionType,
						},
						Required: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("NamespaceProperties"),
						},
						Required: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Sku"),
						},
						Required: true,
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
			"NamespaceProperties": {
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
							ReferenceName: stringPointer("SkuName"),
						},
						Required: true,
					},
				},
			},
			"SkuTier": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SkuTier"),
						},
						Optional: true,
					},
				},
			},
			"SkuCapacity": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Capacity": {
						JsonName: "capacity",
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
					ReferenceName: stringPointer("Namespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Namespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Namespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"NamespaceId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
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
						Name:       "microsoftServiceBus",
						FixedValue: stringPointer("Microsoft.ServiceBus"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "namespaces",
						FixedValue: stringPointer("namespaces"),
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
		t.Errorf("building schema: %+v", err)
	}

	if actual == nil {
		t.Errorf("expected 3 models but got nil")
	}
	if len(*actual) != 3 {
		t.Errorf("expected 3 models but got %d", len(*actual))
	}

	r.CurrentModel = "Namespace"
	currentModel := (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 7 {
		t.Errorf("expected 7 fields but got %d", len(currentModel.Fields))
	}
	r.checkFieldName(t, currentModel)
	r.checkFieldLocation(t, currentModel)
	r.checkFieldTags(t, currentModel)

	r.checkField(t, currentModel, expected{
		FieldName: "LocalAuthDisabled",
		HclName:   "local_auth_disabled",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "ServiceBusEndpoint",
		HclName:   "service_bus_endpoint",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "ZoneRedundant",
		HclName:   "zone_redundant",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})
}

func TestBuildForServiceBusNamespaceUsingRealData(t *testing.T) {
	//t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "service_bus_namespace"}
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
			"MinimumTlsVersion": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"1.0": "1.0",
					"1.1": "1.1",
					"1.2": "1.2",
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
			"PublicNetworkAccess": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Enabled":            "Enabled",
					"Disabled":           "Disabled",
					"SecuredByPerimeter": "SecuredByPerimeter",
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
			"SkuTier": {
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
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("PrivateLinkConnectionStatus"),
						},
					},
				},
			},
			"Encryption": {
				Fields: map[string]resourcemanager.FieldDetails{
					"KeySource": {
						JsonName: "keySource",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("KeySource"),
						},
						Optional: true,
					},
					"KeyVaultProperties": {
						JsonName: "keyVaultProperties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("KeyVaultProperties"),
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
							Type: resourcemanager.StringApiObjectDefinitionType,
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
						Required: true,
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
							ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
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
							ReferenceName: stringPointer("PrivateEndpoint"),
						},
						Optional: true,
					},
					"PrivateLinkServiceConnectionState": {
						JsonName: "privateLinkServiceConnectionState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ConnectionState"),
						},
						Optional: true,
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("EndPointProvisioningState"),
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
			"Namespace": {
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
						Required: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.LocationApiObjectDefinitionType,
						},
						Required: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("NamespaceProperties"),
						},
						Required: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Sku"),
						},
						Required: true,
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
			"NamespaceProperties": {
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
							ReferenceName: stringPointer("Encryption"),
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
					"MinimumTlsVersion": {
						JsonName: "minimum_tls_version",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("MinimumTlsVersion"),
							Type:          resourcemanager.StringApiObjectDefinitionType,
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
			"NamespaceUpdateParameters": {
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
							ReferenceName: stringPointer("NamespaceUpdateProperties"),
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
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"NamespaceUpdateProperties": {
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
							ReferenceName: stringPointer("Encryption"),
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
								ReferenceName: stringPointer("PrivateEndpointConnection"),
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
							Type:          resourcemanager.StringApiObjectDefinitionType,
							ReferenceName: stringPointer("SkuName"),
						},
						Required: true,
					},
					"Tier": {
						JsonName: "tier",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("SkuTier"),
						},
						Optional: true,
					},
					"Capacity": {
						JsonName: "capacity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
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
					ReferenceName: stringPointer("Namespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Namespace"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("NamespaceUpdateParameters"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("NamespaceId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"NamespaceId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
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
						Name:       "microsoftServiceBus",
						FixedValue: stringPointer("Microsoft.ServiceBus"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "namespaces",
						FixedValue: stringPointer("namespaces"),
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

	if len(*actual) != 15 {
		// TODO - Double check this count when the sku rules are in place :see_no_evil:
		t.Errorf("expected 15 models, got %d", len(*actual))
	}

	// TODO: validate the result
	r.CurrentModel = "Namespace"
	currentModel := (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 18 {
		// TODO - Double check this count when the sku rules are in place :see_no_evil:
		// Missing - sku_name, sku_tier, sku_capacity, private_endpoint_id
		t.Errorf("expected 18 fields but got %d", len(currentModel.Fields))
	}

	r.checkFieldName(t, currentModel)
	r.checkFieldLocation(t, currentModel)
	r.checkFieldTags(t, currentModel)

	r.checkField(t, currentModel, expected{
		FieldName: "SkuName",
		HclName:   "sku_name",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 3,
		},
	})

	r.checkField(t, currentModel, expected{
		FieldName:     "SkuTier",
		HclName:       "sku_tier",
		Optional:      true,
		FieldType:     resourcemanager.TerraformSchemaFieldTypeString,
		ReferenceName: stringPointer("NamespaceSkuTier"),
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 3,
		},
	})

	r.checkField(t, currentModel, expected{
		FieldName: "SkuCapacity",
		HclName:   "sku_capacity",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
	})

	r.checkField(t, currentModel, expected{
		FieldName:     "MinimumTlsVersion",
		HclName:       "minimum_tls_version",
		Optional:      true,
		FieldType:     resourcemanager.TerraformSchemaFieldTypeString,
		ReferenceName: stringPointer("MinimumTlsVersion"),
	})

	r.checkField(t, currentModel, expected{
		FieldName: "CreatedAt",
		HclName:   "created_at",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "UpdatedAt",
		HclName:   "updated_at",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "ServiceBusEndpoint",
		HclName:   "service_bus_endpoint",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "MetricId",
		HclName:   "metric_id",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "ZoneRedundant",
		HclName:   "zone_redundant",
		Optional:  true,
		ForceNew:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})

	r.checkField(t, currentModel, expected{
		FieldName:     "Encryption",
		HclName:       "encryption",
		Optional:      true,
		FieldType:     resourcemanager.TerraformSchemaFieldTypeReference,
		ReferenceName: stringPointer("NamespaceEncryption"),
	})

	r.checkField(t, currentModel, expected{
		FieldName:           "PrivateEndpointConnection",
		HclName:             "private_endpoint_connection",
		Optional:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		NestedReferenceName: stringPointer("NamespacePrivateEndpointConnection"),
	})

	r.checkField(t, currentModel, expected{
		FieldName: "LocalAuthDisabled",
		HclName:   "local_auth_disabled",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "AlternateName",
		HclName:   "alternate_name",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "PublicNetworkAccess",
		HclName:   "public_network_access",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 3,
		},
	})

	r.CurrentModel = "NamespacePrivateEndpoint" // Should be flattened out, only contains `Id` field
	var ok bool
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceKeyVaultProperties" // Should be flattened out
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceUserAssignedIdentityProperties" // Should be flattened out
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespacePrivateEndpointConnectionProperties" // Should this be flattened into `NamespacePrivateEndpointConnection`?
	currentModel = (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 3 {
		t.Errorf("expected 3 fields but got %d", len(currentModel.Fields))
	}

	r.CurrentModel = "NamespaceSku" // Should be absent after Sku rules
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespacePrivateEndpointConnection"
	currentModel = (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 3 {
		t.Errorf("expected 3 fields but got %d", len(currentModel.Fields))
	}
	r.checkField(t, currentModel, expected{
		FieldName: "Id",
		HclName:   "id",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
	r.checkField(t, currentModel, expected{
		FieldName: "Location",
		HclName:   "location",
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
		FieldName: "Type",
		HclName:   "type",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
	r.checkField(t, currentModel, expected{
		FieldName:     "PrivateEndpoint",
		HclName:       "private_endpoint",
		Optional:      true,
		FieldType:     resourcemanager.TerraformSchemaFieldTypeReference,
		ReferenceName: stringPointer("NamespacePrivateEndpoint"),
	})
	r.checkField(t, currentModel, expected{
		FieldName:     "PrivateLinkServiceConnectionState",
		HclName:       "private_link_service_connection_state",
		Optional:      true,
		FieldType:     resourcemanager.TerraformSchemaFieldTypeReference,
		ReferenceName: stringPointer("NamespaceConnectionState"),
	})
	r.checkField(t, currentModel, expected{
		FieldName: "ProvisioningState", // Should be R/O and not have validation
		HclName:   "provisioning_state",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.CurrentModel = "NamespaceNamespaceProperties" // Should be removed as flattened into parent
	currentModel, ok = (*actual)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceConnectionState"
	currentModel = (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
	}
	r.checkField(t, currentModel, expected{
		FieldName: "Status",
		HclName:   "status",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
	r.checkField(t, currentModel, expected{
		FieldName: "Description",
		HclName:   "description",
		Computed:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.CurrentModel = "NamespaceEncryption"
	currentModel = (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 3 {
		t.Errorf("expected 3 fields but got %d", len(currentModel.Fields))
	}
	r.checkField(t, currentModel, expected{
		FieldName: "RequireInfrastructureEncryption",
		HclName:   "require_infrastructure_encryption",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})
	r.checkField(t, currentModel, expected{
		FieldName: "KeySource",
		HclName:   "key_source",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 1,
		},
	})
	r.checkField(t, currentModel, expected{
		FieldName: "KeyVaultUri",
		HclName:   "Key_vault_uri",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
	r.checkField(t, currentModel, expected{
		FieldName: "KeyVersion",
		HclName:   "Key_version",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "KeyVersion",
		HclName:   "Key_version",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
}
