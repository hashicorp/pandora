package parser

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) Parse(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)

	tags := d.findTags()
	// first we assume everything has a tag
	for _, tag := range tags {
		if tagShouldBeIgnored(tag) {
			continue
		}

		resource, err := d.parseResourcesWithinSwaggerTag(&tag)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", tag, err)
		}

		if resource != nil {
			normalizedTag := normalizeTag(tag)
			normalizedTag = cleanup.NormalizeName(normalizedTag)
			resources[normalizedTag] = *resource
		}
	}

	// however some things don't, so we then need to iterate over any without them
	if _, shouldIgnore := tagsToIgnore[strings.ToLower(serviceName)]; !shouldIgnore {
		resource, err := d.parseResourcesWithinSwaggerTag(nil)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		if resource != nil {
			normalizedTag := normalizeTag(serviceName)
			normalizedTag = cleanup.NormalizeName(normalizedTag)
			resources[normalizedTag] = *resource
		}
	}

	return &models.AzureApiDefinition{
		ServiceName: serviceName,
		ApiVersion:  apiVersion,
		Resources:   resources,
	}, nil
}
