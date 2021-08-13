package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForOperation(namespace string, operationName string, operation models.OperationDetails, resource models.AzureApiResource) (*string, error) {
	code := make([]string, 0)

	if g.usesNonDefaultStatusCodes(operation) {
		statusCodes := make([]string, 0)
		for _, sc := range operation.ExpectedStatusCodes {
			statusCodes = append(statusCodes, fmt.Sprintf("\t\t\t\t%s,", g.dotnetNameForStatusCode(sc)))
		}
		sort.Strings(statusCodes)
		code = append(code, fmt.Sprintf(`		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
%s
			};
		}`, strings.Join(statusCodes, "\n")))
	}

	if operation.FieldContainingPaginationDetails != nil {
		code = append(code, fmt.Sprintf(`		public override string? FieldContainingPaginationDetails()
		{
			return %[1]q;
		}`, *operation.FieldContainingPaginationDetails))
	}

	// TODO: other fields, status codes if they're non-default
	if operation.LongRunning {
		code = append(code, `		public override bool LongRunning()
		{
			return true;
		}`)
	}

	if operation.RequestObjectName != nil {
		requestOperationTypeName := *operation.RequestObjectName
		if _, isConstant := resource.Constants[requestOperationTypeName]; isConstant {
			requestOperationTypeName += "Constant"
		}
		if _, isModel := resource.Models[requestOperationTypeName]; isModel {
			requestOperationTypeName += "Model"
		}

		code = append(code, fmt.Sprintf(`		public override Type? RequestObject()
		{
			return typeof(%[1]s);
		}`, requestOperationTypeName))
	} else if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
		// Post and Put operations should have one but it's possible they don't
		code = append(code, fmt.Sprintf(`		public override Type? RequestObject()
		{
			return null;
		}`))
	}

	if operation.ResourceIdName != nil {
		code = append(code, fmt.Sprintf(`		public override ResourceID? ResourceId()
		{
			return new %[1]s();
		}`, *operation.ResourceIdName))
	}

	if operation.ResponseObjectName != nil {
		responseOperationTypeName := *operation.ResponseObjectName
		if _, isConstant := resource.Constants[responseOperationTypeName]; isConstant {
			responseOperationTypeName += "Constant"
		}
		if _, isModel := resource.Models[responseOperationTypeName]; isModel {
			responseOperationTypeName += "Model"
		}

		if operation.FieldContainingPaginationDetails == nil {
			code = append(code, fmt.Sprintf(`		public override Type? ResponseObject()
		{
			return typeof(%[1]s);
		}`, responseOperationTypeName))
		} else {
			code = append(code, fmt.Sprintf(`		public override Type NestedItemType()
		{
			return typeof(%[1]s);
		}`, responseOperationTypeName))
		}
	}

	optionsCode := make([]string, 0)
	if len(operation.Options) > 0 {
		code = append(code, fmt.Sprintf(`		public override Type? OptionsObject()
		{
			return typeof(%[1]sOperation.%[1]sOptions);
		}`, operationName))

		optionsCode = append(optionsCode, fmt.Sprintf("\t\tinternal class %sOptions", operationName))
		optionsCode = append(optionsCode, "\t\t{")

		sortedOptionsKeys := make([]string, 0)
		for k := range operation.Options {
			sortedOptionsKeys = append(sortedOptionsKeys, k)
		}
		sort.Strings(sortedOptionsKeys)

		for _, optionName := range sortedOptionsKeys {
			optionDetails := operation.Options[optionName]
			if optionDetails.QueryStringName != "" {
				optionsCode = append(optionsCode, fmt.Sprintf("\t\t\t[QueryStringName(%q)]", optionDetails.QueryStringName))
			}
			if !optionDetails.Required {
				optionsCode = append(optionsCode, "\t\t\t[Optional]")
			}

			typeName := ""
			if optionDetails.FieldType != nil {
				fieldType, err := dotNetTypeNameForSimpleType(*optionDetails.FieldType)
				if err != nil {
					return nil, err
				}
				typeName = *fieldType
			}
			if optionDetails.ConstantObjectName != nil {
				typeName = *optionDetails.ConstantObjectName
			}
			if typeName == "" {
				return nil, fmt.Errorf("missing a FieldType or ConstantObjectName for Option %q", optionName)
			}
			optionsCode = append(optionsCode, fmt.Sprintf("\t\t\tpublic %s %s { get; set; }", typeName, optionName))
		}
		optionsCode = append(optionsCode, "\t\t}")
	}

	if operation.UriSuffix != nil {
		code = append(code, fmt.Sprintf(`		public override string? UriSuffix()
		{
			return %[1]q;
		}`, *operation.UriSuffix))
	}

	operationType := strings.Title(strings.ToLower(operation.Method))
	if operation.FieldContainingPaginationDetails != nil {
		operationType = "List"
		// since this is a List operation we need to additionally output the HttpMethod
		// since it's possible that these are non-standard (e.g. AppConfig 2020-06-01 ListKeys
		// is a POST not a GET for a List operation)
		if !strings.EqualFold(operation.Method, "GET") {
			method := dotNetNameForHttpMethod(operation.Method)
			code = append(code, fmt.Sprintf(`		public override System.Net.Http.HttpMethod Method() 
        {
            return System.Net.Http.%s;
        }`, method))
		}
	}
	output := fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace %[1]s
{
	internal class %[2]sOperation : Operations.%[3]sOperation
	{
%[4]s

%[5]s
	}
}
`, namespace, operationName, operationType, strings.Join(code, "\n\n"), strings.Join(optionsCode, "\n"))
	return &output, nil
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

func (g PandoraDefinitionGenerator) usesNonDefaultStatusCodes(operation models.OperationDetails) bool {
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

func (g PandoraDefinitionGenerator) dotnetNameForStatusCode(input int) string {
	switch input {
	case 200:
		return "HttpStatusCode.OK"
	case 201:
		return "HttpStatusCode.Created"
	case 202:
		return "HttpStatusCode.Accepted"
	case 204:
		return "HttpStatusCode.NoContent"
	case 301:
		return "HttpStatusCode.Moved"
	case 302:
		return "HttpStatusCode.Found"

	default:
		return fmt.Sprintf("TODO: support %d", input)
	}
}
