package pipeline

import "strings"

type Services map[string][]string

func tagMatches(tagName string, tags []string) bool {
	for _, tag := range tags {
		if t := strings.Split(tag, "."); len(t) > 0 && t[0] == tagName {
			return true
		}
	}
	return false
}
