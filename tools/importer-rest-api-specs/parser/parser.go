package parser

import (
	"fmt"
	"log"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var tagsToIgnore = map[string]struct{}{
	"tags":       {},
	"operations": {},
	"usage":      {},
}

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

	// finally we should go through and normalize this data
	resources = normalizeResources(resources)

	return &models.AzureApiDefinition{
		ServiceName: serviceName,
		ApiVersion:  apiVersion,
		Resources:   resources,
	}, nil
}

func tagShouldBeIgnored(tag string) bool {
	lowered := strings.ToLower(tag)
	for key := range tagsToIgnore {
		// exact matches e.g. Usage
		if strings.EqualFold(tag, key) {
			return true
		}

		// suffixes e.g. `ComputeOperations`
		if strings.HasSuffix(lowered, strings.ToLower(key)) {
			return true
		}
	}

	return false
}

func (d *SwaggerDefinition) findResourcesForTag(tag *string) (*models.AzureApiResource, error) {
	if d.debugLog {
		if tag != nil {
			log.Printf("[DEBUG] Processing Operations with Tag %q..", *tag)
		} else {
			log.Printf("[DEBUG] Processing Operations with No Tag..")
		}
	}

	result := result{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	resourceIds, err := d.findResourceIdsForTag(tag)
	if err != nil {
		return nil, fmt.Errorf("finding resource ids: %+v", err)
	}

	operations, nestedResult, err := d.findOperationsForTag(tag, resourceIds.UriToDetails)
	if err != nil {
		return nil, fmt.Errorf("finding operations: %+v", err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}

	nestedResult, err = d.parseOperations(*operations)
	if err != nil {
		return nil, fmt.Errorf("parsing operations: %+v", err)
	}
	if nestedResult != nil {
		result.append(*nestedResult)
	}

	// if there's nothing here, there's no point generating a package
	if len(*operations) == 0 && len(result.models) == 0 && len(result.constants) == 0 {
		return nil, nil
	}

	resource := models.AzureApiResource{
		Constants:   result.constants,
		Models:      result.models,
		Operations:  *operations,
		ResourceIds: resourceIds.NamesToResourceIds,
	}

	resource.Normalize()

	return &resource, nil
}

func (d *SwaggerDefinition) findTags() []string {
	tags := make(map[string]struct{})

	// first we go through, assuming there are tags
	for _, operation := range d.swaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				tags[tag] = struct{}{}
			}
		}
	}

	out := make([]string, 0)
	for key := range tags {
		out = append(out, key)
	}
	sort.Strings(out)
	return out
}
