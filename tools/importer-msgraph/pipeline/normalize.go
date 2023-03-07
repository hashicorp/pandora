package pipeline

import (
	"fmt"
	"net/http"
	"regexp"
	"strings"
)

func singularize(model string) string {
	if len(model) >= 3 && model[len(model)-3:] == "ies" {
		return fmt.Sprintf("%sy", model[:len(model)-3])
	}
	if len(model) >= 1 && model[len(model)-1:] == "s" {
		return model[:len(model)-1]
	}
	return model
}

func pluralize(model string) string {
	ret := fmt.Sprintf("%ss", model)
	if strings.EqualFold(model, "me") {
		return model
	}
	if len(model) < 1 {
		return ret
	}
	if strings.EqualFold(model[len(model)-1:], "y") {
		return fmt.Sprintf("%sies", model[:len(model)-1])
	}
	if strings.EqualFold(model[len(model)-1:], "s") {
		return model
	}
	if len(model) < 2 {
		return ret
	}
	if strings.EqualFold(model[len(model)-2:], "Of") {
		return model
	}
	return ret
}

func normalizeFieldName(segment string) (field string) {
	if segment[0] == '{' {
		field = segment[1 : len(segment)-1]
		field = strings.Title(field)
		field = regexp.MustCompile("([^A-Za-z0-9])").ReplaceAllString(field, "")
	}
	return
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
