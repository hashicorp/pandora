// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = WorkaroundSecurityInsights22503{}

type WorkaroundSecurityInsights22503 struct{}

func (WorkaroundSecurityInsights22503) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "SecurityInsights" && apiVersion.APIVersion == "2022-10-01-preview"
}

func (w WorkaroundSecurityInsights22503) Name() string {
	return "Security Insights / 22503"
}

func (w WorkaroundSecurityInsights22503) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["SecurityMLAnalyticsSettings"]
	if !ok {
		return nil, errors.New("expected a resource named `SecurityMLAnalyticsSettings` but didn't get one")
	}

	model, ok := resource.Models["AnomalySecurityMLAnalyticsSettingsProperties"]
	if !ok {
		return nil, errors.New("expected a model named `AnomalySecurityMLAnalyticsSettingsProperties` but didn't get one")
	}

	field, ok := model.Fields["CustomizableObservations"]
	if !ok {
		return nil, errors.New("expected a field named `CustomizableObservations` but didn't get one")
	}

	if field.ObjectDefinition.Type != sdkModels.RawObjectSDKObjectDefinitionType {
		return nil, fmt.Errorf("expected the `CustomizableObservations` field type to be `%s`, got `%s`", sdkModels.RawObjectSDKObjectDefinitionType, field.ObjectDefinition.Type)
	}

	field.ObjectDefinition.Type = sdkModels.ReferenceSDKObjectDefinitionType
	field.ObjectDefinition.ReferenceName = pointer.To("AnomalySecurityMLAnalyticsCustomizableObservations")
	model.Fields["CustomizableObservations"] = field

	// The following objects are missing from the API spec, but double check in case it gets fixed
	for _, n := range []string{"AnomalySecurityMLAnalyticsMultiSelectObservations", "AnomalySecurityMLAnalyticsSingleSelectObservations", "AnomalySecurityMLAnalyticsPrioritizeExcludeObservations", "AnomalySecurityMLAnalyticsThresholdObservations"} {
		if _, ok := resource.Models[n]; ok {
			return nil, fmt.Errorf("expected no model definition for `%s`, but found one, this workaround should be removed", n)
		}
	}

	resource.Models["AnomalySecurityMLAnalyticsMultiSelectObservations"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"SupportedValues": {
				JsonName: "supportedValues",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Values": {
				JsonName: "values",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Name": {
				JsonName: "name",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Description": {
				JsonName: "description",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SupportedValuesKql": {
				JsonName: "supportedValuesKql",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"ValuesKql": {
				JsonName: "valuesKql",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SequenceNumber": {
				JsonName: "sequenceNumber",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Rerun": {
				JsonName: "rerun",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}

	resource.Models["AnomalySecurityMLAnalyticsSingleSelectObservations"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"SupportedValues": {
				JsonName: "supportedValues",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						Type: sdkModels.StringSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Value": {
				JsonName: "value",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Name": {
				JsonName: "name",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Description": {
				JsonName: "description",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SupportedValuesKql": {
				JsonName: "supportedValuesKql",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SequenceNumber": {
				JsonName: "sequenceNumber",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Rerun": {
				JsonName: "rerun",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}

	resource.Models["AnomalySecurityMLAnalyticsPrioritizeExcludeObservations"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"Name": {
				JsonName: "name",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Description": {
				JsonName: "description",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Prioritize": {
				JsonName: "prioritize",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Exclude": {
				JsonName: "exclude",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"DataType": {
				JsonName: "dataType",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SequenceNumber": {
				JsonName: "sequenceNumber",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Rerun": {
				JsonName: "rerun",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}

	resource.Models["AnomalySecurityMLAnalyticsThresholdObservations"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"Name": {
				JsonName: "name",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Description": {
				JsonName: "description",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Maximum": {
				JsonName: "maximum",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Minimum": {
				JsonName: "minimum",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Value": {
				JsonName: "value",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SequenceNumber": {
				JsonName: "sequenceNumber",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"Rerun": {
				JsonName: "rerun",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.RawObjectSDKObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}

	resource.Models["AnomalySecurityMLAnalyticsCustomizableObservations"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"MultiSelectObservations": {
				JsonName: "multiSelectObservations",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName: pointer.To("AnomalySecurityMLAnalyticsMultiSelectObservations"),
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"SingleSelectObservations": {
				JsonName: "singleSelectObservations",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName: pointer.To("AnomalySecurityMLAnalyticsSingleSelectObservations"),
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"PrioritizeExcludeObservations": {
				JsonName: "prioritizeExcludeObservations",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName: pointer.To("AnomalySecurityMLAnalyticsPrioritizeExcludeObservations"),
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
			"ThresholdObservations": {
				JsonName: "thresholdObservations",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName: pointer.To("AnomalySecurityMLAnalyticsThresholdObservations"),
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Type: sdkModels.ListSDKObjectDefinitionType,
				},
				Optional: true,
			},
		},
	}

	input.Resources["SecurityMLAnalyticsSettings"] = resource
	return &input, nil
}
