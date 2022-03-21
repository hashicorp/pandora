package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (s *ServiceGenerator) constants(data ServiceGeneratorData) error {
	if len(data.constants) == 0 {
		return nil
	}

	if err := s.writeToPath(data.outputPath, "constants.go", constantsTemplater{}, data); err != nil {
		return fmt.Errorf("templating constants: %+v", err)
	}

	return nil
}

var _ templater = constantsTemplater{}

type constantsTemplater struct {
}

func (c constantsTemplater) template(data ServiceGeneratorData) (*string, error) {
	keys := make([]string, 0)
	for name := range data.constants {
		keys = append(keys, name)
	}
	sort.Strings(keys)

	lines := make([]string, 0)
	for _, constantName := range keys {
		values := data.constants[constantName]
		line, err := c.templateConstant(constantName, values)
		if err != nil {
			return nil, fmt.Errorf("generating template for constant %q: %+v", constantName, err)
		}
		lines = append(lines, *line)
	}

	template := fmt.Sprintf(`package %[1]s

import "strings"

%s`, data.packageName, strings.Join(lines, "\n"))
	return &template, nil
}

func (c constantsTemplater) templateConstant(constantName string, values resourcemanager.ConstantDetails) (*string, error) {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	// TODO: handle this needing a custom deserializer/serializer for rewriting (available in the Parse function)
	constantDefinition := c.constantDefinition(constantName, values)
	possibleValuesFunction := c.possibleValuesFunction(constantName, values)

	parseFunction, err := c.parseFunction(constantName, values)
	if err != nil {
		return nil, fmt.Errorf("generating parse function: %+v", err)
	}

	out := fmt.Sprintf(`%[1]s
%[2]s
%[3]s
`, constantDefinition, possibleValuesFunction, *parseFunction)
	return &out, nil
}

func (c constantsTemplater) constantDefinition(constantName string, values resourcemanager.ConstantDetails) string {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	definitionLines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := values.Values[constantKey]
		definitionTemplate := "\t%[2]s%[1]s %[2]s = %[3]q" // \tMyConstantValue MyConstant = "Value"

		if values.Type == resourcemanager.IntegerConstant || values.Type == resourcemanager.FloatConstant {
			definitionTemplate = "\t%[2]s%[1]s %[2]s = %[3]s" // \tMyConstantValue MyConstant = 1.02
		}
		definitionLines = append(definitionLines, fmt.Sprintf(definitionTemplate, constantKey, constantName, constantValue))
	}

	constantType := mapConstantTypeToGoType(values.Type)
	return fmt.Sprintf(`
type %[1]s %[2]s

const (
%[3]s
)
`, constantName, constantType, strings.Join(definitionLines, "\n"))
}

func (c constantsTemplater) possibleValuesFunction(constantName string, values resourcemanager.ConstantDetails) string {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	typeName := mapConstantTypeToGoType(values.Type)
	lines := make([]string, 0)
	for _, constantKey := range valueKeys {
		lines = append(lines, fmt.Sprintf("%s(%s%s),", typeName, constantName, constantKey))
	}

	return fmt.Sprintf(`
func PossibleValuesFor%[1]s() []%[2]s {
	return []%[2]s{
		%[3]s
	}
}
`, constantName, typeName, strings.Join(lines, "\n"))
}

func (c constantsTemplater) parseFunction(constantName string, values resourcemanager.ConstantDetails) (*string, error) {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	if values.Type == resourcemanager.FloatConstant || values.Type == resourcemanager.IntegerConstant {
		mapLines := make([]string, 0)
		for _, constantKey := range valueKeys {
			constantValue := values.Values[constantKey]
			// whilst the key may look weird here, constantValue is a string containing the formatted int/float value
			// as such we output that raw without any parsing/formatting
			mapLines = append(mapLines, fmt.Sprintf("%s: %s%s,", strings.ToLower(constantValue), constantName, constantKey))
		}
		typeName := mapConstantTypeToGoType(values.Type)

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
`, constantName, strings.Join(mapLines, "\n"), typeName)
		return &out, nil
	}

	if values.Type != resourcemanager.StringConstant {
		return nil, fmt.Errorf("unimplemented constant type %q", string(values.Type))
	}

	mapLines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := values.Values[constantKey]
		mapLines = append(mapLines, fmt.Sprintf("%q: %s%s,", strings.ToLower(constantValue), constantName, constantKey))
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
`, constantName, strings.Join(mapLines, "\n"))
	return &out, nil
}

func mapConstantTypeToGoType(input resourcemanager.ConstantType) string {
	if input == resourcemanager.FloatConstant {
		return "float64"
	}

	if input == resourcemanager.IntegerConstant {
		return "int64"
	}

	if input == resourcemanager.StringConstant {
		return "string"
	}

	return "TODO"
}
