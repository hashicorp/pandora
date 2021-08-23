package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/legacy"
)

var useLegacyParser = true

func (d *SwaggerDefinition) Parse(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	if useLegacyParser {
		innerDefinition := legacy.SwaggerDefinition{
			Name:                      d.Name,
			DebugLog:                  d.debugLog,
			SwaggerSpecExpanded:       d.swaggerSpecExpanded,
			SwaggerSpecWithReferences: d.swaggerSpecWithReferences,
			SwaggerSpecRaw:            d.swaggerSpecRaw,
			SwaggerSpecExtendedRaw:    d.swaggerSpecExtendedRaw,
		}
		return innerDefinition.Parse(serviceName, apiVersion)
	}

	return d.parseNew(serviceName, apiVersion)
}

func (d *SwaggerDefinition) parseNew(serviceName, apiVersion string) (*models.AzureApiDefinition, error) {
	return &models.AzureApiDefinition{}, nil
}