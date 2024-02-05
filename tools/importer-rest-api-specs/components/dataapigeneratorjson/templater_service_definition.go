// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func buildServiceDefinition(serviceName string, resourceProvider, terraformPackage *string, apiVersions []models.AzureApiDefinition) (*dataapimodels.ServiceDefinition, error) {
	output := dataapimodels.ServiceDefinition{
		Name:                 serviceName,
		ResourceProvider:     resourceProvider,
		TerraformPackageName: terraformPackage,
		Generate:             true,
	}

	if terraformPackage != nil {
		terraformResources := make([]string, 0)
		for _, apiVersion := range apiVersions {
			for _, resource := range apiVersion.Resources {
				if resource.Terraform == nil {
					continue
				}

				// TODO: support for Data Sources in the future
				for _, v := range resource.Terraform.Resources {
					terraformResources = append(terraformResources, v.ResourceName)
				}
			}
		}
		sort.Strings(terraformResources)

		output.Terraform = &dataapimodels.TerraformServiceDefinition{
			ServicePackageName: pointer.From(terraformPackage),
			Resources:          terraformResources,
		}
	}

	return &output, nil
}
