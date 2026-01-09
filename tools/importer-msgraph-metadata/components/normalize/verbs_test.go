// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
)

func TestVerbsMatch(t *testing.T) {
	testCases := map[string]struct {
		matched bool
		verb    *string
	}{
		// Standalone verbs
		"Discover":     {true, pointer.To("Discover")},
		"PowerOff":     {true, pointer.To("PowerOff")},
		"Provision":    {true, pointer.To("Provision")},
		"Reprovision":  {true, pointer.To("Reprovision")},
		"Troubleshoot": {true, pointer.To("Troubleshoot")},

		// Verbs at start of name (should be matched)
		"AssignDirectoryRole":                 {true, pointer.To("Assign")},
		"InstantiateApplication":              {true, pointer.To("Instantiate")},
		"PowerOnCloudPC":                      {true, pointer.To("PowerOn")},
		"RevokeCertificate":                   {true, pointer.To("Revoke")},
		"TentativelyAcceptCalendarInvitation": {true, pointer.To("TentativelyAccept")},

		// Verbs not at start of name (should not be matched)
		"AdministratorSetRestriction": {false, nil},
		"FolderShareName":             {false, nil},
		"ReportExtract":               {false, nil},
		"SiteCheckout":                {false, nil},
		"UserDeleted":                 {false, nil},

		// No verbs
		"Demonstrate":          {false, nil},
		"MemberIsUser":         {false, nil},
		"RestartedApplication": {false, nil},
		"ServicePrincipal":     {false, nil},
	}

	for name, expected := range testCases {
		verb, matched := Verbs.Match(name)
		if matched != expected.matched {
			t.Errorf("%s: expected %t match, got %t", name, expected.matched, matched)
		}
		if verb == nil && expected.verb == nil {
			continue
		}
		if (verb == nil && expected.verb != nil) || (verb != nil && expected.verb == nil) || pointer.From(verb) != pointer.From(expected.verb) {
			exp := "nil"
			if expected.verb != nil {
				exp = fmt.Sprintf("%q", *expected.verb)
			}
			got := "nil"
			if verb != nil {
				got = fmt.Sprintf("%q", *verb)
			}
			t.Errorf("%s: expected verb %s, got %s", name, exp, got)
		}
	}
}
