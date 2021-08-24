package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d *SwaggerDefinition) parseResourcesWithinSwaggerTag(tag *string) (*models.AzureApiResource, error) {
	result := parseResult{
		constants: map[string]models.ConstantDetails{},
		models:    map[string]models.ModelDetails{},
	}

	// note that Resource ID's can contain Constants (used as segments)
	resourceIds, err := d.findResourceIdsForTag(tag)
	if err != nil {
		return nil, fmt.Errorf("finding resource ids: %+v", err)
	}
	result.append(resourceIds.nestedResult)

	//operations, nestedResult, err := d.findOperationsForTag(tag, resourceIds.UriToDetails)
	//if err != nil {
	//	return nil, fmt.Errorf("finding operations: %+v", err)
	//}
	//result.append(*nestedResult)
	//
	//nestedResult, err = d.parseOperations(*operations, result)
	//if err != nil {
	//	return nil, fmt.Errorf("parsing operations: %+v", err)
	//}
	//result.append(*nestedResult)

	// if there's nothing here, there's no point generating a package
	//if len(*operations) == 0 && len(result.models) == 0 && len(result.constants) == 0 {
	//	return nil, nil
	//}

	resource := models.AzureApiResource{
		Constants:   result.constants,
		Models:      result.models,
		Operations:  map[string]models.OperationDetails{},
		ResourceIds: map[string]string{},
		//Operations:  *operations,
		//ResourceIds: resourceIds.NamesToResourceIds,
	}

	// first Normalize the names, meaning `foo` -> `Foo` for consistency
	//resource.Normalize()

	return &resource, nil
}
