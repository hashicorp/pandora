// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundTempReadOnlyFieldsDevCenter{}

type workaroundTempReadOnlyFieldsDevCenter struct {
}

func (w workaroundTempReadOnlyFieldsDevCenter) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "DevCenter" && apiVersion.APIVersion == "2023-04-01"
}

func (w workaroundTempReadOnlyFieldsDevCenter) Name() string {
	return "Temp - Mark readonly fields as readonly - DevCenter"
}

func (w workaroundTempReadOnlyFieldsDevCenter) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	definition, err := markFieldAsComputed(input, "Projects", "ProjectProperties", "DevCenterUri")
	if err != nil {
		return nil, err
	}

	definition, err = markFieldAsComputed(*definition, "DevCenters", "DevCenterProperties", "DevCenterUri")
	if err != nil {
		return nil, err
	}

	return definition, nil
}
