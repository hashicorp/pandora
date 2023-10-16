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

type Operation struct {
	Name                             string           `json:"Name"`
	ContentType                      string           `json:"ContentType,omitempty"`
	ExpectedStatusCodes              []int            `json:"ExpectedStatusCodes,omitempty"`
	FieldContainingPaginationDetails string           `json:"FieldContainingPaginationDetails,omitempty"`
	LongRunning                      bool             `json:"LongRunning,omitempty"`
	HTTPMethod                       string           `json:"HTTPMethod,omitempty"`
	OptionsObject                    OptionsObject    `json:"OptionsObject,omitempty"`
	Options                          []Option         `json:"Options,omitempty"`
	ResourceId                       string           `json:"ResourceId,omitempty"`
	RequestObject                    ObjectDefinition `json:"RequestObject,omitempty"`
	ResponseObject                   ObjectDefinition `json:"ResponseObject,omitempty"`
	UriSuffix                        string           `json:"UriSuffix,omitempty"`
}

type OptionsObject struct {
	Name    string   `json:"Name"`
	Options []Option `json:"Options"`
}

type Option struct {
	HeaderName  *string `json:"HeaderName,omitempty"`
	Optional    bool    `json:"Optional"`
	QueryString *string `json:"QueryString,omitempty"`
	Required    bool    `json:"Required"`
	Field       string  `json:"Field"`
	FieldType   string  `json:"FieldType"`
}
