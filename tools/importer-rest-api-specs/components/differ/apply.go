package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (d Differ) ApplyFromExistingAPIDefinitions(existing models.AzureApiDefinition, parsed models.AzureApiDefinition) (models.AzureApiDefinition, error) {
	// todo we should work through and ensure that all Existing items are present within Parsed
	// Each of the Stages to apply can be found in ApplyStages()

	// starting with copying Test Template
	for resourceName, resource := range existing.Resources {
		parsedResource, ok := parsed.Resources[resourceName]
		if !ok {
			return parsed, fmt.Errorf("unable to find the API Resource %q in the newly parsed api definitions", resourceName)
		}

		if existingTerraform := resource.Terraform; existingTerraform != nil {
			if parsedTerraform := parsedResource.Terraform; parsedTerraform != nil {
				for existingTerraformResourceName, existingTerraformResource := range existingTerraform.Resources {
					parsedTerraformResource, ok := parsedTerraform.Resources[existingTerraformResourceName]
					if !ok {
						return parsed, fmt.Errorf("unable to find the Terraform Resource %q in newly parsed api definitions", resourceName)
					}
					if existingTemplate := existingTerraformResource.Tests.TemplateConfiguration; existingTemplate != nil {
						parsedTerraformResource.Tests.TemplateConfiguration = existingTemplate
					}
				}
			}
		}
	}

	return parsed, nil
}
