package models

type Operation struct {
	// Name specifies the Display Name for this Operation (e.g. `Create`) which is also
	// valid as an identifier.
	Name string `json:"Name"`

	// ContentType specifies the format of the information being sent with the Operation (e.g. `application/json; charset=utf-8`)
	ContentType string `json:"ContentType"`

	// ExpectedStatusCodes specifies is a list of Status Codes which are expected to be returned (e.g. 200, 201)
	ExpectedStatusCodes []int `json:"ExpectedStatusCodes"`

	// FieldContainingPaginationDetails is a reference to the field within the Response
	// which contains the pagination details, (e.g. `nextLink`)
	FieldContainingPaginationDetails *string `json:"FieldContainingPaginationDetails,omitempty"`

	// LongRunning specifies if this is a Long Running Operation, meaning that Clients
	// should follow any `Location` headers to track the result of this operation
	LongRunning bool `json:"LongRunning"`

	// HTTPMethod is the Method used for this operation, (e.g. `GET`, `POST`)
	HTTPMethod string `json:"HTTPMethod"`

	// Options is a list of options which can be specified for this operation
	// these are querystring parameters such as 'limit' or 'forceDelete' or similar
	Options []Option `json:"Options,omitempty"`

	// ResourceId specifies the optional Resource ID used for this operation
	ResourceId *string `json:"ResourceId,omitempty"`

	// RequestObject specifies the optional ObjectDefinition to be specified in the Request
	RequestObject *ObjectDefinition `json:"RequestObject,omitempty"`

	// RequestObject specifies the optional ObjectDefinition to be returned by the Request
	ResponseObject *ObjectDefinition `json:"ResponseObject,omitempty"`

	// UriSuffix specifies the suffix which should be appended to the ResourceID for this operation
	// (e.g. `/shutdown`)
	UriSuffix *string `json:"UriSuffix,omitempty"`
}

type Option struct {
	// HeaderName is the name of the Http Header which this Option should be set into
	// (e.g. `If-Match`, `x-ms-client-request-id`)
	HeaderName *string `json:"HeaderName,omitempty"`

	// Optional specifies whether this Option could be specified in the Request
	Optional bool `json:"Optional"`

	// QueryStringName is the Key which should be used for this Option in the QueryString
	// (e.g. `createTimeMax`, `isActive`)
	QueryString *string `json:"QueryString,omitempty"`

	// Required specifies whether this Option must be specified in the Request
	Required bool `json:"Required"`

	// Field specifies the DisplayName of the Option (e.g. `ConstantOption`, `SecondVal`)
	Field string `json:"Field"`

	// FieldType specifies what kind of Option this is (e.g. `String`, `Bool`)
	FieldType ObjectDefinitionType `json:"FieldType"`
}
