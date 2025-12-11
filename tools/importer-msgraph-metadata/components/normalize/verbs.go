// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"fmt"
	"regexp"
)

type operationVerbs []string

// Verbs is a slice of verbs to match against operation names. An operation is considered to match a verb only
// when it begins with a known verb, and verbs can span multiple words, e.g. "TentativelyAccept"
var Verbs = operationVerbs{
	"Accept",
	"Acquire",
	"Add",
	"Assign",
	"Bypass",
	"Cancel",
	"Change",
	"Check",
	"Checkin",
	"Checkout",
	"Clean",
	"Clear",
	"Copy",
	"CreateOrGet", // match before "Create"
	"Create",
	"Decline",
	"Delete",
	"Disable",
	"Discard",
	"Discover",
	"Dismiss",
	"Enable",
	"End",
	"Erase",
	//"Export", // clashes with `/deviceManagement/reports/exportJobs`
	"Evaluate",
	"Extract",
	"Forward",
	"Find",
	"Follow",
	"Forward",
	"Get",
	"Hide",
	"Insert",
	"Instantiate",
	"Invoke",
	"Issue",
	"Locate",
	"Login",
	"Logout",
	"Mark",
	"Move",
	"Parse",
	"Pause",
	"PowerOff",
	"PowerOn",
	"Preview",
	"Process",
	"Provision",
	"Reboot",
	"Recover",
	"RemoteLock",
	"Remove",
	"Rename",
	"Renew",
	"ReplyAll", // match before "Reply"
	"Reply",
	"Reprocess",
	"Reprovision",
	"Request",
	"Reset",
	"Resize",
	"Restart",
	"Restore",
	"Retire",
	"Retry",
	"Revoke",
	"Send",
	"Set",
	"Share",
	"ShutDown",
	"Snooze",
	"Start",
	"Stop",
	"Sync",
	"TentativelyAccept",
	"Translate",
	"Troubleshoot",
	"Unfollow",
	"Unhide",
	"Unmark",
	"Unset",
	"Unshare",
	"Update",
	"Validate",
	"Wipe",
}

var verbMatchers = map[string][]*regexp.Regexp{}

func init() {
	// Compile regexp structs for all verbs in advance for performance
	verbMatchers = make(map[string][]*regexp.Regexp)
	for _, verb := range Verbs {
		verbMatchers[verb] = []*regexp.Regexp{
			// Match when the entire name is a verb
			regexp.MustCompile(fmt.Sprintf("^%s$", verb)),

			// Match when the name starts with a verb and is followed by another title-cased word
			regexp.MustCompile(fmt.Sprintf("^%s[A-Z]", verb)),
		}
	}
}

// Match returns the matched verb and a boolean to indicate a positive match, when an operation name
// begins with a known verb - noting that verbs can span multiple words.
func (ov operationVerbs) Match(operationName string) (*string, bool) {
	for _, v := range ov {
		for _, re := range verbMatchers[v] {
			if re.MatchString(operationName) {
				return &v, true
			}
		}
	}
	return nil, false
}
