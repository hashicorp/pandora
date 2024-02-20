// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapTerraformResourceDefinitionToRepository(resourceLabel string, input resourcemanager.TerraformResourceDetails) (*dataapimodels.TerraformResourceDefinition, error) {
	// TODO: ExampleUsage should probably go out into a file - perhaps `Resource-ExampleUsage.hcl`?
	output := dataapimodels.TerraformResourceDefinition{
		ApiVersion:                   input.ApiVersion,
		Category:                     input.Documentation.Category,
		CreateMethod:                 mapTerraformMethodDefinitionToRepository(input.CreateMethod),
		DeleteMethod:                 mapTerraformMethodDefinitionToRepository(input.DeleteMethod),
		Description:                  input.Documentation.Description,
		DisplayName:                  input.DisplayName,
		ExampleUsage:                 input.Documentation.ExampleUsageHcl,
		Generate:                     input.Generate,
		GenerateIdValidationFunction: input.GenerateIdValidation,
		GenerateModel:                input.GenerateModel,
		GenerateSchema:               input.GenerateSchema,
		Label:                        resourceLabel,
		ReadMethod:                   mapTerraformMethodDefinitionToRepository(input.ReadMethod),
		Resource:                     input.Resource,
		ResourceIdName:               input.ResourceIdName,
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		SchemaModelName: fmt.Sprintf("%sSchema", input.SchemaModelName),
		UpdateMethod:    nil,
	}
	if input.UpdateMethod != nil {
		mapped := mapTerraformMethodDefinitionToRepository(*input.UpdateMethod)
		output.UpdateMethod = pointer.To(mapped)
	}

	return &output, nil
}
