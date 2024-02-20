// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaFieldValidationToRepository(input resourcemanager.TerraformSchemaValidationDefinition) (*dataapimodels.TerraformSchemaFieldValidationDefinition, error) {
	mappedType, ok := terraformSchemaFieldValidationTypesToRepository[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for Schema Field Validation Type %q", string(input.Type))
	}

	output := dataapimodels.TerraformSchemaFieldValidationDefinition{
		Type: mappedType,
	}

	if mappedType == dataapimodels.PossibleValuesTerraformSchemaValidationType {
		if input.PossibleValues == nil {
			return nil, fmt.Errorf("internal-error: bad data -`internal.PossibleValues` was nil for a PossibleValues type")
		}
		possibleValues, err := mapTerraformSchemaFieldValidationPossibleValuesToRepository(*input.PossibleValues)
		if err != nil {
			return nil, fmt.Errorf("mapping the Possible Values for the Terraform Schema Field: %+v", err)
		}
		output.PossibleValues = possibleValues
	}
	return &output, nil
}

var terraformSchemaFieldValidationTypesToRepository = map[resourcemanager.TerraformSchemaValidationType]dataapimodels.TerraformSchemaFieldValidationType{
	resourcemanager.TerraformSchemaValidationTypePossibleValues: dataapimodels.PossibleValuesTerraformSchemaValidationType,
}
