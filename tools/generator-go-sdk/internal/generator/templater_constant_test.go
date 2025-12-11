// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestTemplateFloatConstant(t *testing.T) {
	actual, err := templateForConstant("MyConstant", models.SDKConstant{
		Type: models.FloatSDKConstantType,
		Values: map[string]string{
			"FourPointTwo": "4.2",
			"TwoPointSix":  "2.6",
		},
	}, false, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type MyConstant float64

const (
	MyConstantFourPointTwo MyConstant = 4.2
	MyConstantTwoPointSix MyConstant = 2.6
)

func PossibleValuesForMyConstant() []float64 {
	return []float64{
        float64(MyConstantFourPointTwo),
        float64(MyConstantTwoPointSix),
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateFloatConstantUsedInAResourceID(t *testing.T) {
	actual, err := templateForConstant("MyConstant", models.SDKConstant{
		Type: models.FloatSDKConstantType,
		Values: map[string]string{
			"FourPointTwo": "4.2",
			"TwoPointSix":  "2.6",
		},
	}, false, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type MyConstant float64

const (
	MyConstantFourPointTwo MyConstant = 4.2
	MyConstantTwoPointSix MyConstant = 2.6
)

func PossibleValuesForMyConstant() []float64 {
	return []float64{
        float64(MyConstantFourPointTwo),
        float64(MyConstantTwoPointSix),
	}
}

func parseMyConstant(input float64) (*MyConstant, error) {
	vals := map[float64]MyConstant{
        4.2: MyConstantFourPointTwo,
        2.6: MyConstantTwoPointSix,
	}
	if v, ok := vals[input]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := MyConstant(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateIntegerConstant(t *testing.T) {
	actual, err := templateForConstant("MamboNumber", models.SDKConstant{
		Type: models.IntegerSDKConstantType,
		Values: map[string]string{
			"Five":   "5",
			"TenSix": "16",
			"Two":    "2",
		},
	}, false, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type MamboNumber int64

const (
	MamboNumberFive MamboNumber = 5
	MamboNumberTenSix MamboNumber = 16
	MamboNumberTwo MamboNumber = 2
)

func PossibleValuesForMamboNumber() []int64 {
	return []int64{
        int64(MamboNumberFive),
        int64(MamboNumberTenSix),
		int64(MamboNumberTwo),
	}
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateIntegerConstantUsedInAResourceID(t *testing.T) {
	actual, err := templateForConstant("MamboNumber", models.SDKConstant{
		Type: models.IntegerSDKConstantType,
		Values: map[string]string{
			"Five":   "5",
			"TenSix": "16",
			"Two":    "2",
		},
	}, false, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type MamboNumber int64

const (
	MamboNumberFive MamboNumber = 5
	MamboNumberTenSix MamboNumber = 16
	MamboNumberTwo MamboNumber = 2
)

func PossibleValuesForMamboNumber() []int64 {
	return []int64{
        int64(MamboNumberFive),
        int64(MamboNumberTenSix),
		int64(MamboNumberTwo),
	}
}

func parseMamboNumber(input int64) (*MamboNumber, error) {
	vals := map[int64]MamboNumber{
        5: MamboNumberFive,
        16: MamboNumberTenSix,
		2: MamboNumberTwo,
	}
	if v, ok := vals[input]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := MamboNumber(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateStringConstant(t *testing.T) {
	actual, err := templateForConstant("Capital", models.SDKConstant{
		Type: models.StringSDKConstantType,
		Values: map[string]string{
			"Berlin":   "berlin",
			"Canberra": "canberra",
			"Oslo":     "oslo",
		},
	}, false, false)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type Capital string

const (
	CapitalBerlin Capital = "berlin"
	CapitalCanberra Capital = "canberra"
	CapitalOslo Capital = "oslo"
)

func PossibleValuesForCapital() []string {
	return []string{
		string(CapitalBerlin),
        string(CapitalCanberra),
        string(CapitalOslo),
	}
}

func parseCapital(input string) (*Capital, error) {
	vals := map[string]Capital{
		"berlin": CapitalBerlin,
        "canberra": CapitalCanberra,
        "oslo": CapitalOslo,
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := Capital(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateStringConstantUsedInAResourceID(t *testing.T) {
	// the `UsedInAResourceID` field has no effect, since the Parse function is always output for String constants
	actual, err := templateForConstant("Capital", models.SDKConstant{
		Type: models.StringSDKConstantType,
		Values: map[string]string{
			"Berlin":   "berlin",
			"Canberra": "canberra",
			"Oslo":     "oslo",
		},
	}, false, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type Capital string

const (
	CapitalBerlin Capital = "berlin"
	CapitalCanberra Capital = "canberra"
	CapitalOslo Capital = "oslo"
)

func PossibleValuesForCapital() []string {
	return []string{
		string(CapitalBerlin),
        string(CapitalCanberra),
        string(CapitalOslo),
	}
}

func parseCapital(input string) (*Capital, error) {
	vals := map[string]Capital{
		"berlin": CapitalBerlin,
        "canberra": CapitalCanberra,
        "oslo": CapitalOslo,
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := Capital(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateStringConstantWithNormalizationFunction(t *testing.T) {
	actual, err := templateForConstant("Capital", models.SDKConstant{
		Type: models.StringSDKConstantType,
		Values: map[string]string{
			"Berlin":   "berlin",
			"Canberra": "canberra",
			"Oslo":     "oslo",
		},
	}, true, true)
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type Capital string

const (
	CapitalBerlin Capital = "berlin"
	CapitalCanberra Capital = "canberra"
	CapitalOslo Capital = "oslo"
)

func PossibleValuesForCapital() []string {
	return []string{
		string(CapitalBerlin),
        string(CapitalCanberra),
        string(CapitalOslo),
	}
}

func (s *Capital) UnmarshalJSON(bytes []byte) error {
	var decoded string
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %+v", err)
	}
	out, err := parseCapital(decoded)
	if err != nil {
		return fmt.Errorf("parsing %q: %+v", decoded, err)
	}
	*s = *out
	return nil
}

func parseCapital(input string) (*Capital, error) {
	vals := map[string]Capital{
		"berlin": CapitalBerlin,
        "canberra": CapitalCanberra,
        "oslo": CapitalOslo,
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := Capital(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
