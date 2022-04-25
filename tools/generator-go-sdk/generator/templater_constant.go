package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type constantTemplater struct {
	name    string
	details resourcemanager.ConstantDetails
}

func templateForConstant(name string, details resourcemanager.ConstantDetails) (*string, error) {
	t := constantTemplater{
		name:    name,
		details: details,
	}

	valueKeys := make([]string, 0)
	for key := range details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	// TODO: handle this needing a custom deserializer/serializer for rewriting (available in the Parse function)
	constantDefinition := t.constantDefinition()
	possibleValuesFunction := t.possibleValuesFunction()

	parseFunction, err := t.parseFunction()
	if err != nil {
		return nil, fmt.Errorf("generating parse function: %+v", err)
	}

	out := strings.Join([]string{
		constantDefinition,
		possibleValuesFunction,
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

		if t.details.Type == resourcemanager.IntegerConstant || t.details.Type == resourcemanager.FloatConstant {
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
	valueKeys := make([]string, 0)
	for key := range t.details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	if t.details.Type == resourcemanager.FloatConstant || t.details.Type == resourcemanager.IntegerConstant {
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

	if t.details.Type != resourcemanager.StringConstant {
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
	if t.details.Type == resourcemanager.FloatConstant {
		return "float64"
	}

	if t.details.Type == resourcemanager.IntegerConstant {
		return "int64"
	}

	if t.details.Type == resourcemanager.StringConstant {
		return "string"
	}

	return "TODO"
}
