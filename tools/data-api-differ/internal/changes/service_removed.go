// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ServiceRemoved{}

// ServiceRemoved defines information about a Service which has been removed.
type ServiceRemoved struct {
	// ServiceName is the name of the Service (e.g. `Compute`).
	ServiceName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ServiceRemoved) IsBreaking() bool {
	return true
}
