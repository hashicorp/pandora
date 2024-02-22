// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapServiceDefinitionToRepository(serviceName string, resourceProvider *string, terraformDefinition *models.TerraformDefinition) (*dataapimodels.ServiceDefinition, error) {
	output := dataapimodels.ServiceDefinition{
		Name:             serviceName,
		ResourceProvider: resourceProvider,
		Generate:         true,
	}

	if terraformDefinition != nil {
		// TODO: remove this once the repository is consolidated since this should be inferrable
		terraformResourceNames := make([]string, 0)
		for _, resource := range terraformDefinition.Resources {
			terraformResourceNames = append(terraformResourceNames, resource.ResourceName)
		}

		//TODO: remove this field once the repository package is consolidated
		output.TerraformPackageName = pointer.To(terraformDefinition.TerraformPackageName)
		output.Terraform = &dataapimodels.TerraformServiceDefinition{
			ServicePackageName: terraformDefinition.TerraformPackageName,
			Resources:          terraformResourceNames,
		}
	}

	return &output, nil
}
