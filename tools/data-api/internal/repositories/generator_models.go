package repositories

// NOTE: this is a copy of models from the package `dataapigeneratorjson/models`, these have been duplicated to ease development
// and will be removed once `dataapigeneratorjson/models` has been split out

type Constant struct {
	Name   string          `json:"name"`
	Type   string          `json:"type"`
	Values []ConstantValue `json:"values"`
}

type ConstantValue struct {
	Key         string  `json:"key"`
	Value       string  `json:"value"`
	Description *string `json:"description,omitempty"`
}

type Model struct {
	Name                         string       `json:"name"`
	Fields                       []ModelField `json:"fields"`
	DiscriminatedParentModelName *string      `json:"discriminatedParentModelName,omitempty"`
	DiscriminatedTypeValue       *string      `json:"discriminatedTypeValue,omitempty"`
}

type ModelField struct {
	ContainsDiscriminatedTypeValue bool                    `json:"containsDiscriminatedTypeValue"`
	DateFormat                     *DateFormat             `json:"dateFormat,omitempty"`
	JsonName                       string                  `json:"jsonName"`
	Name                           string                  `json:"name"`
	ObjectDefinition               DataApiObjectDefinition `json:"objectDefinition"`
	Optional                       bool                    `json:"optional"`
	Required                       bool                    `json:"required"`
}

type DataApiObjectDefinition struct {
	Type          ObjectDefinitionType     `json:"type"`
	ReferenceName *string                  `json:"referenceName"`
	NestedItem    *DataApiObjectDefinition `json:"nestedItem,omitempty"`
	MaxItems      *int                     `json:"maxItems,omitempty"`
	MinItems      *int                     `json:"minItems,omitempty"`
	DateFormat    *DateFormat              `json:"dateFormat,omitempty"`
}

type Operation struct {
	Name                             string            `json:"name"`
	ContentType                      string            `json:"contentType"`
	ExpectedStatusCodes              []int             `json:"expectedStatusCodes"`
	FieldContainingPaginationDetails *string           `json:"fieldContainingPaginationDetails,omitempty"`
	LongRunning                      bool              `json:"longRunning"`
	HTTPMethod                       string            `json:"httpMethod"`
	Options                          *[]Option         `json:"options,omitempty"`
	ResourceIdName                   *string           `json:"resourceIdName,omitempty"`
	RequestObject                    *ObjectDefinition `json:"requestObject,omitempty"`
	ResponseObject                   *ObjectDefinition `json:"responseObject,omitempty"`
	UriSuffix                        *string           `json:"uriSuffix,omitempty"`
}

type Option struct {
	HeaderName       *string                        `json:"headerName,omitempty"`
	Optional         bool                           `json:"optional"`
	QueryString      *string                        `json:"queryString,omitempty"`
	Required         bool                           `json:"required"`
	Field            string                         `json:"field"`
	ObjectDefinition *DataApiOptionObjectDefinition `json:"optionsObjectDefinition"`
}

type DataApiOptionObjectDefinition struct {
	Type          OptionObjectDefinitionType     `json:"type"`
	ReferenceName *string                        `json:"referenceName"`
	NestedItem    *DataApiOptionObjectDefinition `json:"nestedItem,omitempty"`
}

type OptionObjectDefinitionType string

type ResourceId struct {
	Name        string    `json:"Name"`
	CommonAlias string    `json:"CommonAlias,omitempty"`
	Id          string    `json:"Id"`
	Segments    []Segment `json:"Segments,omitempty"`
}

type Segment struct {
	Name  string `json:"Name"`
	Type  string `json:"Type"`
	Value string `json:"Value,omitempty"`
}
