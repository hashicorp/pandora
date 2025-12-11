// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundAlertsManagement{}

// workaroundAlertsManagement works around the missing discriminator implementations for
// ActionRuleProperties. This workaround can be removed when v4.0 of the AzureRM Provider
// has been released.
type workaroundAlertsManagement struct {
}

func (workaroundAlertsManagement) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "AlertsManagement"
	apiVersionMatches := apiVersion.APIVersion == "2019-05-05-preview"
	return serviceMatches && apiVersionMatches
}

func (workaroundAlertsManagement) Name() string {
	return "AlertsManagement"
}

func (workaroundAlertsManagement) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["ActionRules"]
	if !ok {
		keys := make([]string, 0)
		for k := range input.Resources {
			keys = append(keys, k)
		}
		sort.Strings(keys)
		return nil, fmt.Errorf("expected a Resource named `ActionRules` but got [%+v]", keys)
	}
	_, ok = resource.Models["ActionRuleProperties"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `ActionRuleProperties`")
	}

	modelNames := []string{
		"ActionGroup",
		"Diagnostics",
		"Suppression",
	}

	for _, name := range modelNames {
		model, ok := resource.Models[name]
		if !ok {
			return nil, fmt.Errorf("expected a Model named `%s`", name)
		}
		model.DiscriminatedValue = pointer.To(name)
		model.ParentTypeName = pointer.To("ActionRuleProperties")
		model.FieldNameContainingDiscriminatedValue = pointer.To("Type")

		resource.Models[name] = model
	}
	input.Resources["ActionRules"] = resource

	return &input, nil
}
