// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundAlertsManagement{}

// workaroundAlertsManagement works around the missing discriminator implementations for
// ActionRuleProperties. This workaround can be removed when v4.0 of the AzureRM Provider
// has been released.
type workaroundAlertsManagement struct {
}

func (workaroundAlertsManagement) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "AlertsManagement"
	apiVersionMatches := apiDefinition.ApiVersion == "2019-05-05-preview"
	return serviceMatches && apiVersionMatches
}

func (workaroundAlertsManagement) Name() string {
	return "AlertsManagement"
}

func (workaroundAlertsManagement) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["ActionRules"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `ActionRules`")
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
	apiDefinition.Resources["ActionRules"] = resource

	return &apiDefinition, nil
}
