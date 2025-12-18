// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelDiscriminatedTypeValueChanged{}

// ModelDiscriminatedTypeValueChanged defines that the Discriminated Value used to uniquely
// identify this Discriminated Type has changed.
type ModelDiscriminatedTypeValueChanged struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model where the Discriminated Type Value has changed.
	ModelName string

	// OldValue specifies the old Value that was used to uniquely identify this Discriminated
	// Implementation.
	OldValue string

	// NewValue specifies the new/updated Value used to uniquely identify this Discriminated
	// Implementation.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelDiscriminatedTypeValueChanged) IsBreaking() bool {
	// If the Discriminated Type Value has changed this is a BIG breaking change
	// since any existing Implementations will likely fail - such this requires
	// additional investigation.
	return true
}
