package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTemplaterModelsParent(t *testing.T) {
	actual, err := modelsTemplater{
		name: "ModeOfTransit",
		model: resourcemanager.ModelDetails{
			TypeHintIn: stringPointer("Type"),
			Fields: map[string]resourcemanager.FieldDetails{
				"Type": {
					IsTypeHint: true,
					JsonName:   "type",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"ModeOfTransit": {
				TypeHintIn: stringPointer("Type"),
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						IsTypeHint: true,
						JsonName:   "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Car": {
				ParentTypeName: stringPointer("ModeOfTransit"),
				TypeHintIn:     stringPointer("Type"),
				TypeHintValue:  stringPointer("car"),
			},
			"Train": {
				ParentTypeName: stringPointer("ModeOfTransit"),
				TypeHintIn:     stringPointer("Type"),
				TypeHintValue:  stringPointer("train"),
			},
		},
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := strings.ReplaceAll(`package somepackage

import (
	"encoding/json"
	"fmt"
	"strings"
	"time"
	"github.com/hashicorp/go-azure-helpers/lang/dates"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
)

type ModeOfTransit interface {
}

func unmarshalModeOfTransitImplementation(input []byte) (ModeOfTransit, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling ModeOfTransit into map[string]interface: %+v", err)
	}

	value, ok := temp["type"].(string)
	if !ok {
		return nil, nil
	}

	if strings.EqualFold(value, "car") {
		var out Car
		if err := json.Unmarshal(input, &out); err != nil {
			return nil, fmt.Errorf("unmarshaling into Car: %+v", err)
		}
		return out, nil
	}

	if strings.EqualFold(value, "Train") {
		var out Train
		if err := json.Unmarshal(input, &out); err != nil {
			return nil, fmt.Errorf("unmarshaling into Train: %+v", err)
		}
		return out, nil
	}

	type RawModeOfTransitImpl struct {
		Type string ''json:"-"''
		Values map[string]interface{} ''json:"-"''
	}
	out := RawModeOfTransitImpl{
		Type:   value,
		Values: temp,
	}
	return out, nil

}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
