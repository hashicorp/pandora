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
		models: map[string]models.SDKModel{
			"Experiment": {
				Fields: map[string]models.SDKField{
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
							ReferenceName: pointer.To("ExperimentProperties"),
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
			"ExperimentProperties": {
				Fields: map[string]models.SDKField{
					"Selector": {
						JsonName: "selectors",
						ObjectDefinition: models.SDKObjectDefinition{
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Selector"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
							Type: models.ListSDKObjectDefinitionType,
						},
						Required: true,
					},
					"StartOnCreation": {
						JsonName: "startOnCreation",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.BooleanSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Step": {
						JsonName: "steps",
						ObjectDefinition: models.SDKObjectDefinition{
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Step"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
							Type: models.ListSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Selector": {
				Fields: map[string]models.SDKField{
					"Id": {
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Target": {
						JsonName: "targets",
						ObjectDefinition: models.SDKObjectDefinition{
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Target"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
							Type: models.ListSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							ReferenceName: pointer.To("SelectorType"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Step": {
				Fields: map[string]models.SDKField{
					"Branch": {
						JsonName: "branches",
						ObjectDefinition: models.SDKObjectDefinition{
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Branch"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
							Type: models.ListSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Target": {
				Fields: map[string]models.SDKField{
					"Id": {
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							ReferenceName: pointer.To("TargetReferenceType"),
							Type:          models.ReferenceSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Branch": {
				Fields: map[string]models.SDKField{
					"Action": {
						JsonName: "actions",
						ObjectDefinition: models.SDKObjectDefinition{
							NestedItem: &models.SDKObjectDefinition{
								ReferenceName: pointer.To("Action"),
								Type:          models.ReferenceSDKObjectDefinitionType,
							},
							Type: models.ListSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Action": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: false,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
		operations: map[string]models.SDKOperation{
			"Create": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Experiment"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ExperimentId"),
			},
			"Delete": {
				LongRunning:    true,
				Method:         "DELETE",
				ResourceIDName: pointer.To("ExperimentId"),
			},
			"Get": {
				LongRunning: false,
				Method:      "GET",
				ResponseObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Experiment"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ExperimentId"),
			},
			"Update": {
				LongRunning: false,
				Method:      "PUT",
				RequestObject: &models.SDKObjectDefinition{
					ReferenceName: pointer.To("Experiment"),
					Type:          models.ReferenceSDKObjectDefinitionType,
				},
				ResourceIDName: pointer.To("ExperimentId"),
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
