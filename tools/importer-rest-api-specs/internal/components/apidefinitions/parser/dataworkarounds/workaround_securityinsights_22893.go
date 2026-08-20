// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = WorkaroundSecurityInsights22893{}

type WorkaroundSecurityInsights22893 struct{}

func (WorkaroundSecurityInsights22893) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "SecurityInsights" && apiVersion.APIVersion == "2022-10-01-preview"
}

func (w WorkaroundSecurityInsights22893) Name() string {
	return "Security Insights / 22893"
}

func (w WorkaroundSecurityInsights22893) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["ThreatIntelligence"]
	if !ok {
		return nil, errors.New("expected a resource named `ThreatIntelligence` but didn't get one")
	}

	model, ok := resource.Models["ThreatIntelligenceGranularMarkingModel"]
	if !ok {
		return nil, errors.New("expected a model named `ThreatIntelligenceGranularMarkingModel` but didn't get one")
	}

	field, ok := model.Fields["MarkingRef"]
	if !ok {
		return nil, errors.New("expected a field named `MarkingRef` but didn't get one")
	}

	if field.ObjectDefinition.Type != sdkModels.IntegerSDKObjectDefinitionType {
		return nil, fmt.Errorf("expected the `CustomizableObservations` field type to be `%s`, got `%s`, this workaround can be removed", sdkModels.IntegerSDKObjectDefinitionType, field.ObjectDefinition.Type)
	}

	field.ObjectDefinition.Type = sdkModels.StringSDKObjectDefinitionType

	model.Fields["MarkingRef"] = field
	resource.Models["ThreatIntelligenceGranularMarkingModel"] = model
	input.Resources["ThreatIntelligence"] = resource

	return &input, nil
}
