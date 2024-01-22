// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func possibleValuesDefinitionFromConstant(t *testing.T, input resourcemanager.ConstantDetails) *resourcemanager.TerraformSchemaValidationPossibleValuesDefinition {
	types := map[resourcemanager.ConstantType]resourcemanager.TerraformSchemaValidationPossibleValueType{
		resourcemanager.FloatConstant:   resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
		resourcemanager.IntegerConstant: resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
		resourcemanager.StringConstant:  resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
	}
	constantType, ok := types[input.Type]
	if !ok {
		t.Fatalf("missing constant type mapping for %q", string(input.Type))
	}
	values := make([]interface{}, 0)
	for _, v := range input.Values {
		values = append(values, v)
	}
	return &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
		Type:   constantType,
		Values: values,
	}
}
