package cleanup

import (
	"github.com/gertd/go-pluralize"
)

type irregularPlural = struct {
	single string
	plural string
}

func GetSingular(input string) string {

	for _, v := range invariablePlurals() {
		if input == v {
			return v
		}
	}

	for _, v := range irregularPlurals() {
		if input == v.plural {
			return v.single
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Singular(input)

	return output
}

func GetPlural(input string) string {

	for _, v := range invariablePlurals() {
		if input == v {
			return v
		}
	}

	for _, v := range irregularPlurals() {
		if input == v.single {
			return v.plural
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Plural(input)

	return output
}

func irregularPlurals() []irregularPlural {

	pluralisationExceptions := []irregularPlural{
		{"cache", "caches"},
		{"Cache", "Caches"},
	}
	return pluralisationExceptions
}

func invariablePlurals() []string {
	return []string{
		"redis",
		"Redis",
		"Compute",
		"ContainerInstance",
		"Cosmos-Db",
		"Kusto",
		"PowerBIDedicated",
		"ServiceLinker",
	}
}
