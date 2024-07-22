// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// This workaround marks the DevCenter field `DevCenterId` as Required rather than Optional
// since whilst this has a default value when unspecified on the Azure API side this is going
// to cause a diff on our side, which is likely to cause user confusion. As such we'll mark
// this field as Required instead so that it's explicit about what's being deployed.

var _ workaround = workaroundDevCenterIdToRequired{}

type workaroundDevCenterIdToRequired struct {
}

func (workaroundDevCenterIdToRequired) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DevCenter" && apiVersion.APIVersion == "2023-04-01"
}

func (workaroundDevCenterIdToRequired) Name() string {
	return "DevCenter"
}

func (workaroundDevCenterIdToRequired) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	// The Field `DevCenterId` within the SDKModel `Projects` within the APIResource `Projects` should be marked as Required

	projectsResource, ok := input.Resources["Projects"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Projects` but didn't get one")
	}
	projectModel, ok := projectsResource.Models["ProjectProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `ProjectProperties` but didn't get one")
	}
	projectDevCenterIdField, ok := projectModel.Fields["DevCenterId"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `DevCenterId` but didn't get one")
	}
	projectDevCenterIdField.Required = true
	projectDevCenterIdField.ReadOnly = false
	projectDevCenterIdField.Optional = false
	projectModel.Fields["DevCenterId"] = projectDevCenterIdField

	projectsResource.Models["ProjectProperties"] = projectModel
	input.Resources["Projects"] = projectsResource

	return &input, nil
}
