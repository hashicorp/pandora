// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestModelTemplaterWithOptionalFloatConstant(t *testing.T) {
	actual, err := modelsTemplater{
		name: "Basic",
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"SomeFloat": {
					JsonName: "someFloat",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("MyFloat"),
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
					"SomeFloat": {
						JsonName: "someFloat",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MyFloat"),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambo": {
					JsonName: "mambo",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("MamboNumber"),
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
					"Mambo": {
						JsonName: "mambo",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MamboNumber"),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Country": {
					JsonName: "country",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Countries"),
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
					"Country": {
						JsonName: "country",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Countries"),
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"SomeFloat": {
					JsonName: "someFloat",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("MyFloat"),
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
					"SomeFloat": {
						JsonName: "someFloat",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MyFloat"),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambo": {
					JsonName: "mambo",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("MamboNumber"),
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
					"Mambo": {
						JsonName: "mambo",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MamboNumber"),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Country": {
					JsonName: "country",
					ObjectDefinition: models.SDKObjectDefinition{
						Type:          models.ReferenceSDKObjectDefinitionType,
						ReferenceName: pointer.To("Countries"),
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
					"Country": {
						JsonName: "country",
						ObjectDefinition: models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Countries"),
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ListOfFloats": {
					JsonName: "listOfFloats",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
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
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"ListOfFloats": {
						JsonName: "listOfFloats",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type: models.ReferenceSDKObjectDefinitionType,
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
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MamboNumber"),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MamboNumber"),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Countries"),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Countries"),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"ListOfFloats": {
					JsonName: "listOfFloats",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MyFloat"),
						},
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
					"ListOfFloats": {
						JsonName: "listOfFloats",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MyFloat"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MamboNumber"),
						},
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
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MamboNumber"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.ListSDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
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
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.ListSDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Countries"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"MapOfFloats": {
					JsonName: "mapOfFloats",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MyFloat"),
						},
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
					"MapOfFloats": {
						JsonName: "mapOfFloats",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MyFloat"),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
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
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MamboNumber"),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Countries"),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Countries"),
							},
						},
						Optional: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"MapOfFloats": {
					JsonName: "mapOfFloats",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("MyFloat"),
						},
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
					"MapOfFloats": {
						JsonName: "mapOfFloats",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MyFloat"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MyFloat": {
				Type: models.FloatSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"Mambos": {
					JsonName: "mambos",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type: models.ReferenceSDKObjectDefinitionType,
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
	}.template(GeneratorData{
		packageName: "somepackage",
		models: map[string]models.SDKModel{
			"Basic": {
				Fields: map[string]models.SDKField{
					"Mambos": {
						JsonName: "mambos",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("MamboNumber"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"MamboNumber": {
				Type: models.IntegerSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
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
		model: models.SDKModel{
			Fields: map[string]models.SDKField{
				"FavouriteCountries": {
					JsonName: "favouriteCountries",
					ObjectDefinition: models.SDKObjectDefinition{
						Type: models.DictionarySDKObjectDefinitionType,
						NestedItem: &models.SDKObjectDefinition{
							Type:          models.ReferenceSDKObjectDefinitionType,
							ReferenceName: pointer.To("Countries"),
						},
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
					"FavouriteCountries": {
						JsonName: "favouriteCountries",
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.DictionarySDKObjectDefinitionType,
							NestedItem: &models.SDKObjectDefinition{
								Type:          models.ReferenceSDKObjectDefinitionType,
								ReferenceName: pointer.To("Countries"),
							},
						},
						Required: true,
					},
				},
			},
		},
		constants: map[string]models.SDKConstant{
			"Countries": {
				Type: models.StringSDKConstantType,
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
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
)

// acctests licence placeholder

type Basic struct {
	FavouriteCountries map[string]Countries ''json:"favouriteCountries"''
}
`, "''", "`")
	assertTemplatedCodeMatches(t, expected, *actual)
}
