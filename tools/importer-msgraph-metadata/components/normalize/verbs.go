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
