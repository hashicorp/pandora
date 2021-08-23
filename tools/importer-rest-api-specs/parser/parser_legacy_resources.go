package parser

import (
	"fmt"
	"log"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

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

	nestedResult, err = d.parseOperations(*operations, result)
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

	// first Normalize the names, meaning `foo` -> `Foo` for consistency
	resource.Normalize()

	return &resource, nil
}

func (d *SwaggerDefinition) findTags() []string {
	tags := make(map[string]struct{})

	// first we go through, assuming there are tags
	for _, operation := range d.swaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				normalizedTag := normalizeTag(tag)
				tags[normalizedTag] = struct{}{}
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