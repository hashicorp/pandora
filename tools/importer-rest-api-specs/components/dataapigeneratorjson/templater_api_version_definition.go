package dataapigeneratorjson

import (
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	dataApiModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func buildApiVersionDefinition(apiVersion string, isPreview bool, resources map[string]models.AzureApiResource) (*dataApiModels.ApiVersionDefinition, error) {
	versionDefinition := dataApiModels.ApiVersionDefinition{
		ApiVersion: apiVersion,
		IsPreview:  isPreview,
		Generate:   true,
	}

	names := make([]string, 0)
	for name, value := range resources {
		// skip ones which are filtered out
		if len(value.Operations) == 0 {
			continue
		}
		names = append(names, name)
	}
	sort.Strings(names)

	versionDefinition.Resources = names

	return &versionDefinition, nil
}
