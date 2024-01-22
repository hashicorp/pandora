// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationRequestObjectChanged{}

// OperationRequestObjectChanged defines an existing Operation where the Request Object has changed.
type OperationRequestObjectChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which now has a Request Object.
	OperationName string

	// NewRequestObject specifies the new/updated value for the Request Object.
	NewRequestObject string

	// OldRequestObject specifies the old/existing value for the Request Object.
	OldRequestObject string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationRequestObjectChanged) IsBreaking() bool {
	return true
}
