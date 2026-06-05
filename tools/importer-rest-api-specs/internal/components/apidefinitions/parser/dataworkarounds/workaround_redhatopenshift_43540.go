// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundRedHatOpenShift43540{}

// workaroundRedHatOpenShift43540 narrows the identity shape to match
// the ARO API, which only accepts exactly one user-assigned identity.
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/43540
type workaroundRedHatOpenShift43540 struct{}

func (workaroundRedHatOpenShift43540) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "RedHatOpenShift" && apiVersion.APIVersion == "2025-07-25"
}

func (workaroundRedHatOpenShift43540) Name() string {
	return "RedHatOpenShift / 43540"
}

func (workaroundRedHatOpenShift43540) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["OpenShiftClusters"]
	if !ok {
		return nil, errors.New("expected a resource named `OpenShiftClusters` but didn't get one")
	}

	models := []string{
		"OpenShiftCluster",
		"OpenShiftClusterUpdate",
	}

	for _, modelName := range models {
		model, ok := resource.Models[modelName]
		if !ok {
			return nil, fmt.Errorf("couldn't find model `%s`", modelName)
		}

		identityField, ok := model.Fields["Identity"]
		if !ok {
			return nil, fmt.Errorf("couldn't find the field `Identity` within model `%s`", modelName)
		}

		identityField.ObjectDefinition.Type = sdkModels.UserAssignedIdentityMapSDKObjectDefinitionType
		identityField.ObjectDefinition.ReferenceName = nil

		model.Fields["Identity"] = identityField
		resource.Models[modelName] = model
	}

	input.Resources["OpenShiftClusters"] = resource

	return &input, nil
}
