package repositories

// NOTE: this is a copy of models from the package `dataapigeneratorjson` which is in the `importer-rest-api-specs` tool
// these have been duplicated to ease development and will be removed once `dataapigeneratorjson` has been split out

type Constant struct {
	Name   string  `json:"Name"`
	Type   string  `json:"Type"`
	Values []Value `json:"Values"`
}

type Value struct {
	Key         string  `json:"Key"`
	Value       string  `json:"Value"`
	Description *string `json:"Description,omitempty"`
}

type Model struct {
	Fields          []Field `json:"Fields"`
	IsDiscriminator *bool   `json:"IsDiscriminator,omitempty"`
	ParentModelName *string `json:"ParentModelName,omitempty"`
	ValueForType    *string `json:"ValueForType,omitempty"`
}

type Field struct {
	Name             string           `json:"Name"`
	JsonName         string           `json:"JsonName"`
	Required         *bool            `json:"Required,omitempty"`
	Optional         *bool            `json:"Optional,omitempty"`
	ObjectDefinition ObjectDefinition `json:"ObjectDefinition"`
	MinItems         *int             `json:"MinItems,omitempty"`
	MaxItems         *int             `json:"MaxItems,omitempty"`
	DateFormat       *string          `json:"DateFormat,omitempty"`
	ProvidesTypeHint *bool            `json:"ProvidesTypeHint,omitempty"`
}
