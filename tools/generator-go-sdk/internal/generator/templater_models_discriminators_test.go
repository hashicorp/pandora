// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestTemplaterModelsParent(t *testing.T) {
	actual, err := modelsTemplater{
		name: "ModeOfTransit",
		model: models.SDKModel{
			FieldNameContainingDiscriminatedValue: stringPointer("Type"),
			Fields: map[string]models.SDKField{
				"Type": {
					ContainsDiscriminatedValue: true,
					JsonName:                   "type",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"ModeOfTransit": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				Fields: map[string]models.SDKField{
					"Type": {
						ContainsDiscriminatedValue: true,
						JsonName:                   "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Car": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				DiscriminatedValue:                    stringPointer("car"),
				ParentTypeName:                        stringPointer("ModeOfTransit"),
			},
			"Train": {
				DiscriminatedValue:                    stringPointer("train"),
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				ParentTypeName:                        stringPointer("ModeOfTransit"),
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
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
)

// acctests licence placeholder

type ModeOfTransitBase struct {
	Type string ''json:"type"''
}

type ModeOfTransit interface {
	ModeOfTransit() ModeOfTransitBase
}

// RawModeOfTransitImpl is returned when the Discriminated Value
// doesn't match any of the defined types
// NOTE: this should only be used when a type isn't defined for this type of Object (as a workaround)
// and is used only for Deserialization (e.g. this cannot be used as a Request Payload).
type RawModeOfTransitImpl struct {
	modeOfTransit ModeOfTransitBase
	Type string
	Values map[string]interface{}
}

func (s RawModeOfTransitImpl) ModeOfTransit() ModeOfTransitBase {
	return s.modeOfTransit
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

	var parent ModeOfTransitBase
	if err := json.Unmarshal(input, &parent); err != nil {
		return nil, fmt.Errorf("unmarshaling into ModeOfTransitBase: %+v", err)
	}

	out := RawModeOfTransitImpl{
		modeOfTransit: parent,
		Type: value,
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Number": {
					Required: true,
					JsonName: "number",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
				"Operator": {
					Required: true,
					JsonName: "operator",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
			},
			FieldNameContainingDiscriminatedValue: stringPointer("Type"),
			ParentTypeName:                        stringPointer("ModeOfTransit"),
			DiscriminatedValue:                    stringPointer("train"),
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"ModeOfTransit": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				Fields: map[string]models.SDKField{
					"Name": {
						Required: true,
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"Type": {
						ContainsDiscriminatedValue: true,
						JsonName:                   "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Train": {
				Fields: map[string]models.SDKField{
					"Number": {
						Required: true,
						JsonName: "number",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"Operator": {
						Required: true,
						JsonName: "operator",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
				DiscriminatedValue:                    stringPointer("train"),
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				ParentTypeName:                        stringPointer("ModeOfTransit"),
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
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
)

// acctests licence placeholder

var _ ModeOfTransit = Train{}

type Train struct {
	Number string ''json:"number"''
	Operator string ''json:"operator"''

	// Fields inherited from ModeOfTransit
	Name string ''json:"name"''
	Type string ''json:"type"''
}

func (s Train) ModeOfTransit() ModeOfTransitBase {
	return ModeOfTransitBase{
		Name: s.Name,
		Type: s.Type,
	}
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

func TestTemplaterModelsFieldImplementation(t *testing.T) {
	actual, err := modelsTemplater{
		name: "TrainFactory",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Train": {
					Required: true,
					JsonName: "train",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: stringPointer("Train"),
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"ModeOfTransit": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				Fields: map[string]models.SDKField{
					"Name": {
						Required: true,
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"Type": {
						ContainsDiscriminatedValue: true,
						JsonName:                   "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
			"Train": {
				Fields: map[string]models.SDKField{
					"Number": {
						Required: true,
						JsonName: "number",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"Operator": {
						Required: true,
						JsonName: "operator",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
				DiscriminatedValue:                    stringPointer("train"),
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				ParentTypeName:                        stringPointer("ModeOfTransit"),
			},
			"TrainFactory": {
				Fields: map[string]models.SDKField{
					"Train": {
						Required: true,
						JsonName: "train",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: stringPointer("Train"),
						},
					},
				},
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
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
)

// acctests licence placeholder
type TrainFactory struct {
	Train Train ''json:"train"''
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplaterModelsImplementationInheritedFromParentType(t *testing.T) {
	actual, err := modelsTemplater{
		name: "FirstImplementation",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Serialization": {
					Required: true,
					JsonName: "serialization",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: stringPointer("Serialization"),
					},
				},
			},
			DiscriminatedValue:                    stringPointer("first"),
			FieldNameContainingDiscriminatedValue: stringPointer("Type"),
			ParentTypeName:                        stringPointer("First"),
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"First": {
				Fields: map[string]models.SDKField{
					"Type": {
						Required: true,
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
			},
			"FirstImplementation": {
				Fields: map[string]models.SDKField{
					"Serialization": {
						Required: true,
						JsonName: "serialization",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: stringPointer("Serialization"),
						},
					},
				},
				ParentTypeName:                        stringPointer("First"),
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				DiscriminatedValue:                    stringPointer("first"),
			},
			"Serialization": {
				Fields: map[string]models.SDKField{
					"Type": {
						Required: true,
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
			},
			"JsonSerialization": {
				Fields: map[string]models.SDKField{
					"Example": {
						Required: true,
						JsonName: "example",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
				ParentTypeName:                        stringPointer("Serialization"),
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				DiscriminatedValue:                    stringPointer("json"),
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
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
)

// acctests licence placeholder

var _ First = FirstImplementation{}

type FirstImplementation struct {
	Serialization Serialization ''json:"serialization"''

	// Fields inherited from First
	Type string ''json:"type"''
}

func (s FirstImplementation) First() FirstBase {
	return FirstBase{
		Type: s.Type,
	}
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
