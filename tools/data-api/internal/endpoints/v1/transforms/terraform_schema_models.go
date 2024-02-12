package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func mapTerraformSchemaModels(input map[string]repositories.TerraformSchemaModelDefinition) (*map[string]models.TerraformSchemaModelDefinition, error) {
	output := make(map[string]models.TerraformSchemaModelDefinition)

	for key, value := range input {
		mappedModel, err := mapTerraformSchemaModel(value)
		if err != nil {
			return nil, fmt.Errorf("mapping Terraform Schema Model %q: %+v", key, err)
		}

		output[key] = *mappedModel
	}

	return &output, nil
}

func mapTerraformSchemaModel(input repositories.TerraformSchemaModelDefinition) (*models.TerraformSchemaModelDefinition, error) {
	mappedFields, err := mapTerraformSchemaFields(input.Fields)
	if err != nil {
		return nil, fmt.Errorf("mapping Fields: %+v", err)
	}

	return &models.TerraformSchemaModelDefinition{
		Fields: *mappedFields,
	}, nil
}
