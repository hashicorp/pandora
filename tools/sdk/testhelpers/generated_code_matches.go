package testhelpers

import (
	"strings"
	"testing"
)

func AssertTemplatedCodeMatches(t *testing.T, expected string, actual string) {
	// when generating "for real" we run gofmt after it - whilst we
	// could do that here, as the test data won't contain the other files
	// as such comparing these line by line is fine for now
	actualLines := splitLines(actual)
	expectedLines := splitLines(expected)

	normalizedActualValue := strings.Join(actualLines, "\n")
	normalizedExpectedValue := strings.Join(expectedLines, "\n")

	if len(actualLines) != len(expectedLines) {
		t.Fatalf(`Expected %d lines but got %d lines.

Expected Value:
---
%s
---

Actual Value:
---
%s
---
`, len(expectedLines), len(actualLines), normalizedExpectedValue, normalizedActualValue)
	}

	for i := 0; i < len(actualLines); i++ {
		actualLine := actualLines[i]
		expectedLine := expectedLines[i]
		if !strings.EqualFold(strings.TrimSpace(actualLine), strings.TrimSpace(expectedLine)) {
			t.Fatalf(`Expected and Actual differ on line %d

Expected %q but got %q

Expected Value:
---
%s
---

Actual Value:
---
%s
---
`, i, expectedLine, actualLine, normalizedExpectedValue, normalizedActualValue)
		}
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
