// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (t pipelineTask) generateTerraformTests(data *models.AzureApiDefinition, providerPrefix string, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	for _, resource := range data.Resources {
		if resource.Terraform == nil {
			continue
		}

		tf := resource.Terraform

		for resourceLabel, resourceDetails := range tf.Resources {
			if !resourceDetails.Tests.Generate {
				logger.Trace(fmt.Sprintf("Skipping generation of tests for %q since generation is disabled", resourceLabel))
				continue
			}

			logger.Trace(fmt.Sprintf("Generating Tests for %q", resourceLabel))
			testBuilder := testing.NewTestBuilder(providerPrefix, resourceLabel, resourceDetails)
			tests, err := testBuilder.GenerateForResource()
			if err != nil {
				return nil, fmt.Errorf("generating tests for %q: %+v", resourceLabel, err)
			}
			resourceDetails.Tests = *tests

			resource.Terraform.Resources[resourceLabel] = resourceDetails
		}
	}

	return data, nil
}
