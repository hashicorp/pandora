// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cleanup

import (
	"golang.org/x/text/cases"
	"golang.org/x/text/language"
)

func Title(in string) string {
	return cases.Title(language.AmericanEnglish, cases.NoLower).String(in)
}
