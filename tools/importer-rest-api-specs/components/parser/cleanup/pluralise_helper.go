package cleanup

import (
	"github.com/gertd/go-pluralize"
	"log"
	"strings"
)

type irregularPlural = struct {
	single string
	plural string
}

type caseType int

const (
	LOWER caseType = iota
	UPPER
	TITLE
	CAMEL // This is likely the default in the context of TF and Azure?
)

// GetSingular return the singular version of a given plural
// return values are case preserved to the input.
func GetSingular(input string) string {
	casing := detectCasing(input)
	for _, v := range invariablePlurals() {
		if strings.EqualFold(input, v) {
			log.Printf("got %q returning %q", input, returnCased(v, casing))
			return returnCased(v, casing)
		}
	}

	for _, v := range irregularPlurals() {
		if strings.EqualFold(input, v.plural) {
			return returnCased(v.single, casing)
		}
	}

	client := pluralize.NewClient()
	output := client.Singular(input)

	return returnCased(output, casing)
}

// GetPlural returns the plural of a given word
// return values are case preserved to the input
func GetPlural(input string) string {
	casing := detectCasing(input)
	for _, v := range invariablePlurals() {
		if strings.EqualFold(input, v) {
			return returnCased(v, casing)
		}
	}

	for _, v := range irregularPlurals() {
		if strings.EqualFold(input, v.single) {
			return returnCased(v.plural, casing)
		}
	}

	pluralize := pluralize.NewClient()
	output := pluralize.Plural(input)

	return returnCased(output, casing)
}

// irregularPlurals is an exceptions list for plurals that are not satisfied by go-pluralize
// This list is intended to be treated case insensitively by consumers
func irregularPlurals() []irregularPlural {

	pluralisationExceptions := []irregularPlural{
		{"Cache", "Caches"},
	}
	return pluralisationExceptions
}

// invariablePlurals is a list of words and names that should never be pluralised
func invariablePlurals() []string {
	return []string{
		"Redis",
		"Compute",
		"ContainerInstance",
		"Cosmos-Db",
		"Kusto",
		"PowerBIDedicated",
		"ServiceLinker",
	}
}

func detectCasing(input string) caseType {
	switch {
	case input == strings.ToUpper(input):
		return UPPER
	case input == strings.ToLower(input):
		return LOWER
	case input == strings.Title(input):
		return TITLE
	}
	// Fallback?
	return CAMEL
}

func returnCased(input string, casing caseType) string {
	if casing == LOWER {
		return strings.ToLower(input)
	}
	if casing == UPPER {
		return strings.ToUpper(input)
	}
	if casing == TITLE {
		return strings.Title(input)
	}

	return input
}
