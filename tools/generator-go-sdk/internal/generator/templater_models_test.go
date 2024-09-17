// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestModelTemplaterSimple(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Name": {
					JsonName: "name",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
				"Age": {
					JsonName: "age",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.IntegerSDKObjectDefinitionType,
					},
					Optional: true,
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Age": {
						JsonName: "age",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.IntegerSDKObjectDefinitionType,
						},
						Optional: true,
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

type Basic struct {
	Age *int64 ''json:"age,omitempty"''
	Name string ''json:"name"''
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithDate(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Name": {
					JsonName: "name",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
				"DateOfBirth": {
					JsonName:   "dateOfBirth",
					DateFormat: pointer.To(models.RFC3339SDKDateFormat),
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DateTimeSDKObjectDefinitionType,
					},
					Optional: true,
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},

					"DateOfBirth": {
						JsonName: "dateOfBirth",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DateTimeSDKObjectDefinitionType,
						},
						Optional: true,
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

type Basic struct {
	DateOfBirth *string ''json:"dateOfBirth,omitempty"''
	Name string ''json:"name"''
}

func (o *Basic) GetDateOfBirthAsTime() (*time.Time, error) {
	if o.DateOfBirth == nil {
		return nil, nil
	}
	return dates.ParseAsFormat(o.DateOfBirth, "2006-01-02T15:04:05Z07:00")
}

func (o *Basic) SetDateOfBirthAsTime(input time.Time) {
	formatted := input.Format("2006-01-02T15:04:05Z07:00")
	o.DateOfBirth = &formatted
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalObject(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Name": {
					JsonName: "name",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
				"BobcatOptional": {
					JsonName: "bobcatOptional",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: stringPointer("Bobcat"),
					},
					Optional: true,
				},
				"BobcatRequired": {
					JsonName: "bobcatRequired",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: stringPointer("Bobcat"),
					},
					Required: true,
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"BobcatOptional": {
						JsonName: "bobcatOptional",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: stringPointer("Bobcat"),
						},
						Optional: true,
					},
					"BobcatRequired": {
						JsonName: "bobcatRequired",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: stringPointer("Bobcat"),
						},
						Required: true,
					},
				},
			},
			"Bobcat": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
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

type Basic struct {
	BobcatOptional *Bobcat ''json:"bobcatOptional,omitempty"''
	BobcatRequired Bobcat ''json:"bobcatRequired"''
	Name string ''json:"name"''
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithReadOnlyField(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Example",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Name": {
					JsonName: "name",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Required: true,
				},
				"Description": {
					JsonName: "description",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					Optional: true,
				},
				"Type": {
					JsonName: "type",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.StringSDKObjectDefinitionType,
					},
					ReadOnly: true,
				},
			},
		},
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Example": {
				Fields: map[string]models.SDKField{
					"Name": {
						JsonName: "name",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
					"Description": {
						JsonName: "description",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Optional: true,
					},
					"Type": {
						JsonName: "type",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						ReadOnly: true,
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

type Example struct {
	Description *string ''json:"description,omitempty"''
	Name string ''json:"name"''
	Type *string ''json:"type,omitempty"''
}

var _ json.Marshaler = Example{}

func (s Example) MarshalJSON() ([]byte, error) {
	type wrapper Example
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling Example: %+v", err)
	}

	var decoded map[string]interface{}
	if err = json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling Example: %+v", err)
	}

	delete(decoded, "Type")
	encoded, err = json.Marshal(decoded)

	if err != nil {
		return nil, fmt.Errorf("re-marshaling Example: %+v", err)
	}

	return encoded, nil
}

`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
