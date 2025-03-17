// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundSql33215{}

type workaroundSql33215 struct{}

func (workaroundSql33215) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Sql" && apiVersion.APIVersion == "2023-08-01-preview"
}

func (workaroundSql33215) Name() string {
	return "Sql / 33215"
}

func (workaroundSql33215) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["JobAgents"]
	if !ok {
		return nil, errors.New("expected a resource named `JobAgents` but didn't get one")
	}

	models := []string{
		"JobAgent",
		"JobAgentUpdate",
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
	input.Resources["JobAgents"] = resource

	return &input, nil
}
