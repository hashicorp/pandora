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

func TestBuildForChaosStudioExperimentWithRealData(t *testing.T) {
	t.Skipf("TODO: update schema gen & re-enable this test")
	r := resourceUnderTest{Name: "chaos_studio_experiment"}
	builder := Builder{
		constants: map[string]models.SDKConstant{
			"TargetReferenceType": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"ChaosTarget": "ChaosTarget",
				},
			},
			"SelectorType": {
				Type: models.StringSDKConstantType,
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
							ReferenceName: pointer.To("ExperimentProperties"),
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
								ReferenceName: pointer.To("Selector"),
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
								ReferenceName: pointer.To("Step"),
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
						Required: true,
					},
					"Target": {
						JsonName: "targets",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: pointer.To("Target"),
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							},
							Type: resourcemanager.ListApiObjectDefinitionType,
						},
						Required: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: pointer.To("SelectorType"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Required: true,
						Validation: &resourcemanager.FieldValidationDetails{
							Type: resourcemanager.RangeValidation,
							Values: &[]interface{}{
								"List",
								"Percent",
								"Random",
								"Tag",
							},
						},
					},
				},
			},
			"Step": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Branch": {
						JsonName: "branches",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: pointer.To("Branch"),
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
							ReferenceName: pointer.To("TargetReferenceType"),
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						},
						Required: true,
						Validation: &resourcemanager.FieldValidationDetails{
							Type: resourcemanager.RangeValidation,
							Values: &[]interface{}{
								"ChaosTarget",
							},
						},
					},
				},
			},
			"Branch": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Action": {
						JsonName: "actions",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							NestedItem: &resourcemanager.ApiObjectDefinition{
								ReferenceName: pointer.To("Action"),
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
					ReferenceName: pointer.To("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: pointer.To("ExperimentId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIdName: pointer.To("ExperimentId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: pointer.To("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: pointer.To("ExperimentId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &resourcemanager.ApiObjectDefinition{
					ReferenceName: pointer.To("Experiment"),
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				},
				ResourceIdName: pointer.To("ExperimentId"),
			},
		},
		resourceIds: map[string]models.ResourceID{
			"ExperimentId": {
				CommonIDAlias: nil,
				ConstantNames: nil,
				ExampleValue:  "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Chaos/experiments/{experimentName}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
					models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
					models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
					models.NewStaticValueResourceIDSegment("providers", "providers"),
					models.NewResourceProviderResourceIDSegment("microsoftChaos", "Microsoft.Chaos"),
					models.NewStaticValueResourceIDSegment("experiments", "experiments"),
					models.NewUserSpecifiedResourceIDSegment("experimentName", "experimentName"),
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

	var inputResourceBuildInfo *importerModels.ResourceBuildInfo

	actualModels, actualMappings, err := builder.Build(input, inputResourceBuildInfo, hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Errorf("building schema: %+v", err)
	}

	if actualModels == nil {
		t.Fatalf("expected 7 models but got nil")
	}
	if actualMappings == nil {
		// TODO: tests for Mappings
		t.Fatalf("expected some mappings but got nil")
	}

	if len(*actualModels) != 7 {
		t.Errorf("expected 7 models but got %d", len(*actualModels))
	}

	var ok bool
	r.CurrentModel = "Experiment"
	currentModel, ok := (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {

		if len(currentModel.Fields) != 7 {
			t.Errorf("expected 7 fields but got %d", len(currentModel.Fields))
		}

		r.checkFieldName(t, currentModel)
		r.checkFieldLocation(t, currentModel)
		r.checkFieldTags(t, currentModel)
		r.IdentityConfig = &IdentityConfig{
			FieldConfig: &FieldConfig{
				Optional: true,
			},
			IdentityType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
		}
		r.checkFieldIdentity(t, currentModel)

		r.checkField(t, currentModel, expected{
			FieldName:           "Selector",
			HclName:             "selector",
			Optional:            false,
			Required:            true,
			Computed:            false,
			ForceNew:            false,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
			ReferenceName:       nil,
			NestedReferenceName: pointer.To("ExperimentSelector"),
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
			NestedReferenceName: pointer.To("ExperimentStep"),
		})
	}

	r.CurrentModel = "ExperimentSelector"
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {

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
			NestedReferenceName: pointer.To("ExperimentTarget"),
		})

		r.checkField(t, currentModel, expected{
			FieldName:           "Type",
			HclName:             "type",
			Required:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName:       pointer.To("SelectorType"),
			NestedReferenceName: nil,
			Validation: &expectedValidation{
				Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
				PossibleValueCount: 4,
			},
		})
	}

	r.CurrentModel = "ExperimentStep"
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 2 {
			t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
		}

		r.checkField(t, currentModel, expected{
			FieldName:           "Branch",
			HclName:             "branch",
			Required:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeList,
			NestedReferenceName: pointer.To("ExperimentBranch"),
		})

		r.checkField(t, currentModel, expected{
			FieldName: "Name",
			HclName:   "name",
			Required:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})
	}

	r.CurrentModel = "ExperimentTarget"
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {

		if len(currentModel.Fields) != 2 {
			t.Errorf("expected 2 fields but got %d", len(currentModel.Fields))
		}

		r.checkField(t, currentModel, expected{
			FieldName: "Id",
			HclName:   "id",
			Required:  true,
			FieldType: resourcemanager.TerraformSchemaFieldTypeString,
		})

		r.checkField(t, currentModel, expected{
			FieldName:           "Type",
			HclName:             "type",
			Required:            true,
			FieldType:           resourcemanager.TerraformSchemaFieldTypeReference,
			ReferenceName:       pointer.To("TargetReferenceType"),
			NestedReferenceName: nil,
			Validation: &expectedValidation{
				Type:               resourcemanager.TerraformSchemaValidationTypePossibleValues,
				PossibleValueCount: 1,
			},
		})
	}

	r.CurrentModel = "ExperimentBranch"
	currentModel, ok = (*actualModels)[r.CurrentModel]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {

		if len(currentModel.Fields) != 2 {
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
			NestedReferenceName: pointer.To("ExperimentAction"),
		})
	}

	r.CurrentModel = "ExperimentAction"
	currentModel, ok = (*actualModels)["ExperimentAction"]
	if !ok {
		t.Errorf("expected there to be a model %q, but there wasn't", r.CurrentModel)
	} else {
		if len(currentModel.Fields) != 2 {
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
}
