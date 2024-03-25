// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func mapTerraformSchemaModels(input map[string]repositories.TerraformSchemaModelDefinition) (*map[string]models.TerraformSchemaModel, error) {
	output := make(map[string]models.TerraformSchemaModel)

	for key, value := range input {
		mappedModel, err := mapTerraformSchemaModel(value)
		if err != nil {
			return nil, fmt.Errorf("mapping Terraform Schema Model %q: %+v", key, err)
		}

		output[key] = *mappedModel
	}

	return &output, nil
}

func mapTerraformSchemaModel(input repositories.TerraformSchemaModelDefinition) (*models.TerraformSchemaModel, error) {
	mappedFields, err := mapTerraformSchemaFields(input.Fields)
	if err != nil {
		return nil, fmt.Errorf("mapping Fields: %+v", err)
	}

	return &models.TerraformSchemaModel{
		Fields: *mappedFields,
	}, nil
}
