package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForChaosStudioExperimentWithRealData(t *testing.T) {
	builder := Builder{
		constants: map[string]resourcemanager.ConstantDetails{
			"TargetReferenceType": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"ChaosTarget": "ChaosTarget",
				},
			},
			"SelectorType": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"List":    "List",
					"Percent": "Percent",
					"Random":  "Random",
					"Tag":     "Tag",
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"Experiment": {
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
							ReferenceName: stringPointer("ExperimentProperties"),
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
			"ExperimentProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Selectors": {
						JsonName: "selectors",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Selectors"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: true,
					},
					"StartOnCreation": {
						JsonName: "startOnCreation",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Steps": {
						JsonName: "steps",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Steps"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: true,
					},
				},
			},
			"Selectors": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Targets": {
						JsonName: "targets",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Targets"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("SelectorType"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: false,
					},
				},
			},
			"Steps": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Branches": {
						JsonName: "branches",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Branches"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
				},
			},
			"Targets": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("TargetReferenceType"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Optional: false,
					},
				},
			},
			"Branches": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Actions": {
						JsonName: "actions",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Actions"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
				},
			},
			"Actions": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Optional: false,
					},
				},
			},
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ExperimentId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: stringPointer("ExperimentId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ExperimentId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: stringPointer("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: stringPointer("ExperimentId"),
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"ExperimentId": {
				CommonAlias:   nil,
				ConstantNames: nil,
				Id:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/experiments/{experimentName}",
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
						FixedValue: stringPointer("resourceGroups"),
						Name:       "resourceGroups",
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
						Name:       "microsoftChaos",
						FixedValue: stringPointer("Microsoft.Chaos"),
						Type:       resourcemanager.ResourceProviderSegment,
					},
					{
						Name:       "experiments",
						FixedValue: stringPointer("experiments"),
						Type:       resourcemanager.StaticSegment,
					},
					{
						Name: "experimentName",
						Type: resourcemanager.UserSpecifiedSegment,
					},
				},
			},
		},
	}

	input := resourcemanager.TerraformResourceDetails{
		ApiVersion: "2022-07-01",
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
		DisplayName: "Chaos Experiment",
		ReadMethod: resourcemanager.MethodDefinition{
			Generate:         true,
			MethodName:       "Get",
			TimeoutInMinutes: 5,
		},
		Resource:        "Experiment",
		ResourceIdName:  "ExperimentId",
		ResourceName:    "Experiment",
		SchemaModelName: "Experiment",
	}

	actual, err := builder.Build(input, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("building schema: %+v", err)
	}

	if actual == nil {
		t.Fatalf("expected 3 models but got nil")
	}

	if len(*actual) != 7 {
		t.Fatalf("expected 7 models but got %d", len(*actual))
	}

	topLevelModel := (*actual)["Experiment"]
	if len(topLevelModel.Fields) != 7 {
		t.Fatalf("expected 7 fields but got %d", len(topLevelModel.Fields))
	}

	name, ok := topLevelModel.Fields["Name"]
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

	location, ok := topLevelModel.Fields["Location"]
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

	tags, ok := topLevelModel.Fields["Tags"]
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
