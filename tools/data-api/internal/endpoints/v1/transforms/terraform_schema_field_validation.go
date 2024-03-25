// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var possibleValuesTypes = map[repositories.TerraformSchemaValidationPossibleValueType]models.TerraformSchemaFieldValidationPossibleValuesType{
	repositories.TerraformSchemaValidationPossibleValueTypeFloat:  models.FloatTerraformSchemaFieldValidationPossibleValuesType,
	repositories.TerraformSchemaValidationPossibleValueTypeInt:    models.IntegerTerraformSchemaFieldValidationPossibleValuesType,
	repositories.TerraformSchemaValidationPossibleValueTypeString: models.StringTerraformSchemaFieldValidationPossibleValuesType,
}

func mapTerraformSchemaFieldValidation(input repositories.TerraformSchemaValidationDefinition) (models.TerraformSchemaFieldValidationDefinition, error) {
	// NOTE: models.TerraformSchemaFieldValidationDefinition is an interface type, so there's no need to make this a **

	if input.Type == repositories.PossibleValuesTerraformSchemaValidationType {
		possibleValuesType, ok := possibleValuesTypes[input.PossibleValues.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for TerraformSchemaFieldValidationPossibleValuesType %q", string(input.Type))
		}

		return &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
			// temp wrapper model until the refactor is complete
			PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
				Type:   possibleValuesType,
				Values: input.PossibleValues.Values,
			},
		}, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for Validation Type %q", string(input.Type))
}
