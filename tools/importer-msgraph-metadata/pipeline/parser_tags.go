package pipeline

import (
	"fmt"
	"github.com/getkin/kin-openapi/openapi3"
	"strings"
)

type Services map[string][]string

// parsetags returns a Services (map[string][]string) for the provided openapi3.Tags. Note that the resulting Services
// item values are not capitalized, singularized or otherwise cleaned up.
func parseTags(tags openapi3.Tags) (services Services, err error) {
	services = make(map[string][]string, 0)
	for _, tag := range tags {
		if tag == nil {
			continue
		}
		if tag.Name != "" {
			t := strings.Split(tag.Name, ".")
			if len(t) != 2 {
				return nil, fmt.Errorf("encountered malformed tag: %q", tag.Name)
			}
			if _, ok := services[t[0]]; !ok {
				services[t[0]] = make([]string, 0)
			}
			services[t[0]] = append(services[t[0]], t[1])
		}
	}
	return
}

// tagMatches returns true when the provided tagName is found in the provided tags; used for filtering out resources or
// operations for other services when selectively importing a specific tag.
func tagMatches(tagName string, tags []string) bool {
	for _, tag := range tags {
		if t := strings.Split(tag, "."); len(t) > 0 && t[0] == tagName {
			return true
		}
	}
	return false
}
