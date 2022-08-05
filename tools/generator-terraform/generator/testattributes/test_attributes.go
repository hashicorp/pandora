package testattributes

import (
	"fmt"
	"sort"

	"github.com/hashicorp/hcl/v2"

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
		hclName := input.Fields[fieldName].HclName
		if hclName == "" {
			return fmt.Errorf("internal-error: hclName was empty for %q", fieldName)
		}
		if err := h.codeForTestAttribute(input.Fields[fieldName].ObjectDefinition, hclName, requiredOnly, hclBody); err != nil {
			return err
		}
	}
	return nil
}

func (h TestAttributesHelpers) codeForTestAttribute(input resourcemanager.TerraformSchemaFieldObjectDefinition, hclName string, requiredOnly bool, hclBody hclwrite.Body) error {
	switch input.Type {
	// todo randomize values
	case resourcemanager.TerraformSchemaFieldTypeBoolean:
		hclBody.SetAttributeValue(hclName, cty.False)
	case resourcemanager.TerraformSchemaFieldTypeFloat:
		hclBody.SetAttributeValue(hclName, cty.NumberFloatVal(10.1))
	case resourcemanager.TerraformSchemaFieldTypeInteger:
		hclBody.SetAttributeValue(hclName, cty.NumberIntVal(15))
	case resourcemanager.TerraformSchemaFieldTypeString:
		hclBody.SetAttributeValue(hclName, cty.StringVal("foo"))
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
		reference, ok := h.SchemaModels[*input.ReferenceName]
		if !ok {
			return fmt.Errorf("schema model %q was not found", *input.ReferenceName)
		}
		if err := h.GetAttributesForTests(reference, *hclBody.AppendNewBlock(hclName, nil).Body(), requiredOnly); err != nil {
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
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(hclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(hclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("UserAssigned"))
		identityBody.AppendNewline()
		identityBody.AppendUnstructuredTokens(hclwrite.TokensForTraversal(hcl.Traversal{
			hcl.TraverseRoot{
				Name: "// todo add azurerm_user_assigned_identity.test to template",
			},
		}))
		identityBody.AppendNewline()
		identityBody.SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_user_assigned_identity.test.id",
				},
			})}))
		hclBody.AppendNewline()

	}

	return nil
}
