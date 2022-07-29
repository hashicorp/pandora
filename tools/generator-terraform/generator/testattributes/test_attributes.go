package testattributes

import (
	"fmt"
	"sort"

	"github.com/zclconf/go-cty/cty"

	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTestConfig(input resourcemanager.TerraformSchemaModelDefinition) (string, error) {
	// fields should be sorted Required -> Optional -> Computed, and alphabetically within each category
	requiredFields := make([]string, 0)
	optionalFields := make([]string, 0)
	for fieldName, details := range input.Fields {
		if details.Required {
			requiredFields = append(requiredFields, fieldName)
			continue
		}

		if details.Optional {
			optionalFields = append(optionalFields, fieldName)
			continue
		}

		return "", fmt.Errorf("field %q is neither required/optional/computed", fieldName)
	}
	sort.Strings(requiredFields)
	sort.Strings(optionalFields)

	sortedNames := make([]string, 0)
	sortedNames = append(sortedNames, requiredFields...)
	sortedNames = append(sortedNames, optionalFields...)

	f := hclwrite.NewEmptyFile()
	rootBody := f.Body()
	for _, fieldName := range sortedNames {
		field := input.Fields[fieldName]
		if field.Required {
			switch field.ObjectDefinition.Type {
			// todo randomize values
			case resourcemanager.TerraformSchemaFieldTypeBoolean:
				rootBody.SetAttributeValue(fieldName, cty.False)
			case resourcemanager.TerraformSchemaFieldTypeFloat:
				rootBody.SetAttributeValue(fieldName, cty.NumberFloatVal(10.1))
			case resourcemanager.TerraformSchemaFieldTypeInteger:
				rootBody.SetAttributeValue(fieldName, cty.NumberIntVal(15))
			case resourcemanager.TerraformSchemaFieldTypeString:
				rootBody.SetAttributeValue(fieldName, cty.StringVal("foo"))
			}
		}
	}

	return fmt.Sprintf("%s", f.Bytes()), nil
}
