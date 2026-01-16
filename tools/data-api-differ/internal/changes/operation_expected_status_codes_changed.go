// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = OperationExpectedStatusCodesChanged{}

// OperationExpectedStatusCodesChanged defines when the Expected Status Codes for an existing Operation
// have changed.
type OperationExpectedStatusCodesChanged struct {
	// ServiceName specifies the name of the Service which contains this Operation.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Operation.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Operation.
	ResourceName string

	// OperationName specifies the name of the Operation which has an updated set of Expected Status Codes.
	OperationName string

	// OldExpectedStatusCodes specifies the old/existing Expected Status Codes for this Operation.
	OldExpectedStatusCodes []int

	// NewExpectedStatusCodes specifies the new/updated Expected Status Codes for this Operation.
	NewExpectedStatusCodes []int
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (c OperationExpectedStatusCodesChanged) IsBreaking() bool {
	// Whether this is a breaking change depends on whether any existing Expected Status Codes have
	// been removed. Whilst adding a new Expected Status Code COULD well be a breaking change, in
	// practice this depends on the downstream usage (for example if we've added a Custom Poller to
	// work around this in the interim).
	removed := make([]int, 0)
	for _, v := range c.OldExpectedStatusCodes {
		existsInNew := false
		for _, other := range c.NewExpectedStatusCodes {
			if other == v {
				existsInNew = true
				break
			}
		}

		if !existsInNew {
			removed = append(removed, v)
		}
	}

	isBreakingChange := len(removed) > 0
	return isBreakingChange
}
