// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestComponentIDValidationFunc_CommonResourceID_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: models.TerraformResourceDefinition{
			GenerateIDValidation: false,
			ResourceIDName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("SubscriptionId"),
			},
		},
	}
	actual, err := idValidationFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but got %q", *actual)
	}
}

func TestComponentIDValidationFunc_CommonResourceID_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: models.TerraformResourceDefinition{
			GenerateIDValidation: true,
			ResourceIDName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				CommonIDAlias: pointer.To("Subscription"),
			},
		},
	}
	actual, err := idValidationFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
func (r ExampleResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return commonids.ValidateSubscriptionID
}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}

func TestComponentIDValidationFunc_RegularResourceID_Disabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: models.TerraformResourceDefinition{
			GenerateIDValidation: false,
			ResourceIDName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				ExampleValue: "/customSubscriptions/{subscriptionId}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticCustomSubscriptions", "customSubscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				},
			},
		},
	}
	actual, err := idValidationFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	if actual != nil {
		t.Fatalf("expected `actual` to be nil but it wasn't: %q", *actual)
	}
}

func TestComponentIDValidationFunc_RegularResourceID_Enabled(t *testing.T) {
	input := generatorModels.ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: models.TerraformResourceDefinition{
			GenerateIDValidation: true,
			ResourceIDName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]models.ResourceID{
			"CustomSubscriptionId": {
				ExampleValue: "/customSubscriptions/{subscriptionId}",
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("staticCustomSubscriptions", "customSubscriptions"),
					models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
				},
			},
		},
	}
	actual, err := idValidationFunctionForResource(input)
	if err != nil {
		t.Fatalf("error: %+v", err)
	}
	expected := strings.TrimSpace(`
func (r ExampleResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return sdkresource.ValidateCustomSubscriptionID
}
`)
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
