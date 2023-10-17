package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForConstant(constantName string, details resourcemanager.ConstantDetails) ([]byte, error) {
	mapped, err := mapConstant(constantName, details)
	if err != nil {
		return nil, err
	}

	data, err := json.MarshalIndent(mapped, "", "\t")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func mapConstant(constantName string, details resourcemanager.ConstantDetails) (*models.Constant, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]models.ConstantValue)
	for _, key := range details.Values {
		keys = append(keys, key)
		keysToValues[key] = models.ConstantValue{
			Key:   key,
			Value: details.Values[key],
			// TODO: expose Description in the future when this is surfaced from the Parser
		}
	}
	sort.Strings(keys)

	values := make([]models.ConstantValue, 0)
	for _, key := range keys {
		value := keysToValues[key]
		values = append(values, value)
	}

	constantType, err := mapConstantFieldType(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}

	return &models.Constant{
		Name:   constantName,
		Type:   pointer.From(constantType),
		Values: values,
	}, nil
}

func mapConstantFieldType(input resourcemanager.ConstantType) (*models.ConstantType, error) {
	mappings := map[resourcemanager.ConstantType]models.ConstantType{
		resourcemanager.FloatConstant:   models.FloatConstant,
		resourcemanager.IntegerConstant: models.IntegerConstant,
		resourcemanager.StringConstant:  models.StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}
