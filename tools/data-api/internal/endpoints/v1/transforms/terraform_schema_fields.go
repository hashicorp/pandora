package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func mapTerraformSchemaFields(input map[string]repositories.TerraformSchemaFieldDefinition) (*map[string]models.TerraformSchemaField, error) {
	output := make(map[string]models.TerraformSchemaField)
	for key, val := range input {
		mapped, err := mapTerraformSchemaField(val)
		if err != nil {
			return nil, fmt.Errorf("mapping Terraform Schema Field %q: %+v", key, err)
		}
		output[key] = *mapped
	}
	return &output, nil
}

func mapTerraformSchemaField(input repositories.TerraformSchemaFieldDefinition) (*models.TerraformSchemaField, error) {
	objectDefinition, err := mapTerraformSchemaFieldObjectDefinition(input.ObjectDefinition)
	if err != nil {
		return nil, fmt.Errorf("mapping Object Definition: %+v", err)
	}

	output := models.TerraformSchemaFieldDefinition{
		Computed:         input.Computed,
		ForceNew:         input.ForceNew,
		HCLName:          input.HclName,
		Optional:         input.Optional,
		ObjectDefinition: *objectDefinition,
		Required:         input.Required,
		Documentation: models.TerraformSchemaDocumentationDefinition{
			Markdown: input.Documentation.Markdown,
		},
	}
	if input.Validation != nil {
		mappedValidation, err := mapTerraformSchemaFieldValidation(*input.Validation)
		if err != nil {
			return nil, fmt.Errorf("mapping Validation: %+v", err)
		}
		output.Validation = mappedValidation
	}

	return &output, nil
}
