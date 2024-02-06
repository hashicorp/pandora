// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

type CommonTypesDetails struct {
	// Constants is a map of key (Constant Name) to value (ConstantDetails) describing
	// each common Constant supported by this API
	Constants map[string]ConstantDetails `json:"constants"`

	// Models is a map of key (Model Name) to value (ModelDetails) describing
	// each common Model supported by this API
	Models map[string]ModelDetails `json:"models"`
}
