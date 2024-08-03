// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"regexp"
	"strings"

	"golang.org/x/text/cases"
	"golang.org/x/text/language"
)

func Singularize(name string) string {
	if len(name) >= 3 && name[len(name)-3:] == "ies" {
		return fmt.Sprintf("%sy", name[:len(name)-3])
	}
	if len(name) >= 3 && name[len(name)-3:] == "ses" {
		return name[:len(name)-2]
	}
	if len(name) >= 1 && name[len(name)-1:] == "s" {
		return name[:len(name)-1]
	}
	return name
}

func Pluralize(name string) string {
	if name == "" {
		return ""
	}
	ret := fmt.Sprintf("%ss", name)
	if strings.EqualFold(name, "me") {
		return name
	}
	if len(name) == 0 {
		return ret
	}
	if strings.EqualFold(name[len(name)-2:], "ay") || strings.EqualFold(name[len(name)-2:], "ey") {
		return fmt.Sprintf("%ss", name)
	}
	if strings.EqualFold(name[len(name)-1:], "y") {
		return fmt.Sprintf("%sies", name[:len(name)-1])
	}
	if strings.EqualFold(name[len(name)-1:], "s") {
		return name
	}
	if len(name) < 2 {
		return ret
	}
	if strings.EqualFold(name[len(name)-2:], "Of") {
		return name
	}
	return ret
}

func CleanName(name string) string {
	// Trim a "microsoft.graph" prefix from type names
	name = strings.TrimPrefix(name, "microsoft.graph")

	// Replace all periods with spaces to allow for title casing
	name = strings.ReplaceAll(name, ".", " ")

	// Convert name to title case
	name = cases.Title(language.AmericanEnglish, cases.NoLower).String(name)

	// Remove all non-alphanumeric characters, except for any leading underscores
	leading := regexp.MustCompile(`^_+`).FindString(name)
	trailing := regexp.MustCompile(`[^a-zA-Z0-9]`).ReplaceAllString(name[len(leading):], "")
	name = leading + trailing

	// Odata should be OData
	name = regexp.MustCompile("^Odata").ReplaceAllString(name, "OData")

	// Innererror should be InnerError
	name = regexp.MustCompile("^Innererror").ReplaceAllString(name, "InnerError")

	// known issue where CloudPC appears with inconsistent casing
	name = regexp.MustCompile("(?i)CloudPc").ReplaceAllString(name, "CloudPC")

	// Orderby should be OrderBy
	name = regexp.MustCompile("^Orderby").ReplaceAllString(name, "OrderBy")

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
