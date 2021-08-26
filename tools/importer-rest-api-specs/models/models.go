package models

type AzureApiDefinition struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]AzureApiResource
}

type AzureApiResource struct {
	Constants   map[string]ConstantDetails
	Models      map[string]ModelDetails
	Operations  map[string]OperationDetails
	ResourceIds map[string]string
}

type OperationDetails struct {
	ApiVersion                       *string
	ContentType                      string
	ExpectedStatusCodes              []int
	FieldContainingPaginationDetails *string
	LongRunning                      bool
	Method                           string
	Options                          map[string]OperationOption
	RequestObject                    *ObjectDefinition
	ResourceIdName                   *string
	ResponseObject                   *ObjectDefinition
	Uri                              string
	UriSuffix                        *string
}

type ObjectDefinition struct {
	NestedItem    *ObjectDefinition
	ReferenceName *string
	Type          ObjectDefinitionType

	// Minimum is the minimum number of items which must be specified when this is a Dictionary/List element, if specified
	Minimum *int

	// Maximum is the maximum number of items which must be specified when this is a Dictionary/List element, if specified
	Maximum *int

	// UniqueItems specifies whether every item in this List/Dictionary must be unique
	UniqueItems *bool
}

type ObjectDefinitionType string

const (
	ObjectDefinitionBoolean    ObjectDefinitionType = "Boolean"
	ObjectDefinitionDateTime   ObjectDefinitionType = "DateTime"
	ObjectDefinitionDictionary ObjectDefinitionType = "Dictionary"
	ObjectDefinitionInteger    ObjectDefinitionType = "Integer"
	ObjectDefinitionFloat      ObjectDefinitionType = "Float"
	ObjectDefinitionList       ObjectDefinitionType = "List"
	ObjectDefinitionReference  ObjectDefinitionType = "Reference"
	ObjectDefinitionString     ObjectDefinitionType = "String"
)

type OperationOption struct {
	ObjectDefinition *ObjectDefinition
	QueryStringName  string
	// TODO: support Header names here too in time
	Required bool
}

type ConstantDetails struct {
	Values    map[string]string
	FieldType ConstantFieldType
}

type ConstantFieldType string

const (
	IntegerConstant ConstantFieldType = "int"
	FloatConstant   ConstantFieldType = "float"
	StringConstant  ConstantFieldType = "string"
	UnknownConstant ConstantFieldType = "unknown"
)

type ModelDetails struct {
	Description string
	Fields      map[string]FieldDetails

	// @tombuildsstuff: placeholder until the other branch is merged
	ParentTypeName *string
	TypeHintIn     *string
	TypeHintValue  *string

	// TODO: include ReadOnly, which'll mean we need to generate this on a per-type basis if necessary
}

// IsEmpty defines if this is an empty/placeholder object - which can be useful for determining
// if this object will be replaced later in the process
func (m ModelDetails) IsEmpty() bool {
	return len(m.Fields) == 0 && m.Description == "" && m.TypeHintIn == nil && m.TypeHintValue == nil && m.ParentTypeName == nil
}

type FieldDetails struct {
	Required  bool
	ReadOnly  bool
	Sensitive bool
	JsonName  string

	CustomFieldType  *CustomFieldType
	ObjectDefinition *ObjectDefinition

	// TODO: should we output Description here too?
}

type CustomFieldType string

const (
	CustomFieldTypeLocation                               CustomFieldType = "location"
	CustomFieldTypeSystemAssignedIdentity                 CustomFieldType = "system-assigned-identity"
	CustomFieldTypeSystemAssignedUserAssignedIdentityList CustomFieldType = "system-assigned-user-assigned-identity-list"
	CustomFieldTypeSystemAssignedUserAssignedIdentityMap  CustomFieldType = "system-assigned-user-assigned-identity-map"
	CustomFieldTypeUserAssignedIdentityList               CustomFieldType = "user-assigned-identity-list"
	CustomFieldTypeUserAssignedIdentityMap                CustomFieldType = "user-assigned-identity-map"
	CustomFieldTypeTags                                   CustomFieldType = "tags"
)
