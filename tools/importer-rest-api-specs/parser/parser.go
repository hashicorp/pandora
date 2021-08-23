package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var useLegacyParser = true

func (d *SwaggerDefinition) Parse(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	if useLegacyParser {
		return d.parseLegacy(serviceName, apiVersion)
	}

	return d.parseNew(serviceName, apiVersion)
}

func (d *SwaggerDefinition) parseNew(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	return &models.AzureApiDefinition{}, nil
}