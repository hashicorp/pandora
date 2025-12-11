// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapTerraformResourceDefinitionFromRepository(resourceName string, input repositoryModels.TerraformResourceDefinition, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition, tests sdkModels.TerraformResourceTestsDefinition) (*sdkModels.TerraformResourceDefinition, error) {
	output := sdkModels.TerraformResourceDefinition{
		APIResource:  input.Resource,
		APIVersion:   input.ApiVersion,
		CreateMethod: mapTerraformMethodDefinitionFromRepository(input.CreateMethod),
		DeleteMethod: mapTerraformMethodDefinitionFromRepository(input.DeleteMethod),
		Documentation: sdkModels.TerraformDocumentationDefinition{
			Category:        input.Category,
			Description:     input.Description,
			ExampleUsageHCL: helpers.TrimNewLinesAround(input.ExampleUsage),
		},
		DisplayName:          input.DisplayName,
		Generate:             input.Generate,
		GenerateModel:        input.GenerateModel,
		GenerateIDValidation: input.GenerateIdValidationFunction,
		GenerateSchema:       input.GenerateSchema,
		Mappings:             mappings,
		ReadMethod:           mapTerraformMethodDefinitionFromRepository(input.ReadMethod),
		ResourceLabel:        input.Label,
		ResourceIDName:       input.ResourceIdName,
		ResourceName:         resourceName,
		SchemaModelName:      input.SchemaModelName,
		SchemaModels:         schemaModels,
		Tests:                tests,
		UpdateMethod:         nil,
	}
	if input.UpdateMethod != nil {
		updateMethod := mapTerraformMethodDefinitionFromRepository(*input.UpdateMethod)
		output.UpdateMethod = pointer.To(updateMethod)
	}

	return &output, nil
}

func MapTerraformResourceDefinitionToRepository(resourceLabel string, input sdkModels.TerraformResourceDefinition) (*repositoryModels.TerraformResourceDefinition, error) {
	// TODO: ExampleUsage should probably go out into a file - perhaps `Resource-ExampleUsage.hcl`?
	output := repositoryModels.TerraformResourceDefinition{
		ApiVersion:                   input.APIVersion,
		Category:                     input.Documentation.Category,
		CreateMethod:                 mapTerraformMethodDefinitionToRepository(input.CreateMethod),
		DeleteMethod:                 mapTerraformMethodDefinitionToRepository(input.DeleteMethod),
		Description:                  input.Documentation.Description,
		DisplayName:                  input.DisplayName,
		ExampleUsage:                 helpers.TrimNewLinesAround(input.Documentation.ExampleUsageHCL),
		Generate:                     input.Generate,
		GenerateIdValidationFunction: input.GenerateIDValidation,
		GenerateModel:                input.GenerateModel,
		GenerateSchema:               input.GenerateSchema,
		Label:                        resourceLabel,
		ReadMethod:                   mapTerraformMethodDefinitionToRepository(input.ReadMethod),
		Resource:                     input.APIResource,
		ResourceIdName:               input.ResourceIDName,
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		SchemaModelName: fmt.Sprintf("%sSchema", input.SchemaModelName),
		// TODO: output tests here
		UpdateMethod: nil,
	}
	if input.UpdateMethod != nil {
		mapped := mapTerraformMethodDefinitionToRepository(*input.UpdateMethod)
		output.UpdateMethod = pointer.To(mapped)
	}

	return &output, nil
}
