package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForConstant(namespace, constantName string, details models.ConstantDetails) string {
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
	attributes = append(attributes, fmt.Sprintf("\t[ConstantType(%s)]", mapConstantFieldType(details.FieldType)))

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace %[1]s
{
%[4]s
	internal enum %[2]s
	{
%[3]s
	}
}
`, namespace, constantName, strings.Join(code, "\n\n"), strings.Join(attributes, "\n"))
}

func mapConstantFieldType(input models.ConstantFieldType) string {
	if input == models.FloatConstant {
		return "ConstantTypeAttribute.ConstantType.Float"
	}

	if input == models.IntegerConstant {
		return "ConstantTypeAttribute.ConstantType.Integer"
	}

	if input == models.StringConstant {
		return "ConstantTypeAttribute.ConstantType.String"
	}

	return "TODO"
}

func (g PandoraDefinitionGenerator) normalizeConstantKey(input string) string {
	output := input
	output = strings.ReplaceAll(output, ",", "")
	output = strings.ReplaceAll(output, " ", "")
	return output
}
