// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundWebKindApiConnection45544{}

// workaroundWebKindApiConnection45544 adds the missing `kind` field to ApiConnectionDefinition.
// The stable 2016-06-01 spec was written from scratch in March 2018 (PR #2761) as a
// retroactive swagger for an already-running API. The author wrote a new ResourceDefinition
// base class but accidentally omitted the `kind` property that existed in the 2015-08-01-preview
// spec. The Azure backend has always accepted and persisted V1 and V2 — V2 is required for
// Logic App Standard workflows and exposes the connectionRuntimeUrl property.
// Confirmed by live API testing (PUT + GET round-trip) and acknowledged by the Microsoft
// ARM Deployments team (Azure/bicep#3512, July 2026).
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/45544
type workaroundWebKindApiConnection45544 struct{}

func (workaroundWebKindApiConnection45544) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Web" && apiVersion.APIVersion == "2016-06-01"
}

func (workaroundWebKindApiConnection45544) Name() string {
	return "Web / kind missing from ApiConnectionDefinition"
}

func (workaroundWebKindApiConnection45544) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Connections"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Connections` but didn't get one")
	}

	model, ok := resource.Models["ApiConnectionDefinition"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `ApiConnectionDefinition`")
	}

	// Guard: if Kind is already present (spec fixed upstream) do nothing
	if _, exists := model.Fields["Kind"]; exists {
		return &input, nil
	}

	model.Fields["Kind"] = sdkModels.SDKField{
		Description: "Kind of resource",
		JsonName:    "kind",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			Type: sdkModels.StringSDKObjectDefinitionType,
		},
		Optional: true,
	}

	resource.Models["ApiConnectionDefinition"] = model
	input.Resources["Connections"] = resource

	return &input, nil
}
