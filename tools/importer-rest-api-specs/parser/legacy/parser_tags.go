package legacy

import "strings"

var tagsToIgnore = map[string]struct{}{
	"tags":       {},
	"operations": {},
	"usage":      {},
}

func tagShouldBeIgnored(tag string) bool {
	lowered := strings.ToLower(tag)
	for key := range tagsToIgnore {
		// exact matches e.g. Usage
		if strings.EqualFold(tag, key) {
			return true
		}

		// suffixes e.g. `ComputeOperations`
		if strings.HasSuffix(lowered, strings.ToLower(key)) {
			return true
		}
	}

	return false
}

func normalizeTag(input string) string {
	// NOTE: we could be smarter here, but given this is a handful of cases it's
	// probably prudent to hard-code these for now (and fix the swaggers as we
	// come across them?)
	output := input
	output = strings.ReplaceAll(output, "NetWork", "Network")
	return output
}
