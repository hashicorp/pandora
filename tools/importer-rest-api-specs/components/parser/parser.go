// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) parse(serviceName, apiVersion string, resourceProvider *string, resourceIds resourceids.ParseResult) (*importerModels.AzureApiDefinition, error) {
	resources := make(map[string]sdkModels.APIResource, 0)

	tags := d.findTags()
	// first we assume everything has a tag
	for _, tag := range tags {
		if ignore.SwaggerTag(tag) {
			continue
		}

		resource, err := d.parseResourcesWithinSwaggerTag(&tag, resourceProvider, resourceIds)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", tag, err)
		}

		if resource != nil {
			logging.Tracef("The Tag %q has %d API Operations", tag, len(resource.Operations))
			normalizedTag := cleanup.NormalizeTag(tag)
			normalizedTag = cleanup.NormalizeResourceName(normalizedTag)
			resources[normalizedTag] = *resource
		}
	}

	// however some things don't, so we then need to iterate over any without them
	if !ignore.SwaggerTag(serviceName) {
		resource, err := d.parseResourcesWithinSwaggerTag(nil, resourceProvider, resourceIds)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		// Since we're dealing with missing tag data in the swagger, we'll assume the proper tag name here is the file name
		// This is less than ideal, but _should_ be fine.
		inferredTag := cleanup.PluraliseName(d.Name)

		if resource != nil {
			normalizedTag := cleanup.NormalizeTag(inferredTag)
			normalizedTag = cleanup.NormalizeResourceName(normalizedTag)

			if mergeResources, ok := resources[normalizedTag]; ok {
				resources[normalizedTag] = importerModels.MergeResourcesForTag(mergeResources, *resource)
			} else {
				resources[normalizedTag] = *resource
			}
		}
	}

	// now that we have a canonical list of resources, can we simplify the Operation names at all?
	resourcesOut := make(map[string]sdkModels.APIResource)
	for resourceName, resource := range resources {
		logging.Tracef("Simplifying operation names for resource %q", resourceName)
		updated := d.simplifyOperationNamesForResource(resource, resourceName)
		resourcesOut[resourceName] = updated
	}

	// discriminator implementations that are defined in separate files with no link to a swagger tag
	// are not parsed. So far there are two known instances of this (Data Factory, Chaos Studio) where the
	// files are defined in a nested directory e.g. d.Name = /Types/Capabilities
	swaggerFileName := strings.Split(d.Name, "/")
	if len(resources) == 0 && len(swaggerFileName) > 2 {
		// if we're here then there is no tag in this file, so we'll use the file name
		inferredTag := cleanup.PluraliseName(swaggerFileName[len(swaggerFileName)-1])
		normalizedTag := cleanup.NormalizeResourceName(inferredTag)

		result, err := d.findOrphanedDiscriminatedModels(serviceName)
		if err != nil {
			return nil, fmt.Errorf("finding orphaned discriminated models in %q: %+v", d.Name, err)
		}

		// this is to avoid the creation of empty packages/directories in the api definitions
		if len(result.Models) > 0 || len(result.Constants) > 0 {
			resource := sdkModels.APIResource{
				Constants: result.Constants,
				Models:    result.Models,
			}
			resource = cleanup.NormalizeAPIResource(resource)

			if mergeResources, ok := resources[normalizedTag]; ok {
				resources[normalizedTag] = importerModels.MergeResourcesForTag(mergeResources, resource)
			} else {
				resourcesOut[normalizedTag] = resource
			}
		}
	}

	return &importerModels.AzureApiDefinition{
		ServiceName: cleanup.NormalizeServiceName(serviceName),
		ApiVersion:  apiVersion,
		Resources:   resourcesOut,
	}, nil
}

func (d *SwaggerDefinition) simplifyOperationNamesForResource(resource sdkModels.APIResource, resourceName string) sdkModels.APIResource {
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
		logging.Tracef("Skipping simplifying operation names for resource %q", resourceName)
		return resource
	}

	output := make(map[string]sdkModels.SDKOperation)
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

		logging.Tracef("Simplifying Operation %q to %q", key, updatedKey)
		output[updatedKey] = value
	}

	resource.Operations = output
	return resource
}
