package generator

import (
	"fmt"
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

const AccTestLicenceType resourcemanager.ApiDefinitionsSource = "acctest"

func assertTemplatedCodeMatches(t *testing.T, expected string, actual string) {
	// when generating "for real" we run gofmt after it - whilst we
	// could do that here, as the test data won't contain the other files
	// as such comparing these line by line is fine for now
	actualLines := splitLines(actual)
	expectedLines := splitLines(expected)

	normalizedActualValue := strings.Join(numberLines(actualLines), "\n")
	normalizedExpectedValue := strings.Join(numberLines(expectedLines), "\n")

	actualLen := len(actualLines)
	expectedLen := len(expectedLines)

	if actualLen != expectedLen {
		t.Errorf("Expected %d lines but got %d lines.", len(expectedLines), len(actualLines))
	}

	for i := 0; i < len(actualLines); i++ {
		actualLine := actualLines[i]

		if expectedLen <= i {
			t.Errorf("Actual ends at line %d", expectedLen)
			break
		} else if expectedLine := expectedLines[i]; !strings.EqualFold(strings.TrimSpace(actualLine), strings.TrimSpace(expectedLine)) {
			t.Errorf("Expected and Actual differ on line %d\nExpected %q but got %q", i+1, expectedLine, actualLine)
			break
		}
	}

	if t.Failed() {
		t.Fatalf(`
Expected Value:
---
%s
---

Actual Value:
---
%s
---
`, normalizedExpectedValue, normalizedActualValue)
	}
}

func splitLines(input string) []string {
	// normalize the spacing and remove any empty lines, since they don't matter for testing
	lines := strings.Split(strings.TrimSpace(input), "\n")
	out := make([]string, 0)
	for _, line := range lines {
		line = strings.TrimSpace(line)
		line = strings.ReplaceAll(line, "\t", " ")
		if line == "" || line == "\n" {
			continue
		}

		out = append(out, line)
	}
	return out
}

func numberLines(input []string) []string {
	out := make([]string, len(input))
	for n := range input {
		out[n] = fmt.Sprintf("%d\t%s", n+1, input[n])
	}
	return out
}

func stringPointer(in string) *string {
	return &in
}
