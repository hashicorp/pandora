package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type ApiSchemaClient struct {
	Client
}

func (c ApiSchemaClient) Get(input ResourceSummary) (*ApiSchemaDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.SchemaUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response ApiSchemaDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type ApiSchemaDetails struct {
	// Constants is a map of key (Constant Name) to value (ConstantDetails) describing
	// each Constant supported by this API Version.
	Constants map[string]ConstantDetails `json:"constants"`

	// Models is a map of key (Model Name) to value (ModelDetails) describing
	// each Model supported by this API version, used in either Requests or Responses
	Models map[string]ModelDetails `json:"models"`
}

type ConstantDetails struct {
	// CaseInsensitive specifies that this Constant can be returned insensitively
	// and should be rewritten on the Client side to be consistent
	CaseInsensitive bool `json:"caseInsensitive"`

	// Values specifies a key (Display Name) to value (Constant Value) for the
	// possible values for this Constant
	Values map[string]string `json:"values"`
}

type ModelDetails struct {
	// Fields is a map of key (FieldName) to value (FieldDetails) for the fields
	// supported by this Model.
	Fields map[string]FieldDetails `json:"fields"`
}

type FieldDetails struct {
	// ConstantReferenceName is an optional value specifying the Name of the Constant
	// for this field
	ConstantReferenceName *string `json:"constantReferenceName"`

	// Default is an optional value which should be used as the default for this field
	Default *interface{} `json:"default"`

	// DateFormat is the format which should be used for this field when Type is set to DateTime
	DateFormat *DateFormat `json:"dateFormat"`

	// ForceNew specifies that this value cannot be changed in the API after creation
	ForceNew bool `json:"forceNew"`

	// JsonName is the name of the field within the JSON, which may be different
	// to the Name used for this field, which can be more descriptive.
	JsonName string `json:"jsonName"`

	// ListElementType is an optional value the nested Type when 'Type' is set to 'List'
	ListElementType *string `json:"ListElementType"`

	// ModelReferenceName is an optional value specifying the Name of the Model
	// for this field
	ModelReferenceName *string `json:"modelReferenceName"`

	// Optional specifies that this field is Optional - since a field can either be
	// Required or Optional, but not both.
	Optional bool `json:"optional"`

	// Required specifies that this field is Required - since a field can either be
	// Required or Optional, but not both.
	Required bool `json:"required"`

	// Type specifies the Type for this field, for example String, List etc.
	Type FieldType `json:"type"`

	// Validation is an optional value defining the Validation requirements for this
	// field, if any.
	Validation *FieldValidationDetails `json:"validation"`
}

type DateFormat string

const (
	RFC3339     DateFormat = "RFC3339"
	RFC3339Nano DateFormat = "RFC3339Nano"
)

type FieldType string

const (
	Boolean  FieldType = "Boolean"
	Constant FieldType = "Constant"
	DateTime FieldType = "DateTime"
	Integer  FieldType = "Integer"
	List     FieldType = "List"
	Location FieldType = "Location"
	Object   FieldType = "Object"
	Tags     FieldType = "Tags"
	String   FieldType = "String"
)

type FieldValidationDetails struct {
	// Type specifies the Type of Validation which should be applied
	Type FieldValidationType `json:"type"`

	// Values is an optional field specifying zero or more values which can be
	// contextually useful for the validation type. As an example, a "Range"
	// validation may have a pre-defined range of values for the Range (e.g. min/max)
	Values *[]interface{} `json:"values"`
}

type FieldValidationType string

const (
	// RangeValidation specifies that this field must fall within a Range of pre-defined values
	RangeValidation FieldValidationType = "Range"
)
