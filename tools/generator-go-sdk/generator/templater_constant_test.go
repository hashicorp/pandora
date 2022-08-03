package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTemplateFloatConstant(t *testing.T) {
	actual, err := templateForConstant("MyConstant", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.FloatConstant,
		Values: map[string]string{
			"FourPointTwo": "4.2",
			"TwoPointSix":  "2.6",
		},
	})
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
	actual, err := templateForConstant("MamboNumber", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.IntegerConstant,
		Values: map[string]string{
			"Five":   "5",
			"TenSix": "16",
			"Two":    "2",
		},
	})
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
	actual, err := templateForConstant("Capital", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.StringConstant,
		Values: map[string]string{
			"Berlin": "berlin",
			"Oslo":   "oslo",
			"Sydney": "sydney",
		},
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type Capital string

const (
	CapitalBerlin Capital = "berlin"
	CapitalOslo Capital = "oslo"
	CapitalSydney Capital = "sydney"
)

func PossibleValuesForCapital() []string {
	return []string{
		string(CapitalBerlin),
        string(CapitalOslo),
        string(CapitalSydney),
	}
}

func parseCapital(input string) (*Capital, error) {
	vals := map[string]Capital{
		"berlin": CapitalBerlin,
        "oslo": CapitalOslo,
        "sydney": CapitalSydney,
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
