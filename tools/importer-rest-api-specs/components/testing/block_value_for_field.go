package testing

import (
	"fmt"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func (tb TestBuilder) getBlockValueForField(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, onlyRequiredFields bool) (*[]*hclwrite.Block, error) {
	if function, isCommonSchema := blocksToCommonSchemaFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		val := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &[]*hclwrite.Block{
			val,
		}, nil
	}

	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList || field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeSet {
		// TODO: support for Lists of Basic Types
		if field.ObjectDefinition.NestedObject.Type != resourcemanager.TerraformSchemaFieldTypeReference {
			return nil, fmt.Errorf("internal-error: Lists and Sets currently only support a Reference - but got %q", string(field.ObjectDefinition.NestedObject.Type))
		}

		nestedModelName := *field.ObjectDefinition.NestedObject.ReferenceName
		nestedModel, ok := tb.details.SchemaModels[nestedModelName]
		if !ok {
			return nil, fmt.Errorf("TODO")
		}

		// first go pull out the nested item
		nestedBlock, err := tb.getBlockValueForModel(field.HclName, nestedModel, dependencies, onlyRequiredFields)
		if err != nil {
			return nil, fmt.Errorf("retrieving block value for field %q containing nested List/Set reference to %q: %+v", field.HclName, nestedModelName, err)
		}

		if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList {
			return &[]*hclwrite.Block{
				nestedBlock,
			}, nil
		}

		return &[]*hclwrite.Block{
			nestedBlock,
		}, nil
	}

	// if it's a Reference it's exposed as a List with `MaxItems: 1`
	if field.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
		nestedModelName := *field.ObjectDefinition.ReferenceName
		nestedModel, ok := tb.details.SchemaModels[nestedModelName]
		if !ok {
			return nil, fmt.Errorf("the referenced SchemaModel %q was not found", nestedModelName)
		}

		nestedBlock, err := tb.getBlockValueForModel(field.HclName, nestedModel, dependencies, onlyRequiredFields)
		if err != nil {
			return nil, fmt.Errorf("retrieving block value for field %q's nested model %q: %+v", field.HclName, nestedModelName, err)
		}
		return &[]*hclwrite.Block{
			nestedBlock,
		}, nil
	}

	return nil, fmt.Errorf("not implemented")
}

type blockValueFunction func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block

var blocksToCommonSchemaFunctions = map[resourcemanager.TerraformSchemaFieldType]blockValueFunction{
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		block := hclwrite.NewBlock(field.HclName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		return block
	},
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		dependencies.setNeedsUserAssignedIdentity()

		block := hclwrite.NewBlock(field.HclName, []string{})
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
	resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		block := hclwrite.NewBlock(field.HclName, []string{})
		block.Body().SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		block.Body().SetAttributeValue("identity_ids", cty.ListValEmpty(cty.String))
		return block
	},
	resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned: func(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies, resourceLabel, providerPrefix string) *hclwrite.Block {
		dependencies.setNeedsUserAssignedIdentity()

		block := hclwrite.NewBlock(field.HclName, []string{})
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
