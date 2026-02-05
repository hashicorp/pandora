// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package processors

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestFieldNameRenameMislabelledResourceID_NotApplicable_DifferentConstantValue(t *testing.T) {
	t.Parallel()
	metadata := FieldMetadata{
		TerraformDetails: sdkModels.TerraformResourceDefinition{},
		Model: sdkModels.SDKModel{
			Fields: map[string]sdkModels.SDKField{
				"ResourceId": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Type"),
					},
				},
			},
		},
		Constants: map[string]sdkModels.SDKConstant{
			"Type": {
				Type: sdkModels.StringSDKConstantType,
				Values: map[string]string{
					"SystemAssigned": "SystemAssigned",
				},
			},
		},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_DifferentName(t *testing.T) {
	t.Parallel()
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("Location", FieldMetadata{})
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_SingleField(t *testing.T) {
	t.Parallel()
	metadata := FieldMetadata{
		TerraformDetails: sdkModels.TerraformResourceDefinition{},
		Model: sdkModels.SDKModel{
			Fields: map[string]sdkModels.SDKField{
				"ResourceId": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]sdkModels.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_NotApplicable_MultipleFields(t *testing.T) {
	t.Parallel()
	metadata := FieldMetadata{
		TerraformDetails: sdkModels.TerraformResourceDefinition{},
		Model: sdkModels.SDKModel{
			Fields: map[string]sdkModels.SDKField{
				"ResourceId": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
				"Third": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]sdkModels.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil since this isn't applicable but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_Applicable_UsingConstant(t *testing.T) {
	t.Parallel()
	metadata := FieldMetadata{
		TerraformDetails: sdkModels.TerraformResourceDefinition{},
		Model: sdkModels.SDKModel{
			Fields: map[string]sdkModels.SDKField{
				"ResourceId": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Type"),
					},
				},
			},
		},
		Constants: map[string]sdkModels.SDKConstant{
			"Type": {
				Type: sdkModels.StringSDKConstantType,
				Values: map[string]string{
					"UserAssigned": "UserAssigned",
				},
			},
		},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	if *actual != "UserAssignedIdentityId" {
		t.Fatalf("expected `actual` to be `UserAssignedIdentityId` but got %q", *actual)
	}
}

func TestFieldNameRenameMislabelledResourceID_WithAMatchingTypeFieldThatIsAString(t *testing.T) {
	t.Parallel()
	metadata := FieldMetadata{
		TerraformDetails: sdkModels.TerraformResourceDefinition{},
		Model: sdkModels.SDKModel{
			Fields: map[string]sdkModels.SDKField{
				"ResourceId": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
				"Type": {
					ObjectDefinition: sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
				},
			},
		},
		Constants: map[string]sdkModels.SDKConstant{},
	}
	actual, err := fieldNameRenameMislabelledResourceID{}.ProcessField("ResourceId", metadata)
	if err != nil {
		t.Fatal(err.Error())
	}
	if actual == nil {
		t.Fatalf("expected `actual` to have a value but was nil")
	}
	if *actual != "UserAssignedIdentityId" {
		t.Fatalf("expected `actual` to be `UserAssignedIdentityId` but got %q", *actual)
	}
}
