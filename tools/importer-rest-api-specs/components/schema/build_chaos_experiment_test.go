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
					"Selector": {
						JsonName: "selectors",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Selector"),
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
					"Step": {
						JsonName: "steps",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Step"),
							Type:          resourcemanager.ListApiObjectDefinitionType,
						},
						Optional: true,
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
						Optional: false,
					},
					"Target": {
						JsonName: "targets",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Target"),
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
			"Step": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Branch": {
						JsonName: "branches",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Branch"),
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
			"Target": {
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
			"Branch": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Action": {
						JsonName: "actions",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							ReferenceName: stringPointer("Action"),
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
			"Action": {
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
		t.Errorf("building schema: %+v", err)
	}

	if actual == nil {
		t.Errorf("expected 3 models but got nil")
	}

	if len(*actual) != 7 {
		t.Errorf("expected 7 models but got %d", len(*actual))
	}

	topLevelModel := (*actual)["Experiment"]
	if len(topLevelModel.Fields) != 7 {
		t.Errorf("expected 7 fields but got %d", len(topLevelModel.Fields))
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
	// note: this differs from the model above, since this is implicitly required as a top level field
	// even if it's defined as optional in the schema
	if !name.Required {
		t.Errorf("expected the field 'Name' to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Errorf("expected the field 'Name' to be ForceNew but it wasn't")
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
	// TODO: source WriteOnly from the mappings?
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
	// TODO: source WriteOnly from the mappings?
	//if tags.Required || tags.Computed || tags.ForceNew || tags.WriteOnly {
	//	t.Errorf("expected the field 'Tags' to be !Required, !Computed, !ForceNew and !WriteOnly but got %t / %t / %t / %t", tags.Required, tags.Computed, tags.ForceNew, tags.WriteOnly)
	//}
	if tags.Required || tags.Computed || tags.ForceNew {
		t.Errorf("expected the field 'Tags' to be !Required, !Computed, !ForceNew but got %t / %t / %t", tags.Required, tags.Computed, tags.ForceNew)
	}

	selector, ok := topLevelModel.Fields["Selector"]
	if !ok {
		t.Errorf("expected there to be a field 'Selector' but didn't get one")
	}
	if selector.HclName != "selector" {
		t.Errorf("expected the HclName for field 'Selector' to be 'selector' but got %q", selector.HclName)
	}
	if selector.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
		t.Errorf("expected the field 'Selector' to have the type `list` but got %q", string(selector.ObjectDefinition.Type))
	}
	if !selector.Required {
		t.Errorf("expected the field 'Selector' to be Required but it wasn't")
	}
	if selector.ForceNew {
		t.Errorf("expected the field 'Selector' to be !ForceNew but it was")
	}
	if selector.ObjectDefinition.ReferenceName == nil {
		t.Errorf("expected the field 'Selector' to be have a reference to another model but it didn't")
	} else if *selector.ObjectDefinition.ReferenceName != "ExperimentSelector" {
		t.Errorf("expected the field 'Selector' to be have a reference to the 'ExperimentSelector' model but got %q", *selector.ObjectDefinition.ReferenceName)
	}

	startOnCreation, ok := topLevelModel.Fields["StartOnCreation"]
	if !ok {
		t.Errorf("expected there to be a field 'StartOnCreation' but didn't get one")
	}
	if startOnCreation.HclName != "start_on_creation" {
		t.Errorf("expected the HclName for field 'StartOnCreation' to be 'start_on_creation' but got %q", startOnCreation.HclName)
	}
	if startOnCreation.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeBoolean {
		t.Errorf("expected the field 'StartOnCreation' to have the type `bool` but got %q", string(startOnCreation.ObjectDefinition.Type))
	}
	if startOnCreation.Required {
		t.Errorf("expected the field 'StartOnCreation' to be !Required but it was")
	}
	if !startOnCreation.Optional {
		t.Errorf("expected the field 'StartOnCreation' to be Optional but it wasn't")
	}
	if startOnCreation.ForceNew {
		t.Errorf("expected the field 'StartOnCreation' to be !ForceNew but it was")
	}

	steps, ok := topLevelModel.Fields["Step"]
	if !ok {
		t.Errorf("expected there to be a field 'Step' but didn't get one")
	}
	if steps.HclName != "step" {
		t.Errorf("expected the HclName for field 'Step' to be 'step' but got %q", steps.HclName)
	}
	if steps.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
		t.Errorf("expected the field 'Step' to have the type `list` but got %q", string(steps.ObjectDefinition.Type))
	}
	if !steps.Required {
		t.Errorf("expected the field 'Step' to be Required but it wasn't")
	}
	if steps.ForceNew {
		t.Errorf("expected the field 'Step' to be !ForceNew but it was")
	}
	if steps.ObjectDefinition.ReferenceName == nil {
		t.Errorf("expected the field 'Step' to be have a reference to another model but it didn't")
	} else if *steps.ObjectDefinition.ReferenceName != "ExperimentStep" {
		t.Errorf("expected the field 'Step' to be have a reference to the 'ExperimentStep' model but got %q", *steps.ObjectDefinition.ReferenceName)
	}

	selectorsModel := (*actual)["ExperimentSelector"]
	if len(selectorsModel.Fields) != 3 {
		t.Errorf("expected 3 fields but got %d", len(selectorsModel.Fields))
	}

	selectorId, ok := selectorsModel.Fields["Id"]
	if !ok {
		t.Errorf("expected there to be a field 'Id' (model: Selector) but didn't get one")
	}
	if selectorId.HclName != "id" {
		t.Errorf("expected the HclName for field 'Id' (model: Selector) to be 'id' but got %q", selectorId.HclName)
	}
	if selectorId.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Id' (model: Selector) to have the type `string` but got %q", string(selectorId.ObjectDefinition.Type))
	}
	if !selectorId.Required {
		t.Errorf("expected the field 'Id' (model: Selector) to be Required but it wasn't")
	}
	if selectorId.ForceNew {
		t.Errorf("expected the field 'Id' (model: Selector) to be !ForceNew but it was")
	}

	targets, ok := selectorsModel.Fields["Target"]
	if !ok {
		t.Errorf("expected there to be a field 'Target' (model: Selector) but didn't get one")
	}
	if targets.HclName != "target" {
		t.Errorf("expected the HclName for field 'Target' (model: Selector) to be 'target' but got %q", targets.HclName)
	}
	if targets.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
		t.Errorf("expected the field 'Target' (model: Selector) to have the type `list` but got %q", string(targets.ObjectDefinition.Type))
	}

	if !targets.Required {
		t.Errorf("expected the field 'Target' (model: Selector) to be Required but it wasn't")
	}
	if targets.ForceNew {
		t.Errorf("expected the field 'Target' (model: Selector) to be !ForceNew but it was")
	}

	selectorType, ok := selectorsModel.Fields["Type"]
	if !ok {
		t.Errorf("expected there to be a field 'Type' (model: Selector) but didn't get one")
	}
	if selectorType.HclName != "type" {
		t.Errorf("expected the HclName for field 'Type' (model: Selector) to be 'type' but got %q", selectorType.HclName)
	}
	if selectorType.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
		t.Errorf("expected the field 'Type' (model: Selector) to have the type `reference` but got %q", string(selectorType.ObjectDefinition.Type))
	}
	if !selectorType.Required {
		t.Errorf("expected the field 'Type' (model: Selector) to be Required but it wasn't")
	}
	if selectorType.ForceNew {
		t.Errorf("expected the field 'Type' (model: Selector) to be !ForceNew but it was")
	}
	if val := selectorType.Validation; val != nil {
		if val.PossibleValues == nil {
			t.Errorf("expected validation for the field 'Type' (model: Selector) to have 4 items but it got nil")
		} else if len(*val.PossibleValues) != 4 {
			t.Errorf("expected validation for the field 'Type' (model: Selector) to have 4 items but it had %d", len(*val.PossibleValues))
		}
	} else {
		t.Errorf("expected the field 'Type' (model: Selector) to have Validation but it didn't")
	}

	stepsModel := (*actual)["ExperimentStep"]
	if len(stepsModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(stepsModel.Fields))
	}

	branch, ok := stepsModel.Fields["Branch"]
	if !ok {
		t.Errorf("expected there to be a field 'Branch' (model: Step) but didn't get one")
	}
	if branch.HclName != "branch" {
		t.Errorf("expected the HclName for field 'Branch' (model: Step) to be 'branch' but got %q", branch.HclName)
	}
	if branch.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
		t.Errorf("expected the field 'Branch' (model: Step) to have the type `list` but got %q", string(branch.ObjectDefinition.Type))
	}
	if branch.ObjectDefinition.ReferenceName == nil {
		t.Errorf("expected the field 'Branch' to be have a reference to another model but it didn't")
	} else if *branch.ObjectDefinition.ReferenceName != "ExperimentBranch" {
		t.Errorf("expected the field 'Branch' (model: Step) to be have a reference to the 'ExperimentBranch' model but got %q", *branch.ObjectDefinition.ReferenceName)
	}
	if !branch.Required {
		t.Errorf("expected the field 'Branch' (model: Step) to be Required but it wasn't")
	}
	if branch.ForceNew {
		t.Errorf("expected the field 'Branch' (model: Step) to be !ForceNew but it was")
	}

	stepName, ok := stepsModel.Fields["Name"]
	if !ok {
		t.Errorf("expected there to be a field 'Name' (model: Step) but didn't get one")
	}
	if stepName.HclName != "name" {
		t.Errorf("expected the HclName for field 'Name' (model: Step) to be 'name' but got %q", stepName.HclName)
	}
	if stepName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Name' (model: Step) to have the type `string` but got %q", string(stepName.ObjectDefinition.Type))
	}
	if !stepName.Required {
		t.Errorf("expected the field 'Name' (model: Step) to be Required but it wasn't")
	}
	if stepName.ForceNew {
		t.Errorf("expected the field 'Name' (model: Step) to be !ForceNew but it was")
	}

	targetModel := (*actual)["ExperimentTarget"]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(targetModel.Fields))
	}
	// Field: Id (string)
	targetId, ok := selectorsModel.Fields["Id"]
	if !ok {
		t.Errorf("expected there to be a field 'Id' (model: Target) but didn't get one")
	}
	if targetId.HclName != "id" {
		t.Errorf("expected the HclName for field 'Id' (model: Target) to be 'id' but got %q", targetId.HclName)
	}
	if targetId.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Id' (model: Target) to have the type `string` but got %q", string(targetId.ObjectDefinition.Type))
	}
	if !targetId.Required {
		t.Errorf("expected the field 'Id' (model: Target) to be Required but it wasn't")
	}
	if targetId.ForceNew {
		t.Errorf("expected the field 'Id' (model: Target) to be !ForceNew but it was")
	}
	// TODO - check validation when ID validation is a thing in `TerraformSchemaValidationDefinition`

	// Field: Type (Enum)
	targetType, ok := selectorsModel.Fields["Type"]
	if !ok {
		t.Errorf("expected there to be a field 'Type' (model: Target) but didn't get one")
	}
	if targetType.HclName != "type" {
		t.Errorf("expected the HclName for field 'Type' (model: Target) to be 'type' but got %q", targetType.HclName)
	}
	if targetType.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference {
		t.Errorf("expected the field 'Type' (model: Target) to have the type `reference` but got %q", string(targetType.ObjectDefinition.Type))
	}
	if !targetType.Required {
		t.Errorf("expected the field 'Type' (model: Target) to be Required but it wasn't")
	}
	if targetType.ForceNew {
		t.Errorf("expected the field 'Type' (model: Target) to be !ForceNew but it was")
	}
	if val := targetType.Validation; val != nil {
		if val.PossibleValues == nil {
			t.Errorf("expected validation for the field 'Type' (model: Target) to have 4 items but it got nil")
		} else if len(*val.PossibleValues) != 1 {
			t.Errorf("expected validation for the field 'Type' (model: Target) to have 4 items but it had %d", len(*val.PossibleValues))
		}
	} else {
		t.Errorf("expected the field 'Type' (model: Target) to have Validation but it didn't")
	}

	branchModel := (*actual)["ExperimentBranch"]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(branchModel.Fields))
	}

	branchName, ok := branchModel.Fields["Name"]
	if !ok {
		t.Errorf("expected there to be a field 'Name' (model: Branch) but didn't get one")
	}
	if branchName.HclName != "name" {
		t.Errorf("expected the HclName for field 'Name' (model: Branch) to be 'name' but got %q", branchName.HclName)
	}
	if branchName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Name' (model: Branch) to have the type `string` but got %q", string(branchName.ObjectDefinition.Type))
	}
	if !branchName.Required {
		t.Errorf("expected the field 'Name' (model: Branch) to be Required but it wasn't")
	}
	if branchName.ForceNew {
		t.Errorf("expected the field 'Name' (model: Branch) to be !ForceNew but it was")
	}

	actions, ok := branchModel.Fields["Action"]
	if !ok {
		t.Errorf("expected there to be a field 'Action' (model: Branch) but didn't get one")
	}
	if actions.HclName != "action" {
		t.Errorf("expected the HclName for field 'Action' (model: Branch) to be 'branch' but got %q", actions.HclName)
	}
	if actions.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeList {
		t.Errorf("expected the field 'Action' (model: Branch) to have the type `list` but got %q", string(actions.ObjectDefinition.Type))
	}
	if actions.ObjectDefinition.ReferenceName == nil {
		t.Errorf("expected the field 'Action' (model: Branch) to be have a reference to another model but it didn't")
	} else if *actions.ObjectDefinition.ReferenceName != "ExperimentAction" {
		t.Errorf("expected the field 'Action' (model: Branch) to be have a reference to the 'ExperimentAction' model but got %q", *actions.ObjectDefinition.ReferenceName)
	}
	if !actions.Required {
		t.Errorf("expected the field 'Action' (model: Branch) to be Required but it wasn't")
	}
	if actions.ForceNew {
		t.Errorf("expected the field 'Action' (model: Branch) to be !ForceNew but it was")
	}

	actionModel := (*actual)["ExperimentAction"]
	if len(targetModel.Fields) != 2 {
		t.Errorf("expected 2 fields but got %d", len(actionModel.Fields))
	}

	actionName, ok := actionModel.Fields["Name"]
	if !ok {
		t.Errorf("expected there to be a field 'Name' (model: Action) but didn't get one")
	}
	if actionName.HclName != "name" {
		t.Errorf("expected the HclName for field 'Name' (model: Action) to be 'name' but got %q", actionName.HclName)
	}
	if actionName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Name' (model: Action) to have the type `string` but got %q", string(actionName.ObjectDefinition.Type))
	}
	if !actionName.Required {
		t.Errorf("expected the field 'Name' (model: Action) to be Required but it wasn't")
	}
	if actionName.ForceNew {
		t.Errorf("expected the field 'Name' (model: Action) to be !ForceNew but it was")
	}

	// Field: Type (string)
	actionType, ok := actionModel.Fields["Type"]
	if !ok {
		t.Errorf("expected there to be a field 'Type` (model: Action) but didn't get one")
	}
	if actionType.HclName != "type" {
		t.Errorf("expected the HclName for field 'Type` (model: Action) to be 'name' but got %q", actionType.HclName)
	}
	if actionType.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Errorf("expected the field 'Type` (model: Action) to have the type `string` but got %q", string(actionType.ObjectDefinition.Type))
	}
	if !actionType.Required {
		t.Errorf("expected the field 'Type` (model: Action) to be Required but it wasn't")
	}
	if actionType.ForceNew {
		t.Errorf("expected the field 'Type` (model: Action) to be !ForceNew but it was")
	}
}
