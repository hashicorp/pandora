package transforms

import (
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapAPIVersionToRepository(apiVersion string, isPreview bool, resources map[string]models.AzureApiResource) (*dataapimodels.ApiVersionDefinition, error) {
	versionDefinition := dataapimodels.ApiVersionDefinition{
		ApiVersion: apiVersion,
		IsPreview:  isPreview,
		Generate:   true,
		Source:     dataapimodels.AzureRestApiSpecsRepositoryApiDefinitionsSource,
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
