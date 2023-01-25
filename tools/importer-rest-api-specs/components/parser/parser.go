package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (d *SwaggerDefinition) parse(serviceName, apiVersion string, resourceProvider *string, resourceIds resourceids.ParseResult) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)

	tags := d.findTags()
	// first we assume everything has a tag
	for _, tag := range tags {
		if tagShouldBeIgnored(tag) {
			continue
		}

		resource, err := d.parseResourcesWithinSwaggerTag(&tag, resourceProvider, resourceIds)
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
		resource, err := d.parseResourcesWithinSwaggerTag(nil, resourceProvider, resourceIds)
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

		d.logger.Trace(fmt.Sprintf("Processing ID %q (%q)", name, value.ID()))
		usesADifferentResourceProvider, err := resourceIdUsesAResourceProviderOtherThan(pointer.To(value), pointer.To(resourceProvider))
		if err != nil {
			return nil, err
		}

		if !*usesADifferentResourceProvider {
			output.NamesToResourceIDs[name] = value
		}
	}

	return &output, nil
}

func resourceIdUsesAResourceProviderOtherThan(input *models.ParsedResourceId, resourceProvider *string) (*bool, error) {
	if input == nil || resourceProvider == nil {
		return pointer.To(false), nil
	}

	for i, segment := range input.Segments {
		if segment.Type != resourcemanager.ResourceProviderSegment {
			continue
		}

		if segment.FixedValue == nil {
			return nil, fmt.Errorf("the Resource ID %q Segment %d was a ResourceProviderSegment with no FixedValue", input.ID(), i)
		}
		if !strings.EqualFold(*segment.FixedValue, *resourceProvider) {
			return pointer.To(true), nil
		}
	}
	return pointer.To(false), nil
}
