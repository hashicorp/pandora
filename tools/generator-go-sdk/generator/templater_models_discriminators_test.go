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

func TestTemplaterModelsContainingRequiredDiscriminator(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journey",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mode": {
					Required: true,
					JsonName: "mode",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("ModeOfTransit"),
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journey": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Mode": {
						Optional: true,
						JsonName: "mode",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
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

type Journey struct {
	Mode ModeOfTransit ''json:"mode"''
}

var _ json.Unmarshaler = &Journey{}

func (s *Journey) UnmarshalJSON(bytes []byte) error {
	type alias Journey
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journey: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journey: %+v", err)
	}
	if v := decoded["mode"]; v != nil {
		inner, err := unmarshalModeOfTransitImplementation(v)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit: %+v", err)
		}
		s.Mode = *inner
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsContainingOptionalDiscriminator(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journey",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mode": {
					Optional: true,
					JsonName: "mode",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("ModeOfTransit"),
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journey": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Mode": {
						Optional: true,
						JsonName: "mode",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
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

type Journey struct {
	Mode ModeOfTransit ''json:"mode"''
}

var _ json.Unmarshaler = &Journey{}

func (s *Journey) UnmarshalJSON(bytes []byte) error {
	type alias Journey
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journey: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journey: %+v", err)
	}
	if v := decoded["mode"]; v != nil {
		inner, err := unmarshalModeOfTransitImplementation(v)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit: %+v", err)
		}
		s.Mode = inner
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsContainingRequiredListOfDiscriminators(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journeys",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"PossibleModes": {
					Required: true,
					JsonName: "possibleModes",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journeys": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PossibleModes": {
						Required: true,
						JsonName: "possibleModes",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("ModeOfTransit"),
							},
						},
					},
				},
			},
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

type Journeys struct {
	PossibleModes []ModeOfTransit ''json:"possibleModes"''
}

var _ json.Unmarshaler = &Journeys{}

func (s *Journeys) UnmarshalJSON(bytes []byte) error {
	type alias Journeys
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journeys: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journeys: %+v", err)
	}
	if v := decoded["possibleModes"]; v != nil {
		items := make([]ModeOfTransit, 0)
		var list []json.RawMessage
		if err := json.Unmarshal(v, &list); err != nil {
			return nil, fmt.Errorf("unmarshaling json value for "possibleModes" into []ModeOfTransit: %+v", err)
		}
		for i, item := range list {
			inner, err := unmarshalModeOfTransitImplementation(item)
			if err != nil {
				return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit item %d: %+v", i, err)
			}
			items = append(items, *inner)
		}
		s.PossibleModes = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsContainingOptionalListOfDiscriminators(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journeys",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"PossibleModes": {
					Optional: true,
					JsonName: "possibleModes",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journeys": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PossibleModes": {
						Optional: true,
						JsonName: "possibleModes",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("ModeOfTransit"),
							},
						},
					},
				},
			},
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

type Journeys struct {
	PossibleModes *[]ModeOfTransit ''json:"possibleModes,omitempty"''
}

var _ json.Unmarshaler = &Journeys{}

func (s *Journeys) UnmarshalJSON(bytes []byte) error {
	type alias Journeys
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journeys: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journeys: %+v", err)
	}
	if v := decoded["possibleModes"]; v != nil {
		items := make([]ModeOfTransit, 0)
		var list []json.RawMessage
		if err := json.Unmarshal(v, &list); err != nil {
			return nil, fmt.Errorf("unmarshaling json value for "possibleModes" into []ModeOfTransit: %+v", err)
		}
		for i, item := range list {
			inner, err := unmarshalModeOfTransitImplementation(item)
			if err != nil {
				return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit item %d: %+v", i, err)
			}
			if inner != nil {
				items = append(items, *inner)
			}
		}
		s.PossibleModes = items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsContainingRequiredMapOfDiscriminators(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journeys",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"PossibleModes": {
					Required: true,
					JsonName: "possibleModes",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journeys": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PossibleModes": {
						Required: true,
						JsonName: "possibleModes",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("ModeOfTransit"),
							},
						},
					},
				},
			},
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

type Journeys struct {
	PossibleModes map[string]ModeOfTransit ''json:"possibleModes"''
}

var _ json.Unmarshaler = &Journeys{}

func (s *Journeys) UnmarshalJSON(bytes []byte) error {
	type alias Journeys
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journeys: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journeys: %+v", err)
	}
	if v := decoded["possibleModes"]; v != nil {
		items := make(map[string]ModeOfTransit, 0)
		var dict map[string]json.RawMessage
		if err := json.Unmarshal(v, &dict); err != nil {
			return nil, fmt.Errorf("unmarshaling json value for "possibleModes" into map[string]ModeOfTransit: %+v", err)
		}
		for k, item := range dict {
			inner, err := unmarshalModeOfTransitImplementation(item)
			if err != nil {
				return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit item %q: %+v", k, err)
			}
			items[k] = *inner
		}
		s.PossibleModes = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsContainingOptionalMapOfDiscriminators(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Journeys",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"PossibleModes": {
					Optional: true,
					JsonName: "possibleModes",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("ModeOfTransit"),
						},
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Journeys": {
				Fields: map[string]resourcemanager.FieldDetails{
					"PossibleModes": {
						Optional: true,
						JsonName: "possibleModes",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type:          resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: stringPointer("ModeOfTransit"),
							},
						},
					},
				},
			},
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

type Journeys struct {
	PossibleModes *map[string]ModeOfTransit ''json:"possibleModes,omitempty"''
}

var _ json.Unmarshaler = &Journeys{}

func (s *Journeys) UnmarshalJSON(bytes []byte) error {
	type alias Journeys
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Journeys: %+v", err)
	}

	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Journeys: %+v", err)
	}
	if v := decoded["possibleModes"]; v != nil {
		items := make(map[string]ModeOfTransit, 0)
		var dict map[string]json.RawMessage
		if err := json.Unmarshal(v, &dict); err != nil {
			return nil, fmt.Errorf("unmarshaling json value for "possibleModes" into map[string]ModeOfTransit: %+v", err)
		}
		for k, item := range dict {
			inner, err := unmarshalModeOfTransitImplementation(item)
			if err != nil {
				return nil, fmt.Errorf("unmarshaling implementation for ModeOfTransit item %q: %+v", k, err)
			}
			if inner != nil {
				items[k] = *inner
			}
		}
		s.PossibleModes = items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
