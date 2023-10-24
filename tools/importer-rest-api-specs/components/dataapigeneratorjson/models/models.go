package models

// NOTE: these types are intentionally undocumented atm, these'll be added in a follow-up PR

type Model struct {
	Name string `json:"name"`

	Fields []ModelField `json:"fields"`

	DiscriminatedParentModelName *string `json:"discriminatedParentModelName,omitempty"`

	DiscriminatedTypeValue *string `json:"discriminatedTypeValue,omitempty"`
}

type ModelField struct {
	ContainsDiscriminatedTypeValue bool `json:"containsDiscriminatedTypeValue"`

	DateFormat *DateFormat `json:"dateFormat,omitempty"`

	JsonName string `json:"jsonName"`

	Name string `json:"name"`

	ObjectDefinition ObjectDefinition `json:"objectDefinition"`

	Optional bool `json:"optional"`

	Required bool `json:"required"`
}
