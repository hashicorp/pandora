// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapServiceDefinitionToRepository(serviceName string, resourceProvider *string, terraformDefinition *sdkModels.TerraformDefinition) (*repositoryModels.ServiceDefinition, error) {
	output := repositoryModels.ServiceDefinition{
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
		sort.Strings(terraformResourceNames)

		//TODO: remove this field once the repository package is consolidated
		output.TerraformPackageName = pointer.To(terraformDefinition.TerraformPackageName)
		output.Terraform = &repositoryModels.TerraformServiceDefinition{
			ServicePackageName: terraformDefinition.TerraformPackageName,
			Resources:          terraformResourceNames,
		}
	}

	return &output, nil
}
