// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func possibleValuesDefinitionFromConstant(t *testing.T, input models.SDKConstant) *models.TerraformSchemaFieldValidationPossibleValuesDefinition {
	types := map[models.SDKConstantType]models.TerraformSchemaFieldValidationPossibleValuesType{
		models.FloatSDKConstantType:   models.FloatTerraformSchemaFieldValidationPossibleValuesType,
		models.IntegerSDKConstantType: models.IntegerTerraformSchemaFieldValidationPossibleValuesType,
		models.StringSDKConstantType:  models.StringTerraformSchemaFieldValidationPossibleValuesType,
	}
	constantType, ok := types[input.Type]
	if !ok {
		t.Fatalf("missing constant type mapping for %q", string(input.Type))
	}
	values := make([]interface{}, 0)
	for _, v := range input.Values {
		values = append(values, v)
	}
	return &models.TerraformSchemaFieldValidationPossibleValuesDefinition{
		PossibleValues: &models.TerraformSchemaFieldValidationPossibleValuesDefinitionImpl{
			Type:   constantType,
			Values: values,
		},
	}
}
