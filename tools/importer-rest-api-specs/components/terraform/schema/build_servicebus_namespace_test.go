// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForServiceBusNamespaceHappyPath(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "service_bus_namespace"}
	builder := Builder{
		constants: map[string]models.SDKConstant{
			"SkuName": {
				Type: models.StringSDKConstantType,
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
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.LocationSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("NamespaceProperties"),
						},
						Required: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Sku"),
						},
						Required: true,
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
			"NamespaceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SkuName"),
						},
						Required: true,
					},
				},
			},
			"SkuTier": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SkuTier"),
						},
						Optional: true,
					},
				},
			},
			"SkuCapacity": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Capacity": {
						JsonName: "capacity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Namespace"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Namespace"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Namespace"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
		},
		resourceIds: map[string]models.ResourceID{
			"NamespaceId": {
				CommonIDAlias: nil,
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("microsoftServiceBus", "Microsoft.ServiceBus"),
					models.NewStaticValueResourceIDSegment("namespaces", "namespaces"),
					models.NewUserSpecifiedResourceIDSegment("namespaceName", "namespaceName"),
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

	var inputResourceBuildInfo *importerModels.ResourceBuildInfo

	actualModels, actualMappings, err := builder.Build(input, inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Errorf("building schema: %+v", err)
	}

	if actualModels == nil {
		t.Errorf("model %q - expected models but got nil", r.CurrentModel)
	}
	if len(*actualModels) != 3 {
		t.Errorf("model %q - expected 3 models but got %d", r.CurrentModel, len(*actualModels))
	}
	if actualMappings == nil {
		// TODO: tests for Mappings
		t.Fatalf("expected some mappings but got nil")
	}

	r.CurrentModel = "Namespace"
	currentModel := (*actualModels)[r.CurrentModel]
	if len(currentModel.Fields) != 7 {
		t.Errorf("model %q - expected 7 fields but got %d", r.CurrentModel, len(currentModel.Fields))
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
	t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "service_bus_namespace"}
	builder := Builder{
		constants: map[string]models.SDKConstant{
			"EndPointProvisioningState": {
				Type: models.StringSDKConstantType,
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
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"MicrosoftPointKeyVault": "Microsoft.KeyVault",
				},
			},
			"MinimumTlsVersion": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"1.0": "1.0",
					"1.1": "1.1",
					"1.2": "1.2",
				},
			},
			"PrivateLinkConnectionStatus": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"Approved":     "Approved",
					"Disconnected": "Disconnected",
					"Pending":      "Pending",
					"Rejected":     "Rejected",
				},
			},
			"PublicNetworkAccess": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"Enabled":            "Enabled",
					"Disabled":           "Disabled",
					"SecuredByPerimeter": "SecuredByPerimeter",
				},
			},
			"SkuName": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"Basic":    "Basic",
					"Premium":  "Premium",
					"Standard": "Standard",
				},
			},
			"SkuTier": {
				Type: models.StringSDKConstantType,
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
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("PrivateLinkConnectionStatus"),
						},
					},
				},
			},
			"Encryption": {
				Fields: map[string]resourcemanager.FieldDetails{
					"KeySource": {
						JsonName: "keySource",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("KeySource"),
						},
						Optional: true,
					},
					"KeyVaultProperties": {
						JsonName: "keyVaultProperties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("KeyVaultProperties"),
							},
						},
						Optional: true,
					},
					"RequireInfrastructureEncryption": {
						JsonName: "requireInfrastructureEncryption",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"KeyVaultProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"KeyName": {
						JsonName: "keyName",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"KeyVaultUri": {
						JsonName: "keyVaultUri",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"KeyVersion": {
						JsonName: "keyVersion",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpointConnection": {
				Fields: map[string]resourcemanager.FieldDetails{
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
							ReferenceName: pointer.To("PrivateEndpointConnectionProperties"),
						},
					},
					"SystemData": {
						JsonName: "systemData",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.SystemData,
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
			"PrivateEndpointConnectionProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PrivateEndpoint": {
						JsonName: "privateEndpoint",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("PrivateEndpoint"),
						},
						Optional: true,
					},
					"PrivateLinkServiceConnectionState": {
						JsonName: "privateLinkServiceConnectionState",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("ConnectionState"),
						},
						Optional: true,
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("EndPointProvisioningState"),
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpoint": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Namespace": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Location": {
						JsonName: "location",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.LocationSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("NamespaceProperties"),
						},
						Required: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Sku"),
						},
						Required: true,
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
			"NamespaceProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"AlternateName": {
						JsonName: "alternateName",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"CreatedAt": {
						JsonName: "createdAt",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Encryption"),
						},
						Optional: true,
					},
					"MetricId": {
						JsonName: "metricId",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"MinimumTlsVersion": {
						JsonName: "minimum_tls_version",
						ObjectDefinition: models.SDKObjectDefinition{
							ReferenceName: pointer.To("MinimumTlsVersion"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						Optional: true,
						Validation: &resourcemanager.FieldValidationDetails{
							Type: resourcemanager.RangeValidation,
							Values: &[]interface{}{
								"1.0",
								"1.1",
								"1.2",
							},
						},
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("PrivateEndpointConnection"),
							},
						},
						Optional: true,
					},
					"PublicNetworkAccess": {
						JsonName: "publicNetworkAccess",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"UpdatedAt": {
						JsonName: "updatedAt",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"NamespaceUpdateParameters": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
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
							ReferenceName: pointer.To("NamespaceUpdateProperties"),
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Sku"),
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
			"NamespaceUpdateProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"AlternateName": {
						JsonName: "alternateName",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"CreatedAt": {
						JsonName: "createdAt",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Encryption"),
						},
						Optional: true,
					},
					"MetricId": {
						JsonName: "metricId",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("PrivateEndpointConnection"),
							},
						},
						Optional: true,
					},
					"ServiceBusEndpoint": {
						JsonName: "serviceBusEndpoint",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Status": {
						JsonName: "status",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"ZoneRedundant": {
						JsonName: "zoneRedundant",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"UpdatedAt": {
						JsonName: "updatedAt",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SkuName"),
						},
						Required: true,
						Validation: &resourcemanager.FieldValidationDetails{
							Type: resourcemanager.RangeValidation,
							Values: &[]interface{}{
								"Basic",
								"Premium",
								"Standard",
							},
						},
					},
					"Tier": {
						JsonName: "tier",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("SkuTier"),
						},
						Optional: true,
						Validation: &resourcemanager.FieldValidationDetails{
							Type: resourcemanager.RangeValidation,
							Values: &[]interface{}{
								"Basic",
								"Premium",
								"Standard",
							},
						},
					},
					"Capacity": {
						JsonName: "capacity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"UserAssignedIdentityProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"UserAssignedIdentity": {
						JsonName: "userAssignedIdentity",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Namespace"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Namespace"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("NamespaceUpdateParameters"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("NamespaceId"),
			},
		},
		resourceIds: map[string]models.ResourceID{
			"NamespaceId": {
				CommonIDAlias: nil,
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("microsoftServiceBus", "Microsoft.ServiceBus"),
					models.NewStaticValueResourceIDSegment("namespaces", "namespaces"),
					models.NewUserSpecifiedResourceIDSegment("namespaceName", "namespaceName"),
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

	var inputResourceBuildInfo *importerModels.ResourceBuildInfo

	actualModels, actualMappings, err := builder.Build(input, inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	if actualModels == nil {
		t.Fatalf("expected 4 models but got nil")
	}
	if actualMappings == nil {
		// TODO: tests for Mappings
		t.Fatalf("expected some mappings but got nil")
	}

	if len(*actualModels) != 4 {
		// TODO - Double check this count when the sku rules are in place :see_no_evil:
		t.Errorf("expected 4 models, got %d", len(*actualModels))
	}

	r.CurrentModel = "Namespace"
	currentModel, ok := (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("top level model %q missing", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 16 {
			// TODO - Double check this count when the sku rules are in place :see_no_evil:
			// Missing - sku_name, sku_tier, sku_capacity, private_endpoint_id
			// Should be removed - created_at, updated_at, sku
			t.Errorf("model %q - expected 16 fields but got %d", r.CurrentModel, len(currentModel.Fields))
		}

		r.checkFieldName(t, currentModel)
		r.checkFieldLocation(t, currentModel)
		r.IdentityConfig = &IdentityConfig{
			IdentityType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
		}
		r.checkFieldIdentity(t, currentModel)
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
			ReferenceName: pointer.To("NamespaceSkuTier"),
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
			ReferenceName: pointer.To("MinimumTlsVersion"),
		})

		r.checkField(t, currentModel, expected{
			FieldName: "CreatedAt",
			HclName:   "created_at",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeDateTime,
		})

		r.checkField(t, currentModel, expected{
			FieldName: "UpdatedAt",
			HclName:   "updated_at",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeDateTime,
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
			ReferenceName: pointer.To("NamespaceEncryption"),
		})

		r.checkField(t, currentModel, expected{
			FieldName:           "PrivateEndpointConnection",
			HclName:             "private_endpoint_connection",
			Optional:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
			NestedReferenceName: pointer.To("NamespacePrivateEndpointConnection"),
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
			FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
		})
	}

	r.CurrentModel = "NamespacePrivateEndpoint" // Should be flattened out, only contains `Id` field
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceKeyVaultProperties" // Should be flattened out
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceUserAssignedIdentityProperties" // Should be flattened out
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespacePrivateEndpointConnectionProperties"
	currentModel = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceSku" // Should be absent after Sku rules
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespacePrivateEndpointConnection"
	currentModel = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 7 {
			t.Errorf("model %q - expected 3 fields but got %d", r.CurrentModel, len(currentModel.Fields))
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
			ReferenceName: pointer.To("NamespacePrivateEndpoint"),
		})
		r.checkField(t, currentModel, expected{
			FieldName:     "PrivateLinkServiceConnectionState",
			HclName:       "private_link_service_connection_state",
			Computed:      true,
			FieldType:     resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName: pointer.To("NamespaceConnectionState"),
		})
	}

	r.CurrentModel = "NamespaceNamespaceProperties" // Should be removed as flattened into parent
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if ok {
		t.Errorf("expected model %q to be removed but it was present", r.CurrentModel)
	}

	r.CurrentModel = "NamespaceConnectionState"
	currentModel = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 2 {
			t.Errorf("model %q - expected 2 fields but got %d", r.CurrentModel, len(currentModel.Fields))
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
		currentModel = (*actualModels)[r.CurrentModel]
		if len(currentModel.Fields) != 3 {
			t.Errorf("model %q - expected 3 fields but got %d", r.CurrentModel, len(currentModel.Fields))
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
			HclName:   "key_version",
			Optional:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})
	}
}
