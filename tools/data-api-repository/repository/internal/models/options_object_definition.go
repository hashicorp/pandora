// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// OptionObjectDefinition specifies the type of values that the HTTP Operation supports and sends at Request time in either the
// HTTP Header and/or the QueryString
type OptionObjectDefinition struct {
	// OptionObjectDefinitionType defines what kind of ObjectDefinition this is, such as a Reference, String or List
	Type OptionObjectDefinitionType `json:"type"`

	// ReferenceName is the name of the Constant that this is a reference to
	ReferenceName *string `json:"referenceName"`

	// NestedItem is a nested OptionObjectDefinition when Type is a CSV or a List
	NestedItem *OptionObjectDefinition `json:"nestedItem,omitempty"`
}

type OptionObjectDefinitionType string

const (
	// BooleanOptionObjectDefinitionType signifies that this type is a simple Boolean.
	BooleanOptionObjectDefinitionType OptionObjectDefinitionType = "Boolean"

	// IntegerOptionObjectDefinitionType signifies that this field contains an Integer.
	IntegerOptionObjectDefinitionType OptionObjectDefinitionType = "Integer"

	// FloatOptionObjectDefinitionType signifies that this field contains a Float.
	FloatOptionObjectDefinitionType OptionObjectDefinitionType = "Float"

	// StringOptionObjectDefinitionType signifies that this field contains a String.
	StringOptionObjectDefinitionType OptionObjectDefinitionType = "String"

	// CsvOptionObjectDefinitionType signifies that this field contains a CSV of simple types e.g. String, Integer, Float.
	CsvOptionObjectDefinitionType OptionObjectDefinitionType = "Csv"

	// ListOptionObjectDefinitionType signifies that this field contains a List, the List's Value Type is defined as a Nested Object Definition.
	ListOptionObjectDefinitionType OptionObjectDefinitionType = "List"

	// ReferenceOptionObjectDefinitionType signifies that this field points to a Constant.
	ReferenceOptionObjectDefinitionType OptionObjectDefinitionType = "Reference"
)
