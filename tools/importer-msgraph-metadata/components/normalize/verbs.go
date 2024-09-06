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
	"Cancel",
	"Change",
	"Check",
	"Checkin",
	"Checkout",
	"Copy",
	"Create",
	"Decline",
	"Delete",
	"Discard",
	"Discover",
	"Dismiss",
	"End",
	"Erase",
	"Export",
	"Extract",
	"Find",
	"Follow",
	"Forward",
	"Get",
	"Hide",
	"Insert",
	"Instantiate",
	"Invoke",
	"Issue",
	"Mark",
	"Parse",
	"Pause",
	"PowerOff",
	"PowerOn",
	"Preview",
	"Process",
	"Provision",
	"Reboot",
	"Remove",
	"Rename",
	"Renew",
	"Reprocess",
	"Reprovision",
	"Resize",
	"Restart",
	"Restore",
	"Retry",
	"Revoke",
	"Send",
	"Set",
	"Share",
	"Snooze",
	"Start",
	"Stop",
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
			regexp.MustCompile(fmt.Sprintf("^%s$", verb)),
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
