// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapTerraformMethodDefinitionToRepository(input models.TerraformMethodDefinition) dataapimodels.TerraformMethodDefinition {
	return dataapimodels.TerraformMethodDefinition{
		Generate:         input.Generate,
		Name:             input.SDKOperationName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}
