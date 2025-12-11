// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// Constant describes a constant specific to the SDK
// Azure supports Constants being either Float, Integer or String values
// however for convenience we store the values as Strings and decode these as needed.
type Constant struct {
	// Name specifies the Display Name for this Constant (e.g. `SkuName`) which is also
	// valid as an identifier.
	Name string `json:"name"`

	// Type specifies what kind of Constant this is (a StringConstant, IntegerConstant etc).
	Type ConstantType `json:"type"`

	// Values defines the possible values for this Constant
	//
	// > ".. why not use a `map[string]ConstantValue` here?" I hear you ask
	// in short: so we can keep consistency in the output, minimizing spurious diff's.
	Values []ConstantValue `json:"values"`
}

// ConstantType defines the type of Constant being surfaced - for example a StringConstant
// or an IntegerConstant.
type ConstantType string

const (
	// FloatConstant is used to indicate that the constant stores Float values (e.g. 13.07).
	FloatConstant ConstantType = "Float"

	// IntegerConstant is used to indicate that the constant stores Integer values (e.g. 1989).
	IntegerConstant ConstantType = "Integer"

	// StringConstant is used to indicate that the constant stores String values (e.g. "Red").
	StringConstant ConstantType = "String"
)

// ConstantValue defines a possible value for this Constant Type
type ConstantValue struct {
	// Key specifies a unique identifier for this Constant Value, which is safe to use as a
	// type name (e.g. a key for a constant in any generated source code) as required.
	//
	// This is typically formed from Value with unsafe characters removed so it's usable as
	// an identifier.
	//
	// Example: `StandardA1`.
	Key string `json:"key"`

	// Value specifies the literal value for this Constant as defined in API.
	//
	// Example: `Standard_A1`.
	Value string `json:"value"`

	// Description is an optional description for this constant value - providing
	// further context as required.
	Description *string `json:"description,omitempty"`
}
