package cleanup

import (
	"github.com/gertd/go-pluralize"
)

type irregularPlural = struct {
	single string
	plural string
}

func GetSingular(input string) string {
	for _, v := range pluralisationExceptions() {
		if input == v.single {
			return v.single
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Singular(input)

	return output
}

func GetPlural(input string) string {
	for _, v := range pluralisationExceptions() {
		if input == v.single {
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
		{"Redis", "Redis"},
	}

	return pluralisationExceptions
}
