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

func normalizeMyConstant(input MyConstant) MyConstant {
	// a float can't be case-corrected, so just return it
	return input
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
	assertTemplatedCodeMatches(t, *actual, expected)
}

func TestTemplateIntegerConstant(t *testing.T) {
	actual, err := templateForConstant("Multiple", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.IntegerConstant,
		Values: map[string]string{
			"Four":   "4",
			"TenSix": "16",
			"Two":    "2",
		},
	})
	if err != nil {
		t.Fatal(err.Error())
	}
	expected := `type Multiple int64

const (
	MultipleFour Multiple = 4
	MultipleTenSix Multiple = 16
	MultipleTwo Multiple = 2
)

func PossibleValuesForMultiple() []int64 {
	return []int64{
        int64(MultipleFour),
        int64(MultipleTenSix),
		int64(MultipleTwo),
	}
}

func normalizeMultiple(input Multiple) Multiple {
	// a number can't be case-corrected, so just return it
	return input
}

func parseMultiple(input int64) (*Multiple, error) {
	vals := map[int64]Multiple{
        4: MultipleFour,
        16: MultipleTenSix,
		2: MultipleTwo,
	}
	if v, ok := vals[input]; ok {
    	return &v, nil
	}
        
	// otherwise presume it's an undefined value and best-effort it
	out := Multiple(input)
	return &out, nil
}
`
	assertTemplatedCodeMatches(t, *actual, expected)
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

func normalizeCapital(input Capital) Capital {
	vals := map[string]Capital{
		"berlin": CapitalBerlin,
		"oslo": CapitalOslo,
		"sydney": CapitalSydney,
	}
	if v, ok := vals[strings.ToLower(input)]; ok {
		return v
	}

	// otherwise presume it's an undefined value and just return it
	return input
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
	assertTemplatedCodeMatches(t, *actual, expected)
}
