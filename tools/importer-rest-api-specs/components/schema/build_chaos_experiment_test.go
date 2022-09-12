package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestBuildForChaosStudioExperimentWithRealData(t *testing.T) {
	//t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "chaos_studio_experiment"}
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
							ReferenceName: stringPointer("ExperimentProperties"),
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
			"ExperimentProperties": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Selector": {
						JsonName: "selectors",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("Selector"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: true,
					},
					"StartOnCreation": {
						JsonName: "startOnCreation",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.BooleanApiObjectDefinitionType,
						},
						Optional: true,
					},
					"Step": {
						JsonName: "steps",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("Step"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Selector": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
					"Target": {
						JsonName: "targets",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("Target"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("SelectorType"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
			"Step": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Branch": {
						JsonName: "branches",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("Branch"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: false,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
			"Target": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Id": {
						JsonName: "id",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("TargetReferenceType"),
							Type:          resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Branch": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Action": {
						JsonName: "actions",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: stringPointer("Action"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Action": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
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
		t.Errorf("building schema: %+v", err)
	}

	if actual == nil {
		t.Fatalf("expected 3 models but got nil")
	}

	if len(*actual) != 7 {
		t.Errorf("expected 7 models but got %d", len(*actual))
	}

	r.CurrentModel = "Experiment"
	currentModel := (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 7 {
		t.Errorf("expected 7 fields but got %d", len(currentModel.Fields))
	}

	r.checkFieldName(t, currentModel)
	r.checkFieldLocation(t, currentModel)
	r.checkFieldTags(t, currentModel)

	r.checkField(t, currentModel, expected{
		FieldName:           "Selector",
		HclName:             "selector",
		Optional:            false,
		Required:            true,
		Computed:            false,
		ForceNew:            false,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		ReferenceName:       nil,
		NestedReferenceName: stringPointer("ExperimentSelector"),
	})

	r.checkField(t, currentModel, expected{
		FieldName: "StartOnCreation",
		HclName:   "start_on_creation",
		Optional:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	})

	r.checkField(t, currentModel, expected{
		FieldName:           "Step",
		HclName:             "step",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		NestedReferenceName: stringPointer("ExperimentStep"),
	})

	r.CurrentModel = "ExperimentSelector"
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
		FieldName:           "Target",
		HclName:             "target",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		NestedReferenceName: stringPointer("ExperimentTarget"),
	})

	r.checkField(t, currentModel, expected{
		FieldName:           "Type",
		HclName:             "type",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeReference,
		ReferenceName:       stringPointer("SelectorType"),
		NestedReferenceName: nil,
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 4,
		},
	})

	r.CurrentModel = "ExperimentStep"
	currentModel = (*actual)[r.CurrentModel]
	if len(currentModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
	}

	r.checkField(t, currentModel, expected{
		FieldName:           "Branch",
		HclName:             "branch",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		NestedReferenceName: stringPointer("ExperimentBranch"),
	})

	r.checkField(t, currentModel, expected{
		FieldName: "Name",
		HclName:   "name",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	targetModel := (*actual)["ExperimentTarget"]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(targetModel.Fields))
	}

	r.checkField(t, targetModel, expected{
		FieldName: "Id",
		HclName:   "id",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, targetModel, expected{
		FieldName:           "Type",
		HclName:             "type",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeReference,
		ReferenceName:       stringPointer("TargetReferenceType"),
		NestedReferenceName: nil,
		Validation: &expectedValidation{
			Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
			PossibleValueCount: 1,
		},
	})

	r.CurrentModel = "ExperimentBranch"
	currentModel = (*actual)[r.CurrentModel]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
	}

	r.checkField(t, currentModel, expected{
		FieldName: "Name",
		HclName:   "name",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName:           "Action",
		HclName:             "action",
		Required:            true,
		FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
		NestedReferenceName: stringPointer("ExperimentAction"),
	})

	r.CurrentModel = "ExperimentAction"
	currentModel = (*actual)["ExperimentAction"]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
	}

	r.checkField(t, currentModel, expected{
		FieldName: "Name",
		HclName:   "name",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})

	r.checkField(t, currentModel, expected{
		FieldName: "Type",
		HclName:   "type",
		Required:  true,
		FieldType: resourcemanager.TerraformSchemaFieldTypeString,
	})
}
