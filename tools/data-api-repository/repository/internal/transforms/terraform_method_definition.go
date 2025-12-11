// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapTerraformMethodDefinitionFromRepository(input repositoryModels.TerraformMethodDefinition) sdkModels.TerraformMethodDefinition {
	return sdkModels.TerraformMethodDefinition{
		Generate:         input.Generate,
		SDKOperationName: input.Name,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}

func mapTerraformMethodDefinitionToRepository(input sdkModels.TerraformMethodDefinition) repositoryModels.TerraformMethodDefinition {
	return repositoryModels.TerraformMethodDefinition{
		Generate:         input.Generate,
		Name:             input.SDKOperationName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}
