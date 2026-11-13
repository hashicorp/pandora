// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundSynapseRerunTumblingWindowTrigger{}

// workaroundSynapseRerunTumblingWindowTrigger works around Synapse data-plane API generation flipping the discriminated type value for `RerunTumblingWindowTrigger` between PascalCase and camelCase across regenerations.
// The canonical value is `RerunTumblingWindowTrigger` (PascalCase), which matches all other discriminated type values in the Synapse Triggers resource.
type workaroundSynapseRerunTumblingWindowTrigger struct{}

func (workaroundSynapseRerunTumblingWindowTrigger) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Synapse" && apiVersion.APIVersion == "2019-06-01-preview"
}

func (workaroundSynapseRerunTumblingWindowTrigger) Name() string {
	return "Synapse / RerunTumblingWindowTrigger discriminated type value casing"
}

func (workaroundSynapseRerunTumblingWindowTrigger) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Triggers"]
	if !ok {
		return nil, fmt.Errorf("couldn't find API Resource `Triggers`")
	}

	model, ok := resource.Models["RerunTumblingWindowTrigger"]
	if !ok {
		return nil, fmt.Errorf("couldn't find model `RerunTumblingWindowTrigger`")
	}

	model.DiscriminatedValue = new("RerunTumblingWindowTrigger")
	resource.Models["RerunTumblingWindowTrigger"] = model

	input.Resources["Triggers"] = resource

	return &input, nil
}
