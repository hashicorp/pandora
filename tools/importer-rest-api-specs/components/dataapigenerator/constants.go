package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForConstant(namespace, constantName string, details models.ConstantDetails) (*string, error) {
	code := make([]string, 0)

	sortedKeys := make([]string, 0)
	for key := range details.Values {
		sortedKeys = append(sortedKeys, key)
	}
	sort.Strings(sortedKeys)

	for _, key := range sortedKeys {
		value := details.Values[key]
		normalizedKey := g.normalizeConstantKey(key) // NOTE: it should be possible to remove this since the data's normalized now
		code = append(code, fmt.Sprintf("\t\t[Description(%q)]\n\t\t%s,", value, normalizedKey))
	}

	attributes := make([]string, 0)
	constantFieldType, err := mapConstantFieldType(details.FieldType)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.FieldType), err)
	}
	attributes = append(attributes, fmt.Sprintf("\t[ConstantType(%s)]", *constantFieldType))

	out := fmt.Sprintf(`using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace %[1]s;

%[4]s
internal enum %[2]sConstant
{
%[3]s
}
`, namespace, constantName, strings.Join(code, "\n\n"), strings.Join(attributes, "\n"))
	return &out, nil
}

func mapConstantFieldType(input models.ConstantFieldType) (*string, error) {
	result := func(in string) (*string, error) {
		return &in, nil
	}
	if input == models.FloatConstant {
		return result("ConstantTypeAttribute.ConstantType.Float")
	}

	if input == models.IntegerConstant {
		return result("ConstantTypeAttribute.ConstantType.Integer")
	}

	if input == models.StringConstant {
		return result("ConstantTypeAttribute.ConstantType.String")
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}

func (g PandoraDefinitionGenerator) normalizeConstantKey(input string) string {
	output := input
	output = strings.ReplaceAll(output, ",", "")
	output = strings.ReplaceAll(output, " ", "")
	return output
}
