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
	// TODO: PossibleValues
	// if field.Validation != nil && field.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues && field.Validation.PossibleValues != nil

	if function, isCommonSchema := commonSchemaAttributeValueFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		val := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &val, nil
	}

	return nil, fmt.Errorf("not implemented")
}

type commonSchemaAttributeValueFunction func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) hclwrite.Tokens

var commonSchemaAttributeValueFunctions = map[resourcemanager.TerraformSchemaFieldType]commonSchemaAttributeValueFunction{
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
