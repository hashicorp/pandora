package testing

import (
	"fmt"
	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

func (tb TestBuilder) getBlockValueForField(field resourcemanager.TerraformSchemaFieldDefinition, dependencies *testDependencies) (*[]*hclwrite.Block, error) {
	if function, isCommonSchema := blocksToCommonSchemaFunctions[field.ObjectDefinition.Type]; isCommonSchema {
		val := function(field, dependencies, tb.resourceLabel, tb.providerPrefix)
		return &[]*hclwrite.Block{
			val,
		}, nil
	}

	// TODO: handle a Block being a List and a Set (e.g. call this function, get the block and nest it

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
