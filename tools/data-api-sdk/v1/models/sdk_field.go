// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKField defines a field present within a SDKModel.
// The shape of the field is described by the ObjectDefinition object.
type SDKField struct {
	// ContainsDiscriminatedValue specifies whether this SDKField contains the Discriminated Value
	// used to uniquely identify a Discriminated Type.
	ContainsDiscriminatedValue bool `json:"isTypeHint"` // TODO: update the json struct tag once everything is switched overs

	// DateFormat specifies the SDKDateFormat which should be used when the ObjectDefinition is a
	// DateTimeSDKObjectDefinitionType.
	DateFormat *SDKDateFormat `json:"dateFormat,omitempty"`

	// Description specifies the description for this SDKField.
	Description string `json:"description"`

	// JsonName specifies the name of this field within the JSON - which is typically in camelCase.
	JsonName string `json:"jsonName"`

	// ObjectDefinition specifies the shape of the Type backing this SDKField.
	ObjectDefinition SDKObjectDefinition `json:"objectDefinition"`

	// Optional specifies that this SDKField is Optional and can be omitted from the Request/Response.
	// NOTE that a field must be either Optional or Required but not both.
	Optional bool `json:"optional"`

	// ReadOnly specifies that this SDKField is ReadOnly and so should be omitted from Requests but may
	// be present in the Response.
	// NOTE: This can either be used in conjunction with Optional and Computed or by itself (i.e. Computed).
	ReadOnly bool `json:"readOnly"`

	// Required specifies that this SDKField is Required and must be present in the Request/Response.
	// NOTE that a field must be either Optional or Required but not both.
	Required bool `json:"required"`

	// Sensitive specifies that this field contains a Sensitive value (such as a password or an API Key).
	Sensitive bool `json:"sensitive"`
}
