// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestModelTemplaterSimple(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Name": {
					JsonName: "name",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
				"Age": {
					JsonName: "age",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.IntegerApiObjectDefinitionType,
					},
					Optional: true,
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Basic": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
					"Age": {
						JsonName: "age",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.IntegerApiObjectDefinitionType,
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
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Name": {
					JsonName: "name",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
				"DateOfBirth": {
					JsonName: "dateOfBirth",
					DateFormat: func() *resourcemanager.DateFormat {
						v := resourcemanager.RFC3339
						return &v
					}(),
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DateTimeApiObjectDefinitionType,
					},
					Optional: true,
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Basic": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},

					"DateOfBirth": {
						JsonName: "dateOfBirth",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DateTimeApiObjectDefinitionType,
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
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Name": {
					JsonName: "name",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
					Required: true,
				},
				"BobcatOptional": {
					JsonName: "bobcatOptional",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("Bobcat"),
					},
					Optional: true,
				},
				"BobcatRequired": {
					JsonName: "bobcatRequired",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: stringPointer("Bobcat"),
					},
					Required: true,
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName: "somepackage",
		models: map[string]resourcemanager.ModelDetails{
			"Basic": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
					"BobcatOptional": {
						JsonName: "bobcatOptional",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Bobcat"),
						},
						Optional: true,
					},
					"BobcatRequired": {
						JsonName: "bobcatRequired",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type:          resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: stringPointer("Bobcat"),
						},
						Required: true,
					},
				},
			},
			"Bobcat": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Name": {
						JsonName: "name",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
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
