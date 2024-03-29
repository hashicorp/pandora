// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// SDKOperationOption defines a QueryString or HTTP Header that can be specified for an
// Operation.
type SDKOperationOption struct {
	// HeaderName specifies the name of the HTTP Header associated with this Option.
	HeaderName *string `json:"headerName,omitempty"`

	// QueryStringName specifies the name for the QueryString key associated with this Option.
	QueryStringName *string `json:"queryStringName,omitempty"`

	// ObjectDefinition specifies the shape of the payload this Option represents.
	ObjectDefinition SDKOperationOptionObjectDefinition `json:"objectDefinition"`

	// Required specifies whether this Option must be specified in the Request or not.
	Required bool `json:"required"`
}
