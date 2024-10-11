package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/featureflags"
)

// TODO: add unit tests covering this

var _ templaterForResource = resourceIdTestsTemplater{}

type resourceIdTestsTemplater struct {
	resourceName    string
	resourceData    models.ResourceID
	constantDetails map[string]models.SDKConstant
}

func (i resourceIdTestsTemplater) template(data GeneratorData) (*string, error) {
	res, err := i.generateTests(data.packageName, data.source)
	if err != nil {
		return nil, fmt.Errorf("while generating parser tests: %+v", err)
	}
	return res, nil
}

func (i resourceIdTestsTemplater) generateTests(packageName string, source models.SourceDataOrigin) (*string, error) {
	structName := strings.Title(i.resourceName)
	structWithoutSuffix := strings.TrimSuffix(structName, "Id")
	lines := make([]string, 0)

	copyrightLines, err := copyrightLinesForSource(source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

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

	// Segments function test
	segmentsTest := i.generateSegmentsFunctionTest(structName)
	lines = append(lines, segmentsTest)

	out := fmt.Sprintf(`package %[1]s

import (
	"reflect"
	"testing"

    "github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%[2]s

var _ resourceids.ResourceId = &%[3]s{}

%[4]s
`, packageName, *copyrightLines, structName, strings.Join(lines, "\n"))
	return &out, nil
}

func (i resourceIdTestsTemplater) generateIdFunctionTest(structWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)

	exampleValues := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		if segment.Type != models.ResourceProviderResourceIDSegmentType && segment.Type != models.StaticResourceIDSegmentType {
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
		t.Fatalf("Expected the Formatted ID to be %%q but got %%q", expected, actual)
	} 
}
`, structWithoutSuffix, strings.Join(arguments, ", "), expectedUri)
	return &out, nil
}

func (i resourceIdTestsTemplater) generateNewFunctionTest(structWithoutSuffix string) (*string, error) {
	arguments := make([]string, 0)
	assertions := make([]string, 0)

	for _, segment := range i.resourceData.Segments {
		if segment.Type == models.ResourceProviderResourceIDSegmentType || segment.Type == models.StaticResourceIDSegmentType {
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

func (i resourceIdTestsTemplater) generateParseFunctionTest(structName, structWithoutSuffix string, caseSensitive bool) (*string, error) {
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

func (i resourceIdTestsTemplater) generateSegmentsFunctionTest(structName string) string {
	return fmt.Sprintf(`
func TestSegmentsFor%[1]s(t *testing.T) {
	segments := %[1]s{}.Segments()
	if len(segments) == 0 {
		t.Fatalf("%[1]s has no segments")
	}

	uniqueNames := make(map[string]struct{}, 0)
	for _, segment := range segments {
		uniqueNames[segment.Name] = struct{}{}
	}
	if len(uniqueNames) != len(segments) {
		t.Fatalf("Expected the Segments to be unique but got %%q unique segments and %%d total segments", len(uniqueNames), len(segments))
	} 
}`, structName)
}

func (i resourceIdTestsTemplater) getTestCases(caseSensitive bool) (*string, error) {
	cases := make([]string, 0)
	urlVals := make([]string, 0)
	structMap := make([]string, 0)
	caseInsensitiveStructMap := make([]string, 0)

	for _, segment := range i.resourceData.Segments {
		urlVals = append(urlVals, segment.ExampleValue)

		switch segment.Type {
		case models.StaticResourceIDSegmentType:
			fallthrough
		case models.ResourceProviderResourceIDSegmentType:
			continue
		case models.ConstantResourceIDSegmentType:
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

	isSingleSegmentOnly := len(i.resourceData.Segments) == 1 && i.resourceData.Segments[0].Type == models.ScopeResourceIDSegmentType
	idEndsInScopeSegment := len(i.resourceData.Segments) > 1 && i.resourceData.Segments[len(i.resourceData.Segments)-1].Type == models.ScopeResourceIDSegmentType
	fullUrl := urlFromSegments(urlVals)
	cases = append(cases, fmt.Sprintf(`{
		// Valid URI
		Input: "%s",
		Expected: &%s{
			%s
		},
	},`, fullUrl, i.resourceName, strings.Join(structMap, "\n")))
	if !isSingleSegmentOnly && !idEndsInScopeSegment {
		cases = append(cases, fmt.Sprintf(`{
		// Invalid (Valid Uri with Extra segment) 
		Input: "%s/extra",
		Error: true,
	},`, fullUrl))
	}

	if !caseSensitive {
		fullUrl = alternateCasingOnEveryLetter(fullUrl)
		cases = append(cases, fmt.Sprintf(`{
		// Valid URI (mIxEd CaSe since this is insensitive)
		Input: "%s",
		Expected: &%s{
			%s
		},
	},`, fullUrl, i.resourceName, strings.Join(caseInsensitiveStructMap, "\n")))
		if !isSingleSegmentOnly && !idEndsInScopeSegment {
			cases = append(cases, fmt.Sprintf(`{
		// Invalid (Valid Uri with Extra segment - mIxEd CaSe since this is insensitive)
		Input: "%s/extra",
		Error: true,
	},`, fullUrl))
		}
	}

	out := strings.Join(cases, "\n")
	return &out, nil
}

func (i resourceIdTestsTemplater) getAssertions() (*string, error) {
	lines := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		switch segment.Type {
		case models.ResourceProviderResourceIDSegmentType:
			fallthrough
		case models.StaticResourceIDSegmentType:
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
