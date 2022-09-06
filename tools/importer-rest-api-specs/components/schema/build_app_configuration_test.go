package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForAppConfigurationUsingRealData(t *testing.T) {
	//t.Skipf("TODO: update schema gen & re-enable this test")

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
						JsonName: "",
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

	topLevelModel := (*actual)["ConfigurationStore"]
	if len(topLevelModel.Fields) != 14 {
		t.Errorf("expected 14 fields, but got %d", len(topLevelModel.Fields))
	}

	name, ok := topLevelModel.Fields["Name"]
	if !ok {
		t.Errorf("expected there to be a field 'Name' but didn't get one")
	}
	if name.HclName != "name" {
		t.Errorf("expected the HclName for field 'Name' to be 'name' but got %q", name.HclName)
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Name' to have the type `string` but got %q", string(name.ObjectDefinition.Type))
	}
	if !name.Required {
		t.Errorf("expected the field 'Name' to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Errorf("expected the field 'Name' to be ForceNew but it wasn't")
	}

	// TODO: source WriteOnly from the mappings
	//if name.Optional || name.Computed || name.WriteOnly {
	//	t.Errorf("expected the field 'Name' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", name.Optional, name.Computed, name.WriteOnly)
	//}

	if name.Optional || name.Computed {
		t.Errorf("expected the field 'Name' to be !Optional, !Computed but got %t / %t", name.Optional, name.Computed)
	}

	location, ok := topLevelModel.Fields["Location"]
	if !ok {
		t.Errorf("expected there to be a field 'Location' but didn't get one")
	}
	if location.HclName != "location" {
		t.Errorf("expected the HclName for field 'Location' to be 'location' but got %q", location.HclName)
	}
	if location.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeLocation {
		t.Errorf("expected the field 'Location' to have the type `location` but got %q", string(location.ObjectDefinition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !location.Required {
		t.Errorf("expected the field 'Location' to be Required but it wasn't")
	}
	if !location.ForceNew {
		t.Errorf("expected the field 'Location' to be ForceNew but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if location.Optional || location.Computed || location.WriteOnly {
	//	t.Errorf("expected the field 'Location' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", location.Optional, location.Computed, location.WriteOnly)
	//}
	if location.Optional || location.Computed {
		t.Errorf("expected the field 'Location' to be !Optional, !Computed but got %t / %t", location.Optional, location.Computed)
	}

	tags, ok := topLevelModel.Fields["Tags"]
	if !ok {
		t.Errorf("expected there to be a field 'Tags' but didn't get one")
	}
	if tags.HclName != "tags" {
		t.Errorf("expected the HclName for field 'Tags' to be 'tags' but got %q", tags.HclName)
	}
	if tags.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeTags {
		t.Errorf("expected the field 'Tags' to have the type `tags` but got %q", string(tags.ObjectDefinition.Type))
	}
	if !tags.Optional {
		t.Errorf("expected the field 'Tags' to be Optional but it wasn't")
	}
	// TODO: source WriteOnly from the mappings
	//if tags.Required || tags.Computed || tags.ForceNew || tags.WriteOnly {
	//	t.Errorf("expected the field 'Tags' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", tags.Required, tags.Computed, tags.ForceNew, tags.WriteOnly)
	//}
	if tags.Required || tags.Computed || tags.ForceNew {
		t.Errorf("expected the field 'Tags' to be !Required, !Computed, !ForceNew but got %t / / %t / %t", tags.Required, tags.Computed, tags.ForceNew)
	}

	createMode, ok := topLevelModel.Fields["CreateMode"]
	if !ok {
		t.Errorf("expected there to be a field 'CreateMode' but didn't get one")
	}
	if createMode.HclName != "create_mode" {
		t.Errorf("expected the HclName for field 'CreateMode' to be 'create_mode' but got %q", createMode.HclName)
	}
	if createMode.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
		t.Errorf("expected the field 'CreateMode' to have the type `reference` but got %q", string(createMode.ObjectDefinition.Type))
	}
	if createMode.ObjectDefinition.ReferenceName == nil {
		t.Errorf("expected field 'Createmode' to have a reference to an Enum, but got 'nil'")
	}
	if *createMode.ObjectDefinition.ReferenceName != "CreateMode" {
		t.Errorf("expected field 'Createmode' to reference model 'CreateMode', but got %q", *createMode.ObjectDefinition.ReferenceName)
	}
	if !createMode.Optional {
		t.Errorf("expected the field 'CreateMode' to be Optional but it wasn't")
	}
	if !createMode.ForceNew {
		// TODO - This should be ForceNew since it cannot be update post creation? Switch to t.Errorf later.
		t.Errorf("expected the field 'CreateMode' to be ForceNew but it wasn't")
	}

	// TODO: source WriteOnly from the mappings
	//if createMode.Optional || createMode.Computed || createMode.WriteOnly {
	//	t.Errorf("expected the field 'createMode' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", createMode.Optional, createMode.Computed, createMode.WriteOnly)
	//}

	if createMode.Required || createMode.Computed {
		t.Errorf("expected the field 'CreateMode' to be Optional, !Computed but got %t / %t", createMode.Optional, createMode.Computed)
	}

	// CreationDate - date / string?
	creationDate, ok := topLevelModel.Fields["CreationDate"]
	if !ok {
		t.Errorf("expected there to be a field 'Name' but didn't get one")
	}
	if creationDate.HclName != "creation_date" {
		t.Errorf("expected the HclName for field 'CreationDate' to be 'creation_date' but got %q", name.HclName)
	}
	if creationDate.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeDateTime {
		t.Errorf("expected the field 'CreationDate' to have the type `DateTime` but got %q", string(creationDate.ObjectDefinition.Type))
	}

	if creationDate.Required || creationDate.Optional {
		// TODO - This should be Computed only, but coming through as Optional?
		t.Errorf("expected the field 'CreationDate' to be !Required and !Optional but it got %t / %t", creationDate.Required, creationDate.Optional)
	}

	// TODO: source WriteOnly from the mappings
	//if creationDate.Optional || creationDate.Required || creationDate.WriteOnly {
	//	t.Errorf("expected the field 'CreationDate' to be !Optional, !Required and !WriteOnly but got %t / %t / %t", creationDate.Optional, creationDate.Computed, creationDate.WriteOnly)
	//}

	if !creationDate.Computed {
		// TODO - This should be Computed only, but coming through as Optional?
		t.Errorf("expected the field 'CreationDate' to be Computed but got %t", creationDate.Computed)
	}

	disableLocalAuth, ok := topLevelModel.Fields["DisableLocalAuth"]
	if !ok {
		t.Errorf("expected there to be a field 'DisableLocalAuth' but didn't get one")
	}
	if disableLocalAuth.HclName != "local_auth_disabled" {
		// TODO - switch for t.Errorf when rename rule in place
		t.Errorf("expected the HclName for field 'DisableLocalAuth' to be 'local_auth_disabled' but got %q", disableLocalAuth.HclName)
	}
	if disableLocalAuth.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeBoolean {
		t.Errorf("expected the field 'DisableLocalAuth' to have the type `bool` but got %q", string(disableLocalAuth.ObjectDefinition.Type))
	}
	if !disableLocalAuth.Optional {
		t.Errorf("expected the field 'DisableLocalAuth' to be Optional but it wasn't")
	}
	if !disableLocalAuth.ForceNew {
		t.Errorf("expected the field 'DisableLocalAuth' to be ForceNew but it wasn't")
	}

	// TODO: source WriteOnly from the mappings
	//if name.Optional || name.Computed || name.WriteOnly {
	//	t.Errorf("expected the field 'DisableLocalAuth' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", name.Optional, name.Computed, name.WriteOnly)
	//}

	if !disableLocalAuth.Optional {
		t.Errorf("expected the field 'DisableLocalAuth' to be Optional but it wasn't")
	}

	if disableLocalAuth.Computed {
		t.Errorf("expected the field 'DisableLocalAuth' to be !Computed but it was")
	}

	enablePurgeProtection, ok := topLevelModel.Fields["EnablePurgeProtection"]
	if !ok {
		t.Errorf("expected there to be a field 'EnablePurgeProtection' but didn't get one")
	}
	if enablePurgeProtection.HclName != "purge_protection_enabled" {
		// TODO - switch for t.Errorf when rename rule in place
		t.Errorf("expected the HclName for field 'EnablePurgeProtection' to be 'purge_protection_enabled' but got %q", enablePurgeProtection.HclName)
	}
	if enablePurgeProtection.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeBoolean {
		t.Errorf("expected the field 'EnablePurgeProtection' to have the type `bool` but got %q", string(enablePurgeProtection.ObjectDefinition.Type))
	}
	if !enablePurgeProtection.Optional {
		t.Errorf("expected the field 'EnablePurgeProtection' to be Optional but it wasn't")
	}
	if !enablePurgeProtection.ForceNew {
		t.Errorf("expected the field 'EnablePurgeProtection' to be ForceNew but it is")
	}

	// TODO: source WriteOnly from the mappings
	//if name.Required || name.Computed || name.WriteOnly {
	//	t.Errorf("expected the field 'EnablePurgeProtection' to be !Required, !Computed and !WriteOnly but got %t / %t / %t", name.Optional, name.Computed, name.WriteOnly)
	//}

	if !enablePurgeProtection.Optional {
		t.Errorf("expected the field 'EnablePurgeProtection' to be Optional, but it wasn't")
	}

	if enablePurgeProtection.Computed {
		t.Errorf("expected the field 'EnablePurgeProtection' to be !Computed but it was")
	}

	// ProvisioningState - should be filtered out of the TF
	_, ok = topLevelModel.Fields["ProvisioningState"]
	if ok {
		t.Errorf("expected there not to be a field 'ProvisioningState' but found one")
	}

	// SoftDeleteRetentionInDays - int

	softDeleteRetentionInDays, ok := topLevelModel.Fields["SoftDeleteRetentionInDays"]
	if !ok {
		t.Errorf("expected there to be a field 'SoftDeleteRetentionInDays' but didn't get one")
	}
	if softDeleteRetentionInDays.HclName != "soft_delete_retention_in_days" {
		t.Errorf("expected the HclName for field 'SoftDeleteRetentionInDays' to be 'soft_delete_retention_in_days' but got %q", softDeleteRetentionInDays.HclName)
	}
	if softDeleteRetentionInDays.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeInteger {
		t.Errorf("expected the field 'SoftDeleteRetentionInDays' to have the type `int` but got %q", string(softDeleteRetentionInDays.ObjectDefinition.Type))
	}
	if softDeleteRetentionInDays.Required {
		t.Errorf("expected the field 'SoftDeleteRetentionInDays' to be !Required but it was")
	}
	if softDeleteRetentionInDays.ForceNew {
		t.Errorf("expected the field 'SoftDeleteRetentionInDays' to be !ForceNew but it was")
	}

	// TODO: source WriteOnly from the mappings
	//if softDeleteRetentionInDays.Optional || softDeleteRetentionInDays.Computed || softDeleteRetentionInDays.WriteOnly {
	//	t.Errorf("expected the field 'SoftDeleteRetentionInDays' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", softDeleteRetentionInDays.Optional, softDeleteRetentionInDays.Computed, softDeleteRetentionInDays.WriteOnly)
	//}

	if softDeleteRetentionInDays.Optional || softDeleteRetentionInDays.Computed {
		t.Errorf("expected the field 'SoftDeleteRetentionInDays' to be !Optional, !Computed but got %t / %t", softDeleteRetentionInDays.Optional, softDeleteRetentionInDays.Computed)
	}

	// TODO - Nested Blocks...
	// Encryption
	// PublicNetworkAccess - block of PublicNetworkAccess
	// sku - Should be flattened to string and disappear when rules are correct?

	// TODO - Lists...
	// PrivateEndpointConnections - list of PrivateEndpointConnectionReference
}
