package testing

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func (tb TestBuilder) getAttributeValueForField(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies) (*hclwrite.Tokens, error) {
	// TODO: Default Values where applicable, once threaded through (https://github.com/hashicorp/pandora/issues/810)

	if field.Validation != nil && field.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues {
		return tb.getAttributeValueForPossibleValuesField(field)
	}

	if function, isCommonSchema := commonSchemaAttributeValueFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		val := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &val, nil
	}

	if function, isBasicType := attributeValuesForBasicTypes[field.ObjectDefinition.Type]; isBasicType {
		out := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &out, nil
	}

	return nil, fmt.Errorf("internal-error: support for ObjectDefinition Type %q as an Attribute is not implemented", field.ObjectDefinition)
}

func (tb TestBuilder) getAttributeValueForPossibleValuesField(field resourcemanager.TerraformSchemaFieldDefinition) (*hclwrite.Tokens, error) {
	if field.Validation.PossibleValues == nil || len(field.Validation.PossibleValues.Values) == 0 {
		return nil, fmt.Errorf("internal-error: at this time only PossibleValues is supported as a Validation type for building up the field")
	}

	switch field.Validation.PossibleValues.Type {
	case resourcemanager.TerraformSchemaValidationPossibleValueTypeInt:
		{
			intValRaw := field.Validation.PossibleValues.Values[0]
			intVal, ok := intValRaw.(int64)
			if !ok {
				return nil, fmt.Errorf("schema field defines an integer but the PossibleValues type didn't match - got %q", string(field.Validation.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.NumberIntVal(intVal))
			return &out, nil
		}

	case resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat:
		{
			floatValRaw := field.Validation.PossibleValues.Values[0]
			floatVal, ok := floatValRaw.(float64)
			if !ok {
				return nil, fmt.Errorf("schema field defines a float but the PossibleValues type didn't match - got %q", string(field.Validation.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.NumberFloatVal(floatVal))
			return &out, nil
		}

	case resourcemanager.TerraformSchemaValidationPossibleValueTypeString:
		{
			stringValRaw := field.Validation.PossibleValues.Values[0]
			stringVal, ok := stringValRaw.(string)
			if !ok {
				return nil, fmt.Errorf("schema field defines a string but the PossibleValues type didn't match - got %q", string(field.Validation.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.StringVal(stringVal))
			return &out, nil
		}

	}

	return nil, fmt.Errorf("internal-error: missing support for the PossibleValues type %q", string(field.Validation.PossibleValues.Type))
}

type attributeValueFunction func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens

var attributeValuesForBasicTypes = map[resourcemanager.TerraformSchemaFieldType]attributeValueFunction{
	resourcemanager.TerraformSchemaFieldTypeBoolean: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.BoolVal(false))
	},
	resourcemanager.TerraformSchemaFieldTypeFloat: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.NumberFloatVal(21.42))
	},
	resourcemanager.TerraformSchemaFieldTypeInteger: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.NumberIntVal(int64(21)))
	},
	resourcemanager.TerraformSchemaFieldTypeString: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.StringVal("example"))
	},
}

var commonSchemaAttributeValueFunctions = map[resourcemanager.TerraformSchemaFieldType]attributeValueFunction{
	// NOTE: there's a handful of top-level resources which have specific overrides (e.g. the Resource Group Name etc)
	resourcemanager.TerraformSchemaFieldTypeEdgeZone: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		dependencies.setNeedsEdgeZones()
		return hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: "element(data.azurerm_extended_locations.test.extended_locations, 0)",
			},
		})
	},
	resourcemanager.TerraformSchemaFieldTypeLocation: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		if strings.EqualFold(resourceLabel, "resource_group") {
			dependencies.variables.needsPrimaryLocation = true
			return hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`var.primary_location`)},
			}
		}

		dependencies.setNeedsResourceGroup()
		return hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_resource_group.test.location", providerPrefix),
			},
		})
	},
	resourcemanager.TerraformSchemaFieldTypeResourceGroup: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		if strings.EqualFold(resourceLabel, "resource_group") {
			dependencies.variables.needsRandomInteger = true
			return hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`"acctestrg-${var.random_integer}"`)},
			}
		}

		dependencies.setNeedsResourceGroup()
		return hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_resource_group.test.name", providerPrefix),
			},
		})
	},
	resourcemanager.TerraformSchemaFieldTypeTags: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.ObjectVal(map[string]cty.Value{
			"environment": cty.StringVal("terraform-acctests"),
			"some_key":    cty.StringVal("some-value"),
		}))
	},

	resourcemanager.TerraformSchemaFieldTypeSku: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.StringVal("Standard"))
	},
	resourcemanager.TerraformSchemaFieldTypeZone: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.StringVal("1"))
	},
	resourcemanager.TerraformSchemaFieldTypeZones: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens {
		return hclwrite.TokensForValue(cty.ListVal([]cty.Value{
			cty.StringVal("1"),
			cty.StringVal("2"),
			cty.StringVal("3"),
		}))
	},

	// NOTE: the following CommonSchema types are exposed as Blocks and not Attributes (valid under `terraform-plugin-sdk@v2` / protocol v5)
	// however this'll change in the future under `terraform-plugin-framework` / protocol v6
	//  * TerraformSchemaFieldTypeIdentitySystemAssigned
	//  * TerraformSchemaFieldTypeIdentitySystemAndUserAssigned
	//  * TerraformSchemaFieldTypeIdentitySystemOrUserAssigned
	//  * TerraformSchemaFieldTypeIdentityUserAssigned
}
