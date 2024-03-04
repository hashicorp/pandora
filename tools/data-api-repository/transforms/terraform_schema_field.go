// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

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
