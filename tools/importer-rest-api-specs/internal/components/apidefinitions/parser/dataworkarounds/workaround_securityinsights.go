// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = WorkaroundSecurityInsights{}

// WorkaroundSecurityInsights - Covers remaining generation issues
// these appear to be a Pandora issue rather than an API spec issue
type WorkaroundSecurityInsights struct{}

func (WorkaroundSecurityInsights) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "SecurityInsights" && apiVersion.APIVersion == "2022-10-01-preview"
}

func (WorkaroundSecurityInsights) Name() string {
	return "Security Insights"
}

func (WorkaroundSecurityInsights) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["AlertRuleTemplates"]
	if !ok {
		return nil, errors.New("expected a resource named `AlertRuleTemplates` but didn't get one")
	}

	for _, m := range []string{"MLBehaviorAnalyticsAlertRuleTemplateProperties", "NrtAlertRuleTemplateProperties", "ThreatIntelligenceAlertRuleTemplateProperties"} {
		model, ok := resource.Models[m]
		if !ok {
			return nil, fmt.Errorf("expected a model named `%s` but didn't get one", m)
		}

		if _, ok := model.Fields["DisplayName"]; ok {
			return nil, fmt.Errorf("expected a field named `DisplayName` to be missing from `%s`, but it was present, this workaround can be removed", m)
		}
		model.Fields["DisplayName"] = sdkModels.SDKField{
			JsonName: "displayName",
			ObjectDefinition: sdkModels.SDKObjectDefinition{
				Type: sdkModels.StringSDKObjectDefinitionType,
			},
			Optional: true,
		}

		if m != "MLBehaviorAnalyticsAlertRuleTemplateProperties" {
			if _, ok := model.Fields["Description"]; ok {
				return nil, fmt.Errorf("expected a field named `Description` to be missing from `%s`, but it was present, this workaround can be removed", m)
			}
			model.Fields["Description"] = sdkModels.SDKField{
				JsonName: "description",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.StringSDKObjectDefinitionType,
				},
				Optional: true,
			}
		}

		resource.Models[m] = model
	}

	input.Resources["AlertRuleTemplates"] = resource

	return &input, nil
}
