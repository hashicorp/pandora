// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/zclconf/go-cty/cty"
)

func (tb testBuilder) getBlockValueForField(field sdkModels.TerraformSchemaField, dependencies *testDependencies, onlyRequiredFields bool, testData definitions.VariablesDefinition) (*[]*hclwrite.Block, error) {
	if function, isCommonSchema := blocksToCommonSchemaFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		val := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &[]*hclwrite.Block{
			val,
		}, nil
	}

	if field.ObjectDefinition.Type == sdkModels.ListTerraformSchemaObjectDefinitionType || field.ObjectDefinition.Type == sdkModels.SetTerraformSchemaObjectDefinitionType {
		var nestedBlock *hclwrite.Block
		var err error

		if field.ObjectDefinition.NestedObject.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
			nestedModelName := *field.ObjectDefinition.NestedObject.ReferenceName
			nestedModel, ok := tb.details.SchemaModels[nestedModelName]
			if !ok {
				return nil, fmt.Errorf("the schema model %q referenced by nested List/Set %q was not found", nestedModelName, field.HCLName)
			}

			// first go pull out the nested item
			nestedBlock, err = tb.getBlockValueForModel(field.HCLName, nestedModel, dependencies, onlyRequiredFields, testData)
			if err != nil {
				return nil, fmt.Errorf("retrieving block value for field %q containing nested List/Set reference to %q: %+v", field.HCLName, nestedModelName, err)
			}
		}

		if nestedBlock == nil {
			return nil, fmt.Errorf("internal-error: Lists and Sets currently only support a Reference or String - but got %q", string(field.ObjectDefinition.NestedObject.Type))
		}

		return &[]*hclwrite.Block{
			nestedBlock,
		}, nil
	}

	// if it's a Reference it's exposed as a List with `MaxItems: 1`
	if field.ObjectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
		nestedModelName := *field.ObjectDefinition.ReferenceName
		nestedModel, ok := tb.details.SchemaModels[nestedModelName]
		if !ok {
			return nil, fmt.Errorf("the referenced SchemaModel %q was not found", nestedModelName)
		}

		nestedBlock, err := tb.getBlockValueForModel(field.HCLName, nestedModel, dependencies, onlyRequiredFields, testData)
		if err != nil {
			return nil, fmt.Errorf("retrieving block value for field %q's nested model %q: %+v", field.HCLName, nestedModelName, err)
		}
		return &[]*hclwrite.Block{
			nestedBlock,
		}, nil
	}

	return nil, fmt.Errorf("not implemented")
}

type blockValueFunction func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block

var blocksToCommonSchemaFunctions = map[sdkModels.TerraformSchemaObjectDefinitionType]blockValueFunction{
	sdkModels.SystemAssignedIdentityTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		block := hclwrite.NewBlock(field.HCLName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		return block
	},
	sdkModels.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		dependencies.setNeedsUserAssignedIdentity()

		block := hclwrite.NewBlock(field.HCLName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("SystemAssigned, UserAssigned"))
		block.Body().SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: fmt.Sprintf("%s_user_assigned_identity.test.id", providerPrefix),
				},
			}),
		}))
		return block
	},
	sdkModels.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		block := hclwrite.NewBlock(field.HCLName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		block.Body().SetAttributeValue("identity_ids", cty.ListValEmpty(cty.String))
		return block
	},
	sdkModels.UserAssignedIdentityTerraformSchemaObjectDefinitionType: func(field sdkModels.TerraformSchemaField, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		dependencies.setNeedsUserAssignedIdentity()

		block := hclwrite.NewBlock(field.HCLName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("UserAssigned"))
		block.Body().SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: fmt.Sprintf("%s_user_assigned_identity.test.id", providerPrefix),
				},
			}),
		}))
		return block
	},
}
