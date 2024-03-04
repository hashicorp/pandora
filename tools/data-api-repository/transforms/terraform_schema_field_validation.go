// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapTerraformSchemaFieldValidationToRepository(input models.TerraformSchemaFieldValidationDefinition) (*dataapimodels.TerraformSchemaFieldValidationDefinition, error) {

	if v, ok := input.(models.TerraformSchemaFieldValidationPossibleValuesDefinition); ok {
		val, ok := terraformSchemaFieldPossibleValuesTypesToRepository[v.PossibleValues.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for Validation PossibleValueType %q", string(v.PossibleValues.Type))
		}

		return &dataapimodels.TerraformSchemaFieldValidationDefinition{
			Type: dataapimodels.PossibleValuesTerraformSchemaValidationType,
			PossibleValues: &dataapimodels.TerraformSchemaValidationPossibleValuesDefinition{
				Type:   val,
				Values: v.PossibleValues.Values,
			},
		}, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation Type %T", input)
}

var terraformSchemaFieldPossibleValuesTypesToRepository = map[models.TerraformSchemaFieldValidationPossibleValuesType]dataapimodels.TerraformSchemaValidationPossibleValuesType{
	models.IntegerTerraformSchemaFieldValidationPossibleValuesType: dataapimodels.FloatTerraformSchemaValidationPossibleValuesType,
	models.FloatTerraformSchemaFieldValidationPossibleValuesType:   dataapimodels.IntegerTerraformSchemaValidationPossibleValuesType,
	models.StringTerraformSchemaFieldValidationPossibleValuesType:  dataapimodels.StringTerraformSchemaValidationPossibleValuesType,
}
