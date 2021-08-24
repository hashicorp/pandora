package parser

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/legacy"
	"strings"
)

var useLegacyParser = false

func (d *SwaggerDefinition) Parse(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	if useLegacyParser {
		innerDefinition := legacy.SwaggerDefinition{
			Name:                      d.Name,
			DebugLog:                  d.debugLog,
			SwaggerSpecExpanded:       d.swaggerSpecExpanded,
			SwaggerSpecWithReferences: d.swaggerSpecWithReferences,
			SwaggerSpecRaw:            d.swaggerSpecRaw,
			SwaggerSpecExtendedRaw:    d.swaggerSpecExtendedRaw,
		}
		return innerDefinition.Parse(serviceName, apiVersion)
	}

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
			resources[tag] = *resource
		}
	}

	// however some things don't, so we then need to iterate over any without them
	if _, shouldIgnore := tagsToIgnore[strings.ToLower(serviceName)]; !shouldIgnore {
		resource, err := d.parseResourcesWithinSwaggerTag(nil)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		if resource != nil {
			resources[serviceName] = *resource
		}
	}

	return &models.AzureApiDefinition{}, nil
}