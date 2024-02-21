// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package terraform

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/schema"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/testing"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/transformer"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/examples"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// NOTE: this file wants further refactoring and is just a minimal viable grouping for now

func PopulateForResources(data *models.AzureApiDefinition, resourceBuildInfo map[string]models.ResourceBuildInfo, providerPrefix string, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	logger.Trace("generating Terraform Details")
	var err error
	data, err = generateTerraformDetails(data, resourceBuildInfo, logger.Named("TerraformDetails"))
	if err != nil {
		return nil, fmt.Errorf("generating Terraform Details: %+v", err)
	}

	logger.Trace("generating Terraform Tests")
	data, err = generateTerraformTests(data, providerPrefix, logger.Named("TerraformTests"))
	if err != nil {
		return nil, fmt.Errorf("generating Terraform Tests: %+v", err)
	}

	logger.Trace("Generating Example Usage from the Terraform Tests")
	data, err = generateTerraformExampleUsage(data)
	if err != nil {
		return nil, fmt.Errorf("generating Terraform Example Usage: %+v", err)
	}

	return data, nil
}

func generateTerraformDetails(data *models.AzureApiDefinition, resourceBuildInfo map[string]models.ResourceBuildInfo, logger hclog.Logger) (*models.AzureApiDefinition, error) {
	for key, resource := range data.Resources {
		if resource.Terraform == nil {
			continue
		}

		// This is the data API name of the resource i.e. VirtualMachines
		r, err := transformer.ApiResourceFromModelResource(resource)
		if err != nil {
			return nil, err
		}

		b := schema.NewBuilder(resource.Constants, r.Schema.Models, r.Operations.Operations, r.Schema.ResourceIds)

		terraformResources := make(map[string]resourcemanager.TerraformResourceDetails)
		for resourceLabel, resourceDetails := range resource.Terraform.Resources {
			// We need to add to this map any sub-schemas we find so their classes can also be generated
			logger.Info(fmt.Sprintf("Building Schema for %s", resourceLabel))

			// use the ResourceName to build up the name for this Schema Model
			resourceDetails.SchemaModelName = fmt.Sprintf("%sResource", resourceDetails.ResourceName)

			var buildInfo *models.ResourceBuildInfo
			if resourceBuildInfo != nil {
				if b, ok := resourceBuildInfo[resourceLabel]; ok {
					buildInfo = &b
				}
			}

			modelsForResource, mappings, err := b.Build(resourceDetails, buildInfo, logger)
			if err != nil {
				return nil, err
			}

			if modelsForResource == nil {
				logger.Debug(fmt.Sprintf("Resource %q returned no models, meaning this has been filtered out (maybe a discriminated type)", resourceLabel))
				continue
			}

			if resourceDetails.UpdateMethod != nil {
				generateUpdate := false
				for _, model := range *modelsForResource {
					for _, field := range model.Fields {
						if !field.ForceNew {
							generateUpdate = true
						}
					}
				}
				resourceDetails.UpdateMethod.Generate = generateUpdate
			}

			resourceDetails.ApiVersion = data.ApiVersion
			resourceDetails.SchemaModels = *modelsForResource
			resourceDetails.Mappings = *mappings
			resourceDetails.Tests.Generate = true

			terraformResources[resourceLabel] = resourceDetails
		}
		resource.Terraform.Resources = terraformResources

		data.Resources[key] = resource
	}

	return data, nil
}

func generateTerraformExampleUsage(data *models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	apiResources := make(map[string]models.AzureApiResource)
	for k, v := range data.Resources {
		if v.Terraform != nil {
			// TODO: support Data Sources

			tfResources := make(map[string]resourcemanager.TerraformResourceDetails)
			for resourceKey, resourceValue := range v.Terraform.Resources {
				example, err := examples.ResourceExampleFromTests(resourceValue.Tests)
				if err != nil {
					return nil, fmt.Errorf("building Example Usage from the Tests for Resource %q: %+v", resourceKey, err)
				}
				resourceValue.Documentation.ExampleUsageHcl = *example
				tfResources[resourceKey] = resourceValue
			}
			v.Terraform.Resources = tfResources
		}
		apiResources[k] = v
	}
	data.Resources = apiResources
	return data, nil
}

func generateTerraformTests(data *models.AzureApiDefinition, providerPrefix string, logger hclog.Logger) (*models.AzureApiDefinition, error) {
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
