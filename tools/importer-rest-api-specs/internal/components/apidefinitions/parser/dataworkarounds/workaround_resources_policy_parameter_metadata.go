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
	for resourceName, resource := range input.Resources {
		switch resourceName {
		case "PolicyDefinitions", "PolicyDefinitionVersions", "PolicySetDefinitions", "PolicySetDefinitionVersions":
		default:
			continue
		}

		model, ok := resource.Models["ParameterDefinitionsValue"]
		if !ok {
			return nil, fmt.Errorf("expected a model named `ParameterDefinitionsValue` in resource `%s`", resourceName)
		}
		field, ok := model.Fields["Metadata"]
		if !ok {
			return nil, fmt.Errorf("expected a field named `Metadata` in model `ParameterDefinitionsValue` in resource `%s`", resourceName)
		}
		if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType ||
			field.ObjectDefinition.ReferenceName == nil ||
			*field.ObjectDefinition.ReferenceName != "ParameterDefinitionsValueMetadata" {
			return nil, fmt.Errorf("expected `Metadata` to reference `ParameterDefinitionsValueMetadata` in resource `%s`", resourceName)
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
		input.Resources[resourceName] = resource
	}

	return &input, nil
}
