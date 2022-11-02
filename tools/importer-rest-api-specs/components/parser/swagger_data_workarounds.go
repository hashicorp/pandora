package parser

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func patchSwaggerData(input []models.AzureApiDefinition, logger hclog.Logger) (*[]models.AzureApiDefinition, error) {
	output := make([]models.AzureApiDefinition, 0)

	// NOTE: each override in this file is temporary until the associated upstream Swagger PR is merged.

	for _, item := range input {
		// This works around the Patch Model having no type for the Tags field (which is parsed as an Object instead)
		// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/20961
		if item.ServiceName == "LoadTestService" && (item.ApiVersion == "2021-12-01-preview" || item.ApiVersion == "2022-04-15-preview" || item.ApiVersion == "2022-12-01") {
			logger.Trace(fmt.Sprintf("Processing Overrides for Service %q / API Version %q..", item.ServiceName, item.ApiVersion))
			resource, ok := item.Resources["LoadTests"]
			if !ok {
				return nil, fmt.Errorf("couldn't find API Resource LoadTests")
			}
			model, ok := resource.Models["LoadTestResourcePatchRequestBody"]
			if !ok {
				return nil, fmt.Errorf("couldn't find Model LoadTestResourcePatchRequestBody")
			}
			field, ok := model.Fields["Tags"]
			if !ok {
				return nil, fmt.Errorf("couldn't find field Tags within model LoadTestResourcePatchRequestBody")
			}
			tagsType := models.CustomFieldTypeTags
			field.CustomFieldType = &tagsType
			field.ObjectDefinition = nil

			model.Fields["Tags"] = field
			resource.Models["LoadTestResourcePatchRequestBody"] = model
			item.Resources["LoadTests"] = resource
		}

		// Works around the `DnsPrefix` field being required but being marked as Optional
		// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/21394
		if item.ServiceName == "ContainerService" && item.ApiVersion == "2022-09-02-preview" {
			logger.Trace(fmt.Sprintf("Processing Overrides for Service %q / API Version %q..", item.ServiceName, item.ApiVersion))
			resource, ok := item.Resources["Fleets"]
			if !ok {
				return nil, fmt.Errorf("couldn't find API Resource Fleets")
			}
			model, ok := resource.Models["FleetHubProfile"]
			if !ok {
				return nil, fmt.Errorf("couldn't find Model FleetHubProfile")
			}
			field, ok := model.Fields["DnsPrefix"]
			if !ok {
				return nil, fmt.Errorf("couldn't find field DnsPrefix within model FleetHubProfile")
			}
			field.Required = true

			model.Fields["DnsPrefix"] = field
			resource.Models["FleetHubProfile"] = model
			item.Resources["Fleets"] = resource
		}

		output = append(output, item)
	}

	return &output, nil
}
