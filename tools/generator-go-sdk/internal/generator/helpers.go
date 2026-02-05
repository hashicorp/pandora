// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"os"
	"strings"
	"unicode"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func CleanAndRecreateWorkingDirectory(path string) error {
	// rm -r 💥
	if err := os.RemoveAll(path); err != nil {
		return fmt.Errorf("deleting %q: %+v", path, err)
	}

	return EnsureWorkingDirectoryExists(path)
}

func EnsureWorkingDirectoryExists(path string) error {
	if err := os.MkdirAll(path, 0777); err != nil {
		if !os.IsExist(err) {
			return fmt.Errorf("creating %q: %+v", path, err)
		}
	}

	return nil
}

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

func baseClientPackageForSdk(input models.SourceDataType) string {
	switch input {
	case models.MicrosoftGraphSourceDataType:
		return "msgraph"
	case models.ResourceManagerSourceDataType:
		return "resourcemanager"
	case models.DataPlaneSourceDataType:
		return "dataplane"
	}
	return "client"
}

func camelCase(input string) string {
	return strings.ToLower(input[0:1]) + input[1:]
}

func capitalizeFirstLetter(input string) string {
	return strings.ToUpper(input[0:1]) + strings.ToLower(input[1:])
}

func copyrightLinesForSource(input models.SourceDataOrigin) (*string, error) {
	if input == models.HandWrittenSourceDataOrigin {
		out := `
// Copyright IBM Corp. 2021, 2025 All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &out, nil
	}

	if input == models.MicrosoftGraphMetaDataSourceDataOrigin {
		out := `
// Copyright IBM Corp. 2021, 2025 All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &out, nil
	}

	if input == models.AzureRestAPISpecsSourceDataOrigin {
		out := `
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &out, nil
	}

	// this is used purely for acctests - to ensure the config is stable this is a
	// hand-defined value
	if string(input) == "acctest" {
		out := "// acctests licence placeholder"
		return &out, nil
	}

	return nil, fmt.Errorf("unimplemented license type: %s", string(input))
}

func golangConstantForStatusCode(statusCode int) string {
	codes := map[int]string{
		200: "http.StatusOK",
		201: "http.StatusCreated",
		202: "http.StatusAccepted",
		204: "http.StatusNoContent",
		205: "http.StatusResetContent",
		206: "http.StatusPartialContent",
		207: "http.StatusMultiStatus",
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

func golangTypeNameForConstantType(input models.SDKConstantType) (*string, error) {
	segmentTypes := map[models.SDKConstantType]string{
		models.FloatSDKConstantType:   "float64",
		models.IntegerSDKConstantType: "int64",
		models.StringSDKConstantType:  "string",
	}
	segmentType, ok := segmentTypes[input]
	if !ok {
		return nil, fmt.Errorf("constant type %q has no segmentTypes mapping", input)
	}
	return &segmentType, nil
}

func urlFromSegments(input []string, isDataPlane bool) string {
	output := ""
	for k, v := range input {
		// intentionally to handle scopes
		if !strings.HasPrefix(v, "/") && !(k == 0 && isDataPlane) {
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

	valLength := len(val)
	for i, c := range val {
		isUpper := unicode.IsUpper(c)
		isLower := unicode.IsLower(c)
		isNum := unicode.IsDigit(c)

		if (i + 1) < valLength {
			next := rune(val[i+1])
			nextIsUpper := unicode.IsUpper(next)
			nextIsLower := unicode.IsLower(next)
			nextIsNum := unicode.IsDigit(next)

			if i > 0 {
				if prevIsUpper := unicode.IsUpper(rune(val[i-1])); prevIsUpper && isUpper && nextIsLower {
					output += " "
				}
			}

			if (isUpper && nextIsNum) || (isLower && (nextIsUpper || nextIsNum) || (isNum && (nextIsUpper || nextIsLower))) {
				output += string(c)
				output += " "
				continue
			}
		}
		output += string(c)
	}

	return strings.TrimPrefix(output, " ")
}

// wrapOnWordBoundary attempts to wrap a string on whitespace to the specified maximum length, optionally
// prefixing each line with the provided prefix (useful for comments).
func wrapOnWordBoundary(in string, maxLength int, prefix string) string {
	words := strings.Fields(in)
	out := make([]string, 0)
	currentLine := prefix

	for _, word := range words {
		if len(currentLine)+len(word) >= maxLength {
			out = append(out, strings.TrimSpace(currentLine))
			currentLine = prefix
		}
		currentLine = fmt.Sprintf("%s %s", currentLine, word)
	}

	if currentLine != prefix {
		out = append(out, strings.TrimSpace(currentLine))
	}

	return strings.Join(out, "\n")
}
