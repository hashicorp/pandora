package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

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

type ObjectDefinition struct {
	Name string `json:"Name,omitempty"`
	Type string `json:"Type,omitempty"`
}

func codeForOperation(operationName string, operation models.OperationDetails, resource models.AzureApiResource) ([]byte, error) {
	contentType := ""
	if !strings.Contains(strings.ToLower(operation.ContentType), "application/json") {
		contentType = operation.ContentType
	}

	statusCodes := make([]int, 0)
	if usesNonDefaultStatusCodes(operation) {
		for _, sc := range operation.ExpectedStatusCodes {
			statusCodes = append(statusCodes, sc)
		}
		sort.Ints(statusCodes)
	}

	fieldContainingPaginationDetails := ""
	if operation.FieldContainingPaginationDetails != nil {
		fieldContainingPaginationDetails = *operation.FieldContainingPaginationDetails
	}

	longRunning := false
	if operation.LongRunning {
		// TODO: we can use the `LongRunning` operation base types too
		longRunning = true
	}

	var requestObject ObjectDefinition
	//requestObject := ObjectDefinition{}
	if operation.RequestObject != nil {
		requestObject.Name = pointer.From(operation.RequestObject.ReferenceName)
		requestObject.Type = string(operation.ResponseObject.Type)

	} else if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
		// Post and Put operations should have one but it's possible they don't
		// TODO what goes here?
	}

	resourceId := ""
	if operation.ResourceIdName != nil {
		resourceId = *operation.ResourceIdName
	}

	responseObject := ObjectDefinition{}
	if operation.ResponseObject != nil {
		responseObject.Name = pointer.From(operation.ResponseObject.ReferenceName)
		responseObject.Type = string(operation.ResponseObject.Type)

		// TODO
		//if operation.FieldContainingPaginationDetails == nil {
		//	code = append(code, fmt.Sprintf(`		public override Type? ResponseObject() => typeof(%[1]s);`, *responseOperationTypeName))
		//} else {
		//	code = append(code, fmt.Sprintf(`		public override Type NestedItemType() => typeof(%[1]s);`, *responseOperationTypeName))
		//}
	}

	optionsObject := OptionsObject{}
	options := make([]Option, 0)
	if len(operation.Options) > 0 {
		optionsObject.Name = operationName

		sortedOptionsKeys := make([]string, 0)
		for k := range operation.Options {
			sortedOptionsKeys = append(sortedOptionsKeys, k)
		}
		sort.Strings(sortedOptionsKeys)

		for _, optionName := range sortedOptionsKeys {
			optionDetails := operation.Options[optionName]

			if optionDetails.ObjectDefinition == nil {
				return nil, fmt.Errorf("missing object definition")
			}

			fieldType := string(optionDetails.ObjectDefinition.Type)

			option := Option{
				HeaderName:  optionDetails.HeaderName,
				QueryString: optionDetails.QueryStringName,
				Field:       optionName,
				FieldType:   fieldType,
			}

			if !optionDetails.Required {
				option.Optional = true
			} else {
				option.Required = true
			}

			options = append(options, option)
		}

		optionsObject.Options = options
	}

	uriSuffix := ""
	if operation.UriSuffix != nil {
		uriSuffix = *operation.UriSuffix
	}

	HTTPMethod := strings.Title(strings.ToLower(operation.Method))
	if operation.FieldContainingPaginationDetails != nil {
		HTTPMethod = "List"
		// TODO is there a todo here?
		// since this is a List operation we need to additionally output the HttpMethod
		// since it's possible that these are non-standard (e.g. AppConfig 2020-06-01 ListKeys
		// is a POST not a GET for a List operation)
		//if !strings.EqualFold(operation.Method, "GET") {
		//	method := dotNetNameForHttpMethod(operation.Method)
		//	code = append(code, fmt.Sprintf(`		public override System.Net.Http.HttpMethod Method() => System.Net.Http.%s;`, method))
		//}
	}
	op := Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		ExpectedStatusCodes:              statusCodes,
		FieldContainingPaginationDetails: fieldContainingPaginationDetails,
		LongRunning:                      longRunning,
		HTTPMethod:                       HTTPMethod,
		OptionsObject:                    optionsObject,
		Options:                          options,
		ResourceId:                       resourceId,
		RequestObject:                    requestObject,
		ResponseObject:                   responseObject,
		UriSuffix:                        uriSuffix,
	}

	data, err := json.MarshalIndent(op, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func usesNonDefaultStatusCodes(operation models.OperationDetails) bool {
	defaultStatusCodes := map[string][]int{
		"get":    {200},
		"post":   {200, 201},
		"put":    {200, 201},
		"delete": {200, 201},
		"patch":  {200, 201},
	}
	expected, ok := defaultStatusCodes[strings.ToLower(operation.Method)]
	if !ok {
		// potentially an unsupported use-case but fine for now
		return true
	}

	if len(expected) != len(operation.ExpectedStatusCodes) {
		return true
	}

	sort.Ints(expected)
	sort.Ints(operation.ExpectedStatusCodes)
	for i, ev := range expected {
		av := operation.ExpectedStatusCodes[i]
		if ev != av {
			return true
		}
	}

	return false
}

func dotNetNameForHttpMethod(method string) string {
	switch strings.ToUpper(method) {
	case "DELETE":
		return "HttpMethod.Delete"

	case "GET":
		return "HttpMethod.Get"

	case "HEAD":
		return "HttpMethod.Head"

	case "PATCH":
		return "HttpMethod.Patch"

	case "POST":
		return "HttpMethod.Post"

	case "PUT":
		return "HttpMethod.Put"

	default:
		return fmt.Sprintf("TODO (unimplemented %q)", method)
	}
}
