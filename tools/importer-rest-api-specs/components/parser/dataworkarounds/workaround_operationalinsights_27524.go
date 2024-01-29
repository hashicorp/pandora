// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundOperationalinsights27524{}

// workaroundOperationalinsights27524 works around the missed 201 status code.
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/27524
type workaroundOperationalinsights27524 struct{}

func (workaroundOperationalinsights27524) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "OperationalInsights" && apiDefinition.ApiVersion == "2019-09-01"
}

func (workaroundOperationalinsights27524) Name() string {
	return "OperationalInsights / 27524"
}

func (workaroundOperationalinsights27524) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["QueryPacks"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `QueryPacks` but didn't get one")
	}
	operation, ok := resource.Operations["CreateOrUpdate"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `CreateOrUpdate` but didn't get one")
	}
	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, 201)
	resource.Operations["CreateOrUpdate"] = operation
	apiDefinition.Resources["QueryPacks"] = resource
	return &apiDefinition, nil
}
