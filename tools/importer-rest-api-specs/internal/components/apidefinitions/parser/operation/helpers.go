// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package operation

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"net/http"
	"sort"
	"strings"

	"github.com/go-openapi/spec"
)

func determineContentType(operation parsedOperation) string {
	contentType := "application/json"

	if strings.EqualFold(operation.httpMethod, "HEAD") || strings.EqualFold(operation.httpMethod, "GET") {
		if len(operation.operation.Produces) > 0 {
			contentType = operation.operation.Produces[0]
		}
	} else {
		if len(operation.operation.Consumes) > 0 {
			contentType = operation.operation.Consumes[0]
		}
	}

	return contentType
}

func expectedStatusCodesForOperation(input parsedOperation) []int {
	statusCodes := make([]int, 0)

	for statusCode, resp := range input.operation.Responses.StatusCodeResponses {
		// sanity checking
		if isASuccessResponse(statusCode, resp) {
			statusCodes = append(statusCodes, statusCode)
		}
	}

	if !usesNonDefaultStatusCodes(input, statusCodes) {
		if isLongRunning(input) {
			if strings.EqualFold(input.httpMethod, "delete") {
				statusCodes = []int{200, 202}
			}
			if strings.EqualFold(input.httpMethod, "post") {
				statusCodes = []int{201, 202}
			}
			if strings.EqualFold(input.httpMethod, "put") {
				statusCodes = []int{201, 202}
			}
		}
		if isListOperation(input) {
			if strings.EqualFold(input.httpMethod, "get") {
				statusCodes = []int{200}
			}
		}
		if strings.EqualFold(input.httpMethod, "delete") || strings.EqualFold(input.httpMethod, "get") || strings.EqualFold(input.httpMethod, "post") || strings.EqualFold(input.httpMethod, "head") {
			statusCodes = []int{200}
		}
		if strings.EqualFold(input.httpMethod, "put") || strings.EqualFold(input.httpMethod, "patch") {
			statusCodes = []int{200, 201}
		}
	}
	sort.Ints(statusCodes)

	return statusCodes
}

func fieldContainingPaginationDetailsForOperation(input parsedOperation) *string {
	if raw, ok := input.operation.VendorExtensible.Extensions["x-ms-pageable"]; ok {
		val, ok := raw.(map[string]interface{})
		if ok {
			for k, v := range val {
				// this can be 'null' in the swagger
				if v == nil {
					continue
				}
				if strings.EqualFold("nextLinkName", k) {
					str := v.(string)
					return &str
				}
			}
		}
	}

	return nil
}

func isASuccessResponse(statusCode int, resp spec.Response) bool {
	// Status Codes with the extension `x-ms-error-response` reference an error response
	// which should be ignored in our case - as errors will instead be pulled out via the
	// base layer
	isErrorValue, exists := resp.Extensions.GetBool("x-ms-error-response")
	if exists && isErrorValue {
		return false
	}

	return statusCode >= 200 && statusCode < 300
}

func isListOperation(input parsedOperation) bool {
	paginationField := fieldContainingPaginationDetailsForOperation(input)
	if paginationField != nil {
		return true
	}

	// otherwise if we have a parameter of `$skiptoken` in the query, we assume that it is
	for _, parameter := range input.operation.Parameters {
		if strings.EqualFold(parameter.Name, "$skipToken") {
			return true
		}
	}

	return false
}

func isLongRunning(input parsedOperation) bool {
	// Some Swaggers have the following defined on an Operation:
	//   > "x-ms-long-running-operation": true,
	//   > "x-ms-long-running-operation-options": {
	//   >   "final-state-via": "azure-async-operation"
	//   > }
	// Whilst these _could_ be useful at some point we can likely ignore them for
	// the moment since the convention is either `Location` or `Azure-AsyncOperation`
	val, exists := input.operation.Extensions.GetBool("x-ms-long-running-operation")
	if !exists {
		return false
	}

	return val
}

func matchesTag(operation *spec.Operation, tag *string) bool {
	// if there's no tags defined, we should capture it when the tag matched
	if tag == nil {
		return len(operation.Tags) == 0
	}

	for _, thisTag := range operation.Tags {
		if strings.EqualFold(thisTag, *tag) {
			return true
		}
	}

	return false
}

func shouldBeIgnored(input sdkModels.SDKOperation) bool {
	// Some HTTP Operations don't make sense for us to expose at this time, for example
	// a GET request which returns no content. They may at some point in the future but
	// for now there's not much point
	//
	// Example: the 'GetSubscriptionOperationWithAsyncResponse' in Web, which returns the
	// result of a LRO - but in our case that's handled elsewhere so we don't need it
	if strings.EqualFold(input.Method, "GET") {
		if len(input.ExpectedStatusCodes) == 1 && input.ExpectedStatusCodes[0] == http.StatusNoContent && input.ResponseObject == nil {
			return true
		}
	}

	return false
}

func usesNonDefaultStatusCodes(input parsedOperation, statusCodes []int) bool {
	defaultStatusCodes := map[string][]int{
		"get":    {200},
		"post":   {200, 201},
		"put":    {200, 201},
		"delete": {200, 201},
		"patch":  {200, 201},
	}
	expected, ok := defaultStatusCodes[strings.ToLower(input.httpMethod)]
	if !ok {
		// potentially an unsupported use-case but fine for now
		return true
	}

	if len(expected) != len(statusCodes) {
		return true
	}

	sort.Ints(expected)
	sort.Ints(statusCodes)
	for i, ev := range expected {
		av := statusCodes[i]
		if ev != av {
			return true
		}
	}

	return false
}
