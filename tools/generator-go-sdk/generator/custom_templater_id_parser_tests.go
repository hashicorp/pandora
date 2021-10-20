package generator

import (
	"fmt"
	"regexp"
	"strings"

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
	return &res, nil
}

func (i idCustomParserTestsTemplater) generateTests(packageName string) (string, error) {
	preamble, err := i.generatePreamble(packageName)
	if err != nil {
		return "", err
	}

	parserTest, err := i.generateParserTest()
	if err != nil {
		return "", err
	}

	resourceTest := i.generateTestCases()
	if err != nil {
		return "", err
	}

	return strings.Join([]string{preamble, parserTest, resourceTest}, "\n"), nil
}

func (i idCustomParserTestsTemplater) generatePreamble(packageName string) (string, error) {
	return fmt.Sprintf(`package %[1]s

import (
	"reflect"
	"testing"

    "github.com/hashicorp/terraform-provider-azurerm/internal/resourceid"
)

var _ resourceid.Formatter = %[2]s{}

`, packageName, strings.Title(i.resourceName)), nil
}

func (i idCustomParserTestsTemplater) generateParserTest() (string, error) {
	re := regexp.MustCompile("Id$")
	resourceName := re.ReplaceAllString(strings.Title(i.resourceName), "ID")
	paramVals, urlVals, err := i.getVals()
	if err != nil {
		return "", fmt.Errorf("while getting values for test generation: %+v", err)
	}
	url := fmt.Sprintf("/%s", strings.Join(urlVals, "/"))
	params := strings.Join(paramVals, ",")

	// Remove duplicate separators
	re, err = regexp.Compile("/+")
	if err != nil {
		return "", fmt.Errorf("while compiling regexp '/+': %+v", err)
	}
	url = re.ReplaceAllString(url, "/")
	params = re.ReplaceAllString(params, "/")

	out := fmt.Sprintf(`func TestParse%[1]s(t *testing.T) {
	expected := %[2]q
	actual := New%[1]s(%[3]s).ID()
	if actual != expected {
	t.Fatalf("Expected %%q but got %%q", expected, actual)}}`, resourceName, url, params)

	return out, nil
}

func (i idCustomParserTestsTemplater) getVals() ([]string, []string, error) {
	urlVals := make([]string, 0)
	paramVals := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		urlVals = append(urlVals, fmt.Sprintf("%s", segment.ExampleValue))
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment:
			fallthrough
		case resourcemanager.StaticSegment:
			continue
		default:
			paramVals = append(paramVals, fmt.Sprintf("%q", segment.ExampleValue))
		}
	}

	return paramVals, urlVals, nil
}

func (i idCustomParserTestsTemplater) getTestCases(resourceName string) string {
	cases := make([]string, 0)
	urlVals := make([]string, 0)
	segments := i.resourceData.Segments
	structMap := make([]string, 0)
	for _, segment := range segments {
		urlVals = append(urlVals, segment.ExampleValue)
		switch segment.Type {
		case resourcemanager.StaticSegment:
			fallthrough
		case resourcemanager.ResourceProviderSegment:
			continue
		default:
			structMap = append(structMap, fmt.Sprintf("%s: %q,", strings.Title(segment.Name), segment.ExampleValue))
		}
	}
	rps := i.getResourceProviders()
	if len(rps) > 0 {
		structMap = append(structMap, fmt.Sprintf("ResourceProvidersUsed: []string{%s},", strings.Join(rps, ",")))
	}

	for idx := 0; idx < len(urlVals); idx++ {
		testUrl := strings.Join(urlVals[0:idx], "/")
		cases = append(cases, fmt.Sprintf(`
		{
			Input: "/%s",
			Error: true,
		},`, testUrl))
	}

	fullUrl := strings.Join(urlVals, "/")
	re := regexp.MustCompile("/+")
	fullUrl = re.ReplaceAllString(fullUrl, "/")
	final := fmt.Sprintf(`
	{
		Input: "%s",
		Expected: &%s{
			%s
		},
	},
`, fullUrl, i.resourceName, strings.Join(structMap, "\n"))

	cases = append(cases, final)
	return strings.Join(cases, "\n")
}

func (i idCustomParserTestsTemplater) getResourceProviders() []string {
	out := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		if segment.Type != resourcemanager.ResourceProviderSegment {
			continue
		}
		if segment.FixedValue != nil {
			out = append(out, fmt.Sprintf("%q", *segment.FixedValue))
		}
	}
	return out
}

func (i idCustomParserTestsTemplater) getTestCaseChecks() string {
	out := make([]string, 0)
	for _, segment := range i.resourceData.Segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment:
			fallthrough
		case resourcemanager.StaticSegment:
			continue
		default:
			out = append(out, fmt.Sprintf(`
if actual.%[1]s != v.Expected.%[1]s {
	t.Fatalf("Expected %%q but got %%q for %[1]s", v.Expected.%[1]s, actual.%[1]s)
}`, strings.Title(segment.Name)))
		}
	}
	out = append(out, `if !reflect.DeepEqual(actual.ResourceProvidersUsed, v.Expected.ResourceProvidersUsed) {
	t.Fatalf("Expected %q but got %q for ResourceProvidersUsed", v.Expected.ResourceProvidersUsed, actual.ResourceProvidersUsed)
}`)
	return strings.Join(out, "\n")
}

func (i idCustomParserTestsTemplater) generateTestCases() string {
	re, _ := regexp.Compile("Id$")
	resourceName := re.ReplaceAllString(strings.Title(i.resourceName), "ID")

	testCases := i.getTestCases(resourceName)
	testCaseChecks := i.getTestCaseChecks()
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

			t.Fatalf("Expect a value but got an error: %%s", err)
		}
		if v.Error {
			t.Fatal("Expect an error but didn't get one")
		}
%[4]s

	}
}
`, resourceName, strings.Title(i.resourceName), testCases, testCaseChecks)

	return out
}
