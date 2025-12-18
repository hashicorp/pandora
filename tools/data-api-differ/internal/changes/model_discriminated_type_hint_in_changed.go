// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = ModelDiscriminatedTypeHintInChanged{}

// ModelDiscriminatedTypeHintInChanged defines that the TypeHintIn field has changed for the
// Model in question.
type ModelDiscriminatedTypeHintInChanged struct {
	// ServiceName specifies the name of the Service which contains this Model.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Model.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Model.
	ResourceName string

	// ModelName specifies the name of the Model where the Discriminated TypeHintIn has changed.
	ModelName string

	// OldValue specifies the old name of the Field that was used to uniquely identify this
	// Discriminated Implementation.
	OldValue string

	// OldValue specifies the new/updated name of the Field that was used to uniquely identify this
	// Discriminated Implementation.
	NewValue string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (ModelDiscriminatedTypeHintInChanged) IsBreaking() bool {
	// If the field containing the Type Hint used to uniquely identify this Discriminated
	// Implementation has changed this will likely break all existing implementations.
	return true
}
