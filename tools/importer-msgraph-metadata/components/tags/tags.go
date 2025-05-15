// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package tags

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type ServiceTags map[string][]string

// Parse returns a ServiceTags (map[string][]string) for the provided openapi3.Tags. Note that the resulting ServiceTags
// item values are not capitalized, singularized or otherwise cleaned up.
func Parse(tags openapi3.Tags) (services ServiceTags, err error) {
	services = make(map[string][]string, 0)
	for _, tag := range tags {
		if tag == nil {
			continue
		}
		if tag.Name != "" {
			t := strings.Split(tag.Name, ".")
			switch len(t) {
			case 2:
				if _, ok := services[t[0]]; !ok {
					services[t[0]] = make([]string, 0)
				}
				services[t[0]] = append(services[t[0]], t[1])

			case 3:
				if _, ok := services[t[0]]; !ok {
					services[t[0]] = make([]string, 0)
				}
				services[t[0]] = append(services[t[0]], t[2])

			default:
				return nil, fmt.Errorf("encountered malformed tag: %q", tag.Name)

			}
		}
	}
	return
}

// Matches returns true when the provided tagName is found in the provided tags; used for filtering out resources or
// operations for other services when selectively importing a specific tag.
func Matches(tagName string, tags []string) bool {
	for _, tag := range tags {
		if t := strings.Split(tag, "."); len(t) > 0 && t[0] == tagName {
			return true
		}
	}
	return false
}
