package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type ApiOperationsClient struct {
	Client
}

func (c ApiOperationsClient) Get(input ResourceSummary) (*ApiOperationDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.OperationsUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response ApiOperationDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type ApiOperationDetails struct {
	// Operations is a map of key (Operation Name) to value (ApiOperation)
	// for the Operations supported by this API
	Operations map[string]ApiOperation `json:"operations"`
}

type ApiOperation struct {
	// ContentType is an optional ContentType which should be used for when making a
	// Request to this Operation
	ContentType *string `json:"contentType"`

	// ExpectedStatusCodes is a list of Status Codes which are expected to be returned
	// by this API Version
	ExpectedStatusCodes []int `json:"expectedStatusCodes"`

	// LongRunning specifies if this is a Long Running Operation, meaning that Clients
	// should follow any `Location` headers to track the result of this operation
	LongRunning bool `json:"longRunning"`

	// Method is the HTTP Method used for this operation, e.g. GET, POST, PATCH
	Method string `json:"method"`

	// RequestObject defines the optional Object which must be specified in the Request
	RequestObject *ApiObjectDefinition `json:"requestObject"`

	// ResourceIdName is the optional name of the Resource ID type used for this
	// operation, used either on it's own or in conjunction with the `suffix`
	ResourceIdName *string `json:"resourceIdName"`

	// RequestObject defines the optional Object which can be returned in the Response
	ResponseObject *ApiObjectDefinition `json:"requestObject"`

	// ApiVersion is an optional field specifying the Custom API Version which should
	// be used for this API Operation. Whilst bizarre, some Azure API's do this
	// rather than duplicating the API - which is unfortunate since it means
	// we have these mixed-version imports - but I digress.
	ApiVersion *string `json:"apiVersion"`

	// FieldContainingPaginationDetails is a reference to the field within the Response
	// which contains the pagination details, that is a 'nextLink' or similar
	FieldContainingPaginationDetails *string `json:"fieldContainingPaginationDetails"`

	// Options is a map of options which can be specified for this operation
	// these are querystring parameters such as 'limit' or 'forceDelete' or similar
	Options map[string]ApiOperationOption `json:"options"`

	// UriSuffix is a suffix which should be appended to the Resource ID for this operation
	// for example `/shutdown`
	UriSuffix *string `json:"uriSuffix"`
}

type ApiOperationOption struct {
	ConstantName    *string            `json:"constantName,omitempty"`
	FieldType       OperationFieldType `json:"fieldType"`
	QueryStringName string             `json:"queryStringName"`
	Required        bool               `json:"required"`
}

type ApiObjectDefinition struct {
	ReferenceName *string                 `json:"referenceName,omitempty"`
	Type          ApiObjectDefinitionType `json:"type"`
}

type ApiObjectDefinitionType string

const (
	ApiObjectDefinitionBoolean    ApiObjectDefinitionType = "Boolean"
	ApiObjectDefinitionDictionary ApiObjectDefinitionType = "Dictionary"
	ApiObjectDefinitionInteger    ApiObjectDefinitionType = "Integer"
	ApiObjectDefinitionFloat      ApiObjectDefinitionType = "Float"
	ApiObjectDefinitionList       ApiObjectDefinitionType = "List"
	ApiObjectDefinitionReference  ApiObjectDefinitionType = "Reference"
	ApiObjectDefinitionString     ApiObjectDefinitionType = "String"
)

type MetaData struct {
	// ResourceProvider is the name of the Azure Resource Provider which must be
	// registered to use this API Operation
	ResourceProvider *string `json:"resourceProvider"`
}

type OperationFieldType string

const (
	OperationFieldTypeBoolean  OperationFieldType = "Boolean"
	OperationFieldTypeConstant OperationFieldType = "Constant"
	OperationFieldTypeInteger  OperationFieldType = "Integer"
	OperationFieldTypeString   OperationFieldType = "String"
)
