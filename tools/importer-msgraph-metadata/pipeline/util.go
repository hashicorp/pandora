package pipeline

import (
	"fmt"
	"sort"
	"strings"
)

func indentSpace(in string, indent int) string {
	inSlice := strings.Split(in, "\n")
	out := make([]string, len(inSlice))
	for i, line := range inSlice {
		if len(line) > 0 {
			line = fmt.Sprintf("%s%s", strings.Repeat(" ", indent), line)
		}
		out[i] = line
	}
	return strings.Join(out, "\n")
}

func pointerTo[T any](input T) *T {
	return &input
}

func sortedKeys(in map[string]string) []string {
	out := make([]string, 0, len(in))
	for k := range in {
		out = append(out, k)
	}
	sort.Strings(out)
	return out
}
