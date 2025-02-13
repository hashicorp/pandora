// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundDataFactory27816{}

// workaroundDataFactory27816 converts the `headers` property from a string to an interface - this can be removed once
// https://github.com/Azure/azure-rest-api-specs/issues/27816 has been fixed
type workaroundDataFactory27816 struct {
}

func (workaroundDataFactory27816) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DataFactory" && apiVersion.APIVersion == "2018-06-01"
}

func (workaroundDataFactory27816) Name() string {
	return "DataFactory / 27816"
}

func (workaroundDataFactory27816) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Pipelines"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Pipelines` but didn't get one")
	}

	model, ok := resource.Models["WebActivityTypeProperties"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `WebActivityTypeProperties`")
	}

	field, ok := model.Fields["Headers"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Field `Headers`")
	}

	if field.ObjectDefinition.NestedItem != nil {
		field.ObjectDefinition.NestedItem.Type = sdkModels.RawObjectSDKObjectDefinitionType
	}

	model.Fields["Headers"] = field
	resource.Models["WebActivityTypeProperties"] = model
	input.Resources["Pipelines"] = resource

	return &input, nil
}
