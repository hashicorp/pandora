// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationLongRunningRemoved{}

// OperationLongRunningRemoved defines when an existing Operation is no longer Long Running.
type OperationLongRunningRemoved struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which is no longer a Long Running Operation.
	OperationName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (OperationLongRunningRemoved) IsBreaking() bool {
	return true
}
