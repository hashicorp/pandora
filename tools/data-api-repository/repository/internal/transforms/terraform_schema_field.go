// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapTerraformSchemaFieldFromRepository(input repositoryModels.TerraformSchemaField) (*sdkModels.TerraformSchemaField, error) {
	objectDefinition, err := mapTerraformSchemaObjectDefinitionFromRepository(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping the TerraformSchemaFieldObjectDefinition: %+v", err)
	}

	output := sdkModels.TerraformSchemaField{
		Computed:      pointer.From(input.Computed),
		Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
			// intentionally empty by default
		},
		ForceNew:         pointer.From(input.ForceNew),
		HCLName:          input.HclName,
		ObjectDefinition: *objectDefinition,
		Optional:         pointer.From(input.Optional),
		Required:         pointer.From(input.Required),
		Validation:       nil,
	}
	if input.Documentation != nil {
		output.Documentation.Markdown = input.Documentation.Markdown
	}
	return &output, nil
}

func mapTerraformSchemaFieldToRepository(fieldName string, input sdkModels.TerraformSchemaField) (*repositoryModels.TerraformSchemaField, error) {
	objectDefinition, err := MapTerraformSchemaObjectDefinitionToRepository(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping Terraform Schema Object Definition: %+v", err)
	}

	output := repositoryModels.TerraformSchemaField{
		HclName:          input.HCLName,
		Name:             fieldName,
		ObjectDefinition: *objectDefinition,
	}

	if input.Computed {
		output.Computed = pointer.To(true)
	}
	if input.ForceNew {
		output.ForceNew = pointer.To(true)
	}
	if input.Optional {
		output.Optional = pointer.To(true)
	}
	if input.Required {
		output.Required = pointer.To(true)
	}
	if input.Documentation.Markdown != "" {
		output.Documentation = &repositoryModels.TerraformSchemaFieldDocumentation{
			Markdown: input.Documentation.Markdown,
		}
	}
	if input.Validation != nil {
		validation, err := mapTerraformSchemaFieldValidationToRepository(input.Validation)
		if err != nil {
			return nil, fmt.Errorf("building validation: %+v", err)
		}
		output.Validation = validation
	}

	// sanity-check
	if !input.Computed && !input.Optional && !input.Required {
		return nil, fmt.Errorf("the field %q is neither Computed, Optional or Required - this is a bug", fieldName)
	}

	return &output, nil
}
