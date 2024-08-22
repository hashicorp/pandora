// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/gertd/go-pluralize"
	"golang.org/x/text/cases"
	"golang.org/x/text/language"
)

func Singularize(name string) string {
	for _, v := range pluralExceptions {
		if name == v.plural {
			return v.singular
		}
	}

	client := pluralize.NewClient()
	output := client.Singular(name)

	return output
}

func Pluralize(name string) string {
	for _, v := range pluralExceptions {
		if name == v.singular {
			return v.plural
		}
	}

	client := pluralize.NewClient()
	output := client.Plural(name)

	return output
}

func CleanName(name string) string {
	if name == "" {
		return name
	}

	// Trim a "microsoft.graph" prefix from type names
	name = strings.TrimPrefix(name, "microsoft.graph")

	// Replace all periods with spaces to allow for title casing
	name = strings.TrimSpace(strings.ReplaceAll(name, ".", " "))

	// Convert name to title case
	name = cases.Title(language.AmericanEnglish, cases.NoLower).String(name)

	// Remove all non-alphanumeric characters, except for any leading underscores
	leading := regexp.MustCompile(`^_+`).FindString(name)
	trailing := regexp.MustCompile(`[^a-zA-Z0-9]`).ReplaceAllString(name[len(leading):], "")
	name = leading + trailing

	// CloudPc should be CloudPC, also fixes inconsistent casing
	name = regexp.MustCompile("(?i)CloudPc").ReplaceAllString(name, "CloudPC")

	// Innererror should be InnerError
	name = regexp.MustCompile("^Innererror").ReplaceAllString(name, "InnerError")

	// Ip[A-Zv] should be IP[A-Zv]
	name = regexp.MustCompile("Ip([A-Zv])").ReplaceAllString(name, "IP${1}")

	// Cidr should be CIDR
	name = regexp.MustCompile("Cidr").ReplaceAllString(name, "CIDR")

	// Oauth should be OAuth
	name = regexp.MustCompile("^Oauth").ReplaceAllString(name, "OAuth")

	// Odata should be OData
	name = regexp.MustCompile("^Odata").ReplaceAllString(name, "OData")

	// Orderby should be OrderBy
	name = regexp.MustCompile("^Orderby").ReplaceAllString(name, "OrderBy")

	// (trailing) ID should be Id for compatibility with Go SDK generator
	name = regexp.MustCompile("([a-z])ID$").ReplaceAllString(name, "${1}Id")

	return name
}

func CleanNameCamel(name string) string {
	name = CleanName(name)
	return strings.ToLower(name[0:1]) + name[1:]
}

type operationVerbs []string

func (ov operationVerbs) Match(operation string) (*string, bool) {
	for _, v := range ov {
		if regexp.MustCompile(fmt.Sprintf("^%s$", v)).MatchString(operation) {
			return &v, true
		}
		if regexp.MustCompile(fmt.Sprintf("^%s[A-Z]", v)).MatchString(operation) {
			return &v, true
		}
	}
	return nil, false
}

var Verbs = operationVerbs{
	"Acquire",
	"Add",
	"Assign",
	"Check",
	"Discover",
	"Get",
	"Instantiate",
	"Parse",
	"Pause",
	"Provision",
	"Remove",
	"Renew",
	"Restart",
	"Restore",
	"Set",
	"Start",
	"Stop",
	"Unset",
	"Update",
	"Validate",
}

type plural struct {
	singular string
	plural   string
}

var pluralExceptions = []plural{
	{"By", "By"},
	{"Compatibility", "Compatibility"},
	{"Cache", "Caches"},
	{"Data", "Data"},
	{"Metadata", "Metadata"},
	{"Orderby", "Orderby"},
	{"Premise", "Premises"},
	{"Sortby", "Sortby"},
}
