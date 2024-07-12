package apidefinitions

import (
	"fmt"
	"path/filepath"
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/ignore"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func parseAPIResourcesFromFile(filePath, serviceName string, resourceProvider *string, existingAPIResources map[string]sdkModels.APIResource, supplementaryData parserModels.SupplementaryData, resourceIds resourceids.ParseResult) (*map[string]sdkModels.APIResource, error) {
	parser, err := parser.NewAPIDefinitionsParser(filePath, supplementaryData)
	if err != nil {
		return nil, fmt.Errorf("parsing the API Definitions within %q: %+v", filePath, err)
	}

	// 1. Find the Swagger Tags
	tags := parser.ParseSwaggerTags()

	// 2. Then iterate over each of the Swagger Operations with each Tag
	parsedAPIResources := existingAPIResources
	for _, tag := range tags {
		if ignore.SwaggerTag(tag) {
			continue
		}

		normalizedTag := cleanup.NormalizeTag(tag)
		normalizedTag = cleanup.NormalizeResourceName(normalizedTag)

		// pass in any existing/known data so that we can reuse the models/references
		existing := sdkModels.APIResource{
			Constants:   make(map[string]sdkModels.SDKConstant),
			Models:      make(map[string]sdkModels.SDKModel),
			Name:        normalizedTag,
			Operations:  make(map[string]sdkModels.SDKOperation),
			ResourceIDs: make(map[string]sdkModels.ResourceID),
		}
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
			combined, err := combine.ResourcesWith(parsedAPIResources, discoveredResources)
			if err != nil {
				return nil, fmt.Errorf("combining the APIResources for the identified Swagger Tag %q: %+v", tag, err)
			}
			parsedAPIResources = *combined
		}
	}

	// 3. Then parse over any Swagger Operations which DON'T have a Tag
	if !ignore.SwaggerTag(serviceName) {
		// Since we're dealing with missing tag data in the swagger, we'll assume the proper tag name here is the file name
		// This is less than ideal, but _should_ be fine.
		directory := filepath.Dir(filePath)
		fileName := strings.TrimPrefix(filePath, directory)
		fileName = strings.TrimPrefix(fileName, fmt.Sprintf("%c", filepath.Separator))
		fileName = strings.TrimSuffix(fileName, ".json")
		inferredTag := cleanup.PluraliseName(fileName)
		normalizedTag := cleanup.NormalizeTag(inferredTag)
		normalizedTag = cleanup.NormalizeResourceName(normalizedTag)

		// pass in any existing/known data so that we can reuse the models/references
		existing := sdkModels.APIResource{
			Constants:   make(map[string]sdkModels.SDKConstant),
			Models:      make(map[string]sdkModels.SDKModel),
			Name:        normalizedTag,
			Operations:  make(map[string]sdkModels.SDKOperation),
			ResourceIDs: make(map[string]sdkModels.ResourceID),
		}
		if v, ok := parsedAPIResources[normalizedTag]; ok {
			existing = v
		}

		resource, err := parser.ParseAPIResourceWithinSwaggerTag(nil, resourceProvider, resourceIds, existing)
		if err != nil {
			return nil, fmt.Errorf("finding resources for tag %q: %+v", serviceName, err)
		}

		if resource != nil {
			discoveredResources := map[string]sdkModels.APIResource{
				normalizedTag: *resource,
			}
			combined, err := combine.ResourcesWith(parsedAPIResources, discoveredResources)
			if err != nil {
				return nil, fmt.Errorf("combining the APIResources for the inferred Swagger Tag %q: %+v", normalizedTag, err)
			}
			parsedAPIResources = *combined
		}
	}

	// 3. Now that we have a canonical list of resources - can we simplify the Operation names at all?
	simplifiedAPIDefinitions := make(map[string]sdkModels.APIResource)
	for resourceName, resource := range parsedAPIResources {
		logging.Tracef("Simplifying operation names for resource %q", resourceName)
		updated := cleanup.SimplifyOperationNamesForAPIResource(resourceName, resource)
		simplifiedAPIDefinitions[resourceName] = updated
	}

	return &simplifiedAPIDefinitions, nil
}
