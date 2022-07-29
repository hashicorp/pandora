package testattributes

import (
	"fmt"
	"sort"

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
		field := input.Fields[fieldName]
		switch field.ObjectDefinition.Type {
		// todo randomize values
		case resourcemanager.TerraformSchemaFieldTypeBoolean:
			hclBody.SetAttributeValue(fieldName, cty.False)
		case resourcemanager.TerraformSchemaFieldTypeFloat:
			hclBody.SetAttributeValue(fieldName, cty.NumberFloatVal(10.1))
		case resourcemanager.TerraformSchemaFieldTypeInteger:
			hclBody.SetAttributeValue(fieldName, cty.NumberIntVal(15))
		case resourcemanager.TerraformSchemaFieldTypeString:
			hclBody.SetAttributeValue(fieldName, cty.StringVal("foo"))
		case resourcemanager.TerraformSchemaFieldTypeList, resourcemanager.TerraformSchemaFieldTypeSet:
			hclBody.AppendNewline()
			if field.ObjectDefinition.NestedObject.ReferenceName == nil {
				return fmt.Errorf("missing name for reference")
			}
			reference, ok := h.SchemaModels[*field.ObjectDefinition.NestedObject.ReferenceName]
			if !ok {
				return fmt.Errorf("schema model %q was not found", *field.ObjectDefinition.NestedObject.ReferenceName)
			}
			if err := h.GetAttributesForTests(reference, *hclBody.AppendNewBlock(fieldName, nil).Body(), requiredOnly); err != nil {
				return err
			}
			hclBody.AppendNewline()
		}
	}
	return nil
}
