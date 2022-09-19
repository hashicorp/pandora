package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForAppConfigurationUsingRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")

	r := resourceUnderTest{
		Name: "configuration_store",
	}

	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{
			"ActionsRequired": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"None":     "None",
					"Recreate": "Recreate",
				},
			},
			"ConnectionStatus": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Approved":     "Approved",
					"Disconnected": "Disconnected",
					"Pending":      "Pending",
					"Rejected":     "Rejected",
				},
			},
			"CreateMode": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Default": "Default",
					"Recover": "Recover",
				},
			},
			"ProvisioningState": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Cancelled": "Cancelled",
					"Creating":  "Creating",
					"Deleting":  "Deleting",
					"Failed":    "Failed",
					"Succeeded": "Succeeded",
					"Updating":  "Updating",
				},
			},
			"PublicNetworkAccess": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Disabled": "Disabled",
					"Enabled":  "Enabled",
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"ConfigurationStore": {
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
							ReferenceName: stringPointer("ConfigurationStoreProperties"),
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
			"ConfigurationStoreProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"CreateMode": {
						JsonName: "createMode",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem:    nil,
							ReferenceName: stringPointer("CreateMode"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
					"CreationDate": {
						JsonName: "creationDate",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem:    nil,
							ReferenceName: nil,
							Type:          resourcemanager.DateTimeApiObjectDefinitionType,
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
					"EnablePurgeProtection": {
						JsonName: "enablePurgeProtection",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("EncryptionProperties"),
						},
						Optional: true,
					},
					"Endpoint": {
						JsonName: "endpoint",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateEndpointConnections": {
						JsonName: "privateEndpointConnections",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("PrivateEndpointConnectionReference"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("ProvisioningState"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PublicNetworkAccess": {
						JsonName: "publicNetworkAccess",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("PublicNetworkAccess"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
					"SoftDeleteRetentionInDays": {
						JsonName: "softDeleteRetentionInDays",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.IntegerApiObjectDefinitionType,
						},
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Sku"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
				},
			},
			"Sku": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"EncryptionProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"KeyVaultProperties": {
						JsonName: "keyVaultProperties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("KeyVaultProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"PrivateEndpointConnectionReference": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
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
							NestedItem:    nil,
							ReferenceName: stringPointer("PrivateEndpointConnectionProperties"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
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
							ReferenceName: stringPointer("PrivateEndpoint"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
					"PrivateLinkServiceConnectionState": {
						JsonName: "PrivateLinkServiceConnectionState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem:    nil,
							ReferenceName: stringPointer("PrivateLinkServiceConnectionState"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
					"ProvisioningState": {
						JsonName: "provisioningState",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("ProvisioningState"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
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
					},
				},
			},
			"PrivateLinkServiceConnectionState": {
				Fields: map[string]resourcemanager.FieldDetails{
					"ActionsRequired": {
						JsonName: "actionsRequired",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("ActionsRequired"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
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
							ReferenceName: stringPointer("ConnectionStatus"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"KeyVaultProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"IdentityClientId": {
						JsonName: "identityClientId",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
					"KeyIdentifier": {
						JsonName: "keyIdentifier",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"ConfigurationStoreUpdateParameters": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Identity": {
						JsonName: "identity",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Sku": {
						JsonName: "sku",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Sku"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
					},
					"Properties": {
						JsonName: "properties",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("ConfigurationStorePropertiesUpdateParameters"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
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
			"ConfigurationStorePropertiesUpdateParameters": {
				Fields: map[string]resourcemanager.FieldDetails{
					"DisableLocalAuth": {
						JsonName: "disableLocalAuth",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"EnablePurgeProtection": {
						JsonName: "enablePurgeProtection",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Encryption": {
						JsonName: "encryption",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("EncryptionProperties"),
						},
						Optional: true,
					},
					"PublicNetworkAccess": {
						JsonName: "publicNetworkAccess",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("PublicNetworkAccess"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: true,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ConfigurationStore"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ConfigurationStore"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ConfigurationStoreId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("ConfigurationStoreId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ConfigurationStore"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ConfigurationStoreId"),
			},
			"Update": {
				LongRunning: true,
				Method:      "PATCH",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ConfigurationStoreUpdateParameters"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("ConfigurationStore"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ConfigurationStoreId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"ConfigurationStoreId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
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
						FixedValue: stringPointer("Microsoft.AppConfiguration"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "configurationStores",
						FixedValue: stringPointer("configurationStores"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "configStoreName",
						Type: resourcemanager.UserSpecifiedSegment,
					},
				},
			},
		},
	}

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2022-05-01",
		CreateMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Create",
			TimeoutInMinutes: 30,
		},
		DeleteMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Delete",
			TimeoutInMinutes: 30,
		},
		DisplayName: "App Configuration",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "ConfigurationStore",
		ResourceIdName:  "ConfigurationStoreId",
		SchemaModelName: "ConfigurationStore",
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
		t.Errorf("expected 11 models, got nil")
	}
	if len(*actual) != 11 {
		// TODO - Change to t.Errorf when the (PATCH?) Update Models are being processed
		t.Errorf("expected 11 models but got %d", len(*actual))
	}

	currentModel, ok := (*actual)["ConfigurationStore"]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 14 {
			t.Errorf("expected 14 fields, but got %d", len(currentModel.Fields))
		}

		r.checkFieldName(t, currentModel)
		r.checkFieldLocation(t, currentModel)
		r.checkFieldTags(t, currentModel)

		r.checkField(t, currentModel, expected{
			FieldName: "CreateMode",
			HclName:   "create_mode",
			Optional:  true,
			ForceNew:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
			Validation: &expectedValidation{
				Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
				PossibleValueCount: 2,
			},
		})
		r.checkField(t, currentModel, expected{
			FieldName: "CreationDate",
			HclName:   "creation_date",
			Computed:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeDateTime,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "DisableLocalAuth",
			HclName:   "local_auth_disabled",
			Optional:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
		})
		r.checkField(t, currentModel, expected{
			FieldName: "EnablePurgeProtection",
			HclName:   "purge_protection_enabled",
			Optional:  true,
			ForceNew:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
		})

		// ProvisioningState - should be filtered out of the TF - TODO Helper for check absent?
		_, ok = currentModel.Fields["ProvisioningState"]
		if ok {
			t.Errorf("expected there not to be a field 'ProvisioningState' but found one")
		}

		r.checkField(t, currentModel, expected{
			FieldName: "SoftDeleteRetentionInDays",
			HclName:   "soft_delete_retention_in_days",
			Optional:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeInteger,
		})
	}

	// SoftDeleteRetentionInDays - int

	// TODO - Nested Blocks...
	// Encryption
	// PublicNetworkAccess - block of PublicNetworkAccess
	// sku - Should be flattened to string and disappear when rules are correct?

	// TODO - Lists...
	// PrivateEndpointConnections - list of PrivateEndpointConnectionReference
}
