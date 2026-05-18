// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"regexp"

	"github.com/gertd/go-pluralize"
)

type plural struct {
	singular string
	plural   string
}

var pluralExceptions = []plural{
	{"By", "By"},
	{"Cache", "Caches"},
	{"Compatibility", "Compatibility"},
	{"Data", "Data"},
	{"Metadata", "Metadata"},
	{"Orderby", "Orderby"},
	{"Premise", "Premises"},
	{"Sms", "Sms"},
	{"Sortby", "Sortby"},
}

var (
	singularMatchers = map[string]*regexp.Regexp{}
	pluralMatchers = map[string]*regexp.Regexp{}
	pluralizeClient = pluralize.NewClient()
)

func init() {
	singularMatchers = make(map[string]*regexp.Regexp)
	pluralMatchers = make(map[string]*regexp.Regexp)

	for _, exception := range pluralExceptions {
		singularMatchers[exception.singular] = regexp.MustCompile(fmt.Sprintf("^(.*[a-z]?)%s$", exception.plural))
		pluralMatchers[exception.plural] = regexp.MustCompile(fmt.Sprintf("^(.*[a-z]?)%s$", exception.singular))
	}
}

func Singularize(name string) string {
	for _, exception := range pluralExceptions {
		if singularMatchers[exception.singular].MatchString(name) {
			return singularMatchers[exception.singular].ReplaceAllString(name, "$1") + exception.singular
		}
	}

	output := pluralizeClient.Singular(name)

	return output
}

func Pluralize(name string) string {
	for _, exception := range pluralExceptions {
		if pluralMatchers[exception.plural].MatchString(name) {
			return pluralMatchers[exception.plural].ReplaceAllString(name, "$1") + exception.plural
		}
	}

	output := pluralizeClient.Plural(name)

	return output
}
