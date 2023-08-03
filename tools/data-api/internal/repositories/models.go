package repositories

type ApiDefinitionSourceType string
type ConstantType string
type FieldValidationType string
type ObjectDefinitionType string
type ResourceIdSegmentType string
type ServiceType string

type DateFormat string

const (
	MicrosoftGraphV1BetaServiceType   ServiceType = "microsoft-graph-beta"
	MicrosoftGraphV1StableServiceType ServiceType = "microsoft-graph-v1-stable"
	ResourceManagerServiceType        ServiceType = "resource-manager"

	HandWrittenApiDefinitionsSource                 ApiDefinitionSourceType = "HandWritten"
	MicrosoftGraphMetadataApiDefinitionsSource      ApiDefinitionSourceType = "MicrosoftGraphMetadata"
	ResourceManagerRestApiSpecsApiDefinitionsSource ApiDefinitionSourceType = "ResourceManagerRestApiSpecs"

	ReferenceObjectDefinitionType ObjectDefinitionType = "Reference"
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
	ObjectDefinition *ObjectDefinition
	Required         bool
}

type ConstantDetails struct {
	CaseInsensitive bool
	Type            ConstantType
	Values          map[string]string
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
	Fields        map[string]FieldDetails
	TypeHintIn    *string
	TypeHintValue *string
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
