package dataapigeneratoryaml

import (
	"fmt"
	"sort"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type Constant struct {
	Name   string  `yaml:"Name"`
	Type   string  `yaml:"Type"`
	Values []Value `yaml:"Values"`
}

type Value struct {
	Key         string  `yaml:"Key"`
	Value       string  `yaml:"Value"`
	Description *string `yaml:"Description,omitempty"`
}

func codeForConstant(constantName string, details resourcemanager.ConstantDetails) ([]byte, error) {
	sortedKeys := make([]string, 0)
	for key := range details.Values {
		sortedKeys = append(sortedKeys, key)
	}
	sort.Strings(sortedKeys)

	values := make([]Value, 0)

	for _, key := range sortedKeys {
		value := Value{
			Key:   key,
			Value: details.Values[key],
			// TODO Description isn't available in the ConstantDetails model
		}

		values = append(values, value)
	}

	constantType, err := mapConstantFieldType(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}

	constant := Constant{
		Name:   constantName,
		Type:   pointer.From(constantType),
		Values: values,
	}

	data, err := yaml.Marshal(constant)
	if err != nil {
		return nil, err
	}

	return data, nil
}

func mapConstantFieldType(input resourcemanager.ConstantType) (*string, error) {
	result := func(in string) (*string, error) {
		return pointer.To(in), nil
	}
	if input == resourcemanager.FloatConstant {
		return result("float")
	}

	if input == resourcemanager.IntegerConstant {
		return result("int")
	}

	if input == resourcemanager.StringConstant {
		return result("string")
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}
