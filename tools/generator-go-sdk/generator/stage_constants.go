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
		line := c.templateConstant(constantName, values)
		lines = append(lines, line)
	}

	template := fmt.Sprintf(`package %[1]s

%s`, data.packageName, strings.Join(lines, "\n"))
	return &template, nil
}

func (c constantsTemplater) templateConstant(constantName string, values resourcemanager.ConstantDetails) string {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	definitionLines := make([]string, 0)
	valueLines := make([]string, 0)
	parseValuesLines := make([]string, 0)

	parseFunction := `
	// it could be a new value - best effort convert this
	v := input
`
	if values.Type == resourcemanager.FloatConstant {
		parseFunction = `
	v, err := strconv.ParseFloat(input, 64)
	if err != nil {
		return nil, fmt.Errorf("parsing %%q: %%+v", input, err)
	}
`
	}
	if values.Type == resourcemanager.IntegerConstant {
		parseFunction = `
	v, err := strconv.Atoi(input)
	if err != nil {
		return nil, fmt.Errorf("parsing %%q: %%+v", input, err)
	}
`
	}

	for _, constantKey := range valueKeys {
		constantValue := values.Values[constantKey]
		definitionTemplate := "\t%[2]s%[1]s %[2]s = %[3]q" // \tMyConstantValue MyConstant = "Value"
		valueTemplate := "%q,"
		parseValueTemplate := "%q: %q,"

		if values.Type == resourcemanager.IntegerConstant || values.Type == resourcemanager.FloatConstant {
			definitionTemplate = "\t%[2]s%[1]s %[2]s = %[3]s" // \tMyConstantValue MyConstant = 1.02
			valueTemplate = `fmt.Sprintf("%%d", %[1]s),`
			parseValueTemplate = "%q: %d,"

			if values.Type == resourcemanager.FloatConstant {
				valueTemplate = `fmt.Sprintf("%%f", %[1]s),`
				parseValueTemplate = "%q: %f,"
			}
		}
		definitionLines = append(definitionLines, fmt.Sprintf(definitionTemplate, constantKey, constantName, constantValue))
		valueLines = append(valueLines, fmt.Sprintf(valueTemplate, constantValue))
		parseValuesLines = append(parseValuesLines, fmt.Sprintf(parseValueTemplate, strings.ToLower(constantKey), constantValue))
	}

	//if values.CaseInsensitive {
	//	// TODO: handle this needing a custom deserializer/serializer for rewriting (available in the Parse method)
	//}

	constantType := mapConstantTypeToGoType(values.Type)
	return fmt.Sprintf(`type %[1]s %[2]s

const (
%[3]s
)

func PossibleValuesFor%[1]s() []string {
	return []string{
		%[4]s
	}
}

func parse%[1]s(input string) (*%[1]s, error) {
	vals := map[string]%[1]s{
		%[5]s
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
		return &v, nil
	}

	%[6]s

	out := %[1]s(v)
	return &out, nil
}
`, constantName, constantType, strings.Join(definitionLines, "\n"), strings.Join(valueLines, "\n"), strings.Join(parseValuesLines, "\n"), parseFunction)
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
