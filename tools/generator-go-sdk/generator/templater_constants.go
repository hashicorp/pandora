package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templaterForResource = constantsTemplater{}

type constantsTemplater struct {
	constantTemplateFunc func(name string, details resourcemanager.ConstantDetails, generateNormalizationFunction, usedInAResourceId bool) (*string, error)
}

func (c constantsTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	keys := make([]string, 0)
	for name := range data.constants {
		keys = append(keys, name)
	}
	sort.Strings(keys)

	lines := make([]string, 0)
	for _, constantName := range keys {
		values := data.constants[constantName]

		// the rollout of the Constant Normalization functions can be done at the same time as the
		// rollout of the new base layer, to allow us to go gradually
		generateNormalizationFunction := data.useNewBaseLayer

		// TODO: remove this when https://github.com/hashicorp/pandora/issues/3229 has been resolved
		if data.servicePackageName == "keyvault" && data.packageName == "vaults" {
			// The Key Vault API requires that the EXACT casing sent in the Response is sent in the Request
			// to remove a Key Vault Access Policy.
			//
			// We need to raise a Swagger issue to track this - however for the moment we can disable
			// the Normalization of Constants when using the new base layer specifically for Key Vault.
			//
			// Whilst typically we would avoid special-casing this - the Key Vault API is starting to
			// behave differently to how the legacy base layer expects - such as the issue described in
			// https://github.com/hashicorp/terraform-provider-azurerm/pull/24449 - as such there's
			// benefit to using the new base layer, but having Constant Normalization disabled in this
			// one specific scenario.
			//
			// Which is to say, this shouldn't be done for other services - and is only a temporary fix
			// until the upstream API issue is resolved.
			generateNormalizationFunction = false
		}

		// used to reduce the TLOC being output
		usedInAResourceId := false
		for _, id := range data.resourceIds {
			for _, segment := range id.Segments {
				if segment.Type == resourcemanager.ConstantSegment && segment.ConstantReference != nil && *segment.ConstantReference == constantName {
					usedInAResourceId = true
					break
				}
			}
		}

		constantLines, err := c.constantTemplateFunc(constantName, values, generateNormalizationFunction, usedInAResourceId)
		if err != nil {
			return nil, fmt.Errorf("generating template for constant %q: %+v", constantName, err)
		}
		lines = append(lines, *constantLines)
	}

	template := fmt.Sprintf(`package %[1]s

import "strings"

%[3]s

%[2]s`, data.packageName, strings.Join(lines, "\n"), *copyrightLines)
	return &template, nil
}
