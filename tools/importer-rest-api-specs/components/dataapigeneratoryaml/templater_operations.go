package dataapigeneratoryaml

import (
	"fmt"
	"sort"
	"strings"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type Operation struct {
	Name                             string           `yaml:"Name"`
	ContentType                      string           `yaml:"ContentType,omitempty"`
	ExpectedStatusCodes              []int            `yaml:"ExpectedStatusCodes,omitempty"`
	FieldContainingPaginationDetails string           `yaml:"FieldContainingPaginationDetails,omitempty"`
	LongRunning                      bool             `yaml:"LongRunning,omitempty"`
	HTTPMethod                       string           `yaml:"HTTPMethod,omitempty"`
	OptionsObject                    OptionsObject    `yaml:"OptionsObject,omitempty"`
	Options                          []Option         `yaml:"Options,omitempty"`
	ResourceId                       string           `yaml:"ResourceId,omitempty"`
	RequestObject                    ObjectDefinition `yaml:"RequestObject,omitempty"`
	ResponseObject                   ObjectDefinition `yaml:"ResponseObject,omitempty"`
	UriSuffix                        string           `yaml:"UriSuffix,omitempty"`
}

type OptionsObject struct {
	Name    string   `yaml:"Name"`
	Options []Option `yaml:"Options"`
}

type Option struct {
	HeaderName  *string `yaml:"HeaderName,omitempty"`
	Optional    bool    `yaml:"Optional"`
	QueryString *string `yaml:"QueryString,omitempty"`
	Required    bool    `yaml:"Required"`
	Field       string  `yaml:"Field"`
	FieldType   string  `yaml:"FieldType"`
}

type ObjectDefinition struct {
	Name string `yaml:"Name"`
	Type string `yaml:"Type"`
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

	requestObject := ObjectDefinition{}
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

	data, err := yaml.Marshal(op)
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
