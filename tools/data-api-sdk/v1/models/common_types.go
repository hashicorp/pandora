// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// CommonTypes defines the common set of SDKConstant's and SDKModel's used
// throughout this Source Data Type.
type CommonTypes struct {
	// Constants specifies a map of Constant Name (key) to SDKConstant (value) which
	// describes each common Constant supported by this API.
	// NOTE: the Constant Name is a valid Identifier.
	Constants map[string]SDKConstant `json:"constants"`

	// Models specifies a map of Model Name (key) to SDKModel (value) which
	// describes each common Model supported by this API.
	// NOTE: the Model Name is a valid Identifier.
	Models map[string]SDKModel `json:"models"`
}
