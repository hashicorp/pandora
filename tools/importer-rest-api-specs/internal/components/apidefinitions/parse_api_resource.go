// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package apidefinitions

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func parseAPIResourcesFromFile(filePath, serviceName string, resourceProvider *string, parsedAPIResources map[string]sdkModels.APIResource, resourceIds resourceids.ParseResult) (map[string]sdkModels.APIResource, error) {
	parser, err := parser.NewAPIDefinitionsParser(filePath)
	if err != nil {
		return nil, fmt.Errorf("parsing the API Definitions within %q: %+v", filePath, err)
	}

	// 1. Find the Swagger Tags
	tags := parser.ParseSwaggerTags()

	// 2. Then iterate over each of the Swagger Operations with each Tag
	for _, tag := range tags {
		if ignore.SwaggerTag(tag) {
			continue
		}

		normalizedTag := cleanup.NormalizeTag(tag)
		normalizedTag = cleanup.NormalizeResourceName(normalizedTag)

		// pass in any existing/known data so that we can reuse the models/references
		existing := newAPIResource(normalizedTag)
		if v, ok := parsedAPIResources[normalizedTag]; ok {
			existing = v
		}

		resource, err := parser.ParseAPIResourceWithinSwaggerTag(&tag, resourceProvider, resourceIds, existing)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", tag, err)
		}

		if resource != nil {
			logging.Tracef("The Tag %q has %d API Operations", tag, len(resource.Operations))
			discoveredResources := map[string]sdkModels.APIResource{
				normalizedTag: *resource,
			}
			if err = combine.APIResourcesWith(parsedAPIResources, discoveredResources); err != nil {
				return nil, fmt.Errorf("combining the APIResources for the identified Swagger Tag %q: %+v", tag, err)
			}
		}
	}

	// 3. Then parse over any Swagger Operations which DON'T have a Tag
	if !ignore.SwaggerTag(serviceName) {
		inferredTag := cleanup.InferTagFromFilename(filePath)

		// pass in any existing/known data so that we can reuse the models/references
		existing := newAPIResource(inferredTag)
		if v, ok := parsedAPIResources[inferredTag]; ok {
			existing = v
		}

		resource, err := parser.ParseAPIResourceWithinSwaggerTag(nil, resourceProvider, resourceIds, existing)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		if resource != nil {
			discoveredResources := map[string]sdkModels.APIResource{
				inferredTag: *resource,
			}
			if err = combine.APIResourcesWith(parsedAPIResources, discoveredResources); err != nil {
				return nil, fmt.Errorf("combining the APIResources for the inferred Swagger Tag %q: %+v", inferredTag, err)
			}
		}
	}

	// 4. Discriminator implementations that are defined in separate files with no link to a swagger tag
	//    are not parsed. So far there are two known instances of this (Data Factory, Chaos Studio) where
	//    the files are defined in a nested directory e.g. d.Name = /Types/Capabilities
	if len(parsedAPIResources) == 0 {
		// if we're here then there is no tag in this file, so we'll use the file name
		inferredTag := cleanup.InferTagFromFilename(filePath)

		result, err := parser.FindOrphanedDiscriminatedModels(serviceName)
		if err != nil {
			return nil, fmt.Errorf("finding orphaned discriminated models for the inferred Swagger Tag %q in %q: %+v", inferredTag, filePath, err)
		}

		// this is to avoid the creation of empty packages/directories in the api definitions
		if len(result.Models) > 0 || len(result.Constants) > 0 {
			resource := sdkModels.APIResource{
				Constants: result.Constants,
				Models:    result.Models,
			}

			discoveredResources := map[string]sdkModels.APIResource{
				inferredTag: resource,
			}
			if err = combine.APIResourcesWith(parsedAPIResources, discoveredResources); err != nil {
				return nil, fmt.Errorf("combining the APIResources for the inferred Swagger Tag %q: %+v", inferredTag, err)
			}
		}
	}

	return parsedAPIResources, nil
}

func newAPIResource(name string) sdkModels.APIResource {
	return sdkModels.APIResource{
		Constants:   make(map[string]sdkModels.SDKConstant),
		Models:      make(map[string]sdkModels.SDKModel),
		Name:        name,
		Operations:  make(map[string]sdkModels.SDKOperation),
		ResourceIDs: make(map[string]sdkModels.ResourceID),
	}
}
