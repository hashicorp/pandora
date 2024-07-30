package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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

func baseClientPackageForSdk(input models.SourceDataType) string {
	switch input {
	case models.MicrosoftGraphSourceDataType:
		return "msgraph"
	case models.ResourceManagerSourceDataType:
		return "resourcemanager"
	}
	return "client"
}

func capitalizeFirstLetter(input string) string {
	return strings.ToUpper(input[0:1]) + strings.ToLower(input[1:])
}

func copyrightLinesForSource(input models.SourceDataOrigin) (*string, error) {
	if input == models.HandWrittenSourceDataOrigin {
		out := `
// Copyright (c) HashiCorp Inc. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.
`
		return &out, nil
	}

	if input == models.MicrosoftGraphMetaDataSourceDataOrigin {
		out := `
// Copyright (c) HashiCorp Inc. All rights reserved.
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
