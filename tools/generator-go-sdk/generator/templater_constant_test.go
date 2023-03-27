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
	}, false)
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

func TestTemplateIntegerConstant(t *testing.T) {
	actual, err := templateForConstant("MamboNumber", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.IntegerConstant,
		Values: map[string]string{
			"Five":   "5",
			"TenSix": "16",
			"Two":    "2",
		},
	}, false)
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

func TestTemplateStringConstant(t *testing.T) {
	actual, err := templateForConstant("Capital", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.StringConstant,
		Values: map[string]string{
			"Berlin": "berlin",
			"Oslo":   "oslo",
			"Sydney": "sydney",
		},
	}, false)
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
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateStringConstantWithNormalizationFunction(t *testing.T) {
	actual, err := templateForConstant("Capital", resourcemanager.ConstantDetails{
		CaseInsensitive: false,
		Type:            resourcemanager.StringConstant,
		Values: map[string]string{
			"Berlin": "berlin",
			"Oslo":   "oslo",
			"Sydney": "sydney",
		},
	}, true)
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

func (s *Capital) UnmarshalJSON(bytes []byte) error {
	var decoded string
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %+v", err)
	}
	for _, v := range PossibleValuesForCapital() {
		if strings.EqualFold(v, decoded) {
			decoded = v
			break
		}
	}
	*s = Capital(decoded)
	return nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
