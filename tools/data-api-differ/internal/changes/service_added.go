// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ServiceAdded{}

// ServiceAdded defines information about a new Service.
type ServiceAdded struct {
	// ServiceName is the name of the Service (e.g. `Compute`).
	ServiceName string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ServiceAdded) IsBreaking() bool {
	return false
}
