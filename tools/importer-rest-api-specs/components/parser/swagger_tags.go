package parser

import (
	"sort"
	"strings"
)

var tagsToIgnore = map[string]struct{}{
	"tags":       {},
	"operations": {},
	"usage":      {},
}

func (d *SwaggerDefinition) findTags() []string {
	tags := make(map[string]struct{})

	// first we go through, assuming there are tags
	for _, operation := range d.swaggerSpecExpanded.Operations() {
		for _, details := range operation {
			for _, tag := range details.Tags {
				tags[tag] = struct{}{}
			}
		}
	}

	out := make([]string, 0)
	for key := range tags {
		out = append(out, key)
	}
	sort.Strings(out)
	return out
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

	// there's a handful of these (e.g. `FluxConfigurationOperationStatus`)
	if strings.Contains(lowered, "operationstatus") {
		return true
	}

	return false
}
