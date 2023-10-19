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

type ResourceDefinition struct {
	DisplayName                  string `json:"DisplayName"`
	Id                           string `json:"Id"`
	Label                        string `json:"Label"`
	Category                     string `json:"Category"`
	Description                  string `json:"Description"`
	ExampleUsage                 string `json:"ExampleUsage"`
	GenerateIDValidationFunction bool   `json:"GenerateIDValidationFunction"`
	GenerateModel                bool   `json:"GenerateModel"`
	GenerateSchema               bool   `json:"GenerateSchema"`
	CreateMethod                 Method `json:"CreateMethod"`
	DeleteMethod                 Method `json:"DeleteMethod"`
	ReadMethod                   Method `json:"ReadMethod"`
	UpdateMethod                 Method `json:"UpdateMethod"`
}

type Method struct {
	Generate         bool   `json:"Generate"`
	Name             string `json:"Name"`
	TimeoutInMinutes int    `json:"TimeoutInMinutes"`
}
