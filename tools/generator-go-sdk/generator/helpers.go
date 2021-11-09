package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func alternateCasingOnEveryLetter(input string) string {
	output := ""
	caps := false
	for _, c := range input {
		if c == '/' {
			// for every segment restart
			output += string(c)
			caps = false
			continue
		}

		if caps {
			caps = false
			output += strings.ToUpper(string(c))
		} else {
			caps = true
			output += strings.ToLower(string(c))
		}
	}

	return output
}

func golangConstantForStatusCode(statusCode int) string {
	codes := map[int]string{
		200: "http.StatusOK",
		201: "http.StatusCreated",
		202: "http.StatusAccepted",
		204: "http.StatusNoContent",
		301: "http.StatusMovedPermanently",
		302: "http.StatusFound",
		307: "http.StatusTemporaryRedirect",
		308: "http.StatusPermanentRedirect",
		400: "http.StatusBadRequest",
		401: "http.StatusUnauthorized",
		403: "http.StatusForbidden",
		404: "http.StatusNotFound",
		405: "http.StatusMethodNotAllowed",
		406: "http.StatusNotAcceptable",
		407: "http.StatusProxyAuthRequired",
		408: "http.StatusRequestTimeout",
		409: "http.StatusConflict",
		410: "http.StatusGone",
		429: "http.StatusTooManyRequests",
		500: "http.StatusInternalServerError",
		501: "http.StatusNotImplemented",
		502: "http.StatusBadGateway",
		503: "http.StatusServiceUnavailable",
		504: "http.StatusGatewayTimeout",
	}
	v, ok := codes[statusCode]
	if ok {
		return v
	}

	return fmt.Sprintf("%d // TODO: document me", statusCode)
}

func golangTypeNameForConstantType(input resourcemanager.ConstantType) (*string, error) {
	segmentTypes := map[resourcemanager.ConstantType]string{
		resourcemanager.IntegerConstant: "int64",
		resourcemanager.FloatConstant:   "float64",
		resourcemanager.StringConstant:  "string",
	}
	segmentType, ok := segmentTypes[input]
	if !ok {
		return nil, fmt.Errorf("constant type %q has no segmentTypes mapping", string(input))
	}
	return &segmentType, nil
}

func urlFromSegments(input []string) string {
	output := ""
	for _, v := range input {
		// intentionally to handle scopes
		if !strings.HasPrefix(v, "/") {
			output += "/"
		}
		output += v
	}
	return output
}

// wordifyString takes an input PascalCased string and converts it to a more human-friendly variant
// e.g. `ApplicationGroupId` -> `Application Group`
func wordifyString(input string) string {
	val := strings.Title(input)
	val = strings.TrimSuffix(val, "Id")
	output := ""

	for _, c := range val {
		character := string(c)
		if strings.ToUpper(character) == character {
			output += " "
		}
		output += character
	}

	return strings.TrimPrefix(output, " ")
}
