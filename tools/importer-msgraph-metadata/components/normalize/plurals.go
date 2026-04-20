// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"regexp"
	"sync"

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
	pluralizeClient *pluralize.Client
	once sync.Once
	// pluralizeClient is not thread safe
	mux sync.Mutex
)

func PluralizeClient() *pluralize.Client {
	once.Do(func() {
		pluralizeClient = pluralize.NewClient()
	})
	return pluralizeClient
}

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

	mux.Lock()
	defer mux.Unlock()
	output := PluralizeClient().Singular(name)

	return output
}

func Pluralize(name string) string {
	for _, exception := range pluralExceptions {
		if pluralMatchers[exception.plural].MatchString(name) {
			return pluralMatchers[exception.plural].ReplaceAllString(name, "$1") + exception.plural
		}
	}

	mux.Lock()
	defer mux.Unlock()
	output := PluralizeClient().Plural(name)

	return output
}
