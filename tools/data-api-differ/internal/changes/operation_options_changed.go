// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationOptionsChanged{}

// OperationOptionsChanged defines an existing Operation which has had its Options changed.
type OperationOptionsChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has had its Options changed.
	OperationName string

	// OldValue specifies a slice of the old/existing Options for this Operation.
	OldValue map[string]string

	// NewValue specifies a slice of the new/updated Options for this Operation.
	NewValue map[string]string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (o OperationOptionsChanged) IsBreaking() bool {
	// Whether this is a breaking change depends on if the existing Options remain to be supported
	for key, value := range o.OldValue {
		otherValue, exists := o.NewValue[key]
		if !exists {
			// if the Option no longer exists it's a breaking change
			return true
		}

		// if the Option itself has changed this is /potentially/ a breaking change, so flag it
		if value != otherValue {
			return true
		}
	}

	return false
}
