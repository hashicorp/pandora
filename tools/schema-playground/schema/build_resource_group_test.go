package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForResourceGroupAllModelsTheSame(t *testing.T) {
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
	if len(actual.Fields) != 2 {
		t.Fatalf("expected 2 fields but got %d", len(actual.Fields))
	}
	location, ok := actual.Fields["location"]
	if !ok {
		t.Fatalf("expected there to be a field 'location' but didn't get one")
	}
	if location.Definition.Type != resourcemanager.LocationApiObjectDefinitionType {
		t.Fatalf("expected the field 'location' to have the type `location` but got %q", string(location.Definition.Type))
	}
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !location.Required {
		t.Fatalf("expected the field 'location' to be Required but it wasn't")
	}
	if !location.ForceNew {
		t.Fatalf("expected the field 'location' to be ForceNew but it wasn't")
	}
	if location.Optional || location.Computed || location.WriteOnly {
		t.Fatalf("expected the field 'location' to be !Optional, !Computed and !WriteOnly but got %t / %t / %t", location.Optional, location.Computed, location.WriteOnly)
	}

	tags, ok := actual.Fields["tags"]
	if !ok {
		t.Fatalf("expected there to be a field 'tags' but didn't get one")
	}
	if tags.Definition.Type != resourcemanager.TagsApiObjectDefinitionType {
		t.Fatalf("expected the field 'tags' to have the type `tags` but got %q", string(location.Definition.Type))
	}
	if !tags.Optional {
		t.Fatalf("expected the field 'tags' to be Optional but it wasn't")
	}
	if tags.Required || tags.Computed || tags.ForceNew || tags.WriteOnly {
		t.Fatalf("expected the field 'tags' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", location.Required, location.Computed, location.ForceNew, location.WriteOnly)
	}
}

func stringPointer(input string) *string {
	return &input
}
