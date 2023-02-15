package dataworkarounds

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundInvalidGoPackageNames{}

type workaroundInvalidGoPackageNames struct{}

func (workaroundInvalidGoPackageNames) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	for key := range apiDefinition.Resources {
		if strings.EqualFold(key, "documentation") {
			return true
		}
	}
	return false
}

func (workaroundInvalidGoPackageNames) Name() string {
	return "Workaround Invalid Go Package Names"
}

func (workaroundInvalidGoPackageNames) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)

	for resourceName := range apiDefinition.Resources {
		originalName := resourceName
		resource := apiDefinition.Resources[originalName]

		// `documentation` is not a valid Go package name, so let's rename it to `DocumentationResource`
		// double-checking that we're not overwriting anything
		if strings.EqualFold(resourceName, "documentation") {
			resourceName = "DocumentationResource"
			if _, ok := apiDefinition.Resources[resourceName]; ok {
				return nil, fmt.Errorf("the Resource %q is not valid as a Go Package Name - however the replacement name %q is already in use", originalName, resourceName)
			}
		}

		resources[resourceName] = resource
	}
	apiDefinition.Resources = resources
	return &apiDefinition, nil
}
