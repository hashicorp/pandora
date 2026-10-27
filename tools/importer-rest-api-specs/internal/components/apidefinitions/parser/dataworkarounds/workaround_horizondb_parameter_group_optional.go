// Copyright IBM Corp. 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundHorizonDBParameterGroupOptional{}

type workaroundHorizonDBParameterGroupOptional struct{}

func (workaroundHorizonDBParameterGroupOptional) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "HorizonDB" && apiVersion.APIVersion == "2026-10-01-preview"
}

func (workaroundHorizonDBParameterGroupOptional) Name() string {
	return "HorizonDB / Make PoolProperties.ParameterGroup Optional"
}

func (workaroundHorizonDBParameterGroupOptional) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Pools"]
	if !ok {
		return nil, errors.New("expected a resource named `Pools` but didn't get one")
	}

	model, ok := resource.Models["PoolProperties"]
	if !ok {
		return nil, errors.New("couldn't find model `PoolProperties`")
	}

	field, ok := model.Fields["ParameterGroup"]
	if !ok {
		return nil, errors.New("couldn't find the field `ParameterGroup` within model `PoolProperties`")
	}

	field.Optional = true
	field.Required = false
	model.Fields["ParameterGroup"] = field
	resource.Models["PoolProperties"] = model
	input.Resources["Pools"] = resource

	return &input, nil
}
