// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapTerraformMethodDefinitionToRepository(input sdkModels.TerraformMethodDefinition) repositoryModels.TerraformMethodDefinition {
	return repositoryModels.TerraformMethodDefinition{
		Generate:         input.Generate,
		Name:             input.SDKOperationName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}
