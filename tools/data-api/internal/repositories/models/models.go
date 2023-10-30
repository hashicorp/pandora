package models

// NOTE: these types are intentionally undocumented atm, these'll be added in a follow-up PR

// Model describes an API object parsed from the swagger
type Model struct {
	// Name specifies the name of the Model
	Name string `json:"name"`

	// Fields is an array of fields contained in the Model
	Fields []ModelField `json:"fields"`

	// NOTE: If DiscriminatedParentModelName and DiscriminatedTypeValue are both populated then this Model
	// represents a discriminated type
	// DiscriminatedParentModelName contains the name of the Parent Model that this Model would implement
	DiscriminatedParentModelName *string `json:"discriminatedParentModelName,omitempty"`

	// TODO DiscriminatedTypeValue - what's this
	DiscriminatedTypeValue *string `json:"discriminatedTypeValue,omitempty"`
}

// ModelField describes the fields within a Model
type ModelField struct {
	// ContainsDiscriminatedTypeValue specifies whether this particular field contains the type hint if the Model represents a discriminator
	ContainsDiscriminatedTypeValue bool `json:"containsDiscriminatedTypeValue"`

	// DateFormat specifies the date format that this field should use
	DateFormat *DateFormat `json:"dateFormat,omitempty"`

	// JsonName contains the Name following JSON casing convention
	JsonName string `json:"jsonName"`

	// Name specifies the name of the field
	Name string `json:"name"`

	// ObjectDefinition describes the field type
	ObjectDefinition ObjectDefinition `json:"objectDefinition"`

	// Optional specifies that this field is Optional - since a field can either be
	// Required or Optional, but not both.
	Optional bool `json:"optional"`

	// Required specifies that this field is Required - since a field can either be
	// Required or Optional, but not both.
	Required bool `json:"required"`
}
