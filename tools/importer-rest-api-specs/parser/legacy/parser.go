package legacy

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"strings"
)

var useLegacyParser = true

func (d *SwaggerDefinition) Parse(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)

	tags := d.findTags()
	// first we assume everything has a tag
	for _, tag := range tags {
		if tagShouldBeIgnored(tag) {
			continue
		}

		resource, err := d.findResourcesForTag(&tag)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", tag, err)
		}

		if resource != nil {
			resources[tag] = *resource
		}
	}

	// however some things don't, so we then need to iterate over any without them
	if _, shouldIgnore := tagsToIgnore[strings.ToLower(serviceName)]; !shouldIgnore {
		resource, err := d.findResourcesForTag(nil)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		if resource != nil {
			resources[serviceName] = *resource
		}
	}

	// remove any models we needed to process enums before Normalising
	resources = removeModelsWithoutFields(resources)

	// we should go through and normalize this data
	resources = normalizeResources(resources)

	// handle customized types for models
	d.replaceCustomType(resources)

	// then remove anything that's been replaced
	d.removeUnusedModelsAndConstants(resources)

	return &models.AzureApiDefinition{
		ServiceName: serviceName,
		ApiVersion:  apiVersion,
		Resources:   resources,
	}, nil
}
