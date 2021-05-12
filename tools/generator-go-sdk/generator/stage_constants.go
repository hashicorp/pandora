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

func (c constantsTemplater) templateConstant(constantTypeName string, values resourcemanager.ConstantDetails) string {
	valueKeys := make([]string, 0)
	for key := range values.Values {
		valueKeys = append(valueKeys, key)
	}
	sort.Strings(valueKeys)

	lines := make([]string, 0)
	for _, constantKey := range valueKeys {
		constantValue := values.Values[constantKey]
		template := "\t%[2]s%[1]s %[2]s = %[3]q" // \tMyConstantValue MyConstant = "Value"
		lines = append(lines, fmt.Sprintf(template, constantKey, constantTypeName, constantValue))
	}

	//if values.CaseInsensitive {
	//	// TODO: handle this needing a custom deserializer/serializer for rewriting
	//}

	return fmt.Sprintf(`type %s string

const (
%s
)
`, constantTypeName, strings.Join(lines, "\n"))
}
