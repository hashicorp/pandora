// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestFieldNameRenameMislabelledResourceID_NotApplicable_DifferentConstantValue(t *testing.T) {
	metadata := FieldMetadata{
		TerraformDetails: resourcemanager.TerraformResourceDetails{},
		Model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ResourceId": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Type"),
					},
				},
			},
		},
		Constants: map[string]models.SDKConstant{
			"Type": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"SystemAssigned": "SystemAssigned",
				},
			},
		},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_DifferentName(t *testing.T) {
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("Location", FieldMetadata{})
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_SingleField(t *testing.T) {
	metadata := FieldMetadata{
		TerraformDetails: resourcemanager.TerraformResourceDetails{},
		Model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ResourceId": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]models.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_MultipleFields(t *testing.T) {
	metadata := FieldMetadata{
		TerraformDetails: resourcemanager.TerraformResourceDetails{},
		Model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ResourceId": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Third": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]models.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_Applicable_UsingConstant(t *testing.T) {
	metadata := FieldMetadata{
		TerraformDetails: resourcemanager.TerraformResourceDetails{},
		Model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ResourceId": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Type"),
					},
				},
			},
		},
		Constants: map[string]models.SDKConstant{
			"Type": {
				Type: models.StringSDKConstantType,
				Values: map[string]string{
					"UserAssigned": "UserAssigned",
				},
			},
		},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	if *actual != "UserAssignedIdentityId" {
		t.Fatalf("expected `actual` to be `UserAssignedIdentityId` but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_WithAMatchingTypeFieldThatIsAString(t *testing.T) {
	metadata := FieldMetadata{
		TerraformDetails: resourcemanager.TerraformResourceDetails{},
		Model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ResourceId": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]models.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatalf(err.Error())
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	if *actual != "UserAssignedIdentityId" {
		t.Fatalf("expected `actual` to be `UserAssignedIdentityId` but got %q", *actual)
	}
}
