// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationContentTypeChanged{}

// OperationContentTypeChanged defines that the ContentType for an existing Operation has changed.
type OperationContentTypeChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has been an updated ContentType.
	OperationName string

	// OldContentType specifies the old/existing value for the Content-Type field for this Operation.
	OldContentType string

	// NewContentType specifies the new/updated value for the Content-Type field for this Operation.
	NewContentType string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationContentTypeChanged) IsBreaking() bool {
	// If the `Content-Type` for an operation has changed this will affect serialization/deserialization
	// and in the case of the API supporting multiple `Content-Type`s on a single endpoint - can lead
	// to semantically different objects.
	//
	// As such whilst this MAY not be a breaking change (for example changing `application/json` ->
	// `application/json; encoding=utf8`) this will require a manual review, so should be flagged as
	// a breaking change.
	return true
}
