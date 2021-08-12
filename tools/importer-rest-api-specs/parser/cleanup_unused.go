package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (d *SwaggerDefinition) removeUnusedModelsAndConstants(resources map[string]models.AzureApiResource) {
	for _, resource := range resources {
		resource.RemoveUnusedModelsAndConstants()
	}
}
