package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestComponentIDValidationFunc_CommonResourceIDDisabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			GenerateIdValidation: false,
			ResourceIdName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("SubscriptionId"),
			},
		},
	}
	actual := strings.TrimSpace(idValidationFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentIDValidationFunc_CommonResourceIDEnabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			GenerateIdValidation: true,
			ResourceIdName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				CommonAlias: stringPointer("Subscription"),
			},
		},
	}
	actual := strings.TrimSpace(idValidationFunctionForResource(input))
	expected := strings.TrimSpace(`
func (r ExampleResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return commonids.ValidateSubscriptionID
}
`)
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentIDValidationFunc_RegularResourceIDDisabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			GenerateIdValidation: false,
			ResourceIdName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Id: "/customSubscriptions/{subscriptionId}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						ExampleValue: "customSubscriptions",
						FixedValue:   stringPointer("customSubscriptions"),
						Name:         "staticCustomSubscriptions",
						Type:         resourcemanager.StaticSegment,
					},
					{
						ExampleValue: "000000-0000-0000-0000-00000000",
						Name:         "subscriptionId",
						Type:         resourcemanager.SubscriptionIdSegment,
					},
				},
			},
		},
	}
	actual := strings.TrimSpace(idValidationFunctionForResource(input))
	expected := ""
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestComponentIDValidationFunc_RegularResourceIDEnabled(t *testing.T) {
	input := ResourceInput{
		ResourceTypeName: "Example",
		SdkResourceName:  "sdkresource",
		Details: resourcemanager.TerraformResourceDetails{
			GenerateIdValidation: true,
			ResourceIdName:       "CustomSubscriptionId",
		},
		ResourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"CustomSubscriptionId": {
				Id: "/customSubscriptions/{subscriptionId}",
				Segments: []resourcemanager.ResourceIdSegment{
					{
						ExampleValue: "customSubscriptions",
						FixedValue:   stringPointer("customSubscriptions"),
						Name:         "staticCustomSubscriptions",
						Type:         resourcemanager.StaticSegment,
					},
					{
						ExampleValue: "000000-0000-0000-0000-00000000",
						Name:         "subscriptionId",
						Type:         resourcemanager.SubscriptionIdSegment,
					},
				},
			},
		},
	}
	actual := strings.TrimSpace(idValidationFunctionForResource(input))
	expected := strings.TrimSpace(`
func (r ExampleResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return sdkresource.ValidateCustomSubscriptionID
}
`)
	assertTemplatedCodeMatches(t, expected, actual)
}
