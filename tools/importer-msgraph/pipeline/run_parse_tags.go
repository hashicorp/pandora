package pipeline

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Services map[string][]string

func parseTags(spec *openapi3.T) (Services, error) {
	services := make(map[string][]string, 0)
	for _, tag := range spec.Tags {
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
	return services, nil
}

func tagMatches(tagName string, tags []string) bool {
	for _, tag := range tags {
		if t := strings.Split(tag, "."); len(t) > 0 && t[0] == tagName {
			return true
		}
	}
	return false
}
