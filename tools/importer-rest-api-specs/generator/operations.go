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
		code = append(code, fmt.Sprintf(`		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
		{
%s
		};`, strings.Join(statusCodes, "\n")))
	}

	if operation.FieldContainingPaginationDetails != nil {
		code = append(code, fmt.Sprintf(`		public override string? FieldContainingPaginationDetails() => %[1]q;`, *operation.FieldContainingPaginationDetails))
	}

	if operation.LongRunning {
		// TODO: we can use the `LongRunning` operation base types too
		code = append(code, `		public override bool LongRunning() => true;`)
	}

	if operation.RequestObject != nil {
		requestOperationTypeName, err := typeNameForObjectDefinition(*operation.RequestObject, resource)
		if err != nil {
			return nil, fmt.Errorf("determining type name for Request Object: %+v", err)
		}

		code = append(code, fmt.Sprintf(`		public override Type? RequestObject() => typeof(%[1]s);`, *requestOperationTypeName))
	} else if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
		// Post and Put operations should have one but it's possible they don't
		code = append(code, fmt.Sprintf(`		public override Type? RequestObject() => null;`))
	}

	if operation.ResourceIdName != nil {
		code = append(code, fmt.Sprintf(`		public override ResourceID? ResourceId() => new %[1]s();`, *operation.ResourceIdName))
	}

	if operation.ResponseObject != nil {
		responseOperationTypeName, err := typeNameForObjectDefinition(*operation.ResponseObject, resource)
		if err != nil {
			return nil, fmt.Errorf("determining type name for Response Object: %+v", err)
		}

		if operation.FieldContainingPaginationDetails == nil {
			code = append(code, fmt.Sprintf(`		public override Type? ResponseObject() => typeof(%[1]s);`, *responseOperationTypeName))
		} else {
			code = append(code, fmt.Sprintf(`		public override Type NestedItemType() => typeof(%[1]s);`, *responseOperationTypeName))
		}
	}

	optionsCode := make([]string, 0)
	if len(operation.Options) > 0 {
		code = append(code, fmt.Sprintf(`		public override Type? OptionsObject() => typeof(%[1]sOperation.%[1]sOptions);`, operationName))

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
			if optionDetails.ObjectDefinition != nil {
				fieldType, err := dotNetNameForObjectDefinition(optionDetails.ObjectDefinition, resource.Constants, resource.Models)
				if err != nil {
					return nil, err
				}
				typeName = *fieldType
			}
			if typeName == "" {
				return nil, fmt.Errorf("missing an ObjectDefinition for Option %q", optionName)
			}
			optionsCode = append(optionsCode, fmt.Sprintf("\t\t\tpublic %s %s { get; set; }", typeName, optionName))
		}
		optionsCode = append(optionsCode, "\t\t}")
	}

	if operation.UriSuffix != nil {
		code = append(code, fmt.Sprintf(`		public override string? UriSuffix() => %[1]q;`, *operation.UriSuffix))
	}

	operationType := strings.Title(strings.ToLower(operation.Method))
	if operation.FieldContainingPaginationDetails != nil {
		operationType = "List"
		// since this is a List operation we need to additionally output the HttpMethod
		// since it's possible that these are non-standard (e.g. AppConfig 2020-06-01 ListKeys
		// is a POST not a GET for a List operation)
		if !strings.EqualFold(operation.Method, "GET") {
			method := dotNetNameForHttpMethod(operation.Method)
			code = append(code, fmt.Sprintf(`		public override System.Net.Http.HttpMethod Method() => System.Net.Http.%s;`, method))
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

func typeNameForObjectDefinition(input models.ObjectDefinition, resource models.AzureApiResource) (*string, error) {
	if input.Type == models.ObjectDefinitionDictionary {
		typeName := ""
		// either it's a nested Dictionary (e.g. Dictionary<string, string>)
		if input.NestedItem != nil {
			nestedType, err := typeNameForObjectDefinition(*input.NestedItem, resource)
			if err != nil {
				return nil, fmt.Errorf("determining nested type: %+v", err)
			}

			typeName = *nestedType
		}

		// or it's got a reference (e.g. Dictionary<string, Model>)
		if input.ReferenceName != nil {
			typeName = *input.ReferenceName
		}

		if typeName == "" {
			return nil, fmt.Errorf("missing a reference or nested item for nested dictionary item")
		}

		out := fmt.Sprintf("Dictionary<string, %s>", typeName)
		return &out, nil
	}

	if input.Type == models.ObjectDefinitionList {
		typeName := ""
		// either it's a nested List (e.g. List<string>, List<List<string>>)
		if input.NestedItem != nil {
			nestedType, err := typeNameForObjectDefinition(*input.NestedItem, resource)
			if err != nil {
				return nil, fmt.Errorf("determining nested type: %+v", err)
			}

			typeName = *nestedType
		}

		// or it's got a reference (e.g. List<Model>)
		if input.ReferenceName != nil {
			typeName = *input.ReferenceName
		}

		if typeName == "" {
			return nil, fmt.Errorf("missing a reference or nested item for nested list item")
		}

		out := fmt.Sprintf("List<%s>", typeName)
		return &out, nil
	}

	if input.Type == models.ObjectDefinitionReference {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("missing constant/model reference")
		}

		output := *input.ReferenceName
		if _, isConstant := resource.Constants[output]; isConstant {
			output += "Constant"
		}
		if _, isModel := resource.Models[output]; isModel {
			output += "Model"
		}

		return &output, nil
	}

	var out string
	switch input.Type {
	case models.ObjectDefinitionBoolean:
		out = "bool"

	case models.ObjectDefinitionFloat:
		out = "float"

	case models.ObjectDefinitionInteger:
		out = "int"

	case models.ObjectDefinitionString:
		out = "string"
	}

	if out != "" {
		return &out, nil
	}

	return nil, fmt.Errorf("unimplemented object definition type %q", string(input.Type))
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
