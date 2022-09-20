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

	// ResourceIds is a map of key (Resource Name) to value (Resource ID Definitions)
	// used by this API
	ResourceIds map[string]ResourceIdDefinition `json:"resourceIds"`
}

type ConstantDetails struct {
	// CaseInsensitive specifies that this Constant can be returned insensitively
	// and should be rewritten on the Client side to be consistent
	CaseInsensitive bool `json:"caseInsensitive"`

	// Type specifies the backing type for this constant, whilst the name will
	// always be a String, the backing values can be a Float/Integer/String
	// albeit returned as a string to maintain formatting.
	Type ConstantType `json:"type"`

	// Values specifies a key (Display Name) to value (Constant Value) for the
	// possible values for this Constant
	Values map[string]string `json:"values"`
}

type ModelDetails struct {
	// Fields is a map of key (FieldName) to value (FieldDetails) for the fields
	// supported by this Model.
	Fields map[string]FieldDetails `json:"fields"`

	// ParentTypeName specifies the name of the Parent Type for this Model.
	ParentTypeName *string `json:"parentTypeName"`

	// TypeHintIn specifies the field containing the Type Hint (e.g. Discriminator
	// value) signifying which type should be returned.
	TypeHintIn *string `json:"typeHintIn"`

	// TypeHintValue is the value which identifies that this Type should be used
	// when the value in TypeHintIn matches this/
	TypeHintValue *string `json:"typeHintValue"`
}

type FieldDetails struct {
	// Default is an optional value which should be used as the default for this field
	Default *interface{} `json:"default"`

	// DateFormat is the format which should be used for this field when Type is set to DateTime
	DateFormat *DateFormat `json:"dateFormat"`

	// ForceNew specifies that this value cannot be changed in the API after creation
	ForceNew bool `json:"forceNew"`

	// IsTypeHint specifies that this field contains a Type Hint, meaning that the Type returned
	// can change depending upon the value of a nested field.
	IsTypeHint bool `json:"isTypeHint"`

	// JsonName is the name of the field within the JSON, which may be different
	// to the Name used for this field, which can be more descriptive.
	JsonName string `json:"jsonName"`

	// ObjectDefinition is the definition defining the Type of this field
	ObjectDefinition ApiObjectDefinition `json:"objectDefinition"`

	// Optional specifies that this field is Optional - since a field can either be
	// Required or Optional, but not both.
	Optional bool `json:"optional"`

	// Required specifies that this field is Required - since a field can either be
	// Required or Optional, but not both.
	Required bool `json:"required"`

	// Validation is an optional value defining the Validation requirements for this
	// field, if any.
	Validation *FieldValidationDetails `json:"validation"`

	// Description is a description of the field
	Description string `json:"description"`
}

type ConstantType string

const (
	FloatConstant   ConstantType = "float"
	IntegerConstant ConstantType = "int"
	StringConstant  ConstantType = "string"
)

type DateFormat string

const (
	RFC3339     DateFormat = "RFC3339"
	RFC3339Nano DateFormat = "RFC3339Nano"
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

type ResourceIdDefinition struct {
	// CommonAlias is the alias used for this Resource ID, if this is a 'Common' Resource ID
	// examples of a Common Resource ID include Resource Group ID's and Subscription ID's
	CommonAlias *string `json:"commonAlias,omitempty"`

	// ConstantNames is a list of Constants used by/in this ResourceId
	ConstantNames []string `json:"constantNames"`

	// Id is the full ResourceId as a string, for example:
	// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
	Id string `json:"id"`

	// Segments is one or more segments present within this ResourceID, each Segment being
	// for example a StaticSegment, ConstantSegment, UserSpecifiedSegment, etc.
	Segments []ResourceIdSegment `json:"segments"`
}

type ResourceIdSegment struct {
	// ConstantReference is the name of the Constant which this Segment is associated with
	// this is only present when `Type` is `ConstantSegment`
	ConstantReference *string `json:"constantReference,omitempty"`

	// ExampleValue is an example of a valid value for this segment
	ExampleValue string `json:"exampleValue"`

	// FixedValue is the Fixed/Static value for this segment - only present when `Type` is `StaticSegment`.
	FixedValue *string `json:"fixedValue,omitempty"`

	// Name is the camelCased name of this segment, which is normalized (and safe to use as a
	// parameter/a field if necessary).
	Name string `json:"name"`

	// Type specifies the Type of Segment that this is, for example a `StaticSegment`
	Type ResourceIdSegmentType `json:"type"`
}

type ResourceIdSegmentType string

const (
	// ConstantSegment specifies that this Segment is a Constant
	ConstantSegment ResourceIdSegmentType = "Constant"

	// ResourceGroupSegment specifies that this Segment is a Resource Group name
	ResourceGroupSegment ResourceIdSegmentType = "ResourceGroup"

	// ResourceProviderSegment specifies that this Segment is a Resource Provider
	ResourceProviderSegment ResourceIdSegmentType = "ResourceProvider"

	// ScopeSegment specifies that this Segment is a Scope
	ScopeSegment ResourceIdSegmentType = "Scope"

	// StaticSegment specifies that this Segment is a Static/Fixed Value
	StaticSegment ResourceIdSegmentType = "Static"

	// SubscriptionIdSegment specifies that this Segment is a Subscription ID
	SubscriptionIdSegment ResourceIdSegmentType = "SubscriptionId"

	// UserSpecifiedSegment specifies that this Segment is User-Specifiable
	UserSpecifiedSegment ResourceIdSegmentType = "UserSpecified"
)
