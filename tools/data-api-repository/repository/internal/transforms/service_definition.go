// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapServiceDefinitionFromRepository(input repositoryModels.ServiceDefinition, apiVersions map[string]sdkModels.APIVersion, terraformDefinition *sdkModels.TerraformDefinition) (*sdkModels.Service, error) {
	return &sdkModels.Service{
		APIVersions:         apiVersions,
		Generate:            input.Generate,
		Name:                input.Name,
		ResourceProvider:    input.ResourceProvider,
		TerraformDefinition: terraformDefinition,
	}, nil
}

func MapServiceDefinitionToRepository(input sdkModels.Service) (*repositoryModels.ServiceDefinition, error) {
	output := repositoryModels.ServiceDefinition{
		Name:             input.Name,
		ResourceProvider: input.ResourceProvider,
		Generate:         true,
	}

	if input.TerraformDefinition != nil {
		// TODO: remove this once the repository is consolidated since this should be inferrable
		terraformResourceNames := make([]string, 0)
		for _, resource := range input.TerraformDefinition.Resources {
			terraformResourceNames = append(terraformResourceNames, resource.ResourceName)
		}
		sort.Strings(terraformResourceNames)

		//TODO: remove this field once the repository package is consolidated
		output.TerraformPackageName = pointer.To(input.TerraformDefinition.TerraformPackageName)
		output.Terraform = &repositoryModels.TerraformServiceDefinition{
			ServicePackageName: input.TerraformDefinition.TerraformPackageName,
			Resources:          terraformResourceNames,
		}
	}

	return &output, nil
}
