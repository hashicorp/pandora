package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

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

	if operation.RequestObject == nil && (strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT")) {
		// Post and Put operations should have a RequestObject one but it's possible they don't
		// TODO what goes here?
	}

	resourceId := ""
	if operation.ResourceIdName != nil {
		resourceId = *operation.ResourceIdName
	}

	options := make([]dataApiModels.Option, 0)
	if len(operation.Options) > 0 {
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

			option := dataApiModels.Option{
				HeaderName:       optionDetails.HeaderName,
				QueryString:      optionDetails.QueryStringName,
				Field:            optionName,
				ObjectDefinition: dataApiModels.OptionObjectDefinitionFromSchemaFieldFromImporterRestApiSpecs(optionDetails.ObjectDefinition),
			}

			if !optionDetails.Required {
				option.Optional = true
			} else {
				option.Required = true
			}

			options = append(options, option)
		}
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
	op := dataApiModels.Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		ExpectedStatusCodes:              statusCodes,
		FieldContainingPaginationDetails: pointer.To(fieldContainingPaginationDetails),
		LongRunning:                      longRunning,
		HTTPMethod:                       HTTPMethod,
		Options:                          options,
		ResourceIdName:                   pointer.To(resourceId),
		RequestObject:                    dataApiModels.ObjectDefinitionFromSchemaFieldFromImporterRestApiSpecs(operation.RequestObject),
		ResponseObject:                   dataApiModels.ObjectDefinitionFromSchemaFieldFromImporterRestApiSpecs(operation.ResponseObject),
		UriSuffix:                        pointer.To(uriSuffix),
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
