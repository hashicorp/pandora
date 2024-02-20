package transforms

import (
	"fmt"
	"sort"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapConstantToRepository(constantName string, details resourcemanager.ConstantDetails) (*dataapimodels.Constant, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]dataapimodels.ConstantValue)
	for k, v := range details.Values {
		keys = append(keys, k)
		keysToValues[k] = dataapimodels.ConstantValue{
			Key:   k,
			Value: v,
			// TODO: expose Description in the future when this is surfaced from the Parser
		}
	}
	sort.Strings(keys)

	values := make([]dataapimodels.ConstantValue, 0)
	for _, key := range keys {
		value := keysToValues[key]
		values = append(values, value)
	}

	constantType, err := mapConstantTypeToRepository(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}

	return &dataapimodels.Constant{
		Name:   constantName,
		Type:   pointer.From(constantType),
		Values: values,
	}, nil
}

func mapConstantTypeToRepository(input resourcemanager.ConstantType) (*dataapimodels.ConstantType, error) {
	mappings := map[resourcemanager.ConstantType]dataapimodels.ConstantType{
		resourcemanager.FloatConstant:   dataapimodels.FloatConstant,
		resourcemanager.IntegerConstant: dataapimodels.IntegerConstant,
		resourcemanager.StringConstant:  dataapimodels.StringConstant,
	}
	if v, ok := mappings[input]; ok {
		return &v, nil
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}
