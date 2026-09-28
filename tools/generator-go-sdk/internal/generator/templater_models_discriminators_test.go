// Copyright IBM Corp. 2023, 2026
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

type ModeOfTransit interface {
	ModeOfTransit() BaseModeOfTransitImpl
}

var _ ModeOfTransit = BaseModeOfTransitImpl{}

type BaseModeOfTransitImpl struct {
	Type string ''json:"type"''
}

func (s BaseModeOfTransitImpl) ModeOfTransit() BaseModeOfTransitImpl {
	return s
}

var _ ModeOfTransit = RawModeOfTransitImpl{}

// RawModeOfTransitImpl is returned when the Discriminated Value doesn't match any of the defined types.
// It can also be used as a Request Payload to provide a raw JSON payload, which is useful
// for preserving arbitrary/extensible JSON properties across a round-trip.
type RawModeOfTransitImpl struct {
	modeOfTransit BaseModeOfTransitImpl
	Type string
	Values map[string]interface{}
}

func (s RawModeOfTransitImpl) ModeOfTransit() BaseModeOfTransitImpl {
	return s.modeOfTransit
}

func (s RawModeOfTransitImpl) MarshalJSON() ([]byte, error) {
	return json.Marshal(s.Values)
}

func UnmarshalModeOfTransitImplementation(input []byte) (ModeOfTransit, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling ModeOfTransit into map[string]interface: %+v", err)
	}

	var value string
	if v, ok := temp["type"]; ok {
		value = fmt.Sprintf("%v", v)
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

	var parent BaseModeOfTransitImpl
	if err := json.Unmarshal(input, &parent); err != nil {
		return nil, fmt.Errorf("unmarshaling into BaseModeOfTransitImpl: %+v", err)
	}

	return RawModeOfTransitImpl{
		modeOfTransit: parent,
		Type: value,
		Values: temp,
	}, nil
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

func (s Train) ModeOfTransit() BaseModeOfTransitImpl {
	return BaseModeOfTransitImpl{
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
	if err = json.Unmarshal(encoded, &decoded); err != nil {
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

func TestTemplaterModelsImplementationWithModelBehaviors(t *testing.T) {
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
		allowOmittingDiscriminatedValue: true,
		packageName:                     "somepackage",
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

	// Model behaviors
	OmitDiscriminatedValue bool ''json:"-"''
}

func (s Train) ModeOfTransit() BaseModeOfTransitImpl {
	return BaseModeOfTransitImpl{
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
	if err = json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Train: %+v", err)
	}

	if !s.OmitDiscriminatedValue {
		decoded["type"] = "train"
	}

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

func (s FirstImplementation) First() BaseFirstImpl {
	return BaseFirstImpl{
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
	if err = json.Unmarshal(encoded, &decoded); err != nil {
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
	var decoded struct {
		Type string ''json:"type"''
	}
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %+v", err)
	}

	s.Type = decoded.Type

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

func TestTemplaterModelsThreeLevelDiscriminatedHierarchyWithDateTimeOnIntermediateParent(t *testing.T) {
	actual, err := modelsTemplater{
		name: "BlobRecord",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"BlobName": {
					Required: true,
					JsonName: "blobName",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
				},
			},
			FieldNameContainingDiscriminatedValue: stringPointer("Type"),
			ParentTypeName:                        stringPointer("RetrievalRecord"),
			DiscriminatedValue:                    stringPointer("blob"),
		},
	}.template(GeneratorData{
		packageName:         "somepackage",
		recurseParentModels: true,
		models: map[string]models.SDKModel{
			"ActivityRecord": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				Fields: map[string]models.SDKField{
					"Id": {
						Required: true,
						JsonName: "id",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.IntegerSDKObjectDefinitionType,
						},
					},
					"Type": {
						ContainsDiscriminatedValue: true,
						Required:                   true,
						JsonName:                   "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
					"StartedOn": {
						Optional:   true,
						JsonName:   "startedOn",
						DateFormat: stringPointer(string(models.RFC3339SDKDateFormat)),
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
					},
				},
			},
			"RetrievalRecord": {
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				ParentTypeName:                        stringPointer("ActivityRecord"),
				DiscriminatedValue:                    stringPointer("RetrievalRecord"),
				Fields: map[string]models.SDKField{
					"QueryTime": {
						Optional:   true,
						JsonName:   "queryTime",
						DateFormat: stringPointer(string(models.RFC3339SDKDateFormat)),
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
					},
				},
			},
			"BlobRecord": {
				Fields: map[string]models.SDKField{
					"BlobName": {
						Required: true,
						JsonName: "blobName",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
					},
				},
				FieldNameContainingDiscriminatedValue: stringPointer("Type"),
				ParentTypeName:                        stringPointer("RetrievalRecord"),
				DiscriminatedValue:                    stringPointer("blob"),
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

var _ ActivityRecord = BlobRecord{}

type BlobRecord struct {
	BlobName string ''json:"blobName"''

	// Fields inherited from ActivityRecord
	Id int64 ''json:"id"''
	StartedOn *string ''json:"startedOn,omitempty"''
	Type string ''json:"type"''
}

func (s BlobRecord) ActivityRecord() BaseActivityRecordImpl {
	return BaseActivityRecordImpl{
		Id: s.Id,
		StartedOn: s.StartedOn,
		Type: s.Type,
	}
}

func (o *BlobRecord) GetStartedOnAsTime() (*time.Time, error) {
	if o.StartedOn == nil {
		return nil, nil
	}
	return dates.ParseAsFormat(o.StartedOn, "2006-01-02T15:04:05Z07:00")
}

func (o *BlobRecord) SetStartedOnAsTime(input time.Time) {
	formatted := input.Format("2006-01-02T15:04:05Z07:00")
	o.StartedOn = &formatted
}

var _ json.Marshaler = BlobRecord{}

func (s BlobRecord) MarshalJSON() ([]byte, error) {
	type wrapper BlobRecord
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling BlobRecord: %+v", err)
	}

	var decoded map[string]interface{}
	if err = json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling BlobRecord: %+v", err)
	}
	decoded["type"] = "blob"

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling BlobRecord: %+v", err)
	}

	return encoded, nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
