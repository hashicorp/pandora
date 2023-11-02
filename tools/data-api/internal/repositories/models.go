package repositories

type ApiDefinitionSourceType string
type ConstantType string
type DateFormat string
type FieldValidationType string
type ObjectDefinitionType string
type OptionObjectDefinitionType string
type ResourceIdSegmentType string
type ServiceType string

const (
	MicrosoftGraphV1BetaServiceType   ServiceType = "microsoft-graph-beta"
	MicrosoftGraphV1StableServiceType ServiceType = "microsoft-graph-v1-stable"
	ResourceManagerServiceType        ServiceType = "resource-manager"

	HandWrittenApiDefinitionsSource                 ApiDefinitionSourceType = "HandWritten"
	MicrosoftGraphMetadataApiDefinitionsSource      ApiDefinitionSourceType = "MicrosoftGraphMetadata"
	ResourceManagerRestApiSpecsApiDefinitionsSource ApiDefinitionSourceType = "ResourceManagerRestApiSpecs"

	ReferenceObjectDefinitionType  ObjectDefinitionType = "Reference"
	StringObjectDefinitionType     ObjectDefinitionType = "String"
	BooleanObjectDefinitionType    ObjectDefinitionType = "Boolean"
	DateTimeObjectDefinitionType   ObjectDefinitionType = "DateTime"
	IntegerObjectDefinitionType    ObjectDefinitionType = "Integer"
	FloatObjectDefinitionType      ObjectDefinitionType = "Float"
	RawFileObjectDefinitionType    ObjectDefinitionType = "RawFile"
	RawObjectObjectDefinitionType  ObjectDefinitionType = "RawObject"
	CsvObjectDefinitionType        ObjectDefinitionType = "Csv"
	DictionaryObjectDefinitionType ObjectDefinitionType = "Dictionary"
	ListObjectDefinitionType       ObjectDefinitionType = "List"

	BooleanOptionObjectDefinition       OptionObjectDefinitionType = "Boolean"
	IntegerOptionObjectDefinition       OptionObjectDefinitionType = "Integer"
	FloatOptionObjectDefinitionType     OptionObjectDefinitionType = "Float"
	StringOptionObjectDefinitionType    OptionObjectDefinitionType = "String"
	CsvOptionObjectDefinitionType       OptionObjectDefinitionType = "Csv"
	ListOptionObjectDefinitionType      OptionObjectDefinitionType = "List"
	ReferenceOptionObjectDefinitionType OptionObjectDefinitionType = "Reference"

	EdgeZoneObjectDefinitionType                                ObjectDefinitionType = "EdgeZone"
	LocationObjectDefinitionType                                ObjectDefinitionType = "Location"
	TagsObjectDefinitionType                                    ObjectDefinitionType = "Tags"
	SystemAssignedIdentityObjectDefinitionType                  ObjectDefinitionType = "SystemAssignedIdentity"
	SystemAndUserAssignedIdentityListObjectDefinitionType       ObjectDefinitionType = "SystemAndUserAssignedIdentityList"
	SystemAndUserAssignedIdentityMapObjectDefinitionType        ObjectDefinitionType = "SystemAndUserAssignedIdentityMap"
	LegacySystemAndUserAssignedIdentityListObjectDefinitionType ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityList"
	LegacySystemAndUserAssignedIdentityMapObjectDefinitionType  ObjectDefinitionType = "LegacySystemAndUserAssignedIdentityMap"
	SystemOrUserAssignedIdentityListObjectDefinitionType        ObjectDefinitionType = "SystemOrUserAssignedIdentityList"
	SystemOrUserAssignedIdentityMapObjectDefinitionType         ObjectDefinitionType = "SystemOrUserAssignedIdentityMap"
	UserAssignedIdentityListObjectDefinitionType                ObjectDefinitionType = "UserAssignedIdentityList"
	UserAssignedIdentityMapObjectDefinitionType                 ObjectDefinitionType = "UserAssignedIdentityMap"
	SystemDataObjectDefinitionType                              ObjectDefinitionType = "SystemData"
	ZoneObjectDefinitionType                                    ObjectDefinitionType = "Zone"
	ZonesObjectDefinitionType                                   ObjectDefinitionType = "Zones"

	RangeFieldValidationType FieldValidationType = "Range"

	FloatConstant   ConstantType = "Float"
	IntegerConstant ConstantType = "Integer"
	StringConstant  ConstantType = "String"

	ConstantResourceIdSegmentType         ResourceIdSegmentType = "Constant"
	ResourceGroupResourceIdSegmentType    ResourceIdSegmentType = "ResourceGroup"
	ResourceProviderResourceIdSegmentType ResourceIdSegmentType = "ResourceProvider"
	ScopeResourceIdSegmentType            ResourceIdSegmentType = "Scope"
	StaticResourceIdSegmentType           ResourceIdSegmentType = "Static"
	SubscriptionIdResourceIdSegmentType   ResourceIdSegmentType = "SubscriptionId"
	UserSpecifiedResourceIdSegmentType    ResourceIdSegmentType = "UserSpecified"

	RFC3339DateFormat DateFormat = "RFC3339"
)

type ServiceDetails struct {
	Name                 string
	ApiVersions          map[string]*ServiceApiVersionDetails
	Generate             bool
	ResourceProvider     string
	TerraformPackageName *string
	TerraformDetails     TerraformDetails
}

type ServiceApiVersionDetails struct {
	Name      string
	Generate  bool
	Resources map[string]*ServiceApiVersionResourceDetails
	Source    ApiDefinitionSourceType
}

type ServiceApiVersionResourceDetails struct {
	Operations map[string]ResourceOperations
	Schema     ResourceSchema
}

type ResourceOperations struct {
	ContentType                      string
	ExpectedStatusCodes              []int
	LongRunning                      bool
	Method                           string
	RequestObject                    *ObjectDefinition
	ResourceIdName                   *string
	ResponseObject                   *ObjectDefinition
	FieldContainingPaginationDetails *string
	Options                          *map[string]OperationOptions
	UriSuffix                        *string
}

type ResourceSchema struct {
	Constants   map[string]ConstantDetails
	Models      map[string]ModelDetails
	ResourceIds map[string]ResourceIdDefinition
}

type ObjectDefinition struct {
	NestedItem    *ObjectDefinition
	ReferenceName *string
	Type          ObjectDefinitionType
}

type OperationOptions struct {
	HeaderName       *string
	QueryStringName  *string
	ObjectDefinition *OptionObjectDefinition
	Required         bool
}

type OptionObjectDefinition struct {
	Type          OptionObjectDefinitionType
	ReferenceName *string
	NestedItem    *OptionObjectDefinition
}

type ConstantDetails struct {
	Type   ConstantType
	Values map[string]string
}

type FieldValidationDetails struct {
	Type   FieldValidationType
	Values *[]interface{}
}

type FieldDetails struct {
	Default          *interface{}
	DateFormat       *DateFormat
	ForceNew         bool
	IsTypeHint       bool
	JsonName         string
	ObjectDefinition ObjectDefinition
	Optional         bool
	Required         bool
	Validation       *FieldValidationDetails
	Description      string
}

type ModelDetails struct {
	Fields         map[string]FieldDetails
	ParentTypeName *string
	TypeHintIn     *string
	TypeHintValue  *string
}

type ResourceIdSegment struct {
	ConstantReference *string
	ExampleValue      string
	FixedValue        *string
	Name              string
	Type              ResourceIdSegmentType
}

type ResourceIdDefinition struct {
	CommonAlias   *string
	ConstantNames []string
	Id            string
	Segments      []ResourceIdSegment
}

type CommonTypesDetails struct {
	Constants map[string]CommonTypesConstantDetails
	Models    map[string]CommonTypesModelDetails
}

type CommonTypesConstantDetails struct {
	CaseInsensitive bool
	Type            ConstantType
	Values          map[string]string
}

type CommonTypesModelDetails struct {
	Fields         map[string]FieldDetails
	ParentTypeName *string
	TypeHintIn     *string
	TypeHintValue  *string
}
