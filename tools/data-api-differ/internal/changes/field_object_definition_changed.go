// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = FieldObjectDefinitionChanged{}

// FieldObjectDefinitionChanged defines when an existing Field within an existing Model gets an
// updated ObjectDefinition (e.g. a String becomes a Constant).
type FieldObjectDefinitionChanged struct {
	// ServiceName specifies the name of the Service which contains this Field.
	ServiceName string

	// ApiVersion specifies the name of the API Version which contains this Field.
	ApiVersion string

	// ResourceName specifies the name of the API Resource which contains this Field.
	ResourceName string

	// ModelName specifies the name of the Model which contains this Field.
	ModelName string

	// FieldName specifies the name of the Field which has an updated Object Definition.
	FieldName string

	// OldValue specifies the old/existing ObjectDefinition for this Field.
	OldValue string

	// NewValue specifies the new/updated ObjectDefinition for this Field.
	NewValue string
}

func (FieldObjectDefinitionChanged) IsBreaking() bool {
	// If the ObjectDefinition has changed this is going to require code changes
	return true
}
