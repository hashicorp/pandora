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
					"Tags": {
						JsonName: "tags",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.TagsApiObjectDefinitionType,
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
		SchemaModelName: "ResourceGroup",
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

	testValidateResourceGroupSchema(t, actual)
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
		Resource:       "ResourceGroups",
		ResourceIdName: "ResourceGroupId",
		ResourceName:   "ResourceGroup",
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

	testValidateResourceGroupSchema(t, actual)
}

func testValidateResourceGroupSchema(t *testing.T, actual *map[string]resourcemanager.TerraformSchemaModelDefinition) {
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
