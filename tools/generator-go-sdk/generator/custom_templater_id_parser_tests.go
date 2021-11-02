package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/featureflags"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templater = idCustomParserTestsTemplater{}

type idCustomParserTestsTemplater struct {
	resourceName    string
	resourceData    resourcemanager.ResourceIdDefinition
	constantDetails map[string]resourcemanager.ConstantDetails
}

func (i idCustomParserTestsTemplater) template(data ServiceGeneratorData) (*string, error) {
	res, err := i.generateTests(data.packageName)
	if err != nil {
		return nil, fmt.Errorf("while generating parser tests: %+v", err)
	}
	return res, nil
}

func (i idCustomParserTestsTemplater) generateTests(packageName string) (*string, error) {
	structName := strings.Title(i.resourceName)
	structWithoutSuffix := strings.TrimSuffix(structName, "Id")
	lines := make([]string, 0)

	// New{Name}Id function test
	newFunctionTest, err := i.generateNewFunctionTest(structWithoutSuffix)
	if err != nil {
		return nil, fmt.Errorf("generating test for the New{Name}Id function: %+v", err)
	}
	lines = append(lines, *newFunctionTest)

	// ID function test
	idFunctionTest, err := i.generateIdFunctionTest(structWithoutSuffix)
	if err != nil {
		return nil, fmt.Errorf("generating test for the ID function: %+v", err)
	}
	lines = append(lines, *idFunctionTest)

	// case-sensitive test
	parseSensitiveTest, err := i.generateParseFunctionTest(structName, structWithoutSuffix, true)
	if err != nil {
		return nil, fmt.Errorf("generating test for the case-sensitive Parse function: %+v", err)
	}
	lines = append(lines, *parseSensitiveTest)

	if featureflags.GenerateCaseInsensitiveFunctions {
		// case-insensitive test
		parseInsensitiveTest, err := i.generateParseFunctionTest(structName, structWithoutSuffix, false)
		if err != nil {
			return nil, fmt.Errorf("generating test for the case-insensitive Parse function: %+v", err)
		}
		lines = append(lines, *parseInsensitiveTest)
	}

	out := fmt.Sprintf(`package %[1]s

import (
	"reflect"
	"testing"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

var _ resourceids.ResourceId = %[2]s{}

%[3]s
`, packageName, structName, strings.Join(lines, "\n"))
	return &out, nil
}

func (i idCustomParserTestsTemplater) generateIdFunctionTest(structWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)

	exampleValues := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		if segment.Type != resourcemanager.ResourceProviderSegment && segment.Type != resourcemanager.StaticSegment {
			arguments = append(arguments, fmt.Sprintf("%q", segment.ExampleValue))
		}

		exampleValues = append(exampleValues, segment.ExampleValue)
	}
	expectedUri := urlFromSegments(exampleValues)

	out := fmt.Sprintf(`
func TestFormat%[1]sID(t *testing.T) {
	actual := New%[1]sID(%[2]s).ID()
	expected := %[3]q
	if actual != expected {
		t.Fatalf("Expected the Formatted ID to be %%q but got %%q", actual, expected)
	} 
}`, structWithoutSuffix, strings.Join(arguments, ", "), expectedUri)
	return &out, nil
}

func (i idCustomParserTestsTemplater) generateNewFunctionTest(structWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)
	assertions := make([]string, 0)

	for _, segment := range i.resourceData.Segments {
		if segment.Type == resourcemanager.ResourceProviderSegment || segment.Type == resourcemanager.StaticSegment {
			continue
		}

		arguments = append(arguments, fmt.Sprintf("%q", segment.ExampleValue))
		assertions = append(assertions, fmt.Sprintf(`
	if id.%[1]s != %[2]q {
		t.Fatalf("Expected %%q but got %%q for Segment '%[1]s'", id.%[1]s, %[2]q)
	}`, strings.Title(segment.Name), segment.ExampleValue))
	}

	out := fmt.Sprintf(`
func TestNew%[1]sID(t *testing.T) {
	id := New%[1]sID(%[2]s)
	%[3]s 
}`, structWithoutSuffix, strings.Join(arguments, ", "), strings.Join(assertions, "\n"))
	return &out, nil
}

func (i idCustomParserTestsTemplater) generateParseFunctionTest(structName, structWithoutSuffix string, caseSensitive bool) (*string, error) {
	parseFunctionName := fmt.Sprintf("Parse%sID", structWithoutSuffix)
	if !caseSensitive {
		parseFunctionName += "Insensitively"
	}

	testData, err := i.getTestCases(caseSensitive)
	if err != nil {
		return nil, fmt.Errorf("generating test cases: %+v", err)
	}

	assertions, err := i.getAssertions()
	if err != nil {
		return nil, fmt.Errorf("generating assertions: %+v", err)
	}

	out := fmt.Sprintf(`
func Test%[1]s(t *testing.T) {
	testData := []struct {
		Input    string
		Error    bool
		Expected *%[2]s
	}{
		%[3]s
	}
	for _, v := range testData {
		t.Logf("[DEBUG] Testing %%q", v.Input)

		actual, err := %[1]s(v.Input)
		if err != nil {
			if v.Error {
				continue
			}

			t.Fatalf("Expect a value but got an error: %%+v", err)
		}
		if v.Error {
			t.Fatal("Expect an error but didn't get one")
		}

		%[4]s
	}
}
`, parseFunctionName, structName, *testData, *assertions)
	return &out, nil
}

func (i idCustomParserTestsTemplater) getTestCases(caseSensitive bool) (*string, error) {
	cases := make([]string, 0)
	urlVals := make([]string, 0)
	structMap := make([]string, 0)
	caseInsensitiveStructMap := make([]string, 0)

	for _, segment := range i.resourceData.Segments {
		urlVals = append(urlVals, segment.ExampleValue)

		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue
		case resourcemanager.ConstantSegment:
			{
				structMap = append(structMap, fmt.Sprintf("%s: %q,", strings.Title(segment.Name), segment.ExampleValue))
				// intentionally don't alternate the casing, since the constant gets fixed to the correct case
				caseInsensitiveStructMap = append(caseInsensitiveStructMap, fmt.Sprintf("%s: %q,", strings.Title(segment.Name), segment.ExampleValue))
			}

		default:
			{
				structMap = append(structMap, fmt.Sprintf("%s: %q,", strings.Title(segment.Name), segment.ExampleValue))
				caseInsensitiveStructMap = append(caseInsensitiveStructMap, fmt.Sprintf("%s: %q,", strings.Title(segment.Name), alternateCasingOnEveryLetter(segment.ExampleValue)))
			}
		}
	}

	for idx := 0; idx < len(urlVals); idx++ {
		testUrl := urlFromSegments(urlVals[0:idx])

		cases = append(cases, fmt.Sprintf(`{
			// Incomplete URI
			Input: "%s",
			Error: true,
		},`, testUrl))

		// special-casing "" since there's no point making that case-insensitive..
		if !caseSensitive && testUrl != "" {
			// alternate the casing on every other letter
			testUrl = alternateCasingOnEveryLetter(testUrl)
			cases = append(cases, fmt.Sprintf(`{
			// Incomplete URI (mIxEd CaSe since this is insensitive)
			Input: "%s",
			Error: true,
		},`, testUrl))
		}
	}

	fullUrl := urlFromSegments(urlVals)
	cases = append(cases, fmt.Sprintf(`{
		// Valid URI
		Input: "%s",
		Expected: &%s{
			%s
		},
	},`, fullUrl, i.resourceName, strings.Join(structMap, "\n")))
	cases = append(cases, fmt.Sprintf(`{
		// Invalid (Valid Uri with Extra segment) 
		Input: "%s/extra",
		Error: true,
	},`, fullUrl))

	if !caseSensitive {
		fullUrl = alternateCasingOnEveryLetter(fullUrl)
		cases = append(cases, fmt.Sprintf(`{
		// Valid URI (mIxEd CaSe since this is insensitive)
		Input: "%s",
		Expected: &%s{
			%s
		},
	},`, fullUrl, i.resourceName, strings.Join(caseInsensitiveStructMap, "\n")))
		cases = append(cases, fmt.Sprintf(`{
		// Invalid (Valid Uri with Extra segment - mIxEd CaSe since this is insensitive)
		Input: "%s/extra",
		Error: true,
	},`, fullUrl))
	}

	out := strings.Join(cases, "\n")
	return &out, nil
}

func urlFromSegments(input []string) string {
	output := ""
	for _, v := range input {
		// intentionally to handle scopes
		if !strings.HasPrefix(v, "/") {
			output += "/"
		}
		output += v
	}
	return output
}

func (i idCustomParserTestsTemplater) getAssertions() (*string, error) {
	lines := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment:
			fallthrough
		case resourcemanager.StaticSegment:
			continue
		default:
			lines = append(lines, fmt.Sprintf(`
if actual.%[1]s != v.Expected.%[1]s {
	t.Fatalf("Expected %%q but got %%q for %[1]s", v.Expected.%[1]s, actual.%[1]s)
}
`, strings.Title(segment.Name)))
		}
	}
	out := strings.Join(lines, "\n")
	return &out, nil
}

func alternateCasingOnEveryLetter(input string) string {
	output := ""
	caps := false
	for _, c := range input {
		if c == '/' {
			// for every segment restart
			output += string(c)
			caps = false
			continue
		}

		if caps {
			caps = false
			output += strings.ToUpper(string(c))
		} else {
			caps = true
			output += strings.ToLower(string(c))
		}
	}

	return output
}
