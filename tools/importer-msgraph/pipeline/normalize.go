package pipeline

import (
	"fmt"
	"net/http"
	"regexp"
	"strings"
)

func singularize(name string) string {
	if len(name) >= 3 && name[len(name)-3:] == "ies" {
		return fmt.Sprintf("%sy", name[:len(name)-3])
	}
	if len(name) >= 1 && name[len(name)-1:] == "s" {
		return name[:len(name)-1]
	}
	return name
}

func pluralize(name string) string {
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
	if strings.EqualFold(name[len(name)-2:], "ey") {
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

func cleanName(name string) string {
	name = strings.Title(strings.TrimPrefix(name, "microsoft.graph."))
	name = regexp.MustCompile("[^a-zA-Z0-9]").ReplaceAllString(name, "")
	name = regexp.MustCompile("^Is([A-Z])").ReplaceAllString(name, "$1")
	name = regexp.MustCompile("^Odata").ReplaceAllString(name, "OData")
	name = regexp.MustCompile("^Innererror").ReplaceAllString(name, "InnerError")
	return name
}

func cleanNameCamel(name string) string {
	name = cleanName(name)
	return strings.ToLower(name[0:1]) + name[1:]
}

func cleanVersion(version string) string {
	return regexp.MustCompile("[^a-zA-Z0-9]").ReplaceAllString(version, "_")
}

func csHttpStatusCode(code int) string {
	return fmt.Sprintf("HttpStatusCode.%s", strings.ReplaceAll(http.StatusText(code), " ", ""))
}

type operationVerbs []string

func (ov operationVerbs) match(operation string) bool {
	for _, v := range ov {
		if regexp.MustCompile(fmt.Sprintf("^%s$", v)).MatchString(operation) {
			return true
		}
		if regexp.MustCompile(fmt.Sprintf("^%s[A-Z]", v)).MatchString(operation) {
			return true
		}
	}
	return false
}

var verbs = operationVerbs{"Add", "Remove", "Set", "Unset", "Check", "Get", "Acquire", "Discover", "Parse", "Pause", "Provision", "Restart", "Restore", "Start", "Stop", "Validate"}
