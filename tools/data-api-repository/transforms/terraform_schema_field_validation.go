// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapTerraformSchemaFieldValidationToRepository(input sdkModels.TerraformSchemaFieldValidationDefinition) (*repositoryModels.TerraformSchemaFieldValidationDefinition, error) {

	if v, ok := input.(sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition); ok {
		val, ok := terraformSchemaFieldPossibleValuesTypesToRepository[v.PossibleValues.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing mapping for Validation PossibleValueType %q", string(v.PossibleValues.Type))
		}

		return &repositoryModels.TerraformSchemaFieldValidationDefinition{
			Type: repositoryModels.PossibleValuesTerraformSchemaValidationType,
			PossibleValues: &repositoryModels.TerraformSchemaValidationPossibleValuesDefinition{
				Type:   val,
				Values: v.PossibleValues.Values,
			},
		}, nil
	}

	return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation Type %T", input)
}

var terraformSchemaFieldPossibleValuesTypesToRepository = map[sdkModels.TerraformSchemaFieldValidationPossibleValuesType]repositoryModels.TerraformSchemaValidationPossibleValuesType{
	sdkModels.IntegerTerraformSchemaFieldValidationPossibleValuesType: repositoryModels.FloatTerraformSchemaValidationPossibleValuesType,
	sdkModels.FloatTerraformSchemaFieldValidationPossibleValuesType:   repositoryModels.IntegerTerraformSchemaValidationPossibleValuesType,
	sdkModels.StringTerraformSchemaFieldValidationPossibleValuesType:  repositoryModels.StringTerraformSchemaValidationPossibleValuesType,
}
