// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundOperationalinsights26678{}

type workaroundOperationalinsights26678 struct{}

func (workaroundOperationalinsights26678) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	return apiDefinition.ServiceName == "OperationalInsights" && apiDefinition.ApiVersion == "2021-06-01"
}

func (workaroundOperationalinsights26678) Name() string {
	return "OperationalInsights / 26678"
}

func (workaroundOperationalinsights26678) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["Clusters"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Cluster` but didn't get one")
	}
	operation, ok := resource.Operations["Update"]
	if !ok {
		return nil, fmt.Errorf("expected an Operation named `Update` but didn't get one")
	}
	operation.ExpectedStatusCodes = append(operation.ExpectedStatusCodes, 202)
	resource.Operations["Update"] = operation
	apiDefinition.Resources["Clusters"] = resource
	return &apiDefinition, nil
}
