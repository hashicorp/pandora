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
	if len(name) >= 3 && name[len(name)-3:] == "ses" {
		return name[:len(name)-2]
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

func deDuplicate(name string) string {
	name2 := regexp.MustCompile(`\b(\w+)\s+$1\b`).ReplaceAllString(name, "$1")
	fmt.Println(name2)
	nameSpaced := regexp.MustCompile("([A-Z])").ReplaceAllString(name, " $1")
	nameParts := strings.Split(strings.TrimSpace(nameSpaced), " ")
	newParts := make([]string, 0, len(nameParts))
	checkPieces := make([]string, 0)
	for i := 0; i < len(nameParts); i++ {
		checkPiece := ""
		for j := 0; j < i; j++ {
			checkPiece = checkPiece + nameParts[j]
		}
		checkPieces = append(checkPieces, checkPiece)
		if i > 0 && strings.EqualFold(nameParts[i], nameParts[i-1]) {
			continue
		}
		newParts = append(newParts, nameParts[i])
	}
	return strings.Join(newParts, "")
}

func cleanName(name string) string {
	name = strings.Title(strings.TrimPrefix(name, "microsoft.graph"))
	name = regexp.MustCompile("[.]").ReplaceAllString(name, "_")
	name = regexp.MustCompile("[^a-zA-Z0-9]").ReplaceAllString(name, "")
	name = regexp.MustCompile("^Odata").ReplaceAllString(name, "OData")
	name = regexp.MustCompile("^Innererror").ReplaceAllString(name, "InnerError")
	return name
}

func cleanNameCamel(name string) string {
	name = cleanName(name)
	return strings.ToLower(name[0:1]) + name[1:]
}

func cleanVersion(version string) string {
	switch version {
	case "v1.0":
		return "StableV1"
	case "beta":
		return "Beta"
	}

	panic(fmt.Sprintf("Unrecognised API version string: %s", version))
}

func deDuplicateName(name string) string {
	words := make([]string, 0)
	i := 0
	for j, c := range name {
		char := string(c)
		if j > 0 && strings.ToUpper(char) == char {
			i++
		}
		if len(words) <= i {
			words = append(words, "")
		}
		words[i] = words[i] + char
	}

	out := ""
	for k, word := range words {
		if k > 0 && strings.EqualFold(words[k-1], word) {
			continue
		}
		out = out + word
	}

	return out
}

func definitionsDirectory(version string) string {
	return fmt.Sprintf("MicrosoftGraph.%s", cleanVersion(version))
}

func versionIsPreview(version string) bool {
	if version == "v1.0" {
		return false
	}
	return true
}

func csHttpStatusCode(code int) string {
	return fmt.Sprintf("HttpStatusCode.%s", strings.ReplaceAll(http.StatusText(code), " ", ""))
}

type operationVerbs []string

func (ov operationVerbs) match(operation string) (*string, bool) {
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

var verbs = operationVerbs{
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
	"Validate",
}
