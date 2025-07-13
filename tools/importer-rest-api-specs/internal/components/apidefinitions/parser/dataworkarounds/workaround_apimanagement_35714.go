// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// This workaround changes the url and protocol fields in the BackendContractProperties model from required to optional.
// If url or protocol are set (at all) then if type is set to "Pool" the API will return a validation error.
// The "pool" type requires those fields to be unset.

var _ workaround = workaroundAPIManagement35714{}

type workaroundAPIManagement35714 struct{}

func (workaroundAPIManagement35714) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	// Note, only 2024-05-01 is currently created by pandora,
	// but to prevent a potential mistake where other versions are added and the workaround not updated
	// we catch all upstream versions we _know_ have the bug
	applicableVersions := map[string]struct{}{
		"2023-09-01-preview": {}, // Pool type backend introduced
		"2024-05-01":         {},
		"2024-06-01-preview": {}, // Latest as of time of writing
	}
	_, apiVersionMatches := applicableVersions[apiVersion.APIVersion]
	return serviceName == "ApiManagement" && apiVersionMatches
}

func (workaroundAPIManagement35714) Name() string {
	return "ApiManagement / 35714"
}

func (workaroundAPIManagement35714) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	// The url and protocol fields in the BackendContractProperties model should be optional.

	resource, ok := input.Resources["Backend"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Backend`")
	}

	model, ok := resource.Models["BackendContractProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `BackendContractProperties` in Resource `Backend`")
	}

	urlField, ok := model.Fields["Url"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `Url` in Model `BackendContractProperties`")
	}
	urlField.Optional = true
	urlField.Required = false
	model.Fields["Url"] = urlField

	protocolField, ok := model.Fields["Protocol"]
	if !ok {
		return nil, fmt.Errorf("expected a Field named `Protocol` in Model `BackendContractProperties`")
	}
	protocolField.Optional = true
	protocolField.Required = false
	model.Fields["Protocol"] = protocolField

	resource.Models["BackendContractProperties"] = model
	input.Resources["Backend"] = resource

	return &input, nil
}
