package repositories

// NOTE: this is a copy of models from the package `dataapigeneratorjson` which is in the `importer-rest-api-specs` tool
// these have been duplicated to ease development and will be removed once `dataapigeneratorjson` have been moved into
// its own thing

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
