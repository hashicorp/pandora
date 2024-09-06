package normalize

import (
	"fmt"
	"regexp"
)

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
	"Change",
	"Check",
	"Discover",
	"Export",
	"Find",
	"Get",
	"Instantiate",
	"Invoke",
	"Issue",
	"Parse",
	"Pause",
	"Process",
	"Provision",
	"Remove",
	"Renew",
	"Restart",
	"Restore",
	"Retry",
	"Revoke",
	"Set",
	"Send",
	"Start",
	"Stop",
	"Translate",
	"Unset",
	"Update",
	"Validate",
	"Wipe",
}
