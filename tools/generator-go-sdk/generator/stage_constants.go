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

	if err := s.writeToPath("constants.go", constantsTemplater{}, data); err != nil {
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

	lines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := values.Values[constantKey]
		template := "\t%[2]s%[1]s %[2]s = %[3]q" // \tMyConstantValue MyConstant = "Value"
		if values.Type == resourcemanager.IntegerConstant || values.Type == resourcemanager.FloatConstant {
			template = "\t%[2]s%[1]s %[2]s = %[3]s" // \tMyConstantValue MyConstant = 1.02
		}
		lines = append(lines, fmt.Sprintf(template, constantKey, constantName, constantValue))
	}

	//if values.CaseInsensitive {
	//	// TODO: handle this needing a custom deserializer/serializer for rewriting
	//}

	constantType := mapConstantTypeToGoType(values.Type)
	return fmt.Sprintf(`type %[1]s %[2]s

const (
%[3]s
)
`, constantName, constantType, strings.Join(lines, "\n"))
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
