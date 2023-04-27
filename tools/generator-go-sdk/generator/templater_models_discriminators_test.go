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
		source: AccTestLicenceType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/edgezones"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/systemdata"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
)

// acctests licence placeholder

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

func TestTemplaterModelsImplementation(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Train",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Number": {
					Required: true,
					JsonName: "number",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				"Operator": {
					Required: true,
					JsonName: "operator",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
			ParentTypeName: stringPointer("ModeOfTransit"),
			TypeHintIn:     stringPointer("Type"),
			TypeHintValue:  stringPointer("train"),
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
			"Train": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Number": {
						Required: true,
						JsonName: "number",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
					"Operator": {
						Required: true,
						JsonName: "operator",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
				ParentTypeName: stringPointer("ModeOfTransit"),
				TypeHintIn:     stringPointer("Type"),
				TypeHintValue:  stringPointer("train"),
			},
		},
		source: AccTestLicenceType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/edgezones"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/systemdata"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
)

// acctests licence placeholder

var _ ModeOfTransit = Train{}

type Train struct {
	Number string ''json:"number"''
	Operator string ''json:"operator"''

	// Fields inherited from ModeOfTransit
}

var _ json.Marshaler = Train{}

func (s Train) MarshalJSON() ([]byte, error) {
	type wrapper Train
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling Train: %+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Train: %+v", err)
	}
	decoded["type"] = "train"

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling Train: %+v", err)
	}

	return encoded, nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsImplementationInheritedFromParentType(t *testing.T) {
	actual, err := modelsTemplater{
		name: "FirstImplementation",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Serialization": {
					Required: true,
					JsonName: "serialization",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("Serialization"),
					},
				},
			},
			ParentTypeName: stringPointer("First"),
			TypeHintIn:     stringPointer("Type"),
			TypeHintValue:  stringPointer("first"),
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"First": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						Required: true,
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
			},
			"FirstImplementation": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Serialization": {
						Required: true,
						JsonName: "serialization",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Serialization"),
						},
					},
				},
				ParentTypeName: stringPointer("First"),
				TypeHintIn:     stringPointer("Type"),
				TypeHintValue:  stringPointer("first"),
			},
			"Serialization": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						Required: true,
						JsonName: "type",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
				TypeHintIn: stringPointer("Type"),
			},
			"JsonSerialization": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Example": {
						Required: true,
						JsonName: "example",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
					},
				},
				ParentTypeName: stringPointer("Serialization"),
				TypeHintIn:     stringPointer("Type"),
				TypeHintValue:  stringPointer("json"),
			},
		},
		source: AccTestLicenceType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/edgezones"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/systemdata"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
)

// acctests licence placeholder

var _ First = FirstImplementation{}

type FirstImplementation struct {
	Serialization Serialization ''json:"serialization"''

	// Fields inherited from First
}

var _ json.Marshaler = FirstImplementation{}

func (s FirstImplementation) MarshalJSON() ([]byte, error) {
	type wrapper FirstImplementation
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling FirstImplementation: %+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling FirstImplementation: %+v", err)
	}
	decoded["type"] = "first"

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling FirstImplementation: %+v", err)
	}

	return encoded, nil
}

var _ json.Unmarshaler = &FirstImplementation{}

func (s *FirstImplementation) UnmarshalJSON(bytes []byte) error {
	var temp map[string]json.RawMessage
	if err := json.Unmarshal(bytes, &temp); err != nil {
		return fmt.Errorf("unmarshaling FirstImplementation into map[string]json.RawMessage: %+v", err)
	}

	if v, ok := temp["serialization"]; ok {
		impl, err := unmarshalSerializationImplementation(v)
		if err != nil {
			return fmt.Errorf("unmarshaling field 'Serialization' for 'FirstImplementation': %+v", err)
		}
		s.Serialization = impl
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
