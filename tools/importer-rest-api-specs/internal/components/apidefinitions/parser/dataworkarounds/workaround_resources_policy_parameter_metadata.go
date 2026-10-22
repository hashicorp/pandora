// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundResourcesPolicyParameterMetadata{}

type workaroundResourcesPolicyParameterMetadata struct{}

func (workaroundResourcesPolicyParameterMetadata) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Resources" && apiVersion.APIVersion == "2025-01-01"
}

func (workaroundResourcesPolicyParameterMetadata) Name() string {
	return "Resources / Preserve Policy Parameter Metadata"
}

func (workaroundResourcesPolicyParameterMetadata) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["PolicyDefinitions"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `PolicyDefinitions` but didn't get one")
	}

	model, ok := resource.Models["ParameterDefinitionsValue"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `ParameterDefinitionsValue` but didn't get one")
	}

	field, ok := model.Fields["Metadata"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `Metadata` but didn't get one")
	}

	if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType ||
		field.ObjectDefinition.ReferenceName == nil ||
		*field.ObjectDefinition.ReferenceName != "ParameterDefinitionsValueMetadata" {
		return nil, fmt.Errorf("expected `Metadata` to reference `ParameterDefinitionsValueMetadata`")
	}

	// The importer does not preserve additionalProperties alongside named metadata properties.
	field.ObjectDefinition = sdkModels.SDKObjectDefinition{
		Type: sdkModels.DictionarySDKObjectDefinitionType,
		NestedItem: &sdkModels.SDKObjectDefinition{
			Type: sdkModels.RawObjectSDKObjectDefinitionType,
		},
	}
	model.Fields["Metadata"] = field
	resource.Models["ParameterDefinitionsValue"] = model
	input.Resources["PolicyDefinitions"] = resource

	return &input, nil
}
