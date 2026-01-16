// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/zclconf/go-cty/cty"
)

func (tb testBuilder) getAttributeValueForField(field sdkModels.TerraformSchemaField, dependencies *testDependencies, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
	// TODO: Default Values where applicable, once threaded through (https://github.com/hashicorp/pandora/issues/810)

	if field.Validation != nil {
		if v, ok := field.Validation.(sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition); ok {
			return tb.getAttributeValueForPossibleValuesField(v)
		}
	}

	if function, isCommonSchema := commonSchemaAttributeValueFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		out, err := function(field, dependencies, tb.resourceLabel, tb.providerPrefix, tb.details.DisplayName, testData)
		if err != nil {
			return nil, fmt.Errorf("for commonschema type: %+v", err)
		}
		return out, nil
	}

	if function, isBasicType := attributeValuesForBasicTypes[field.ObjectDefinition.Type]; isBasicType {
		out, err := function(field, dependencies, tb.resourceLabel, tb.providerPrefix, tb.details.DisplayName, testData)
		if err != nil {
			return nil, fmt.Errorf("for basic type: %+v", err)
		}
		return out, nil
	}

	if function, isListOrSet := attributeValuesForListsOfBasicTypes[field.ObjectDefinition.Type]; isListOrSet {
		out, err := function(field, dependencies, tb.resourceLabel, tb.providerPrefix, tb.details.DisplayName, testData)
		if err != nil {
			return nil, fmt.Errorf("for list or set type: %+v", err)
		}
		return out, nil
	}

	return nil, fmt.Errorf("internal-error: support for ObjectDefinition Type %q as an Attribute is not implemented", string(field.ObjectDefinition.Type))
}

func (tb testBuilder) getAttributeValueForPossibleValuesField(field sdkModels.TerraformSchemaFieldValidationPossibleValuesDefinition) (*hclwrite.Tokens, error) {
	if field.PossibleValues == nil || len(field.PossibleValues.Values) == 0 {
		return nil, fmt.Errorf("internal-error: at this time only PossibleValues is supported as a Validation type for building up the field")
	}

	switch field.PossibleValues.Type {
	case sdkModels.IntegerTerraformSchemaFieldValidationPossibleValuesType:
		{
			intValRaw := field.PossibleValues.Values[0]
			intVal, ok := intValRaw.(int64)
			if !ok {
				return nil, fmt.Errorf("schema field defines an integer but the PossibleValues type didn't match - got %q", string(field.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.NumberIntVal(intVal))
			return &out, nil
		}

	case sdkModels.FloatTerraformSchemaFieldValidationPossibleValuesType:
		{
			floatValRaw := field.PossibleValues.Values[0]
			floatVal, ok := floatValRaw.(float64)
			if !ok {
				return nil, fmt.Errorf("schema field defines a float but the PossibleValues type didn't match - got %q", string(field.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.NumberFloatVal(floatVal))
			return &out, nil
		}

	case sdkModels.StringTerraformSchemaFieldValidationPossibleValuesType:
		{
			stringValRaw := field.PossibleValues.Values[0]
			stringVal, ok := stringValRaw.(string)
			if !ok {
				return nil, fmt.Errorf("schema field defines a string but the PossibleValues type didn't match - got %q", string(field.PossibleValues.Type))
			}
			out := hclwrite.TokensForValue(cty.StringVal(stringVal))
			return &out, nil
		}

	}

	return nil, fmt.Errorf("internal-error: missing support for the PossibleValues type %q", string(field.PossibleValues.Type))
}

type attributeValueFunction func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error)

var attributeValuesForBasicTypes = map[models.TerraformSchemaObjectDefinitionType]attributeValueFunction{
	models.BooleanTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.BoolVal(false))
		return &val, nil
	},
	models.FloatTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.NumberFloatVal(21.42))
		return &val, nil
	},
	models.IntegerTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.NumberIntVal(int64(21)))
		return &val, nil
	},
	models.StringTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		// when `field.hclName` is `name`, we should be able to do `acctest{letters}-{var.random_string}` using the first letter of each bit of the resource label
		if strings.EqualFold(field.HCLName, "name") {
			dependencies.variables.needsRandomString = true
			suffixForResourceLabel := suffixFromResourceLabel(resourceLabel)
			val := hclwrite.Tokens{
				{
					Type: hclsyntax.TokenQuotedLit, Bytes: []byte(fmt.Sprintf(`"acctest%s-${var.random_string}"`, suffixForResourceLabel)),
				},
			}
			return &val, nil
		}

		// TODO: should fields ending in `_id` be output as a ResourceIDReference type? https://github.com/hashicorp/pandora/issues/866
		var reference *string
		var err error
		if strings.HasSuffix(field.HCLName, "_id") {
			// first check whether field ending in _id has a dependency defined in the TestData
			for k, v := range testData.Strings {
				if strings.EqualFold(field.HCLName, k) {
					reference, dependencies, err = DetermineDependencies(v, providerPrefix, dependencies)
					if err != nil {
						return nil, err
					}
					break
				}
			}
			// if we haven't errored and the field doesn't have its dependency specified by the TestData then check and set it again
			if reference == nil {
				reference, dependencies, err = DetermineDependencies(field.HCLName, providerPrefix, dependencies)
				if err != nil {
					return nil, err
				}
			}

			val := hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: *reference,
				},
			})
			return &val, nil
		}

		for k, v := range testData.Strings {
			if field.HCLName == k {
				out := hclwrite.TokensForValue(cty.StringVal(v))
				return &out, nil
			}
		}

		if strings.EqualFold(field.HCLName, "description") {
			// Description for the Example Thing
			out := hclwrite.TokensForValue(cty.StringVal(fmt.Sprintf("Description for the %s", resourceDisplayName)))
			return &out, nil
		}

		dependencies.variables.needsRandomString = true
		val := hclwrite.Tokens{
			{
				Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`"val-${var.random_string}"`),
			},
		}
		return &val, nil
	},
}

var attributeValuesForListsOfBasicTypes = map[models.TerraformSchemaObjectDefinitionType]attributeValueFunction{
	models.ListTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		if field.ObjectDefinition.NestedObject != nil && field.ObjectDefinition.NestedObject.Type != models.StringTerraformSchemaObjectDefinitionType {
			return nil, fmt.Errorf("not a list or set of basic types")
		}

		testDataForList := findTestDataValue(field.HCLName, testData.Lists)

		if testDataForList == nil {
			return nil, fmt.Errorf("no test data found for field %s in resource %s", field.HCLName, resourceDisplayName)
		}

		listValues := ""
		for _, v := range *testDataForList {
			listValues = listValues + fmt.Sprintf(`"%s",`, v)
		}
		listValues = strings.TrimSuffix(listValues, ",")

		val := hclwrite.Tokens{
			{
				Type:  hclsyntax.TokenOBrack,
				Bytes: []byte(`[`),
			},
			{
				Type:  hclsyntax.TokenIdent,
				Bytes: []byte(listValues),
			},
			{
				Type:  hclsyntax.TokenCBrack,
				Bytes: []byte(`]`),
			},
		}
		return &val, nil
	},

	models.SetTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		return nil, fmt.Errorf("TODO: support for Sets")
	},
}

var commonSchemaAttributeValueFunctions = map[models.TerraformSchemaObjectDefinitionType]attributeValueFunction{
	// NOTE: there's a handful of top-level resources which have specific overrides (e.g. the Resource Group Name etc.)
	models.EdgeZoneTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		dependencies.setNeedsEdgeZones()
		val := hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: "element(data.azurerm_extended_locations.test.extended_locations, 0)",
			},
		})
		return &val, nil
	},
	models.LocationTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		if strings.EqualFold(resourceLabel, "resource_group") {
			dependencies.variables.needsPrimaryLocation = true
			val := hclwrite.Tokens{
				{
					Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`var.primary_location`),
				},
			}
			return &val, nil
		}

		dependencies.setNeedsResourceGroup()
		val := hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_resource_group.test.location", providerPrefix),
			},
		})
		return &val, nil
	},
	models.ResourceGroupTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		if strings.EqualFold(resourceLabel, "resource_group") {
			dependencies.variables.needsRandomInteger = true
			val := hclwrite.Tokens{
				{
					Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`"acctestrg-${var.random_integer}"`),
				},
			}
			return &val, nil
		}

		dependencies.setNeedsResourceGroup()
		val := hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: fmt.Sprintf("%s_resource_group.test.name", providerPrefix),
			},
		})
		return &val, nil
	},
	models.TagsTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.ObjectVal(map[string]cty.Value{
			"environment": cty.StringVal("terraform-acctests"),
			"some_key":    cty.StringVal("some-value"),
		}))
		return &val, nil
	},
	models.ZoneTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.StringVal("1"))
		return &val, nil
	},
	models.ZonesTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix, resourceDisplayName string, testData definitions.VariablesDefinition) (*hclwrite.Tokens, error) {
		val := hclwrite.TokensForValue(cty.ListVal([]cty.Value{
			cty.StringVal("1"),
			cty.StringVal("2"),
			cty.StringVal("3"),
		}))
		return &val, nil
	},

	// NOTE: the following CommonSchema types are exposed as Blocks and not Attributes (valid under `terraform-plugin-sdk@v2` / protocol v5)
	// however this'll change in the future under `terraform-plugin-framework` / protocol v6
	//  * TerraformSchemaFieldTypeIdentitySystemAssigned
	//  * TerraformSchemaFieldTypeIdentitySystemAndUserAssigned
	//  * TerraformSchemaFieldTypeIdentitySystemOrUserAssigned
	//  * TerraformSchemaFieldTypeIdentityUserAssigned
}
