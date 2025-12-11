// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type constantTemplater struct {
	name                          string
	details                       models.SDKConstant
	generateNormalizationFunction bool
	constantUsedInAResourceID     bool
}

func templateForConstant(name string, details models.SDKConstant, generateNormalizationFunc, usedInAResourceId bool) (*string, error) {
	t := constantTemplater{
		name:                          name,
		details:                       details,
		generateNormalizationFunction: generateNormalizationFunc,
		constantUsedInAResourceID:     usedInAResourceId,
	}

	valueKeys := make([]string, 0)
	for key := range details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	constantDefinition := t.constantDefinition()
	possibleValuesFunction := t.possibleValuesFunction()
	normalizationFunction := t.normalizationFunction()

	parseFunction, err := t.parseFunction()
	if err != nil {
		return nil, fmt.Errorf("generating parse function: %+v", err)
	}

	out := strings.Join([]string{
		constantDefinition,
		possibleValuesFunction,
		normalizationFunction,
		*parseFunction,
	}, "\n")
	return &out, nil
}

func (t constantTemplater) constantDefinition() string {
	valueKeys := make([]string, 0)
	for key := range t.details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	definitionLines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := t.details.Values[constantKey]
		definitionTemplate := "\t%[2]s%[1]s %[2]s = %[3]q" // \tMyConstantValue MyConstant = "Value"

		if t.details.Type == models.IntegerSDKConstantType || t.details.Type == models.FloatSDKConstantType {
			definitionTemplate = "\t%[2]s%[1]s %[2]s = %[3]s" // \tMyConstantValue MyConstant = 1.02
		}
		definitionLines = append(definitionLines, fmt.Sprintf(definitionTemplate, constantKey, t.name, constantValue))
	}

	constantType := t.mapToGoType()
	return fmt.Sprintf(`
type %[1]s %[2]s

const (
%[3]s
)
`, t.name, constantType, strings.Join(definitionLines, "\n"))
}

func (t constantTemplater) normalizationFunction() string {
	if !t.generateNormalizationFunction || t.details.Type != models.StringSDKConstantType {
		return ""
	}

	// since we're only normalizing string values, we're intentionally being opinionated here
	return fmt.Sprintf(`
func (s *%[1]s) UnmarshalJSON(bytes []byte) error {
	var decoded string
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %%+v", err)
	}
	out, err := parse%[1]s(decoded)
	if err != nil {
		return fmt.Errorf("parsing %%q: %%+v", decoded, err)
	}
	*s = *out
	return nil
}
`, t.name)
}

func (t constantTemplater) possibleValuesFunction() string {
	valueKeys := make([]string, 0)
	for key := range t.details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	typeName := t.mapToGoType()
	lines := make([]string, 0)
	for _, constantKey := range valueKeys {
		lines = append(lines, fmt.Sprintf("%s(%s%s),", typeName, t.name, constantKey))
	}

	return fmt.Sprintf(`
func PossibleValuesFor%[1]s() []%[2]s {
	return []%[2]s{
		%[3]s
	}
}
`, t.name, typeName, strings.Join(lines, "\n"))
}

func (t constantTemplater) parseFunction() (*string, error) {
	// we only output the parse function if it's a String constant (in which case it'll be needed by the Normalization function)
	// or if the Constant is used in a Resource ID segment (since that calls this to parse the Resource ID segment)
	// we could output this always, but this reduces the TLOC we output, which is preferable.
	requiresParseFunction := t.details.Type == models.StringSDKConstantType || t.constantUsedInAResourceID
	if !requiresParseFunction {
		return pointer.To(""), nil
	}

	valueKeys := make([]string, 0)
	for key := range t.details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	if t.details.Type == models.FloatSDKConstantType || t.details.Type == models.IntegerSDKConstantType {
		mapLines := make([]string, 0)
		for _, constantKey := range valueKeys {
			constantValue := t.details.Values[constantKey]
			// whilst the key may look weird here, constantValue is a string containing the formatted int/float value
			// as such we output that raw without any parsing/formatting
			mapLines = append(mapLines, fmt.Sprintf("%s: %s%s,", strings.ToLower(constantValue), t.name, constantKey))
		}
		typeName := t.mapToGoType()

		out := fmt.Sprintf(`
func parse%[1]s(input %[3]s) (*%[1]s, error) {
	vals := map[%[3]s]%[1]s{
		%[2]s
	}
	if v, ok := vals[input]; ok {
		return &v, nil
	}

	// otherwise presume it's an undefined value and best-effort it
	out := %[1]s(input)
	return &out, nil
}
`, t.name, strings.Join(mapLines, "\n"), typeName)
		return &out, nil
	}

	if t.details.Type != models.StringSDKConstantType {
		return nil, fmt.Errorf("unimplemented constant type %q", string(t.details.Type))
	}

	mapLines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := t.details.Values[constantKey]
		mapLines = append(mapLines, fmt.Sprintf("%q: %s%s,", strings.ToLower(constantValue), t.name, constantKey))
	}
	out := fmt.Sprintf(`
func parse%[1]s(input string) (*%[1]s, error) {
	vals := map[string]%[1]s{
		%[2]s
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
		return &v, nil
	}

	// otherwise presume it's an undefined value and best-effort it
	out := %[1]s(input)
	return &out, nil
}
`, t.name, strings.Join(mapLines, "\n"))
	return &out, nil
}

func (t constantTemplater) mapToGoType() string {
	if t.details.Type == models.FloatSDKConstantType {
		return "float64"
	}

	if t.details.Type == models.IntegerSDKConstantType {
		return "int64"
	}

	if t.details.Type == models.StringSDKConstantType {
		return "string"
	}

	return "TODO"
}
