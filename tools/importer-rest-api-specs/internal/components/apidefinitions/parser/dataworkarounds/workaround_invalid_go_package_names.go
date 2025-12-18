// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundInvalidGoPackageNames{}

type workaroundInvalidGoPackageNames struct{}

func (workaroundInvalidGoPackageNames) IsApplicable(_ string, apiVersion sdkModels.APIVersion) bool {
	for key := range apiVersion.Resources {
		if strings.EqualFold(key, "documentation") || strings.EqualFold(key, "package") {
			return true
		}
	}
	return false
}

func (workaroundInvalidGoPackageNames) Name() string {
	return "Workaround Invalid Go Package Names"
}

func (workaroundInvalidGoPackageNames) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resources := make(map[string]sdkModels.APIResource, 0)

	for resourceName := range input.Resources {
		originalName := resourceName
		resource := input.Resources[originalName]

		// `documentation` is not a valid Go package name, so let's rename it to `DocumentationResource`
		// double-checking that we're not overwriting anything
		if strings.EqualFold(resourceName, "documentation") {
			resourceName = "DocumentationResource"
			if _, ok := input.Resources[resourceName]; ok {
				return nil, fmt.Errorf("the Resource %q is not valid as a Go Package Name - however the replacement name %q is already in use", originalName, resourceName)
			}
		}

		// `package` is not a valid Go package name (reserved keyword), so let's rename it to `PackageResource`
        // double-checking that we're not overwriting anything
        if strings.EqualFold(resourceName, "package") {
            resourceName = "PackageResource"
            if _, ok := input.Resources[resourceName]; ok {
                return nil, fmt.Errorf("the Resource %q is not valid as a Go Package Name - however the replacement name %q is already in use", originalName, resourceName)
            }
        }

		resources[resourceName] = resource
	}
	input.Resources = resources
	return &input, nil
}
