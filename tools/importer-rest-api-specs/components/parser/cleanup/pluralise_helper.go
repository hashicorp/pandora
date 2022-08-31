package cleanup

import (
	"strings"

	"github.com/gertd/go-pluralize"
)

type irregularPlural = struct {
	single string
	plural string
}

func getSingular(input string) string {
	for _, v := range pluralisationExceptions() {
		if strings.EqualFold(strings.ToLower(input), v.plural) {
			return v.single
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Singular(input)

	return output
}

func getPlural(input string) string {
	for _, v := range pluralisationExceptions() {
		if strings.EqualFold(strings.ToLower(input), v.single) {
			return v.plural
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Plural(input)

	return output
}

func pluralisationExceptions() []irregularPlural {

	pluralisationExceptions := []irregularPlural{
		// TODO add more exceptions
		{"redis", "redis"},
	}

	return pluralisationExceptions
}
