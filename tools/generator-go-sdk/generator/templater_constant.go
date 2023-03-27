package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type constantTemplater struct {
	name                          string
	details                       resourcemanager.ConstantDetails
	generateNormalizationFunction bool
}

func templateForConstant(name string, details resourcemanager.ConstantDetails, generateNormalizationFunc bool) (*string, error) {
	t := constantTemplater{
		name:                          name,
		details:                       details,
		generateNormalizationFunction: generateNormalizationFunc,
	}

	valueKeys := make([]string, 0)
	for key := range details.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	constantDefinition := t.constantDefinition()
	possibleValuesFunction := t.possibleValuesFunction()
	normalizationFunction := t.normalizationFunction()

	out := strings.Join([]string{
		constantDefinition,
		possibleValuesFunction,
		normalizationFunction,
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

func (t constantTemplater) normalizationFunction() string {
	if !t.generateNormalizationFunction || t.details.Type != resourcemanager.StringConstant {
		return ""
	}

	// since we're only normalizing string values, we're intentionally being opinionated here
	return fmt.Sprintf(`
func (s *%[1]s) UnmarshalJSON(bytes []byte) error {
	var decoded string
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %%+v", err)
	}
	for _, v := range PossibleValuesFor%[1]s() {
		if strings.EqualFold(v, decoded) {
			decoded = v
			break
		}
	}
	*s = %[1]s(decoded)
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
