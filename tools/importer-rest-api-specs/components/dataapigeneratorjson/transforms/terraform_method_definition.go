// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformMethodDefinitionToRepository(input resourcemanager.MethodDefinition) dataapimodels.TerraformMethodDefinition {
	return dataapimodels.TerraformMethodDefinition{
		Generate:         input.Generate,
		Name:             input.MethodName,
		TimeoutInMinutes: input.TimeoutInMinutes,
	}
}
