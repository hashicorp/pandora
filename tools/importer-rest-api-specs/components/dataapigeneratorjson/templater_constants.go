package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type Constant struct {
	Name   string  `json:"Name"`
	Type   string  `json:"Type"`
	Values []Value `json:"Values"`
}

type Value struct {
	Key         string  `json:"Key"`
	Value       string  `json:"Value"`
	Description *string `json:"Description,omitempty"`
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

	data, err := json.MarshalIndent(constant, "", " ")
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
