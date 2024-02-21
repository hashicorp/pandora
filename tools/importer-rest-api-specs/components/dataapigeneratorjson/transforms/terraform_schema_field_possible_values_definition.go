// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaFieldValidationPossibleValuesToRepository(input resourcemanager.TerraformSchemaValidationPossibleValuesDefinition) (*dataapimodels.TerraformSchemaValidationPossibleValuesDefinition, error) {
	val, ok := terraformSchemaFieldPossibleValuesTypesToRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Validation PossibleValueType %q", string(input.Type))
	}

	return &dataapimodels.TerraformSchemaValidationPossibleValuesDefinition{
		Type:   val,
		Values: input.Values,
	}, nil
}

var terraformSchemaFieldPossibleValuesTypesToRepository = map[resourcemanager.TerraformSchemaValidationPossibleValueType]dataapimodels.TerraformSchemaValidationPossibleValuesType{
	resourcemanager.TerraformSchemaValidationPossibleValueTypeInt:    dataapimodels.FloatTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat:  dataapimodels.IntegerTerraformSchemaValidationPossibleValuesType,
	resourcemanager.TerraformSchemaValidationPossibleValueTypeString: dataapimodels.StringTerraformSchemaValidationPossibleValuesType,
}
