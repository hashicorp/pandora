// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

type Operation struct {
	// Name specifies the Display Name for this Operation (e.g. `Create`) which is also
	// valid as an identifier.
	Name string `json:"name"`

	// ContentType specifies the format of the information being sent with the Operation (e.g. `application/json; charset=utf-8`)
	ContentType string `json:"contentType"`

	// ExpectedStatusCodes specifies is a list of Status Codes which are expected to be returned (e.g. 200, 201)
	ExpectedStatusCodes []int `json:"expectedStatusCodes"`

	// FieldContainingPaginationDetails is a reference to the field within the Response
	// which contains the pagination details, (e.g. `nextLink`)
	FieldContainingPaginationDetails *string `json:"fieldContainingPaginationDetails,omitempty"`

	// LongRunning specifies if this is a Long Running Operation, meaning that Clients
	// should follow any `Location` headers to track the result of this operation
	LongRunning bool `json:"longRunning"`

	// HTTPMethod is the Method used for this operation, (e.g. `GET`, `POST`)
	HTTPMethod string `json:"httpMethod"`

	// Options is a list of options which can be specified for this operation
	// which are either HTTP Headers or QueryString parameters, for example 'limit' or 'forceDelete' or similar
	Options *[]Option `json:"options,omitempty"`

	// ResourceIdName specifies the name of the optional Resource ID used for this operation
	ResourceIdName *string `json:"resourceIdName,omitempty"`

	// ResourceIdNameIsCommonType specifies whether the referenced ResourceIdName is a common type
	ResourceIdNameIsCommonType *bool `json:"resourceIdNameIsCommonType,omitempty"`

	// RequestObject specifies the optional ObjectDefinition to be specified in the Request
	RequestObject *ObjectDefinition `json:"requestObject,omitempty"`

	// RequestObject specifies the optional ObjectDefinition to be returned by the Request
	ResponseObject *ObjectDefinition `json:"responseObject,omitempty"`

	// UriSuffix specifies the suffix which should be appended to the ResourceID for this operation
	// NOTE: that a UriSuffix can be specified instead of, as well as in addition to, a ResourceID.
	// (e.g. `/shutdown`)
	UriSuffix *string `json:"uriSuffix,omitempty"`
}

type Option struct {
	// HeaderName is the name of the Http Header which this Option should be set into
	// (e.g. `If-Match`, `x-ms-client-request-id`)
	HeaderName *string `json:"headerName,omitempty"`

	// Optional specifies whether this Option could be specified in the Request
	// NOTE: this is intentionally not inferred from Required to allow retrieving HTTP Header
	// and QueryString values in the Response in the future.
	Optional bool `json:"optional"`

	// QueryStringName is the Key which should be used for this Option in the QueryString
	// (e.g. `createTimeMax`, `isActive`)
	QueryString *string `json:"queryString,omitempty"`

	// Required specifies whether this Option must be specified in the Request
	Required bool `json:"required"`

	// Field specifies the DisplayName of the Option (e.g. `ConstantOption`, `SecondVal`)
	// which is valid as an identifier.
	Field string `json:"field"`

	// OptionsObjectDefinition describes the information contained within the Field
	ObjectDefinition OptionObjectDefinition `json:"optionsObjectDefinition"`
}
