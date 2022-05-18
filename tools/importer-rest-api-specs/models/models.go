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
	ResourceIds map[string]ParsedResourceId
}

type OperationDetails struct {
	ContentType                      string
	ExpectedStatusCodes              []int
	FieldContainingPaginationDetails *string
	IsListOperation                  bool
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
	// NestedItem is an optional nested ObjectDefinition when Type is a Dictionary or List
	NestedItem *ObjectDefinition

	// ReferenceName is the name of the Constant or Model that this is a reference to.
	ReferenceName *string

	// Type defines what kind of ObjectDefinition this is, such as a Reference, String or List.
	Type ObjectDefinitionType

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
	ObjectDefinitionCsv        ObjectDefinitionType = "Csv"
	ObjectDefinitionDateTime   ObjectDefinitionType = "DateTime"
	ObjectDefinitionDictionary ObjectDefinitionType = "Dictionary"
	ObjectDefinitionInteger    ObjectDefinitionType = "Integer"
	ObjectDefinitionFloat      ObjectDefinitionType = "Float"
	ObjectDefinitionList       ObjectDefinitionType = "List"
	ObjectDefinitionRawFile    ObjectDefinitionType = "RawFile"
	ObjectDefinitionRawObject  ObjectDefinitionType = "RawObject"
	ObjectDefinitionReference  ObjectDefinitionType = "Reference"
	ObjectDefinitionString     ObjectDefinitionType = "String"
)

type OperationOption struct {
	ObjectDefinition *ObjectDefinition
	HeaderName       *string
	QueryStringName  *string
	Required         bool
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
	CustomFieldTypeEdgeZone                                CustomFieldType = "edge-zone"
	CustomFieldTypeLocation                                CustomFieldType = "location"
	CustomFieldTypeSystemAssignedIdentity                  CustomFieldType = "system-assigned-identity"
	CustomFieldTypeSystemAndUserAssignedIdentityList       CustomFieldType = "system-and-user-assigned-identity-list"
	CustomFieldTypeSystemAndUserAssignedIdentityMap        CustomFieldType = "system-and-user-assigned-identity-map"
	CustomFieldTypeLegacySystemAndUserAssignedIdentityList CustomFieldType = "legacy-system-and-user-assigned-identity-list"
	CustomFieldTypeLegacySystemAndUserAssignedIdentityMap  CustomFieldType = "legacy-system-and-user-assigned-identity-map"
	CustomFieldTypeSystemOrUserAssignedIdentityList        CustomFieldType = "system-or-user-assigned-identity-list"
	CustomFieldTypeSystemOrUserAssignedIdentityMap         CustomFieldType = "system-or-user-assigned-identity-map"
	CustomFieldTypeUserAssignedIdentityList                CustomFieldType = "user-assigned-identity-list"
	CustomFieldTypeUserAssignedIdentityMap                 CustomFieldType = "user-assigned-identity-map"
	CustomFieldTypeTags                                    CustomFieldType = "tags"
)
