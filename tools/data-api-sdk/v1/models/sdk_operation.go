// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// SDKOperation defines an API Operation (e.g. a GET operation against an endpoint within
// Azure Resource Manager or Microsoft Graph) that should be output in (and assumed to exist
// within) the Go SDK. This information includes the HTTP Method used, any Request/Response
// Payloads and the expected status codes, amongst other properties.
type SDKOperation struct {
	// ContentType specifies the HTTP `Content-Type` header which should be used when
	// performing the Request for this Operation.
	ContentType string `json:"contentType"`

	// Description is used to write a comment for the operation method
	Description string `json:"description"`

	// ExpectedStatusCodes specifies the list of Status Codes which are expected to be
	// returned by this Operation.
	ExpectedStatusCodes []int `json:"expectedStatusCodes"`

	// FieldContainingPaginationDetails is an optional field specifying the name of the
	// Field within the ResponseObject that contains the pagination information (e.g.
	// the `nextLink` or `@odata.link` field).
	FieldContainingPaginationDetails *string `json:"fieldContainingPaginationDetails,omitempty"`

	// LongRunning specifies if this is a Long Running Operation, meaning that this
	// Operation does not complete immediately - and must be polled until completion.
	// The type of Polling used depends on the HTTP Response - but typically polls on
	// either the HTTP Header `Location` and/or the `provisioningState` value.
	LongRunning bool `json:"longRunning"`

	// Method specifies the HTTP Method used for this operation, e.g. GET, POST, PATCH.
	Method string `json:"method"`

	// Options specifies a map of Option Name (key) to SDKOperationOption (value) which
	// allows supporting optional QueryString or HTTP Header parameters. Example of these
	// are the QueryString parameter `forceDelete` and the HTTP Header `If-Match`.
	// NOTE: the Option Name is a valid Identifier.
	Options map[string]SDKOperationOption `json:"options"`

	// RequestObject optionally specifies the Object which must be provided in the Request.
	// This is represented by an SDKObjectDefinition, which defines the shape of the object.
	RequestObject *SDKObjectDefinition `json:"requestObject"`

	// ResourceIDName optionally specifies the name of the Resource ID related to this Operation.
	// When specified, this forms part of the Request URI - and MAY or MAY NOT be supplemented by
	// a URISuffix.
	// This means the Request URI can be either:
	//   1. {formattedResourceId}
	//   2. {formattedResourceId}{uriSuffix}
	//   3. {uriSuffix}
	ResourceIDName *string `json:"resourceIdName"`

	// ResourceIDNameIsCommonType specifies whether the referenced ResourceIdName is a common type
	ResourceIDNameIsCommonType *bool `json:"resourceIdNameIsCommonType,omitempty"`

	// ResponseObject optionally specifies the Object which is expected to be returned in the
	// HTTP Response. This is represented by an SDKObjectDefinition, which defines the shape
	// of the object.
	ResponseObject *SDKObjectDefinition `json:"responseObject"`

	// URISuffix optionally specifies a static value which will be suffixed onto the URI for
	// this Operation. This is typically used to perform Operations on Resources (e.g. `/shutdown`).
	// When specified, this forms part of the Request URI - and MAY or MAY NOT be supplemented by
	// a ResourceID.
	// This means the Request URI can be either:
	//   1. {formattedResourceId}
	//   2. {formattedResourceId}{uriSuffix}
	//   3. {uriSuffix}
	URISuffix *string `json:"uriSuffix"`
}
