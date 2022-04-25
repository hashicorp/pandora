package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestModelTemplaterWithOptionalFloatConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"SomeFloat": {
					JsonName: "someFloat",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "MyFloat"
							return &v
						}(),
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
					"SomeFloat": {
						JsonName: "someFloat",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	SomeFloat *MyFloat ''json:"someFloat,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if v := decoded.SomeFloat; v != nil {
		normalized := v.Normalize()
		s.SomeFloat = &normalized
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalIntegerConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambo": {
					JsonName: "mambo",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "MamboNumber"
							return &v
						}(),
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
					"Mambo": {
						JsonName: "mambo",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambo *MamboNumber ''json:"mambo,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if v := decoded.Mambo; v != nil {
		normalized := v.Normalize()
		s.Mambo = &normalized
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalStringConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Country": {
					JsonName: "country",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "Countries"
							return &v
						}(),
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
					"Country": {
						JsonName: "country",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	Country *Countries ''json:"country,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if v := decoded.Country; v != nil {
		normalized := v.Normalize()
		s.Country = &normalized
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredFloatConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"SomeFloat": {
					JsonName: "someFloat",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "MyFloat"
							return &v
						}(),
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
					"SomeFloat": {
						JsonName: "someFloat",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	SomeFloat MyFloat ''json:"someFloat"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	s.SomeFloat = decoded.SomeFloat.Normalize()
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredIntegerConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambo": {
					JsonName: "mambo",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "MamboNumber"
							return &v
						}(),
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
					"Mambo": {
						JsonName: "mambo",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambo MamboNumber ''json:"mambo"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	s.Mambo = decoded.Mambo.Normalize()
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredStringConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Country": {
					JsonName: "country",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: func() *string {
							v := "Countries"
							return &v
						}(),
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
					"Country": {
						JsonName: "country",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	Country Countries ''json:"country"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	s.Country = decoded.Country.Normalize()
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalListOfFloatConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ListOfFloats": {
					JsonName: "listOfFloats",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
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
					"ListOfFloats": {
						JsonName: "listOfFloats",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MyFloat"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	ListOfFloats *[]MyFloat ''json:"listOfFloats,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.ListOfFloats; val != nil {
		items := make([]MyFloat, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.ListOfFloats = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalListOfIntegerConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MamboNumber"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambos *[]MamboNumber ''json:"mambos,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.Mambos; val != nil {
		items := make([]MamboNumber, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.Mambos = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalListOfStringConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "Countries"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	FavouriteCountries *[]Countries ''json:"favouriteCountries,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.FavouriteCountries; val != nil {
		items := make([]Countries, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.FavouriteCountries = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredListOfFloatConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"ListOfFloats": {
					JsonName: "listOfFloats",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
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
					"ListOfFloats": {
						JsonName: "listOfFloats",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MyFloat"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	ListOfFloats []MyFloat ''json:"listOfFloats"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.ListOfFloats; val != nil {
		items := make([]MyFloat, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.ListOfFloats = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredListOfIntegerConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MamboNumber"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambos []MamboNumber ''json:"mambos"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.Mambos; val != nil {
		items := make([]MamboNumber, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.Mambos = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredListOfStringConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.ListApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ListApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "Countries"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	FavouriteCountries []Countries ''json:"favouriteCountries"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.FavouriteCountries; val != nil {
		items := make([]Countries, 0)
		for _, v := range val {
			items = append(items, v.Normalize())
		}
		s.FavouriteCountries = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalMapOfFloatConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"MapOfFloats": {
					JsonName: "mapOfFloats",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
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
					"MapOfFloats": {
						JsonName: "mapOfFloats",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MyFloat"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	MapOfFloats *map[string]MyFloat ''json:"mapOfFloats,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.MapOfFloats; val != nil {
		items := make(map[string]MyFloat, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.MapOfFloats = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalMapOfIntegerConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MamboNumber"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambos *map[string]MamboNumber ''json:"mambos,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.Mambos; val != nil {
		items := make(map[string]MamboNumber, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.Mambos = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithOptionalMapOfStringConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "Countries"
									return &v
								}(),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	FavouriteCountries *map[string]Countries ''json:"favouriteCountries,omitempty"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.FavouriteCountries; val != nil {
		items := make(map[string]Countries, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.FavouriteCountries = &items
	}
	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredMapOfFloatConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"MapOfFloats": {
					JsonName: "mapOfFloats",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MyFloat"
								return &v
							}(),
						},
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
					"MapOfFloats": {
						JsonName: "mapOfFloats",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MyFloat"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MyFloat": {
				Type: resourcemanager.FloatConstant,
				Values: map[string]string{
					"OnePointTwo": "1.2",
				},
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

type Basic struct {
	MapOfFloats map[string]MyFloat ''json:"mapOfFloats"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.MapOfFloats; val != nil {
		items := make(map[string]MyFloat, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.MapOfFloats = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredMapOfIntegerConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "MamboNumber"
								return &v
							}(),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "MamboNumber"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"MamboNumber": {
				Type: resourcemanager.IntegerConstant,
				Values: map[string]string{
					"Five": "5",
				},
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

type Basic struct {
	Mambos map[string]MamboNumber ''json:"mambos"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.Mambos; val != nil {
		items := make(map[string]MamboNumber, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.Mambos = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestModelTemplaterWithRequiredMapOfStringConstants(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: resourcemanager.ModelDetails{
			Fields: map[string]resourcemanager.FieldDetails{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.DictionaryApiObjectDefinitionType,
						NestedItem: &resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.ReferenceApiObjectDefinitionType,
							ReferenceName: func() *string {
								v := "Countries"
								return &v
							}(),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.DictionaryApiObjectDefinitionType,
							NestedItem: &resourcemanager.ApiObjectDefinition{
								Type: resourcemanager.ReferenceApiObjectDefinitionType,
								ReferenceName: func() *string {
									v := "Countries"
									return &v
								}(),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]resourcemanager.ConstantDetails{
			"Countries": {
				Type: resourcemanager.StringConstant,
				Values: map[string]string{
					"Canada":  "canada",
					"Germany": "germany",
				},
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

type Basic struct {
	FavouriteCountries map[string]Countries ''json:"favouriteCountries"''
}

var _ json.Unmarshaler = &Basic{}

func (s *Basic) UnmarshalJSON(bytes []byte) error {
	type alias Basic
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into Basic: %+v", err)
	}

	// normalize any constants on the way through
	if val := decoded.FavouriteCountries; val != nil {
		items := make(map[string]Countries, 0)
		for k, v := range val {
			items[k] = v.Normalize()
		}
		s.FavouriteCountries = items
	}

	return nil
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
