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
)

// acctests licence placeholder

type Basic struct {
	SomeFloat *MyFloat ''json:"someFloat,omitempty"''
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

)

// acctests licence placeholder

type Basic struct {
	Mambo *MamboNumber ''json:"mambo,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	Country *Countries ''json:"country,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	SomeFloat MyFloat ''json:"someFloat"''
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
)

// acctests licence placeholder

type Basic struct {
	Mambo MamboNumber ''json:"mambo"''
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
)

// acctests licence placeholder

type Basic struct {
	Country Countries ''json:"country"''
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
)

// acctests licence placeholder

type Basic struct {
	ListOfFloats *[]MyFloat ''json:"listOfFloats,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	Mambos *[]MamboNumber ''json:"mambos,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	FavouriteCountries *[]Countries ''json:"favouriteCountries,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	ListOfFloats []MyFloat ''json:"listOfFloats"''
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
)

// acctests licence placeholder

type Basic struct {
	Mambos []MamboNumber ''json:"mambos"''
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
)

// acctests licence placeholder

type Basic struct {
	FavouriteCountries []Countries ''json:"favouriteCountries"''
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
)

// acctests licence placeholder

type Basic struct {
	MapOfFloats *map[string]MyFloat ''json:"mapOfFloats,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	Mambos *map[string]MamboNumber ''json:"mambos,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	FavouriteCountries *map[string]Countries ''json:"favouriteCountries,omitempty"''
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
)

// acctests licence placeholder

type Basic struct {
	MapOfFloats map[string]MyFloat ''json:"mapOfFloats"''
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
)

// acctests licence placeholder

type Basic struct {
	Mambos map[string]MamboNumber ''json:"mambos"''
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
)

// acctests licence placeholder

type Basic struct {
	FavouriteCountries map[string]Countries ''json:"favouriteCountries"''
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
