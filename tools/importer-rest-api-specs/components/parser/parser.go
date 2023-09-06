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

	// now that we have a canonical list of resources, can we simplify the Operation names at all?
	resourcesOut := make(map[string]models.AzureApiResource)
	for resourceName, resource := range resources {
		d.logger.Trace(fmt.Sprintf("Simplifying operation names for resource %q", resourceName))
		updated := d.simplifyOperationNamesForResource(resource, resourceName)
		resourcesOut[resourceName] = updated
	}

	return &models.AzureApiDefinition{
		ServiceName: cleanup.NormalizeServiceName(serviceName),
		ApiVersion:  apiVersion,
		Resources:   resourcesOut,
	}, nil
}

func (d *SwaggerDefinition) simplifyOperationNamesForResource(resource models.AzureApiResource, resourceName string) models.AzureApiResource {
	allOperationsStartWithPrefix := true
	resourceNameLower := strings.ToLower(resourceName)
	for operationName := range resource.Operations {
		operationNameLowered := strings.ToLower(operationName)
		if !strings.HasPrefix(operationNameLowered, resourceNameLower) || strings.EqualFold(operationNameLowered, resourceNameLower) {
			allOperationsStartWithPrefix = false
			break
		}
	}

	if !allOperationsStartWithPrefix {
		d.logger.Trace(fmt.Sprintf("Skipping simplifying operation names for resource %q", resourceName))
		return resource
	}

	output := make(map[string]models.OperationDetails)
	for key, value := range resource.Operations {
		updatedKey := key[len(resourceNameLower):]
		// Trim off any spurious `s` at the start. This happens when the Swagger Tag and the Operation ID
		// use different pluralizations (e.g. one is Singular and the other is Plural)
		//
		// Whilst it's possible this could happen for other suffixes (e.g. `ies`, or `y`)
		// the Data only shows `s` at this point in time, so this is sufficient for now:
		// https://github.com/hashicorp/pandora/pull/3016#pullrequestreview-1612987765
		//
		// Any other examples will generate successfully but be unusable in the Go SDK since these
		// will be treated as unexported methods - and can be addressed then.
		if strings.HasPrefix(updatedKey, "s") {
			updatedKey = updatedKey[1:]
		}

		d.logger.Trace(fmt.Sprintf("Simplifying Operation %q to %q", key, updatedKey))
		output[updatedKey] = value
	}

	resource.Operations = output
	return resource
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
