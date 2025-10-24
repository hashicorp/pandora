package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type workaroundNetwork38407 struct{}

var _ workaround = workaroundNetwork38407{}

func (w workaroundNetwork38407) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Network" && apiVersion.APIVersion == "2025-01-01"
}

func (w workaroundNetwork38407) Name() string {
	return "Network / 38407"
}

func (w workaroundNetwork38407) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["WebApplicationFirewallPolicies"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `WebApplicationFirewallPolicies` but didn't get one")
	}

	model, ok := resource.Models["ManagedRuleSet"]
	if !ok {
		return nil, fmt.Errorf("couldn't find Model `ManagedRuleSet`")
	}

	if _, ok := model.Fields["ComputedDisabledRules"]; !ok {
		return nil, fmt.Errorf("couldn't find field `ComputedDisabledRules in Model `ManagedRuleSet`")
	}

	// This field should return an array of strings, but instead it returns an array of integers.
	// While we could "fix" the type, that risks Azure fixing the return value of this property
	// and once again breaking the resource.
	// Since this is read-only, and not used by existing resources, removing it is the safer solution.
	delete(model.Fields, "ComputedDisabledRules")
	resource.Models["ManagedRuleSet"] = model
	input.Resources["WebApplicationFirewallPolicies"] = resource

	return &input, nil
}
