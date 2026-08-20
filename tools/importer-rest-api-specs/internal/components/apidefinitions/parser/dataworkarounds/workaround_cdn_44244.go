// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"errors"
	"slices"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = WorkaroundCDN44244{}

type WorkaroundCDN44244 struct{}

func (WorkaroundCDN44244) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "CDN" && apiVersion.APIVersion == "2025-12-01"
}

func (w WorkaroundCDN44244) Name() string {
	return "CDN / 44244"
}

func (w WorkaroundCDN44244) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["RuleSets"]
	if !ok {
		return nil, errors.New("expected a `RuleSets` resource but didn't get one")
	}

	operation, ok := resource.Operations["Create"]
	if !ok {
		return nil, errors.New("expected an Operation named `Create` but didn't get one")
	}

	if slices.Contains(operation.ExpectedStatusCodes, 202) {
		return nil, errors.New("expected the `Create` operation to not contain an `ExpectedStatusCode` of `202`, this workaround can be removed")
	}

	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, 202)
	resource.Operations["Create"] = operation
	input.Resources["RuleSets"] = resource

	return &input, nil
}
