package dataworkarounds

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundNetwork29303{}

// The swagger for PrivateLinkService in Network associates the CreateOrUpdate method with the tag
// `PrivateLinkService` instead of `PrivateLinkServices` like the rest of the operations do. This consolidates
// the two resources that Pandora identifies into one.
// Can be removed when https://github.com/Azure/azure-rest-api-specs/pull/29303 has been merged.
type workaroundNetwork29303 struct {
}

func (workaroundNetwork29303) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	serviceMatches := apiDefinition.ServiceName == "Network"
	_, hasCorrectlyNamedAPIResource := apiDefinition.Resources["PrivateLinkService"]
	_, hasMisnamedAPIResource := apiDefinition.Resources["PrivateLinkServices"]
	return serviceMatches && hasCorrectlyNamedAPIResource && hasMisnamedAPIResource
}

func (workaroundNetwork29303) Name() string {
	return "Network / 29303"
}

func (workaroundNetwork29303) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	correctlyNamedAPIResource, ok := apiDefinition.Resources["PrivateLinkServices"]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource named `PrivateLinkServices` but didn't find one")
	}
	misnamedAPIResource, ok := apiDefinition.Resources["PrivateLinkService"]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource named `PrivateLinkService` but didn't find one")
	}

	apiDefinition.Resources["PrivateLinkServices"] = importerModels.MergeResourcesForTag(correctlyNamedAPIResource, misnamedAPIResource)
	delete(apiDefinition.Resources, "PrivateLinkService")

	return &apiDefinition, nil
}
