// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

type SDKOperationOptionType = string

const (
	SDKOperationOptionTypeData        SDKOperationOptionType = "Data"
	SDKOperationOptionTypeContentType SDKOperationOptionType = "ContentType"
	SDKOperationOptionTypeRetryFunc   SDKOperationOptionType = "RetryFunc"
)

// SDKOperationOption defines a QueryString or HTTP Header that can be specified for an
// Operation.
type SDKOperationOption struct {
	// HeaderName specifies the name of the HTTP Header associated with this Option.
	HeaderName *string `json:"headerName,omitempty"`

	// Type signals a special behavior for this Option.
	//   Data: this option specifies Request data, as described in ObjectDefinition, HeaderName, ODataFieldName and/or QueryStringName.
	//   ContentType: this option specifies a custom Content Type for the Request to be specified by the caller.
	//   RetryFunc: this option specifies a client.RequestRetryFunc that can be passed in.
	Type SDKOperationOptionType `json:"type"`

	// ODataFieldName specifies the name for the OData query string parameter associated with this Option.
	ODataFieldName *string `json:"odataFieldName,omitempty"`

	// QueryStringName specifies the name for the QueryString key associated with this Option.
	QueryStringName *string `json:"queryStringName,omitempty"`

	// ObjectDefinition specifies the shape of the payload this Option represents.
	ObjectDefinition SDKOperationOptionObjectDefinition `json:"objectDefinition"`

	// Required specifies whether this Option must be specified in the Request or not.
	Required bool `json:"required"`
}
