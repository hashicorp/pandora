package generator

import (
	"fmt"
	"strings"
	"unicode"
)

var _ templater = idParserTestsTemplater{}

type idParserTestsTemplater struct {
	name        string
	format      string
	packageName string
}

func (i idParserTestsTemplater) template(data ServiceGeneratorData) (*string, error) {
	rid, err := newResourceID(i.name, i.packageName, i.format)
	if err != nil {
		return nil, fmt.Errorf("scaffolding Tests for ID Parser for %q (%q): %+v", i.name, i.format, err)
	}

	code := rid.testCode()
	return &code, nil
}

func (id resourceIdParserData) testCode() string {
	return fmt.Sprintf(`
package %s

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/resourcemanager/resourceids"
)

%s
%s
%s
`, id.ServicePackageName, id.testCodeForFormatter(), id.testCodeForParser(), id.testCodeForParserInsensitive())
}

func (id resourceIdParserData) testCodeForFormatter() string {
	arguments := make([]string, 0)
	for _, segment := range id.Segments {
		arguments = append(arguments, fmt.Sprintf("%q", segment.SegmentValue))
	}
	arguementsStr := strings.Join(arguments, ", ")
	return fmt.Sprintf(`
var _ resourceids.Id = %[1]sId{}

func Test%[1]sIDFormatter(t *testing.T) {
	actual := New%[1]sID(%[2]s).ID()
	expected := %[3]q
	if actual != expected {
		t.Fatalf("Expected %%q but got %%q", expected, actual)
	}
}
`, id.TypeName, arguementsStr, id.IDRaw)
}

func (id resourceIdParserData) testCodeForParser() string {
	testCases := make([]string, 0)
	testCases = append(testCases, `
		{
			// empty
			Input: "",
			Error: true,
		},
`)
	assignmentChecks := make([]string, 0)
	for _, segment := range id.Segments {
		testCaseFmt := `
		{
			// missing %s
			Input: %q,
			Error: true,
		},`
		// missing the key
		resourceIdToThisPointIndex := strings.Index(id.IDRaw, segment.SegmentKey)
		resourceIdToThisPoint := id.IDRaw[0:resourceIdToThisPointIndex]
		testCases = append(testCases, fmt.Sprintf(testCaseFmt, segment.FieldName, resourceIdToThisPoint))

		// missing the value
		resourceIdToThisPointIndex = strings.Index(id.IDRaw, segment.SegmentValue)
		resourceIdToThisPoint = id.IDRaw[0:resourceIdToThisPointIndex]
		testCases = append(testCases, fmt.Sprintf(testCaseFmt, fmt.Sprintf("value for %s", segment.FieldName), resourceIdToThisPoint))

		assignmentsFmt := "\t\tif actual.%[1]s != v.Expected.%[1]s {\n\t\t\tt.Fatalf(\"Expected %%q but got %%q for %[1]s\", v.Expected.%[1]s, actual.%[1]s)\n\t\t}"
		assignmentChecks = append(assignmentChecks, fmt.Sprintf(assignmentsFmt, segment.FieldName))
	}

	// add a successful test case
	expectAssignments := make([]string, 0)
	for _, segment := range id.Segments {
		expectAssignments = append(expectAssignments, fmt.Sprintf("\t\t\t\t%s:\t%q,", segment.FieldName, segment.SegmentValue))
	}
	testCases = append(testCases, fmt.Sprintf(`
		{
			// valid
			Input: "%[1]s",
			Expected: &%[2]sId{
%[3]s
			},
		},
`, id.IDRaw, id.TypeName, strings.Join(expectAssignments, "\n")))

	// add an intentionally failing upper-cased test case
	testCases = append(testCases, fmt.Sprintf(`
		{
			// upper-cased
			Input: %q,
			Error: true,
		},`, strings.ToUpper(id.IDRaw)))

	testCasesStr := strings.Join(testCases, "\n")
	assignmentCheckStr := strings.Join(assignmentChecks, "\n")
	return fmt.Sprintf(`
func TestParse%[1]sID(t *testing.T) {
	testData := []struct {
		Input  string
		Error  bool
		Expected *%[1]sId
	}{
%[2]s
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %%q", v.Input)

		actual, err := Parse%[1]sID(v.Input)
		if err != nil {
			if v.Error {
				continue
			}

			t.Fatalf("Expect a value but got an error: %%s", err)
		}
		if v.Error {
			t.Fatal("Expect an error but didn't get one")
		}

%[3]s
	}
}
`, id.TypeName, testCasesStr, assignmentCheckStr)
}

func (id resourceIdParserData) testCodeForParserInsensitive() string {
	testCases := make([]string, 0)
	testCases = append(testCases, `
		{
			// empty
			Input: "",
			Error: true,
		},
`)
	assignmentChecks := make([]string, 0)
	for _, segment := range id.Segments {
		testCaseFmt := `
		{
			// missing %s
			Input: %q,
			Error: true,
		},`
		// missing the key
		resourceIdToThisPointIndex := strings.Index(id.IDRaw, segment.SegmentKey)
		resourceIdToThisPoint := id.IDRaw[0:resourceIdToThisPointIndex]
		testCases = append(testCases, fmt.Sprintf(testCaseFmt, segment.FieldName, resourceIdToThisPoint))

		// missing the value
		resourceIdToThisPointIndex = strings.Index(id.IDRaw, segment.SegmentValue)
		resourceIdToThisPoint = id.IDRaw[0:resourceIdToThisPointIndex]
		testCases = append(testCases, fmt.Sprintf(testCaseFmt, fmt.Sprintf("value for %s", segment.FieldName), resourceIdToThisPoint))

		assignmentsFmt := "\t\tif actual.%[1]s != v.Expected.%[1]s {\n\t\t\tt.Fatalf(\"Expected %%q but got %%q for %[1]s\", v.Expected.%[1]s, actual.%[1]s)\n\t\t}"
		assignmentChecks = append(assignmentChecks, fmt.Sprintf(assignmentsFmt, segment.FieldName))
	}

	// add a successful test case
	expectAssignments := make([]string, 0)
	for _, segment := range id.Segments {
		expectAssignments = append(expectAssignments, fmt.Sprintf("\t\t\t\t%s:\t%q,", segment.FieldName, segment.SegmentValue))
	}
	testCases = append(testCases, fmt.Sprintf(`
		{
			// valid
			Input: "%[1]s",
			Expected: &%[2]sId{
%[3]s
			},
		},
`, id.IDRaw, id.TypeName, strings.Join(expectAssignments, "\n")))

	var testCaseWithTransformation = func(testCaseName string, transform func(in string) string) string {
		resourceIdWithTransform := id.IDRaw
		for _, segment := range id.Segments {
			// we're not as concerned with these two for now
			if segment.FieldName == "SubscriptionId" || segment.FieldName == "ResourceGroup" {
				continue
			}

			transformedKey := transform(segment.SegmentKey)
			resourceIdWithTransform = strings.Replace(resourceIdWithTransform, segment.SegmentKey, transformedKey, 1)
		}
		return fmt.Sprintf(`
		{
			// %[4]s
			Input: "%[1]s",
			Expected: &%[2]sId{
%[3]s
			},
		},`, resourceIdWithTransform, id.TypeName, strings.Join(expectAssignments, "\n"), testCaseName)
	}

	testCases = append(testCases, testCaseWithTransformation("lower-cased segment names", strings.ToLower))
	testCases = append(testCases, testCaseWithTransformation("upper-cased segment names", strings.ToUpper))
	testCases = append(testCases, testCaseWithTransformation("mixed-cased segment names", func(in string) string {
		out := make([]rune, 0)
		for i, c := range in {
			if i%2 == 0 {
				out = append(out, unicode.ToUpper(c))
			} else {
				out = append(out, unicode.ToLower(c))
			}
		}
		return string(out)
	}))

	testCasesStr := strings.Join(testCases, "\n")
	assignmentCheckStr := strings.Join(assignmentChecks, "\n")
	return fmt.Sprintf(`
func TestParse%[1]sIDInsensitively(t *testing.T) {
	testData := []struct {
		Input  string
		Error  bool
		Expected *%[1]sId
	}{
%[2]s
	}

	for _, v := range testData {
		t.Logf("[DEBUG] Testing %%q", v.Input)

		actual, err := Parse%[1]sIDInsensitively(v.Input)
		if err != nil {
			if v.Error {
				continue
			}

			t.Fatalf("Expect a value but got an error: %%s", err)
		}
		if v.Error {
			t.Fatal("Expect an error but didn't get one")
		}

%[3]s
	}
}
`, id.TypeName, testCasesStr, assignmentCheckStr)
}
