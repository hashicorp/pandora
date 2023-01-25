package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (d *SwaggerDefinition) parse(serviceName, apiVersion string, resourceIds resourceids.ParseResult) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)

	tags := d.findTags()
	// first we assume everything has a tag
	for _, tag := range tags {
		if tagShouldBeIgnored(tag) {
			continue
		}

		resource, err := d.parseResourcesWithinSwaggerTag(&tag, resourceIds)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", tag, err)
		}

		if resource != nil {
			d.logger.Trace(fmt.Sprintf("The Tag %q has %d API Operations", tag, len(resource.Operations)))
			normalizedTag := normalizeTag(tag)
			normalizedTag = cleanup.NormalizeResourceName(normalizedTag)
			resources[normalizedTag] = *resource
		}
	}

	// however some things don't, so we then need to iterate over any without them
	if _, shouldIgnore := tagsToIgnore[strings.ToLower(serviceName)]; !shouldIgnore {
		resource, err := d.parseResourcesWithinSwaggerTag(nil, resourceIds)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		// Since we're dealing with missing tag data in the swagger, we'll assume the proper tag name here is the file name
		// This is less than ideal, but _should_ be fine.
		inferredTag := cleanup.PluraliseName(d.Name)

		if resource != nil {
			normalizedTag := normalizeTag(inferredTag)
			normalizedTag = cleanup.NormalizeResourceName(normalizedTag)

			if mergeResources, ok := resources[normalizedTag]; ok {
				resources[normalizedTag] = models.MergeResourcesForTag(mergeResources, *resource)

			} else {
				resources[normalizedTag] = *resource
			}
		}
	}

	return &models.AzureApiDefinition{
		ServiceName: cleanup.NormalizeServiceName(serviceName),
		ApiVersion:  apiVersion,
		Resources:   resources,
	}, nil
}

func (d *SwaggerDefinition) ParseResourceIds(resourceProvider *string) (*resourceids.ParseResult, error) {
	parser := resourceids.NewParser(d.logger.Named("ResourceID Parser"), d.swaggerSpecExpanded)

	resourceIds, err := parser.Parse()
	if err != nil {
		return nil, fmt.Errorf("finding Resource IDs: %+v", err)
	}

	if resourceProvider != nil {
		d.logger.Trace(fmt.Sprintf("Filtering Resource IDs to the Resource Provider %q..", *resourceProvider))
		resourceIds, err = d.filterResourceIdsToResourceProvider(*resourceIds, *resourceProvider)
		if err != nil {
			return nil, fmt.Errorf("filtering Resource IDs to Resource Provider %q: %+v", *resourceProvider, err)
		}
	} else {
		d.logger.Trace("Skipping the filtering of Resource IDs to a given Resource Provider since none was specified")
	}

	return resourceIds, nil
}

func (d *SwaggerDefinition) filterResourceIdsToResourceProvider(input resourceids.ParseResult, resourceProvider string) (*resourceids.ParseResult, error) {
	output := resourceids.ParseResult{
		OriginalUrisToResourceIDs: input.OriginalUrisToResourceIDs,
		NamesToResourceIDs:        map[string]models.ParsedResourceId{},
		Constants:                 input.Constants,
	}

	for name := range input.NamesToResourceIDs {
		value := input.NamesToResourceIDs[name]
		add := true

		d.logger.Trace(fmt.Sprintf("Processing ID %q (%q)", name, value.ID()))
		for i, segment := range value.Segments {
			if segment.Type != resourcemanager.ResourceProviderSegment {
				continue
			}

			if segment.FixedValue == nil {
				return nil, fmt.Errorf("the Resource ID Named %q Segment %d was a ResourceProviderSegment with no FixedValue", name, i)
			}
			if !strings.EqualFold(*segment.FixedValue, resourceProvider) {
				add = false
			}
		}
		if add {
			output.NamesToResourceIDs[name] = value
		}
	}

	return &output, nil
}
