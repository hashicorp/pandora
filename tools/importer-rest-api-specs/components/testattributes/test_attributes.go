package testattributes

import (
	"fmt"
	"sort"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

type TestAttributesHelpers struct {
	SchemaModels map[string]resourcemanager.TerraformSchemaModelDefinition
}

// GetAttributesForTests builds terraform configuration based on the attributes passed in.
// It can get either Required only or Required/Optional Attributes
func (h TestAttributesHelpers) GetAttributesForTests(input resourcemanager.TerraformSchemaModelDefinition, hclBody hclwrite.Body, requiredOnly bool) error {
	requiredFields := make([]string, 0)
	optionalFields := make([]string, 0)
	for fieldName, details := range input.Fields {
		if details.Required {
			requiredFields = append(requiredFields, fieldName)
			continue
		}
		if !requiredOnly {
			if details.Optional {
				optionalFields = append(optionalFields, fieldName)
				continue
			}
		}
	}

	sort.Strings(requiredFields)
	sortedNames := make([]string, 0)
	sortedNames = append(sortedNames, requiredFields...)

	if !requiredOnly {
		sort.Strings(optionalFields)
		sortedNames = append(sortedNames, optionalFields...)
	}

	for _, fieldName := range sortedNames {
		if err := h.codeForTestAttribute(input, input.Fields[fieldName].ObjectDefinition, input.Fields[fieldName].HclName, requiredOnly, hclBody); err != nil {
			return err
		}
	}
	return nil
}

func (h TestAttributesHelpers) codeForTestAttribute(models resourcemanager.TerraformSchemaModelDefinition, input resourcemanager.TerraformSchemaFieldObjectDefinition, hclName string, requiredOnly bool, hclBody hclwrite.Body) error {
	switch input.Type {
	// todo randomize values
	case resourcemanager.TerraformSchemaFieldTypeBoolean:
		hclBody.SetAttributeValue(hclName, cty.False)
	case resourcemanager.TerraformSchemaFieldTypeFloat:
		hclBody.SetAttributeValue(hclName, cty.NumberFloatVal(10.1))
	case resourcemanager.TerraformSchemaFieldTypeInteger:
		hclBody.SetAttributeValue(hclName, cty.NumberIntVal(15))
	case resourcemanager.TerraformSchemaFieldTypeString:
		switch hclName {
		case "name":
			// todo pipe in packagename to make "acctest-vm-${local.random_integer}"
			tokens := hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`"acctest-`)},
				{Type: hclsyntax.TokenTemplateInterp, Bytes: []byte(`${`)},
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`local.random_integer}"`)},
			}
			hclBody.SetAttributeRaw(hclName, tokens)
		default:
			hclBody.SetAttributeValue(hclName, cty.StringVal("foo"))
		}
	case resourcemanager.TerraformSchemaFieldTypeList, resourcemanager.TerraformSchemaFieldTypeSet:
		hclBody.AppendNewline()
		if input.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			if input.NestedObject.ReferenceName == nil {
				return fmt.Errorf("missing name for reference")
			}
			reference, ok := h.SchemaModels[*input.NestedObject.ReferenceName]
			if !ok {
				return fmt.Errorf("schema model %q was not found", *input.NestedObject.ReferenceName)
			}
			if err := h.GetAttributesForTests(reference, *hclBody.AppendNewBlock(hclName, nil).Body(), requiredOnly); err != nil {
				return err
			}
		} else {
			// this is an array of a basic type
			switch input.NestedObject.Type {
			case resourcemanager.TerraformSchemaFieldTypeFloat:
				hclBody.SetAttributeValue(hclName, cty.ListVal([]cty.Value{
					cty.NumberFloatVal(1.1),
					cty.NumberFloatVal(2.2),
					cty.NumberFloatVal(3.3)}))
			case resourcemanager.TerraformSchemaFieldTypeInteger:
				hclBody.SetAttributeValue(hclName, cty.ListVal([]cty.Value{
					cty.NumberIntVal(1),
					cty.NumberIntVal(2),
					cty.NumberIntVal(3)}))
			case resourcemanager.TerraformSchemaFieldTypeString:
				hclBody.SetAttributeValue(hclName, cty.ListVal([]cty.Value{
					cty.StringVal("foo"),
					cty.StringVal("baz")}))
			default:
				return fmt.Errorf("internal-error: unimplemented schema field for nested object type %q", string(input.NestedObject.Type))
			}
		}

		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeReference:
		hclBody.AppendNewline()
		if input.ReferenceName == nil {
			return fmt.Errorf("missing name for reference")
		}
		_, ok := h.SchemaModels[*input.ReferenceName]
		if !ok {
			return fmt.Errorf("schema model %q was not found", *input.ReferenceName)
		}
		if err := h.GetAttributesForTests(h.SchemaModels[*input.ReferenceName], *hclBody.AppendNewBlock(hclName, nil).Body(), requiredOnly); err != nil {
			return err
		}
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeEdgeZone:
		// todo put in the checks for correct Required/Optional/Computed usage?
		hclBody.SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: "data.azurerm_extended_locations.test.extended_locations[0]",
			},
		})
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned, resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(hclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(hclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("SystemAssigned, UserAssigned"))
		addCommentToTestConfig(identityBody, "todo add azurerm_user_assigned_identity.test to template")

		identityBody.SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_user_assigned_identity.test.id",
				},
			})}))
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(hclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("UserAssigned"))
		addCommentToTestConfig(identityBody, "todo add azurerm_user_assigned_identity.test to template")

		identityBody.SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_user_assigned_identity.test.id",
				},
			})}))
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeLocation:
		// todo 99% of the time, this is based off a resource group. Account for that 1%?
		hclBody.SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: "azurerm_resource_group.test.location",
			},
		})
	case resourcemanager.TerraformSchemaFieldTypeResourceGroup:
		hclBody.SetAttributeTraversal(hclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: "azurerm_resource_group.test.name",
			},
		})
	case resourcemanager.TerraformSchemaFieldTypeTags:
		hclBody.SetAttributeValue("tags", cty.ObjectVal(map[string]cty.Value{
			"env":  cty.StringVal("Production"),
			"test": cty.StringVal("Acceptance"),
		}))
	case resourcemanager.TerraformSchemaFieldTypeZone:
		hclBody.SetAttributeValue(hclName, cty.NumberIntVal(1))
	case resourcemanager.TerraformSchemaFieldTypeZones:
		hclBody.SetAttributeValue(hclName, cty.ListVal([]cty.Value{
			cty.StringVal("1")}))
	}

	return nil
}

func addCommentToTestConfig(hclBody hclwrite.Body, comment string) {
	hclBody.AppendNewline()
	hclBody.AppendUnstructuredTokens(hclwrite.TokensForTraversal(hcl.Traversal{
		hcl.TraverseRoot{
			Name: fmt.Sprintf("// %s", comment),
		},
	}))
	hclBody.AppendNewline()
}
